Public Class Instruction
    Public Enum InstructionSet
        Halt = &H0
        Add = &H10
        Subtract = &H20
        Store = &H30
        SetStackPointer = &H40
        Load = &H50
        BranchAlways = &H60
        BranchIfZero = &H70
        BranchIfPositive = &H80
        Input = &H91
        Output = &H92
        Data
    End Enum

    Public Enum AddressMode
        Immediate = 0
        Direct = 1
        Indirect = 2
        Indexed = 3
    End Enum

    Public opcode As InstructionSet
    Public a_m As AddressMode
    Public numberOfBytes As Integer
    Public machineCode As String
    Public assembler As String
    Public label As String
    Public lineNumber As Integer
    Public tokens As String()

    Public hexOpcode As String
    Public intOperand As Integer



    Private Function getValue() As String
        Select Case a_m
            Case AddressMode.Immediate
                Return "#" & intOperand
            Case AddressMode.Direct
                Return "&" & intOperand
            Case AddressMode.Indirect
                Return "~" & intOperand
            Case AddressMode.Indexed
                Return "[" & intOperand & "]"
        End Select
        Return ""
    End Function

    Public Sub New()

    End Sub

    Public Sub New(machineCodeHex1 As String, Optional value As Integer = 0)
        hexOpcode = machineCodeHex1
        intOperand = value

        numberOfBytes = 2
        Dim valid_a_m As Boolean = True
        Select Case machineCodeHex1(1)
            Case "0"
                a_m = AddressMode.Immediate
            Case "1"
                a_m = AddressMode.Direct
            Case "2"
                a_m = AddressMode.Indirect
            Case "3"
                a_m = AddressMode.Indexed
            Case Else
                opcode = InstructionSet.Data
                assembler = "DAT " & Convert.ToInt16(machineCodeHex1, 16)
                numberOfBytes = 1
                valid_a_m = False
        End Select

        Select Case machineCodeHex1(0)
            Case "1"
                If valid_a_m Then
                    opcode = InstructionSet.Add
                    assembler = "ADD " & getValue()
                End If
            Case "2"
                If valid_a_m Then
                    opcode = InstructionSet.Subtract
                    assembler = "SUB " & getValue()
                End If
            Case "3"
                If valid_a_m Then
                    opcode = InstructionSet.Store
                    assembler = "STA " & getValue()
                End If
            Case "4"
                If valid_a_m Then
                    opcode = InstructionSet.SetStackPointer
                    assembler = "SP " & getValue()
                End If
            Case "5"
                If valid_a_m Then
                    opcode = InstructionSet.Load
                    assembler = "LDA " & getValue()
                End If
            Case "6"
                If valid_a_m Then
                    opcode = InstructionSet.BranchAlways
                    assembler = "BRA " & getValue()
                End If
            Case "7"
                If valid_a_m Then
                    opcode = InstructionSet.BranchIfZero
                    assembler = "BRZ " & getValue()
                End If
            Case "8"
                If valid_a_m Then
                    opcode = InstructionSet.BranchIfPositive
                    assembler = "BRP " & getValue()
                End If
            Case "9"
                Select Case machineCodeHex1(1)
                    Case "1"
                        assembler = "INP"
                        opcode = InstructionSet.Input
                    Case "2"
                        assembler = "OUT"
                        opcode = InstructionSet.Output
                    Case Else
                        opcode = InstructionSet.Data
                        assembler = "DAT " & Convert.ToInt16(machineCodeHex1, 16)
                End Select
                numberOfBytes = 1
            Case "0"
                numberOfBytes = 1
                If machineCodeHex1(1) = "0" Then
                    opcode = InstructionSet.Halt
                    assembler = "HLT"
                Else
                    opcode = InstructionSet.Data
                    assembler = "DAT " & Convert.ToInt16(machineCodeHex1, 16)
                End If
            Case Else
                numberOfBytes = 1
                opcode = InstructionSet.Data
                assembler = "DAT " & Convert.ToInt16(machineCodeHex1, 16)
        End Select

    End Sub

    Public Overrides Function ToString() As String
        Return assembler
    End Function

End Class
