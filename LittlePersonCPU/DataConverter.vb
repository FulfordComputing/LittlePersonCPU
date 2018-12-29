''' <summary>
''' Converts data between denary, hex and binary
''' </summary>
Public Class DataConverter
    Public Value As Integer

    Public Function ToHex() As String
        Return Value.ToString("X2").PadLeft(2, "0")
    End Function

    Public Function ToBinary() As String
        Return Convert.ToString(Value, 2).PadLeft(8, "0")
    End Function
End Class
