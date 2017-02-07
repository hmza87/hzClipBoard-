Public Class hzList
    Inherits UserControl
    Private _list As List(Of hzListItem), Cs As hzClipboard_.hzListItem.ColorScheme
    Friend WithEvents sc As System.Windows.Forms.VScrollBar
    Friend WithEvents paren As System.Windows.Forms.Panel
    Public Property COLOR_SCHEME() As hzClipboard_.hzListItem.ColorScheme
        Get
            Return Cs
        End Get
        Set(ByVal value As hzClipboard_.hzListItem.ColorScheme)
            Cs = value
            initializ()
        End Set
    End Property


    Public Sub initializ()
        body.Controls.Clear()
        For Each i As hzListItem In _list
            i.BORDERS = New Padding(0, 0, 0, 5)
            i.ColorSchema = Cs
            body.Controls.Add(i)

        Next

        Try
            With body
                .Top = 0 : .Left = 0
                .Width = paren.Width
                .Height = body.Controls.Count * 50
                If .Height > paren.Height Then sc.Maximum = .Height - paren.Height : sc.Visible = True Else sc.Visible = False
                sc.Value = 0
            End With
        Catch ex As Exception

        End Try

    End Sub
    Public Function Items() As List(Of hzListItem)
        Return _list
    End Function
    Public Function Items(ByVal index As Integer) As hzListItem
        Return _list(index)
    End Function
    Public Function Items(ByVal text As String) As List(Of hzListItem)
        Dim iz As New List(Of hzListItem)
        For Each i As hzListItem In _list
            If i.iDetail.Text.Contains(text) _
            Or i.iTitle.Text.Contains(text) _
            Or i.DATA.ToString().Contains(text) Then
                iz.Add(i)

            End If
        Next
        Return iz
    End Function
    Public Sub New()
        _list = New List(Of hzListItem)


        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.body = New System.Windows.Forms.Panel
        Me.sc = New System.Windows.Forms.VScrollBar
        Me.paren = New System.Windows.Forms.Panel
        Me.paren.SuspendLayout()
        Me.SuspendLayout()
        '
        'body
        '
        Me.body.Location = New System.Drawing.Point(12, 12)
        Me.body.Name = "body"
        Me.body.Size = New System.Drawing.Size(200, 313)
        Me.body.TabIndex = 3
        '
        'sc
        '
        Me.sc.Dock = System.Windows.Forms.DockStyle.Right
        Me.sc.Location = New System.Drawing.Point(292, 6)
        Me.sc.Name = "sc"
        Me.sc.Size = New System.Drawing.Size(17, 398)
        Me.sc.TabIndex = 4
        '
        'paren
        '
        Me.paren.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.paren.Controls.Add(Me.body)
        Me.paren.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paren.Location = New System.Drawing.Point(6, 6)
        Me.paren.Name = "paren"
        Me.paren.Size = New System.Drawing.Size(286, 398)
        Me.paren.TabIndex = 5
        '
        'hzList
        '
        Me.Controls.Add(Me.paren)
        Me.Controls.Add(Me.sc)
        Me.Name = "hzList"
        Me.Padding = New System.Windows.Forms.Padding(6)
        Me.Size = New System.Drawing.Size(315, 410)
        Me.paren.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents body As System.Windows.Forms.Panel

    Private Sub body_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles body.Paint

    End Sub

    Private Sub sc_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles sc.Scroll

    End Sub

    Private Sub sc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sc.ValueChanged
        body.Top = -sc.Value
    End Sub
End Class
