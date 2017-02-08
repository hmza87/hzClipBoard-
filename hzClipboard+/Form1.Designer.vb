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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.head = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.logo = New System.Windows.Forms.Label
        Me.det = New System.Windows.Forms.Label
        Me.clo = New System.Windows.Forms.Label
        Me.noti = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cntxx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowHideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lst = New hzClipboard_.hzList
        Me.head.SuspendLayout()
        Me.cntxx.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'head
        '
        Me.head.BackColor = System.Drawing.Color.White
        Me.head.Controls.Add(Me.Label1)
        Me.head.Controls.Add(Me.logo)
        Me.head.Controls.Add(Me.det)
        Me.head.Controls.Add(Me.clo)
        Me.head.Dock = System.Windows.Forms.DockStyle.Top
        Me.head.Location = New System.Drawing.Point(0, 0)
        Me.head.Name = "head"
        Me.head.Size = New System.Drawing.Size(342, 57)
        Me.head.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DARK"
        '
        'logo
        '
        Me.logo.Font = New System.Drawing.Font("Mistral", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.logo.Location = New System.Drawing.Point(197, 13)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(158, 49)
        Me.logo.TabIndex = 0
        Me.logo.Text = "hzClipboard+"
        Me.logo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'det
        '
        Me.det.Font = New System.Drawing.Font("Calibri", 7.75!)
        Me.det.Location = New System.Drawing.Point(1, 13)
        Me.det.Name = "det"
        Me.det.Size = New System.Drawing.Size(143, 44)
        Me.det.TabIndex = 3
        Me.det.Text = "Started at {0}"
        Me.det.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.det.Visible = False
        '
        'clo
        '
        Me.clo.AutoSize = True
        Me.clo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clo.Dock = System.Windows.Forms.DockStyle.Right
        Me.clo.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clo.Location = New System.Drawing.Point(321, 0)
        Me.clo.Name = "clo"
        Me.clo.Size = New System.Drawing.Size(21, 13)
        Me.clo.TabIndex = 2
        Me.clo.Text = "  X  "
        '
        'noti
        '
        Me.noti.ContextMenuStrip = Me.cntxx
        Me.noti.Icon = CType(resources.GetObject("noti.Icon"), System.Drawing.Icon)
        Me.noti.Text = "hzClipboard+"
        Me.noti.Visible = True
        '
        'cntxx
        '
        Me.cntxx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHideToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.cntxx.Name = "ContextMenuStrip1"
        Me.cntxx.Size = New System.Drawing.Size(153, 76)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ShowHideToolStripMenuItem
        '
        Me.ShowHideToolStripMenuItem.Image = Global.hzClipboard_.My.Resources.Resources._1486590425_icons_view
        Me.ShowHideToolStripMenuItem.Name = "ShowHideToolStripMenuItem"
        Me.ShowHideToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShowHideToolStripMenuItem.Text = "Show/Hide"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.hzClipboard_.My.Resources.Resources._1486590457_icons_exit
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'lst
        '
        Me.lst.BackColor = System.Drawing.Color.White
        Me.lst.COLOR_SCHEME = hzClipboard_.hzListItem.ColorScheme.DARK
        Me.lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst.ForeColor = System.Drawing.Color.Gray
        Me.lst.Location = New System.Drawing.Point(0, 57)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(342, 391)
        Me.lst.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.lst)
        Me.Controls.Add(Me.head)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Opacity = 0.92
        Me.TopMost = True
        Me.head.ResumeLayout(False)
        Me.head.PerformLayout()
        Me.cntxx.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst As hzClipboard_.hzList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents head As System.Windows.Forms.Panel
    Friend WithEvents logo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clo As System.Windows.Forms.Label
    Friend WithEvents noti As System.Windows.Forms.NotifyIcon
    Friend WithEvents cntxx As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowHideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents det As System.Windows.Forms.Label

End Class
