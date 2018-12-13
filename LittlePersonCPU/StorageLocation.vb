Public Class StorageLocation
    Public Value As Integer
    Public Name As String

    Public Sub New(name As String, value As String)
        Me.Name = name
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Name & ": " & Value
    End Function
End Class
