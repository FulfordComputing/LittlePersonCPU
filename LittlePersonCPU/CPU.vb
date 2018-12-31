Public Class CPU
    Private form As CPUInterface

    Public ACC As Register
    Public CIR As Register
    Public MAR As Register
    Public MDR As Register
    Public PC As Register
    Public SP As Register

    Public RAM As New List(Of DataStorage)

    Public Sub New(form As CPUInterface)
        Me.form = form
        ACC = New Register("Accumulator", 0, form.lblACC)
        CIR = New Register("Current Instruction Register", 0, form.lblCIR)
        MAR = New Register("Memory Address Register", 0, form.lblMAR)
        MDR = New Register("Memory Data Register", 0, form.lblMDR)
        PC = New Register("Program Counter", 0, form.lblPC)
        SP = New Register("Stack Pointer", 0, form.lblSP)

        For i As Integer = 0 To 255
            RAM.Add(New DataStorage(i, 0))
        Next
    End Sub

    Public Enum ControlSignal
        WriteToRAM
        ReadFromRAM
    End Enum

    Public Sub SendControlSignal(signal As ControlSignal)
        Select Case signal
            ' Write value in MDR to the address specified by the MAR
            Case ControlSignal.WriteToRAM
                RAM(MAR.Value).Value = MDR.Value

            ' Read value in the address specified by the MAR into the MDR
            Case ControlSignal.ReadFromRAM
                MDR.Value = RAM(MAR.Value).Value
        End Select
    End Sub


End Class
