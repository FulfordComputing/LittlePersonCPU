Public Class Register
    Inherits DataStorage

    Private lbl As Label

    ''' <summary>
    ''' Make a new register
    ''' </summary>
    ''' <param name="name">Name of register</param>
    ''' <param name="initialValue">Value the register stores when CPU switches on</param>
    Public Sub New(name As String, initialValue As Integer, lbl As Label)
        MyBase.New(name, initialValue)
        Me.Value = initialValue
        Me.Name = name
        Me.lbl = lbl
    End Sub

    ''' <summary>
    ''' Displays the register's name and value
    ''' </summary>
    Public Sub Update()
        lbl.Text = Me.Name & ": " & Me.Value
    End Sub

End Class
