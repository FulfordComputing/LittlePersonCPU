Public Class CPU
    Private form As CPUInterface

    Public ACC As Register
    Public CIR As Register
    Public MAR As Register
    Public MDR As Register
    Public PC As Register

    Public RAM As New List(Of DataStorage)

    Public Sub New(form As CPUInterface)
        Me.form = form
        ACC = New Register("Accumulator", 0, form.lblACC)
        CIR = New Register("Current Instruction Register", 0, form.lblCIR)
        MAR = New Register("Memory Address Register", 0, form.lblMAR)
        MDR = New Register("Memory Data Register", 0, form.lblMDR)
        PC = New Register("Program Counter", 0, form.lblPC)

        For i As Integer = 0 To 255
            RAM.Add(New DataStorage(i, 0))
        Next
    End Sub


End Class
