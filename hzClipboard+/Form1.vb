Imports System.Runtime.InteropServices

Public Class Form1
    Private Const WM_DRAWCLIPBOARD As Integer = 776
    Private Const WM_CHANGECBCHAIN As Integer = 781
    Private fpChainedWindowHandle As IntPtr
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
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'add yourself to the clipboard viewer
        fpChainedWindowHandle = SetClipboardViewer(Me.Handle)
    End Sub
    Dim lastItem As hzListItem, lastData As IDataObject, lastIMG As Bitmap, lastStr As String



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lst.Items().Add(New hzListItem(New Bitmap("C:\Users\HAMZA\Desktop\tmp\1.png"), hz.hzDataType.IMAGE, "Explorer"))
        'For i As Integer = 0 To 4
        '    Dim l As New hzListItem("ssssz " & i, hz.hzDataType.TEXT, "CHROME")
        '    lst.Items().Add(l)
        'Next
        'lst.initializ()
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
        lst.initializ()
    End Sub
End Class
