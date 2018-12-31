<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPUInterface
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAssemble = New System.Windows.Forms.Button()
        Me.lblSP = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.gridRAM = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gridRAM, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblPC.Location = New System.Drawing.Point(123, 31)
        Me.lblPC.Name = "lblPC"
        Me.lblPC.Size = New System.Drawing.Size(189, 23)
        Me.lblPC.TabIndex = 1
        Me.lblPC.Text = "PC"
        Me.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClockSpeed
        '
        Me.lblClockSpeed.BackColor = System.Drawing.Color.Lime
        Me.lblClockSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClockSpeed.Location = New System.Drawing.Point(432, 17)
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
        'lblCIR
        '
        Me.lblCIR.BackColor = System.Drawing.Color.Yellow
        Me.lblCIR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCIR.Location = New System.Drawing.Point(123, 64)
        Me.lblCIR.Name = "lblCIR"
        Me.lblCIR.Size = New System.Drawing.Size(189, 23)
        Me.lblCIR.TabIndex = 6
        Me.lblCIR.Text = "CIR"
        Me.lblCIR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMAR
        '
        Me.lblMAR.BackColor = System.Drawing.Color.Yellow
        Me.lblMAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMAR.Location = New System.Drawing.Point(123, 95)
        Me.lblMAR.Name = "lblMAR"
        Me.lblMAR.Size = New System.Drawing.Size(189, 23)
        Me.lblMAR.TabIndex = 7
        Me.lblMAR.Text = "MAR"
        Me.lblMAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMDR
        '
        Me.lblMDR.BackColor = System.Drawing.Color.Yellow
        Me.lblMDR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMDR.Location = New System.Drawing.Point(123, 124)
        Me.lblMDR.Name = "lblMDR"
        Me.lblMDR.Size = New System.Drawing.Size(189, 23)
        Me.lblMDR.TabIndex = 8
        Me.lblMDR.Text = "MDR"
        Me.lblMDR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblACC
        '
        Me.lblACC.BackColor = System.Drawing.Color.Yellow
        Me.lblACC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblACC.Location = New System.Drawing.Point(123, 152)
        Me.lblACC.Name = "lblACC"
        Me.lblACC.Size = New System.Drawing.Size(189, 23)
        Me.lblACC.TabIndex = 9
        Me.lblACC.Text = "ACC"
        Me.lblACC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(315, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "RAM"
        '
        'btnAssemble
        '
        Me.btnAssemble.Location = New System.Drawing.Point(195, 358)
        Me.btnAssemble.Name = "btnAssemble"
        Me.btnAssemble.Size = New System.Drawing.Size(117, 58)
        Me.btnAssemble.TabIndex = 14
        Me.btnAssemble.Text = "Assemble source code"
        Me.btnAssemble.UseVisualStyleBackColor = True
        '
        'lblSP
        '
        Me.lblSP.BackColor = System.Drawing.Color.Yellow
        Me.lblSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSP.Location = New System.Drawing.Point(123, 181)
        Me.lblSP.Name = "lblSP"
        Me.lblSP.Size = New System.Drawing.Size(189, 23)
        Me.lblSP.TabIndex = 15
        Me.lblSP.Text = "SP"
        Me.lblSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 255)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(122, 13)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Press Clock Tick to start"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(72, 358)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(117, 58)
        Me.btnReset.TabIndex = 17
        Me.btnReset.Text = "Reset CPU"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Location = New System.Drawing.Point(12, 280)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput.TabIndex = 18
        Me.lblOutput.Text = "Output:"
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(11, 296)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(301, 56)
        Me.lstOutput.TabIndex = 19
        '
        'gridRAM
        '
        Me.gridRAM.AllowUserToAddRows = False
        Me.gridRAM.AllowUserToDeleteRows = False
        Me.gridRAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRAM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.gridRAM.Location = New System.Drawing.Point(318, 50)
        Me.gridRAM.MultiSelect = False
        Me.gridRAM.Name = "gridRAM"
        Me.gridRAM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridRAM.Size = New System.Drawing.Size(487, 366)
        Me.gridRAM.TabIndex = 20
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Label"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Address"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Denary"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Hex"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Binary"
        Me.Column4.Name = "Column4"
        '
        'CPUInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 450)
        Me.Controls.Add(Me.gridRAM)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblSP)
        Me.Controls.Add(Me.btnAssemble)
        Me.Controls.Add(Me.Label1)
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
        Me.Name = "CPUInterface"
        Me.Text = "Little Person CPU"
        CType(Me.gridRAM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAssemble As Button
    Friend WithEvents lblSP As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents lblOutput As Label
    Friend WithEvents lstOutput As ListBox
    Friend WithEvents gridRAM As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
