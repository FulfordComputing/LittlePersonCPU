Public Class Register
    Public Value As Integer
    Public Name As String
    Private lbl As Label

    ''' <summary>
    ''' Make a new register
    ''' </summary>
    ''' <param name="name">Name of register</param>
    ''' <param name="initialValue">Value the register stores when CPU switches on</param>
    Public Sub New(name As String, initialValue As Integer, lbl As Label)
        Me.Value = initialValue
        Me.Name = name
        Me.lbl = lbl
    End Sub

    Public Sub Update()
        lbl.Text = Me.Name & ": " & Me.Value
    End Sub

End Class
