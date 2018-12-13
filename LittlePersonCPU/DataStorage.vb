Public Class DataStorage
    Public Value As Integer
    Public Name As String

    ''' <summary>
    ''' Create a new data storage object
    ''' </summary>
    ''' <param name="name">Name or address</param>
    ''' <param name="value">value stored</param>
    Public Sub New(name As String, value As Integer)
        Me.Value = value
        Me.Name = name

    End Sub

    Public Overrides Function ToString() As String
        Return Name & ": " & Value
    End Function


End Class
