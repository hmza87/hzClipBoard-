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
        Me.lst = New hzClipboard_.hzList
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lst
        '
        Me.lst.BackColor = System.Drawing.Color.White
        Me.lst.COLOR_SCHEME = hzClipboard_.hzListItem.ColorScheme.LIGHT
        Me.lst.Location = New System.Drawing.Point(13, 12)
        Me.lst.Name = "lst"
        Me.lst.Padding = New System.Windows.Forms.Padding(6)
        Me.lst.Size = New System.Drawing.Size(292, 335)
        Me.lst.TabIndex = 0
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 382)
        Me.Controls.Add(Me.lst)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst As hzClipboard_.hzList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
