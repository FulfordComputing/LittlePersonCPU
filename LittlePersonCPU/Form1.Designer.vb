<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnClock = New System.Windows.Forms.Button()
        Me.lblPC = New System.Windows.Forms.Label()
        Me.lblClockSpeed = New System.Windows.Forms.Label()
        Me.tmrClockSpeed = New System.Windows.Forms.Timer(Me.components)
        Me.btnStopClock = New System.Windows.Forms.Button()
        Me.btnClock1Hz = New System.Windows.Forms.Button()
        Me.btnClock10Hz = New System.Windows.Forms.Button()
        Me.tmrAutoClock = New System.Windows.Forms.Timer(Me.components)
        Me.lblCIR = New System.Windows.Forms.Label()
        Me.lblMAR = New System.Windows.Forms.Label()
        Me.lblMDR = New System.Windows.Forms.Label()
        Me.lblACC = New System.Windows.Forms.Label()
        Me.lbRAM = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnClock
        '
        Me.btnClock.Location = New System.Drawing.Point(26, 33)
        Me.btnClock.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClock.Name = "btnClock"
        Me.btnClock.Size = New System.Drawing.Size(210, 98)
        Me.btnClock.TabIndex = 0
        Me.btnClock.Text = "Clock Tick"
        Me.btnClock.UseVisualStyleBackColor = True
        '
        'lblPC
        '
        Me.lblPC.BackColor = System.Drawing.Color.Yellow
        Me.lblPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPC.Location = New System.Drawing.Point(312, 60)
        Me.lblPC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPC.Name = "lblPC"
        Me.lblPC.Size = New System.Drawing.Size(258, 42)
        Me.lblPC.TabIndex = 1
        Me.lblPC.Text = "PC: 0"
        Me.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClockSpeed
        '
        Me.lblClockSpeed.BackColor = System.Drawing.Color.Lime
        Me.lblClockSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClockSpeed.Location = New System.Drawing.Point(1362, 33)
        Me.lblClockSpeed.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblClockSpeed.Name = "lblClockSpeed"
        Me.lblClockSpeed.Size = New System.Drawing.Size(212, 42)
        Me.lblClockSpeed.TabIndex = 2
        Me.lblClockSpeed.Text = "Clock Speed: 0"
        Me.lblClockSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrClockSpeed
        '
        Me.tmrClockSpeed.Enabled = True
        Me.tmrClockSpeed.Interval = 1000
        '
        'btnStopClock
        '
        Me.btnStopClock.Location = New System.Drawing.Point(26, 142)
        Me.btnStopClock.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnStopClock.Name = "btnStopClock"
        Me.btnStopClock.Size = New System.Drawing.Size(210, 98)
        Me.btnStopClock.TabIndex = 3
        Me.btnStopClock.Text = "Stop"
        Me.btnStopClock.UseVisualStyleBackColor = True
        '
        'btnClock1Hz
        '
        Me.btnClock1Hz.Location = New System.Drawing.Point(24, 252)
        Me.btnClock1Hz.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClock1Hz.Name = "btnClock1Hz"
        Me.btnClock1Hz.Size = New System.Drawing.Size(210, 98)
        Me.btnClock1Hz.TabIndex = 4
        Me.btnClock1Hz.Text = "1Hz"
        Me.btnClock1Hz.UseVisualStyleBackColor = True
        '
        'btnClock10Hz
        '
        Me.btnClock10Hz.Location = New System.Drawing.Point(24, 362)
        Me.btnClock10Hz.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnClock10Hz.Name = "btnClock10Hz"
        Me.btnClock10Hz.Size = New System.Drawing.Size(210, 98)
        Me.btnClock10Hz.TabIndex = 5
        Me.btnClock10Hz.Text = "10Hz"
        Me.btnClock10Hz.UseVisualStyleBackColor = True
        '
        'tmrAutoClock
        '
        Me.tmrAutoClock.Interval = 1000
        '
        'lblCIR
        '
        Me.lblCIR.BackColor = System.Drawing.Color.Yellow
        Me.lblCIR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCIR.Location = New System.Drawing.Point(312, 123)
        Me.lblCIR.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCIR.Name = "lblCIR"
        Me.lblCIR.Size = New System.Drawing.Size(258, 42)
        Me.lblCIR.TabIndex = 6
        Me.lblCIR.Text = "PC: 0"
        Me.lblCIR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMAR
        '
        Me.lblMAR.BackColor = System.Drawing.Color.Yellow
        Me.lblMAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMAR.Location = New System.Drawing.Point(312, 183)
        Me.lblMAR.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblMAR.Name = "lblMAR"
        Me.lblMAR.Size = New System.Drawing.Size(258, 42)
        Me.lblMAR.TabIndex = 7
        Me.lblMAR.Text = "PC: 0"
        Me.lblMAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMDR
        '
        Me.lblMDR.BackColor = System.Drawing.Color.Yellow
        Me.lblMDR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMDR.Location = New System.Drawing.Point(312, 238)
        Me.lblMDR.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblMDR.Name = "lblMDR"
        Me.lblMDR.Size = New System.Drawing.Size(258, 42)
        Me.lblMDR.TabIndex = 8
        Me.lblMDR.Text = "PC: 0"
        Me.lblMDR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblACC
        '
        Me.lblACC.BackColor = System.Drawing.Color.Yellow
        Me.lblACC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblACC.Location = New System.Drawing.Point(312, 292)
        Me.lblACC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblACC.Name = "lblACC"
        Me.lblACC.Size = New System.Drawing.Size(258, 42)
        Me.lblACC.TabIndex = 9
        Me.lblACC.Text = "PC: 0"
        Me.lblACC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRAM
        '
        Me.lbRAM.FormattingEnabled = True
        Me.lbRAM.ItemHeight = 25
        Me.lbRAM.Location = New System.Drawing.Point(779, 60)
        Me.lbRAM.Name = "lbRAM"
        Me.lbRAM.Size = New System.Drawing.Size(438, 729)
        Me.lbRAM.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 865)
        Me.Controls.Add(Me.lbRAM)
        Me.Controls.Add(Me.lblACC)
        Me.Controls.Add(Me.lblMDR)
        Me.Controls.Add(Me.lblMAR)
        Me.Controls.Add(Me.lblCIR)
        Me.Controls.Add(Me.btnClock10Hz)
        Me.Controls.Add(Me.btnClock1Hz)
        Me.Controls.Add(Me.btnStopClock)
        Me.Controls.Add(Me.lblClockSpeed)
        Me.Controls.Add(Me.lblPC)
        Me.Controls.Add(Me.btnClock)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form1"
        Me.Text = "Little Person CPU"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClock As Button
    Friend WithEvents lblPC As Label
    Friend WithEvents lblClockSpeed As Label
    Friend WithEvents tmrClockSpeed As Timer
    Friend WithEvents btnStopClock As Button
    Friend WithEvents btnClock1Hz As Button
    Friend WithEvents btnClock10Hz As Button
    Friend WithEvents tmrAutoClock As Timer
    Friend WithEvents lblCIR As Label
    Friend WithEvents lblMAR As Label
    Friend WithEvents lblMDR As Label
    Friend WithEvents lblACC As Label
    Friend WithEvents lbRAM As ListBox
End Class
