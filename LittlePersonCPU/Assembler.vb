Imports System.Text.RegularExpressions

Public Class Assembler
    Protected cpu As CPU
    Public Shared code As String = ""
    Shared labels As New Dictionary(Of String, Integer)
    Public Shared Function getLabels() As Dictionary(Of Integer, String)
        Dim labelsByAddress As New Dictionary(Of Integer, String)
        For Each label As String In labels.Keys
            labelsByAddress.Add(labels(label), label)
        Next
        Return labelsByAddress
    End Function


    Public Class AssemblyError
        Inherits Exception
        Enum ErrorType
            LexicalError
            SyntaxError
            SemanticsError
        End Enum

        Public type As ErrorType
        Public lineNumber As Integer
        Public line As String
        Public detail As String

        Public Sub New(type As ErrorType, message As String, line As String, lineNumber As Integer)
            MyBase.New(message)
            Me.type = type
            Me.line = line
            Me.lineNumber = lineNumber
        End Sub
    End Class

    Sub Assemble()
        ' lexical analysis

        ' split code into lines
        Dim lines As String() = txtAssembly.Text.Split(vbNewLine)
        Dim instructions As New List(Of Instruction)

        ' loop through each line
        For lineNumber As Integer = 1 To lines.Length
            Dim instruction As New Instruction()

            ' remove comments
            instruction.assembler = Regex.Replace(lines(lineNumber - 1), "\/\/.*$", "").Trim

            ' detect label
            If instruction.assembler.Contains(":") Then
                Dim parts As String() = instruction.assembler.Split(":")
                instruction.label = parts(0).Trim
                instruction.assembler = parts(1).Trim
            End If

            ' split instruction into tokens separated by whitespace
            instruction.tokens = Regex.Split(instruction.assembler, "\s+")

            ' remember this instruction
            If instruction.assembler.Length > 0 Then
                instruction.lineNumber = lineNumber
                instructions.Add(instruction)
            End If
        Next

        ' Syntax analysis

        ' work out opcode and number of bytes
        For i As Integer = 0 To instructions.Count - 1
            Dim ins As Instruction = instructions(i)

            ' Check number of tokens is 1 or 2
            CheckIntRange(ins.tokens.Length, 1, 2, New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Invalid token count", ins.assembler, ins.lineNumber))

            ins.numberOfBytes = 2
            Select Case ins.tokens(0).ToUpper
                Case "HLT"
                    ins.opcode = Instruction.InstructionSet.Halt
                    ins.numberOfBytes = 1
                Case "DAT"
                    ins.opcode = Instruction.InstructionSet.Data
                    ins.numberOfBytes = 1
                Case "LDA"
                    ins.opcode = Instruction.InstructionSet.Load
                Case "STA"
                    ins.opcode = Instruction.InstructionSet.Store
                Case "SP"
                    ins.opcode = Instruction.InstructionSet.SetStackPointer
                Case "ADD"
                    ins.opcode = Instruction.InstructionSet.Add
                Case "SUB"
                    ins.opcode = Instruction.InstructionSet.Subtract
                Case "BRA"
                    ins.opcode = Instruction.InstructionSet.BranchAlways
                Case "BRZ"
                    ins.opcode = Instruction.InstructionSet.BranchIfZero
                Case "BRP"
                    ins.opcode = Instruction.InstructionSet.BranchIfPositive
                Case "INP"
                    ins.opcode = Instruction.InstructionSet.Input
                    ins.numberOfBytes = 1
                Case "OUT"
                    ins.opcode = Instruction.InstructionSet.Output
                    ins.numberOfBytes = 1
                Case Else
                    Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Unknown instruction " & ins.tokens(0), ins.assembler, ins.lineNumber)
            End Select
        Next

        ' check there's no duplicated labels
        labels.Clear()
        Dim address As Integer = 0
        For Each ins As Instruction In instructions
            If Not IsNothing(ins.label) Then
                If labels.ContainsKey(ins.label) Then
                    Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Duplicate label: " & ins.label, ins.assembler, ins.lineNumber)
                Else

                    ' Check label is valid
                    If Regex.Match(ins.label, "[A-Za-z_][A-Za-z0-9_]*").Success Then
                        labels.Add(ins.label, address)
                    Else
                        Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Invalid label: " & ins.label, ins.assembler, ins.lineNumber)
                    End If

                End If
            End If
            address += ins.numberOfBytes
        Next

        ' parse addressing mode
        For i As Integer = 0 To instructions.Count - 1
            Dim ins As Instruction = instructions(i)

            ' determine addressing mode for 2 byte instructions
            If ins.numberOfBytes > 1 Then

                ' Check that there is a second token
                CheckInt(ins.tokens.Length, 2, New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Missing value", ins.assembler, ins.lineNumber))

                ' check for a valid addressing mode
                Dim m As Match = Regex.Match(ins.tokens(1), "^([#&~\[])?\s*([A-Za-z0-9_]+)\s*]?$")
                Dim value As Integer = 0
                If m.Success Then

                    Dim a_m As String = m.Groups(1).Value
                    Select Case a_m
                        Case "#"
                            ins.a_m = Instruction.AddressMode.Immediate
                        Case "&"
                            ins.a_m = Instruction.AddressMode.Direct
                        Case "~"
                            ins.a_m = Instruction.AddressMode.Indirect
                        Case "["
                            ins.a_m = Instruction.AddressMode.Indexed
                        Case ""
                            ins.a_m = Instruction.AddressMode.Direct
                            If ins.opcode = Instruction.InstructionSet.Data Or
                                    ins.opcode = Instruction.InstructionSet.BranchAlways Or
                                    ins.opcode = Instruction.InstructionSet.BranchIfPositive Or
                                    ins.opcode = Instruction.InstructionSet.BranchIfZero Then
                                ins.a_m = Instruction.AddressMode.Immediate
                            End If
                        Case Else
                            Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Invalid addressing mode", ins.assembler, ins.lineNumber)
                    End Select

                    ' is value a label rather than a literal value?
                    If Not Integer.TryParse(m.Groups(2).Value, value) Then
                        Try
                            value = labels(m.Groups(2).Value)
                        Catch
                            Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Label not defined", ins.assembler, ins.lineNumber)
                        End Try
                    End If

                    ' generate machine code
                    ins.hexOpcode = Hex(ins.opcode + ins.a_m).PadLeft(2, "0")
                    ins.intOperand = value
                    ins.machineCode = ins.hexOpcode & " " & ins.intOperand.ToString("X2").PadLeft(2, "0")
                Else
                    Throw New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Invalid operand", ins.assembler, ins.lineNumber)
                End If

                ' assemble single byte instructions
            Else
                If ins.opcode = Instruction.InstructionSet.Data Then
                    Dim value As Integer = 0
                    If ins.tokens.Length > 1 Then
                        value = ins.tokens(1)
                    End If
                    CheckIntRange(value, -128, 255, New AssemblyError(AssemblyError.ErrorType.SyntaxError, "Invalid data value", ins.assembler, ins.lineNumber))
                    ins.machineCode = Hex(value).PadLeft(2, "0")
                Else
                    ins.machineCode = Hex(ins.opcode).PadLeft(2, "0")
                End If
            End If
        Next

        ' output all machine code
        Dim machineCode As String = ""
        Dim a As Integer = 0
        For Each ins As Instruction In instructions
            machineCode &= ins.machineCode & " "
            a += ins.numberOfBytes
        Next

        ' pad machine code with zeros
        While a < 256
            a += 1
            machineCode &= "00 "
        End While
        txtMachineCode.Text = machineCode

    End Sub

    Private Sub btnAssemble_Click(sender As Object, e As EventArgs) Handles btnAssemble.Click
        Try
            Assemble()
            SendToCPU()
        Catch ex As AssemblyError
            MsgBox(ex.Message & " on line " & ex.lineNumber & vbNewLine & ex.line & vbNewLine & ex.detail, MsgBoxStyle.Critical, ex.type.ToString())
        End Try
    End Sub

    Private Sub ErrMsg(message As String)
        MsgBox("Error: " & message, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Function CheckIntRange(valToCheck As Integer, minExpectedValue As Integer, maxExpectedValue As Integer, Optional exception As AssemblyError = Nothing) As Boolean
        If valToCheck >= minExpectedValue And valToCheck <= maxExpectedValue Then
            Return True
        Else
            If Not IsNothing(exception) Then
                exception.detail = " expected " & minExpectedValue & " - " & maxExpectedValue & ", actual value: " & valToCheck & ")"
                Throw exception
            End If
        End If
        Return False
    End Function

    Private Function CheckInt(valToCheck As Integer, expectedValue As Integer, Optional exception As AssemblyError = Nothing) As Boolean
        If valToCheck = expectedValue Then
            Return True
        Else
            If Not IsNothing(exception) Then
                exception.detail = " (expected " & expectedValue & ", actual value: " & valToCheck & ")"
                Throw exception
            End If
        End If
        Return False
    End Function

    Private Sub btnDisassemble_Click(sender As Object, e As EventArgs) Handles btnDisassemble.Click
        Try
            ' Get all code as a string
            Dim strMachineCode = txtMachineCode.Text.Trim

            ' split machine code into bytes
            Dim bytes As String() = strMachineCode.Split(" ")

            ' check correct number of bytes
            If bytes.Length <> 256 Then
                Throw New Exception("Expected 256 bytes (found " & bytes.Length & ")")
            End If

            Dim assembler As String = ""

            ' find address to stop
            Dim stopAddress As Integer = bytes.Length - 1
            While bytes(stopAddress - 1) = "00" And stopAddress > 1
                stopAddress -= 1
            End While

            ' loop through each byte in ram
            Dim address As Integer = 0
            While address <= stopAddress
                Dim hex As String = bytes(address)
                Dim value As Integer = 0
                If address < 255 Then
                    value = Convert.ToInt16(bytes(address + 1), 16)
                End If

                Dim instruction As New Instruction(hex, value)
                assembler &= instruction.ToString() & vbNewLine
                address += instruction.numberOfBytes
            End While

            txtAssembly.Text = assembler
        Catch ex As Exception
            ErrMsg(ex.Message)
        End Try

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' File > Open > Machine Code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            txtMachineCode.Text = My.Computer.FileSystem.ReadAllText(dlg.FileName)
        End If

    End Sub

    ''' <summary>
    ''' File > Open > Assembler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AssemblerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssemblerToolStripMenuItem.Click
        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            txtAssembly.Text = My.Computer.FileSystem.ReadAllText(dlg.FileName)
        End If
    End Sub

    ''' <summary>
    ''' File > Save > Machine code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MachineCodeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MachineCodeToolStripMenuItem1.Click
        Dim dlg As New SaveFileDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(dlg.FileName, txtMachineCode.Text, False)
        End If
    End Sub

    ''' <summary>
    ''' File > Save > Assembly
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AssemblerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssemblerToolStripMenuItem1.Click
        Dim dlg As New SaveFileDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(dlg.FileName, txtAssembly.Text, False)
        End If
    End Sub

    Public Sub ShowAssembler(cpu As CPU)
        Me.cpu = cpu
        txtAssembly.Text = code
        Show()
    End Sub


    Private Sub LoadFromCPUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadFromCPUToolStripMenuItem.Click
        Dim strMachineCode As String = ""
        For i As Integer = 0 To 255
            strMachineCode += cpu.RAM(i).ToHex() & " "
        Next
        txtMachineCode.Text = strMachineCode
    End Sub

    Private Sub SendToCPUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToCPUToolStripMenuItem.Click
        SendToCPU()
    End Sub

    Public Sub SendToCPU()
        Dim bytes As String() = txtMachineCode.Text.Trim.Split(" ")
        For i As Integer = 0 To 255
            Dim value As Integer = 0
            If i < bytes.Length Then
                value = Convert.ToInt16(bytes(i), 16)
            End If
            cpu.RAM(i).Value = value
        Next
        CPUInterface.ResetCPU()
    End Sub

    Private Sub txtAssembly_TextChanged(sender As Object, e As EventArgs) Handles txtAssembly.TextChanged
        code = txtAssembly.Text
    End Sub
End Class