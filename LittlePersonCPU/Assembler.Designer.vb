<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Assembler
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
        Me.btnAssemble = New System.Windows.Forms.Button()
        Me.txtAssembly = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMachineCode = New System.Windows.Forms.TextBox()
        Me.btnDisassemble = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MachineCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssemblerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadFromCPUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MachineCodeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssemblerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendToCPUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAssemble
        '
        Me.btnAssemble.Location = New System.Drawing.Point(17, 434)
        Me.btnAssemble.Name = "btnAssemble"
        Me.btnAssemble.Size = New System.Drawing.Size(349, 29)
        Me.btnAssemble.TabIndex = 0
        Me.btnAssemble.Text = "Assemble"
        Me.btnAssemble.UseVisualStyleBackColor = True
        '
        'txtAssembly
        '
        Me.txtAssembly.Location = New System.Drawing.Point(15, 50)
        Me.txtAssembly.Multiline = True
        Me.txtAssembly.Name = "txtAssembly"
        Me.txtAssembly.Size = New System.Drawing.Size(351, 378)
        Me.txtAssembly.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Assembly source code:"
        '
        'txtMachineCode
        '
        Me.txtMachineCode.Location = New System.Drawing.Point(372, 50)
        Me.txtMachineCode.Multiline = True
        Me.txtMachineCode.Name = "txtMachineCode"
        Me.txtMachineCode.Size = New System.Drawing.Size(351, 378)
        Me.txtMachineCode.TabIndex = 3
        '
        'btnDisassemble
        '
        Me.btnDisassemble.Location = New System.Drawing.Point(374, 434)
        Me.btnDisassemble.Name = "btnDisassemble"
        Me.btnDisassemble.Size = New System.Drawing.Size(349, 29)
        Me.btnDisassemble.TabIndex = 4
        Me.btnDisassemble.Text = "Disassemble"
        Me.btnDisassemble.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(371, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Machine code:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(730, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MachineCodeToolStripMenuItem, Me.AssemblerToolStripMenuItem, Me.LoadFromCPUToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'MachineCodeToolStripMenuItem
        '
        Me.MachineCodeToolStripMenuItem.Name = "MachineCodeToolStripMenuItem"
        Me.MachineCodeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.MachineCodeToolStripMenuItem.Text = "Open &Machine code"
        '
        'AssemblerToolStripMenuItem
        '
        Me.AssemblerToolStripMenuItem.Name = "AssemblerToolStripMenuItem"
        Me.AssemblerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AssemblerToolStripMenuItem.Text = "Open &Assembler"
        '
        'LoadFromCPUToolStripMenuItem
        '
        Me.LoadFromCPUToolStripMenuItem.Name = "LoadFromCPUToolStripMenuItem"
        Me.LoadFromCPUToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.LoadFromCPUToolStripMenuItem.Text = "Load from CPU"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MachineCodeToolStripMenuItem1, Me.AssemblerToolStripMenuItem1, Me.SendToCPUToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'MachineCodeToolStripMenuItem1
        '
        Me.MachineCodeToolStripMenuItem1.Name = "MachineCodeToolStripMenuItem1"
        Me.MachineCodeToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.MachineCodeToolStripMenuItem1.Text = "Save &Machine code"
        '
        'AssemblerToolStripMenuItem1
        '
        Me.AssemblerToolStripMenuItem1.Name = "AssemblerToolStripMenuItem1"
        Me.AssemblerToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.AssemblerToolStripMenuItem1.Text = "Save &Assembler"
        '
        'SendToCPUToolStripMenuItem
        '
        Me.SendToCPUToolStripMenuItem.Name = "SendToCPUToolStripMenuItem"
        Me.SendToCPUToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SendToCPUToolStripMenuItem.Text = "Send to CPU"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'Assembler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 469)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDisassemble)
        Me.Controls.Add(Me.txtMachineCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAssembly)
        Me.Controls.Add(Me.btnAssemble)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Assembler"
        Me.Text = "Assembler"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAssemble As Button
    Friend WithEvents txtAssembly As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMachineCode As TextBox
    Friend WithEvents btnDisassemble As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MachineCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssemblerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MachineCodeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AssemblerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadFromCPUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SendToCPUToolStripMenuItem As ToolStripMenuItem
End Class
