Public Class hz
    Public Enum hzDataType As Integer
        IMAGE = 0
        FILE = 1
        TEXT = 2
    End Enum

    Public Shared Function diff_image(ByVal newImage As Bitmap, ByVal OldImage As Bitmap)
        Dim xx, yy As Integer
        Dim diff = False
        If newImage.Width = OldImage.Width Or OldImage.Height = newImage.Height Then
            If newImage.Height < 50 Then yy = newImage.Height Else yy = 50
            If newImage.Width < 50 Then xx = newImage.Width Else xx = 50


            For i As Integer = 0 To xx - 1
                For u As Integer = 0 To yy - 1
                    If newImage.GetPixel(i, u) <> OldImage.GetPixel(i, u) Then
                        Return True
                    End If
                Next
            Next
        Else
            diff = True
        End If



        Return diff
    End Function


    Public Shared Function TimeAgo(ByVal dateTime__1 As DateTime) As String
        Dim result As String = String.Empty
        Dim timeSpan__2 = DateTime.Now.Subtract(dateTime__1)

        If timeSpan__2 <= TimeSpan.FromSeconds(60) Then
            result = "just now"
        ElseIf timeSpan__2 <= TimeSpan.FromMinutes(60) Then
            result = If(timeSpan__2.Minutes > 1, [String].Format("about {0} minutes ago", timeSpan__2.Minutes), "about a minute ago")
        ElseIf timeSpan__2 <= TimeSpan.FromHours(24) Then
            result = If(timeSpan__2.Hours > 1, [String].Format("about {0} hours ago", timeSpan__2.Hours), "about an hour ago")
        ElseIf timeSpan__2 <= TimeSpan.FromDays(30) Then
            result = If(timeSpan__2.Days > 1, [String].Format("about {0} days ago", timeSpan__2.Days), "yesterday")
        ElseIf timeSpan__2 <= TimeSpan.FromDays(365) Then
            result = If(timeSpan__2.Days > 30, [String].Format("about {0} months ago", timeSpan__2.Days / 30), "about a month ago")
        Else
            result = If(timeSpan__2.Days > 365, [String].Format("about {0} years ago", timeSpan__2.Days / 365), "about a year ago")
        End If

        Return result
    End Function
    Public Shared Function getSRC(ByVal hndl As IntPtr) As String
        For Each p As Process In Process.GetProcesses
            If p.MainWindowHandle = hndl Then Return p.ProcessName
        Next
        Return ""
    End Function

End Class
