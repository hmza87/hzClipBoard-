Imports System.Runtime.InteropServices

Public Class Form1
    Private Const WM_DRAWCLIPBOARD As Integer = 776
    Private Const WM_CHANGECBCHAIN As Integer = 781
    Private fpChainedWindowHandle As IntPtr
    Private mouseOffset As Point
    Private cloz As Boolean = False
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If m.Msg = WM_DRAWCLIPBOARD Then
            'if the wm_drawclipboard is recieved the clipboard changed
            'do what you want and send the message to the next window in 
            'the chain
            getC()
            SendMessage(fpChainedWindowHandle, m.Msg, m.LParam, m.WParam)
        ElseIf m.Msg = WM_CHANGECBCHAIN Then
            'Send to the next window 
            SendMessage(fpChainedWindowHandle, m.Msg, m.LParam, m.WParam)
            fpChainedWindowHandle = m.LParam
        End If
    End Sub

    <DllImport("User32.dll")> _
    Public Shared Function SetClipboardViewer(ByVal hWndNewViewer As IntPtr) As IntPtr
    End Function
    <DllImport("User32.dll")> _
    Public Shared Function GetClipboardOwner() As IntPtr
    End Function
    <DllImport("User32.dll")> _
    Public Shared Function SendMessage(ByVal Handle As IntPtr, _
                                 ByVal msg As Integer, _
                                 ByVal wParam As IntPtr, _
                                 ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not cloz Then
			dim k = "hassan"
            e.Cancel = True
            HideME()
        End If
    End Sub
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'add yourself to the clipboard viewer
        fpChainedWindowHandle = SetClipboardViewer(Me.Handle)
    End Sub
    Dim lastItem As hzListItem, lastData As IDataObject, lastIMG As Bitmap, lastStr As String
    Sub initUI()
        With Me
            .Top = Screen.PrimaryScreen.WorkingArea.Height - .Height
            .Left = Screen.PrimaryScreen.WorkingArea.Width - .Width

        End With
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HideME()
		dim k as string
        'lst.Items().Add(New hzListItem(New Bitmap("C:\Users\HAMZA\Desktop\tmp\1.png"), hz.hzDataType.IMAGE, "Explorer"))
        'For i As Integer = 0 To 4
        '    Dim l As New hzListItem("ssssz " & i, hz.hzDataType.TEXT, "CHROME")
        '    lst.Items().Add(l)
        'Next
        'lst.initializ()
        det.Text = String.Format(det.Text, Now.Hour & ":" & Now.Minute & "." & Now.Second)
        initUI()
    End Sub

    Private Sub getC()
        Dim data As IDataObject = Clipboard.GetDataObject
        If Not data Is Nothing And Not lastData Is Nothing Then
            If lastData.Equals(data) Then Exit Sub
        End If
        lastData = data

        Dim ty As String
        If data.GetDataPresent(DataFormats.Text) Then
            ty = data.GetData(DataFormats.Text)
            If lastStr <> ty Then
                Dim l As New hzListItem(ty, hz.hzDataType.TEXT, hz.getSRC(GetClipboardOwner))
                lst.Items.Add(l)
            End If
       
        ElseIf data.GetDataPresent(DataFormats.Bitmap) Then
            Dim img As Bitmap = data.GetData(DataFormats.Bitmap)
            If lastIMG Is Nothing Then lastIMG = My.Resources.ic_more_vert_black_48dp
            If hz.diff_image(img, lastIMG) Then
                Dim l As New hzListItem(img, hz.hzDataType.IMAGE, hz.getSRC(GetClipboardOwner))
                lst.Items.Add(l)
            End If
            lastIMG = img

        End If
        If lst.Items.Count > 0 Then
            head.BackColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.FRONT)
            logo.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
            det.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
            Label1.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
        End If
        lst.initializ()
    End Sub

    Private Sub Me_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) _
        Handles MyBase.MouseDown, head.MouseDown, logo.MouseDown

        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Me_MouseMove(ByVal sender As Object, _
        ByVal e As MouseEventArgs) _
        Handles MyBase.MouseMove, head.MouseMove, logo.MouseMove

        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        With Label1
            If .Text = "DARK" Then
                lst.COLOR_SCHEME = hzListItem.ColorScheme.LIGHT
                .Text = "LIGHT"
            Else
                lst.COLOR_SCHEME = hzListItem.ColorScheme.DARK
                .Text = "DARK"
            End If
        End With
        If lst.Items.Count > 0 Then
            initUIcolors()
        End If
    End Sub
    Sub initUIColors()
        Dim re As Boolean = False
        If lst.Items.Count < 1 Then
            lst.Items.Add(New hzListItem("", hz.hzDataType.TEXT, ""))
            re = True
        End If

        head.BackColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.FRONT)
        logo.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
        Label1.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
        det.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
        clo.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)
        cntxx.ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.FRONT)
        cntxx.BackColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)

        If re Then lst.Items.Clear() : re = False
    End Sub
    Sub HideME()
        Me.Hide()
    End Sub
    Sub ShowME()
        Me.Show()
    End Sub
    

    Private Sub clo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clo.Click
        HideME()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        cloz = True
        Me.Close()
    End Sub

    Private Sub ShowHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideToolStripMenuItem.Click
        ShowME()
    End Sub

    Private Sub noti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles noti.Click

    End Sub

    Private Sub noti_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles noti.MouseDoubleClick

    End Sub

    Private Sub lst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.Load

    End Sub

    Private Sub noti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles noti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.Visible Then HideME() Else ShowME()
        End If
    End Sub

    Private Sub logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logo.Click

    End Sub

    Private Sub logo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles logo.MouseEnter
        det.Visible = True
    End Sub

    Private Sub logo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles logo.MouseLeave
        det.Visible = False
    End Sub

    Private Sub clo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles clo.MouseEnter, Label1.MouseEnter

        If lst.Items.Count > 0 Then DirectCast(sender, Label).ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND_H)

    End Sub

    Private Sub clo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clo.MouseLeave, Label1.MouseLeave

        If lst.Items.Count > 0 Then DirectCast(sender, Label).ForeColor = lst.Items(0).getColorScheme(lst.Items(0).ColorSchema)(hzListItem.CSi.BACKGROUND)

    End Sub
End Class
