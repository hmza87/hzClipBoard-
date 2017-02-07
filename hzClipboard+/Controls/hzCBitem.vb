Public Class hzListItem
    Inherits UserControl
    Public Type As hz.hzDataType
    Public DATA As Object = ""
    Public DataSource As String = ""
    Public Time As DateTime
    Private CSCHEME As ColorScheme
    Private p As Padding
    Public Property BORDERS() As Padding
        Get
            Return p
        End Get
        Set(ByVal value As Padding)
            p = value
        End Set
    End Property
    Public Enum ColorScheme As Integer
        DARK = 0
        LIGHT = 1
        COLORED = 2
    End Enum
    Public Enum CSi
        BACKGROUND = 0
        BACKGROUND_H
        FRONT
        FRONT_H
        SPECIAL
        SPECIAL_H
        FLASH
        FLASH_H
    End Enum
    Public Property ColorSchema() As ColorScheme
        Get
            Return CSCHEME
        End Get
        Set(ByVal value As ColorScheme)
            CSCHEME = value
            normalUI()
        End Set
    End Property

    Friend WithEvents iTool As System.Windows.Forms.PictureBox
    Friend WithEvents ico As System.Windows.Forms.PictureBox
    Friend WithEvents iDetail As System.Windows.Forms.Label
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cx As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents COPYCNTNT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DELCNTNT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents svIMG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents iTitle As System.Windows.Forms.Label
    Public Sub Initializ()
        Select Case Type
            Case hz.hzDataType.TEXT
                iTitle.Text = DATA.ToString
            Case hz.hzDataType.IMAGE
                iTitle.Text = "Image " & CType(DATA, Bitmap).Height & "X" & CType(DATA, Bitmap).Width
                ico.Image = CType(DATA, Bitmap)
                ico.Visible = True
            Case hz.hzDataType.FILE
                iTitle.Text = "File"
        End Select

        iDetail.Text = hz.TimeAgo(Time) & ", From " & DataSource



        For Each c As Control In Me.Controls
            c.BackColor = Color.Transparent
            AddHandler c.MouseEnter, AddressOf MouseEnter_g
            AddHandler c.MouseLeave, AddressOf MouseLeave_g
        Next
        svIMG.Visible = (Type = hz.hzDataType.IMAGE)
        Me.Padding = p
    End Sub
    Sub normalUI()
        Me.BackColor = getColorScheme(Me.CSCHEME)(CSi.BACKGROUND)
        Me.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT)
        iTitle.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT)
        iDetail.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT)
        cx.BackColor = getColorScheme(Me.CSCHEME)(CSi.BACKGROUND)
        cx.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT)
    End Sub
    Sub hoverUI()
        Me.BackColor = getColorScheme(Me.CSCHEME)(CSi.BACKGROUND_H)
        Me.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT_H)
        iTitle.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT_H)
        iDetail.ForeColor = getColorScheme(Me.CSCHEME)(CSi.FRONT_H)
    End Sub
    Public Sub New(ByVal _data As Object, ByVal _type As hz.hzDataType, ByVal _src As String)
        Me.Type = _type
        Me.DATA = _data
        Me.DataSource = _src
        Me.Time = Now()
        InitializeComponent()
        Me.SendToBack()
    End Sub
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.iTitle = New System.Windows.Forms.Label
        Me.iDetail = New System.Windows.Forms.Label
        Me.ico = New System.Windows.Forms.PictureBox
        Me.iTool = New System.Windows.Forms.PictureBox
        Me.cx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.COPYCNTNT = New System.Windows.Forms.ToolStripMenuItem
        Me.DELCNTNT = New System.Windows.Forms.ToolStripMenuItem
        Me.svIMG = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.ico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cx.SuspendLayout()
        Me.SuspendLayout()
        '
        'iTitle
        '
        Me.iTitle.BackColor = System.Drawing.Color.Transparent
        Me.iTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.iTitle.Location = New System.Drawing.Point(0, 0)
        Me.iTitle.Name = "iTitle"
        Me.iTitle.Size = New System.Drawing.Size(285, 34)
        Me.iTitle.TabIndex = 4
        Me.iTitle.Text = "Title"
        '
        'iDetail
        '
        Me.iDetail.BackColor = System.Drawing.Color.Transparent
        Me.iDetail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.iDetail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.iDetail.Location = New System.Drawing.Point(0, 34)
        Me.iDetail.Name = "iDetail"
        Me.iDetail.Size = New System.Drawing.Size(285, 15)
        Me.iDetail.TabIndex = 5
        Me.iDetail.Text = "Detail"
        '
        'ico
        '
        Me.ico.BackColor = System.Drawing.Color.Transparent
        Me.ico.Dock = System.Windows.Forms.DockStyle.Right
        Me.ico.Location = New System.Drawing.Point(285, 0)
        Me.ico.Name = "ico"
        Me.ico.Size = New System.Drawing.Size(49, 49)
        Me.ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ico.TabIndex = 7
        Me.ico.TabStop = False
        Me.ico.Visible = False
        '
        'iTool
        '
        Me.iTool.BackColor = System.Drawing.Color.Transparent
        Me.iTool.Dock = System.Windows.Forms.DockStyle.Right
        Me.iTool.Image = Global.hzClipboard_.My.Resources.Resources.ic_more_vert_black_48dp
        Me.iTool.Location = New System.Drawing.Point(334, 0)
        Me.iTool.Name = "iTool"
        Me.iTool.Size = New System.Drawing.Size(27, 49)
        Me.iTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iTool.TabIndex = 6
        Me.iTool.TabStop = False
        '
        'cx
        '
        Me.cx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COPYCNTNT, Me.svIMG, Me.DELCNTNT})
        Me.cx.Name = "cx"
        Me.cx.Size = New System.Drawing.Size(153, 92)
        '
        'COPYCNTNT
        '
        Me.COPYCNTNT.Name = "COPYCNTNT"
        Me.COPYCNTNT.Size = New System.Drawing.Size(152, 22)
        Me.COPYCNTNT.Text = "Copy Content"
        '
        'DELCNTNT
        '
        Me.DELCNTNT.Name = "DELCNTNT"
        Me.DELCNTNT.Size = New System.Drawing.Size(152, 22)
        Me.DELCNTNT.Text = "Delete"
        '
        'svIMG
        '
        Me.svIMG.Name = "svIMG"
        Me.svIMG.Size = New System.Drawing.Size(152, 22)
        Me.svIMG.Text = "Save Image"
        Me.svIMG.Visible = False
        '
        'hzListItem
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.iTitle)
        Me.Controls.Add(Me.iDetail)
        Me.Controls.Add(Me.ico)
        Me.Controls.Add(Me.iTool)
        Me.Name = "hzListItem"
        Me.Size = New System.Drawing.Size(361, 49)
        CType(Me.ico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cx.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private Sub MouseEnter_g(ByVal sender As Object, ByVal e As System.EventArgs)
        hoverUI()
        iTool.Image = My.Resources.ic_more_vert_black_48dp
    End Sub

    Private Sub MouseLeave_g(ByVal sender As Object, ByVal e As System.EventArgs)
        normalUI()
        iTool.Image = Nothing
    End Sub

    Private Sub hzListItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, iTitle.Click, ico.Click, iDetail.Click
        iTool_Click(sender, e)
    End Sub

    Private Sub hzListItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Dock = DockStyle.Top
        Me.Initializ()
    End Sub
    Private Sub iTool_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles iTool.MouseDown
        DirectCast(sender, Control).BackColor = Color.FromArgb(200, 200, 200)
    End Sub

    Private Sub iTool_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles iTool.MouseUp
        DirectCast(sender, Control).BackColor = Color.Transparent
    End Sub

    Public Function getColorScheme(ByVal ColorS As ColorScheme) As Dictionary(Of Integer, Color)
        Dim DRK, LGHT As New Dictionary(Of Integer, Color)
        With DRK
            .Add(CSi.BACKGROUND_H, Color.Gray)
            .Add(CSi.FRONT_H, Color.FromArgb(224, 224, 224))
            .Add(CSi.SPECIAL_H, Color.White)
            .Add(CSi.FLASH_H, Color.LightYellow)

            .Add(CSi.BACKGROUND, cl(40, 40, 40))
            .Add(CSi.FRONT, Color.FromArgb(224, 224, 224))
            .Add(CSi.SPECIAL, Color.White)
            .Add(CSi.FLASH, Color.LightYellow)
        End With
        With LGHT
            .Add(CSi.BACKGROUND_H, Color.Gainsboro)
            .Add(CSi.FRONT_H, cl(80, 80, 80))
            .Add(CSi.SPECIAL_H, cl(20, 20, 20))
            .Add(CSi.FLASH_H, Color.Black)

            .Add(CSi.BACKGROUND, cl(200, 200, 200))
            .Add(CSi.FRONT, cl(40, 40, 40))
            .Add(CSi.SPECIAL, cl(50, 50, 50))
            .Add(CSi.FLASH, Color.White)
        End With


        If ColorS = ColorScheme.LIGHT Then Return LGHT Else Return DRK
    End Function
    Private Function cl(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Color
        Return Color.FromArgb(r, g, b)
    End Function

    Private Sub iTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iTool.Click
        cx.Width = Me.Width
        cx.Show(iTool, (0 - cx.Width) + iTool.Width, 0)
    End Sub
End Class

