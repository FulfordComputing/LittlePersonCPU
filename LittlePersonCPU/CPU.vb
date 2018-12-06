Public Class CPU
    Private form As Form1

    Public ACC As Register
    Public CIR As Register
    Public MAR As Register
    Public MDR As Register
    Public PC As Register

    Public Sub New(form As Form1)
        Me.form = form
        ACC = New Register("Accumulator", 0, form.lblACC)
        CIR = New Register("Current Instruction Register", 0, form.lblCIR)
        MAR = New Register("Memory Address Register", 0, form.lblMAR)
        MDR = New Register("Memory Data Register", 0, form.lblMDR)
        PC = New Register("Program Counter", 0, form.lblPC)
    End Sub
End Class
