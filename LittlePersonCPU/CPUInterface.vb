Public Class CPUInterface
    ' Stores registers and executes commands
    Dim cpu As CPU
    Dim instructionCount As Integer = 0

    Sub ClockTick()
        cpu.PC.Value += 1
        instructionCount += 1
        UpdateRegisters()
        UpdateRAM()
    End Sub

    Sub UpdateRAM()
        lstRAM.Items.Clear()
        lstRAM.Items.AddRange(cpu.RAM.ToArray)
    End Sub

    Sub UpdateRegisters()
        cpu.PC.Update()
        cpu.CIR.Update()
        cpu.ACC.Update()
        cpu.MAR.Update()
        cpu.MDR.Update()
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

    Private Sub lstRAM_DoubleClick(sender As Object, e As EventArgs) Handles lstRAM.DoubleClick
        Try
            Dim newValue As Integer = InputBox("What's the new value?")
            Dim index As Integer = lstRAM.SelectedIndex
            cpu.RAM(index).Value = newValue
            UpdateRAM()
            lstRAM.SelectedIndex = index
        Catch
            MsgBox("Please enter a valid number")
        End Try
    End Sub

End Class
