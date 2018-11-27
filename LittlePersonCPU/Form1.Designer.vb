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
        Me.SuspendLayout()
        '
        'btnClock
        '
        Me.btnClock.Location = New System.Drawing.Point(13, 17)
        Me.btnClock.Name = "btnClock"
        Me.btnClock.Size = New System.Drawing.Size(105, 51)
        Me.btnClock.TabIndex = 0
        Me.btnClock.Text = "Clock Tick"
        Me.btnClock.UseVisualStyleBackColor = True
        '
        'lblPC
        '
        Me.lblPC.BackColor = System.Drawing.Color.Yellow
        Me.lblPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPC.Location = New System.Drawing.Point(156, 31)
        Me.lblPC.Name = "lblPC"
        Me.lblPC.Size = New System.Drawing.Size(100, 23)
        Me.lblPC.TabIndex = 1
        Me.lblPC.Text = "PC: 0"
        Me.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClockSpeed
        '
        Me.lblClockSpeed.BackColor = System.Drawing.Color.Lime
        Me.lblClockSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClockSpeed.Location = New System.Drawing.Point(681, 17)
        Me.lblClockSpeed.Name = "lblClockSpeed"
        Me.lblClockSpeed.Size = New System.Drawing.Size(107, 23)
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
        Me.btnStopClock.Location = New System.Drawing.Point(13, 74)
        Me.btnStopClock.Name = "btnStopClock"
        Me.btnStopClock.Size = New System.Drawing.Size(105, 51)
        Me.btnStopClock.TabIndex = 3
        Me.btnStopClock.Text = "Stop"
        Me.btnStopClock.UseVisualStyleBackColor = True
        '
        'btnClock1Hz
        '
        Me.btnClock1Hz.Location = New System.Drawing.Point(12, 131)
        Me.btnClock1Hz.Name = "btnClock1Hz"
        Me.btnClock1Hz.Size = New System.Drawing.Size(105, 51)
        Me.btnClock1Hz.TabIndex = 4
        Me.btnClock1Hz.Text = "1Hz"
        Me.btnClock1Hz.UseVisualStyleBackColor = True
        '
        'btnClock10Hz
        '
        Me.btnClock10Hz.Location = New System.Drawing.Point(12, 188)
        Me.btnClock10Hz.Name = "btnClock10Hz"
        Me.btnClock10Hz.Size = New System.Drawing.Size(105, 51)
        Me.btnClock10Hz.TabIndex = 5
        Me.btnClock10Hz.Text = "10Hz"
        Me.btnClock10Hz.UseVisualStyleBackColor = True
        '
        'tmrAutoClock
        '
        Me.tmrAutoClock.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnClock10Hz)
        Me.Controls.Add(Me.btnClock1Hz)
        Me.Controls.Add(Me.btnStopClock)
        Me.Controls.Add(Me.lblClockSpeed)
        Me.Controls.Add(Me.lblPC)
        Me.Controls.Add(Me.btnClock)
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
End Class
