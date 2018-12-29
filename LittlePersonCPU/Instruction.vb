Public Class Instruction
    Public Enum InstructionSet
        Halt = 0
        Add = 1
        Subtract = 2
        Store = 3
        SetStackPointer = 4
        Load = 5
        BranchAlways = 6
        BranchIfZero = 7
        BranchIfPositive = 8
        InputOutput = 9
        Data
    End Enum

    Public Enum AddressMode
        Immediate = 0
        Direct = 1
        Indirect = 2
        Indexed = 3
    End Enum

    Public opcode As InstructionSet
    Public a_m As AddressMode
    Public numberOfBytes As Integer
    Public machineCode As String
    Public assembler As String

    Protected hexOpcode As String
    Protected intOperand As Integer

    Private Function getValue() As String
        Select Case a_m
            Case AddressMode.Immediate
                Return "#" & intOperand
            Case AddressMode.Direct
                Return "&" & intOperand
            Case AddressMode.Indirect
                Return "~" & intOperand
            Case AddressMode.Indexed
                Return "[" & intOperand & "]"
        End Select
    End Function

    Public Sub New(machineCodeHex1 As String, Optional value As Integer = 0)
        hexOpcode = machineCodeHex1
        intOperand = value

        numberOfBytes = 2
        Select Case machineCodeHex1(1)
            Case "0"
                a_m = AddressMode.Immediate
            Case "1"
                a_m = AddressMode.Direct
            Case "2"
                a_m = AddressMode.Indirect
            Case "3"
                a_m = AddressMode.Indexed
        End Select

        Select Case machineCodeHex1(0)
            Case "1"
                opcode = InstructionSet.Add
                assembler = "ADD " & getValue()
            Case "2"
                opcode = InstructionSet.Subtract
                assembler = "SUB " & getValue()
            Case "3"
                opcode = InstructionSet.Store
                assembler = "STA " & getValue()
            Case "4"
                opcode = InstructionSet.SetStackPointer
                assembler = "SP " & getValue()
            Case "5"
                opcode = InstructionSet.Load
                assembler = "LDA " & getValue()
            Case "6"
                opcode = InstructionSet.BranchAlways
                assembler = "BRA " & getValue()
            Case "7"
                opcode = InstructionSet.BranchIfZero
                assembler = "BRZ " & getValue()
            Case "8"
                opcode = InstructionSet.BranchIfPositive
                assembler = "BRP " & getValue()
            Case "9"
                opcode = InstructionSet.InputOutput
                Select Case machineCodeHex1(1)
                    Case "1"
                        assembler = "INP"
                    Case "2"
                        assembler = "OUT"
                End Select
                numberOfBytes = 1
            Case "0"
                numberOfBytes = 1
                opcode = InstructionSet.Halt
                assembler = "HLT"
            Case Else
                numberOfBytes = 1
                opcode = InstructionSet.Data
                assembler = "DAT 0x" & machineCodeHex1
        End Select
    End Sub

    Public Overrides Function ToString() As String
        Return assembler
    End Function

End Class
