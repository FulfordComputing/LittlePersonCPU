Public Class Assembler
    Protected cpu As CPU

    Private Sub btnAssemble_Click(sender As Object, e As EventArgs) Handles btnAssemble.Click
        Dim strMachineCode As String = ""
        For i As Integer = 0 To 255
            strMachineCode += "00 "
        Next
        txtMachineCode.Text = strMachineCode
    End Sub

    Private Sub ErrMsg(message As String)
        MsgBox("Error: " & message, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Function CheckInt(valToCheck As Integer, expectedValue As Integer, errorMessage As String, Optional throwException As Boolean = True) As Boolean
        If valToCheck = expectedValue Then
            Return True
        Else
            If throwException Then
                Throw New Exception(errorMessage & " (expected " & expectedValue & ", actual value: " & valToCheck & ")")
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
            CheckInt(bytes.Length, 256, "Invalid number of bytes in machine code")

            Dim assembler As String = ""

            ' loop through each byte in ram
            Dim address As Integer = 0
            While address < 256
                Dim hex As String = cpu.RAM(address).ToHex()
                Dim value As Integer = 0
                If address < 255 Then
                    value = cpu.RAM(address + 1).Value
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
    Private Sub AssemblerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MachineCodeToolStripMenuItem1.Click
        Dim dlg As New SaveFileDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(dlg.FileName, txtAssembly.Text, False)
        End If
    End Sub

    Public Sub ShowAssembler(cpu As CPU)
        Me.cpu = cpu
        Show()
    End Sub

    Private Sub btnLoadFromCPU_Click(sender As Object, e As EventArgs) Handles btnLoadFromCPU.Click
        Dim strMachineCode As String = ""
        For i As Integer = 0 To 255
            strMachineCode += cpu.RAM(i).ToHex() & " "
        Next
        txtMachineCode.Text = strMachineCode

    End Sub
End Class