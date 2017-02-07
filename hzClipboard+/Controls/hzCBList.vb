Public Class hzList
    Inherits UserControl
    Private _list As List(Of hzListItem), Cs As hzClipboard_.hzListItem.ColorScheme
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
            i.ColorSchema = Cs
            body.Controls.Add(i)

        Next
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
        Me.SuspendLayout()
        '
        'body
        '
        Me.body.Dock = System.Windows.Forms.DockStyle.Fill
        Me.body.Location = New System.Drawing.Point(6, 6)
        Me.body.Name = "body"
        Me.body.Size = New System.Drawing.Size(303, 398)
        Me.body.TabIndex = 3
        '
        'hzList
        '
        Me.Controls.Add(Me.body)
        Me.Name = "hzList"
        Me.Padding = New System.Windows.Forms.Padding(6)
        Me.Size = New System.Drawing.Size(315, 410)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents body As System.Windows.Forms.Panel

    Private Sub body_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles body.Paint

    End Sub
End Class
