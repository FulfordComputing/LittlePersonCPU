''' <summary>
''' Converts data between denary, hex and binary
''' </summary>
Public Class DataConverter
    Protected _value As Integer
    Public Property Value As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            _value = value
            ' check sensible values
            While _value > 255
                _value -= 256
            End While
            While _value < -128
                _value += 256
            End While
        End Set
    End Property


    Public Function ToHex() As String
        Return Right(Value.ToString("X2").PadLeft(2, "0"), 2)
    End Function

    Public Function ToTwosComplement() As Integer
        Dim v As Integer = Value
        If v > 127 Then
            v -= 128
        End If
        Return v
    End Function

    Public Function ToBinary() As String
        Return Right(Convert.ToString(Value, 2).PadLeft(8, "0"), 8)
    End Function
End Class
