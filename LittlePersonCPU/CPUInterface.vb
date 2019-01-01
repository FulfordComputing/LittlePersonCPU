Public Class CPUInterface
    ' Stores registers and executes commands
    Dim cpu As CPU
    Dim instructionCount As Integer = 0
    Dim nextState As CPUState = CPUState.Fetch
    Dim ins As Instruction

    Enum CPUState
        Fetch
        Decode
        Execute
        Halt
    End Enum

    Sub ClockTick()
        Dim description As String = nextState.ToString & ": "
        Select Case nextState
            ' Fetch next instruction
            Case CPUState.Fetch
                description &= "Read next instruction from address " & cpu.PC.Value
                ' set memory address register to the program counter
                cpu.MAR.Value = cpu.PC.Value

                ' load instruction into MDR from address specified by MAR
                cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)

                ' copy instruction into cpu
                cpu.CIR.Value = cpu.MDR.Value

                ' select current instruction
                gridRAM.ClearSelection()
                gridRAM.Rows(cpu.PC.Value).Selected = True

                cpu.PC.Value += 1
                instructionCount += 1
                nextState = CPUState.Fetch

                nextState = CPUState.Decode

            ' decode current instruction
            Case CPUState.Decode

                ' fetch value at next address in case it's needed to decode this instruction
                cpu.MAR.Value = cpu.PC.Value
                cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)

                ins = New Instruction(cpu.CIR.ToHex, cpu.MDR.Value)
                If ins.numberOfBytes = 2 Then
                    cpu.PC.Value += 1
                End If

                description &= ins.assembler
                nextState = CPUState.Execute

            ' execute current instruction
            Case CPUState.Execute
                ' work out addresses and values for multi-byte instructions
                If ins.numberOfBytes > 1 Then
                    Select Case ins.a_m
                        ' immediate mode: value is specified by instruction
                        Case Instruction.AddressMode.Immediate
                            cpu.MDR.Value = ins.intOperand

                        ' direct mode: address is specified by instruction
                        Case Instruction.AddressMode.Direct
                            cpu.MAR.Value = ins.intOperand
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)

                        ' indirect mode: pointer to address is specified by instruction
                        Case Instruction.AddressMode.Indirect
                            cpu.MAR.Value = ins.intOperand
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                            cpu.MAR.Value = cpu.MDR.Value

                        ' indexed mode: load value from address stored at SP + address specified by instruction
                        Case Instruction.AddressMode.Indexed
                            cpu.MAR.Value = cpu.SP.Value + ins.intOperand
                    End Select
                End If

                Select Case ins.opcode

                    ' ACC += MDR
                    Case Instruction.InstructionSet.Add
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        description &= "Added " & cpu.ACC.Value & " to " & cpu.MDR.Value
                        cpu.ACC.Value += cpu.MDR.Value

                    ' Unconditional branch
                    Case Instruction.InstructionSet.BranchAlways
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        description &= "Branching to " & cpu.MDR.Value
                        cpu.PC.Value = cpu.MDR.Value

                    ' Only branch if the ACC value is positive
                    Case Instruction.InstructionSet.BranchIfPositive
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        If cpu.ACC.ToTwosComplement >= 0 Then
                            description &= "Braching to " & cpu.MDR.Value & " because ACC >= 0"
                            cpu.PC.Value = cpu.MDR.Value
                        Else
                            description &= "Not branching because ACC < 0"
                        End If

                    ' Only branch if the ACC
                    Case Instruction.InstructionSet.BranchIfZero
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        If cpu.ACC.Value = 0 Then
                            description &= "Braching to " & cpu.MDR.Value & " because ACC = 0"
                            cpu.PC.Value = cpu.MDR.Value
                        Else
                            description &= "Not branching because ACC is not 0"
                        End If

                    ' Panic! This should never happen. Don't actually do anything.
                    Case Instruction.InstructionSet.Data
                        description &= "Panic! Trying to execute data. Did you forget a HLT?"

                    ' Stop the CPU
                    Case Instruction.InstructionSet.Halt
                        description &= "Halted"
                        nextState = CPUState.Halt
                        tmrAutoClock.Enabled = False

                    ' Read value from the user
                    Case Instruction.InstructionSet.Input
                        cpu.ACC.Value = ReadValue()
                        description &= "Read " & cpu.ACC.ToString & " from user"

                    ' Load value from memory
                    Case Instruction.InstructionSet.Load
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        cpu.ACC.Value = cpu.MDR.Value
                        description &= "Loaded " & cpu.MDR.Value & " into ACC"

                    ' Output accumulator value
                    Case Instruction.InstructionSet.Output
                        output(cpu.ACC.ToString)
                        description &= "Output " & cpu.ACC.ToString

                    ' Set stack pointer (for use with indexed addressing mode)
                    Case Instruction.InstructionSet.SetStackPointer
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        cpu.SP.Value = cpu.MDR.Value
                        description &= "Set SP to " & cpu.SP.Value

                    ' Store value in ACC into RAM
                    Case Instruction.InstructionSet.Store
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.MDR.Value = cpu.ACC.Value
                            cpu.SendControlSignal(CPU.ControlSignal.WriteToRAM)
                            description &= "Stored " & cpu.ACC.Value & " into address " & cpu.MAR.Value
                        Else
                            description &= "Tried to store with immediate address mode: no action"
                        End If

                    ' Subtract value in RAM from ACC
                    Case Instruction.InstructionSet.Subtract
                        If ins.a_m <> Instruction.AddressMode.Immediate Then
                            cpu.SendControlSignal(CPU.ControlSignal.ReadFromRAM)
                        End If
                        description &= "Subtracted " & cpu.MDR.Value & " from " & cpu.ACC.Value
                        cpu.ACC.Value -= cpu.MDR.Value
                End Select

                If nextState <> CPUState.Halt Then
                    nextState = CPUState.Fetch
                End If
        End Select
        lblStatus.Text = description


        UpdateRegisters()
        UpdateRAM()
    End Sub

    Public Sub ResetCPU()
        cpu.PC.Value = 0
        cpu.SP.Value = 0
        cpu.MAR.Value = 0
        cpu.MDR.Value = 0
        cpu.CIR.Value = 0
        cpu.ACC.Value = 0
        lstOutput.Items.Clear()
        nextState = CPUState.Fetch
        UpdateRegisters()
        gridRAM.ClearSelection()
        UpdateRAM()
    End Sub

    Sub UpdateRAM()
        Dim labels = Assembler.getLabels()
        Dim selected As Integer = 0
        Try
            selected = gridRAM.SelectedRows(0).Index
        Catch
        End Try
        gridRAM.Rows.Clear()
        For i As Integer = 0 To cpu.RAM.Count - 1
            Dim label As String = ""
            If labels.ContainsKey(i) Then
                label = labels(i)
            End If
            gridRAM.Rows.Add({label, i, cpu.RAM(i).ToTwosComplement, cpu.RAM(i).ToHex(), cpu.RAM(i).ToBinary})
        Next
        gridRAM.Rows(selected).Selected = True
    End Sub

    Sub UpdateRegisters()
        cpu.PC.Update()
        cpu.CIR.Update()
        cpu.ACC.Update()
        cpu.MAR.Update()
        cpu.MDR.Update()
        cpu.SP.Update()
    End Sub

    Private Sub btnClock_Click(sender As Object, e As EventArgs) Handles btnClock.Click
        ClockTick()
    End Sub

    Private Sub tmrClockSpeed_Tick(sender As Object, e As EventArgs) Handles tmrClockSpeed.Tick
        lblClockSpeed.Text = "Clock Speed: " & instructionCount & "Hz"
        instructionCount = 0
    End Sub

    Private Sub btnStopClock_Click(sender As Object, e As EventArgs) Handles btnStopClock.Click
        tmrAutoClock.Enabled = False
    End Sub

    Private Sub btnClock1Hz_Click(sender As Object, e As EventArgs) Handles btnClock1Hz.Click
        tmrAutoClock.Interval = 1000
        tmrAutoClock.Enabled = True
    End Sub

    Private Sub btnClock10Hz_Click(sender As Object, e As EventArgs) Handles btnClock10Hz.Click
        tmrAutoClock.Interval = 100
        tmrAutoClock.Enabled = True
    End Sub

    Private Sub tmrAutoClock_Tick(sender As Object, e As EventArgs) Handles tmrAutoClock.Tick
        ClockTick()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cpu = New CPU(Me)
        UpdateRAM()
        UpdateRegisters()
    End Sub

    Private Sub btnAssemble_Click(sender As Object, e As EventArgs) Handles btnAssemble.Click
        Assembler.ShowAssembler(Me.cpu)
    End Sub

    Public Sub Output(value As String)
        lstOutput.Items.Add(cpu.ACC)
    End Sub

    Public Function ReadValue() As Integer
        Try
            Dim auto As Boolean = tmrAutoClock.Enabled
            tmrAutoClock.Enabled = False
            Dim newValue As Integer = InputBox("What's the new value?")
            tmrAutoClock.Enabled = auto
            Return newValue
        Catch
            Return ReadValue()
        End Try
    End Function

    'Private Sub lstRAM_DoubleClick(sender As Object, e As EventArgs)
    '    Dim newValue As Integer = ReadValue()

    '    Dim index As Integer = gridRAM.SelectedRows(0).Index
    '    cpu.RAM(index).Value = newValue
    '    UpdateRAM()
    '    gridRAM.clear
    '    lstRAM.SelectedIndex = index

    'End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetCPU()
    End Sub
End Class
