Imports System.Threading
Imports System.Drawing
Imports System.IO
Imports System.Text.RegularExpressions

Public Class tpnStegSteg
    Dim t1 As Thread
    Dim PicBuffer As System.IO.FileInfo
    Dim PicFileStream As System.IO.FileStream

#Region "Thread-safe GUI Updaters"
    Public Delegate Sub setTextSafeCallback([theText] As String)
    Public Delegate Sub clearImageSafeCallback([theImagePath] As String)

    Public Sub clearPBoxSafe(theImagePath As String)
        Try
            With PictureBox1
                If .InvokeRequired Then
                    Dim d As New clearImageSafeCallback(AddressOf clearPBoxSafe)
                    Me.Invoke(d, New Object() {[theImagePath]})
                    d = Nothing
                Else
                    .Image = Nothing
                    .Refresh()
                    .Invalidate()
                End If
            End With
        Catch exAll As Exception : End Try
    End Sub

    Public Sub updateTxtFilenameSafe(theText As String)
        Try
            With txtFilename
                If .InvokeRequired Then
                    Dim d As New setTextSafeCallback(AddressOf updateTxtFilenameSafe)
                    Me.Invoke(d, New Object() {[theText]})
                    d = Nothing
                Else
                    .Text = theText
                    .Refresh()
                    .Invalidate()
                End If
            End With
        Catch exAll As Exception : End Try

    End Sub
#End Region

    Private Function BecomeSteggedImage(picFileStream As System.IO.FileStream, picBuffer As System.IO.FileInfo, theMailItem As Outlook.MailItem) As Boolean
        Try
            Dim theBody As String = theMailItem.Body
            theBody = theBody.Replace("'", "")
            theBody = theBody.Replace("""", "")
            theBody = theBody.Replace("…", "")
            Dim PicBytes As Long = picFileStream.Length
            Dim PicExt As String = picBuffer.Extension
            Dim tmpFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
            Dim PicByteArray(PicBytes) As Byte
            picFileStream.Read(PicByteArray, 0, PicBytes)
            Dim SentinelString() As Byte = {73, 116, 83, 116, 97, 114, 116, 115, 72, 101, 114, 101}

            Dim PlainTextByteArray(theBody.Length) As Byte
            For i As Integer = 0 To (theBody.Length - 1)
                PlainTextByteArray(i) = CByte(AscW(theBody.Chars(i)))
                Diagnostics.Debug.Print(i & " of " & (theBody.Length - 1))
            Next
            Dim PicAndText(PicBytes + theBody.Length + SentinelString.Length) As Byte
            For t As Long = 0 To (PicBytes - 1)
                PicAndText(t) = PicByteArray(t)
            Next
            Dim count As Integer = 0
            For r As Long = PicBytes To (PicBytes + (SentinelString.Length) - 1)
                PicAndText(r) = SentinelString(count)
                count += 1
            Next
            count = 0
            For q As Long = (PicBytes + SentinelString.Length) To (PicBytes + SentinelString.Length + theBody.Length - 1)
                PicAndText(q) = PlainTextByteArray(count)
                count += 1
            Next
            My.Computer.FileSystem.WriteAllBytes(tmpFolder & "Copy of " & picBuffer.Name, PicAndText, False)
            EmailHelpers.SwapAndSteg(theMailItem, tmpFolder & "Copy of " & picBuffer.Name)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromFile.Click
        Dim openPic As New System.Windows.Forms.OpenFileDialog
        With openPic
            .Title = "Open Picture From File"
            .Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            .ShowDialog()
        End With
        If openPic.FileName <> "" Then
            PicBuffer = New System.IO.FileInfo(openPic.FileName)
            ResizeFileName(openPic.FileName, PicBuffer.Name)
            PicFileStream = PicBuffer.OpenRead
            PictureBox1.Image = Image.FromFile(openPic.FileName)
        End If
        openPic = Nothing
    End Sub

    Private Sub btnFromImgur_Click(sender As Object, e As EventArgs) Handles btnFromImgur.Click
        t1 = Nothing
        t1 = New Thread(AddressOf imgurDownloader, 8000000)
        With t1
            .IsBackground = True
            .Priority = ThreadPriority.Lowest
            .SetApartmentState(ApartmentState.STA)
            .Start()
        End With
    End Sub

    Private Sub imgurDownloader()
        clearPBoxSafe("asdf")
        updateTxtFilenameSafe("Loading random Imgur image... please be patient")
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
        Dim getImgurImage As New ImgurHelpers
        Dim randPicPath As String = getImgurImage.GetRandomImg()
        PictureBox1.Image = getImgurImage.webDownloadImage(randPicPath, True, dlLocation)
        PicBuffer = New System.IO.FileInfo(dlLocation & Split(randPicPath, "/")(3))
        ResizeFileName(dlLocation & randPicPath, Split(randPicPath, "/")(3))
    End Sub

    Private Sub btnDoSteg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoSteg.Click
        Dim Ready As Boolean = True
        updateTxtFilenameSafe("Embedded text and attaching...")
        Try
            PicFileStream = PicBuffer.OpenRead
        Catch ex As Exception
            Ready = False
            updateTxtFilenameSafe("Please load a picture before clicking proceed")
        End Try
        If Ready = True Then
            If BecomeSteggedImage(PicFileStream, PicBuffer, ThisAddIn.appOutlook.ActiveInspector.CurrentItem) = True Then
                updateTxtFilenameSafe("Success! You can now send your email!")
            Else
                updateTxtFilenameSafe("An error occurred. Maybe try a different image?")
            End If
        End If
    End Sub

    Private Sub tpnStegSteg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFilename.Text = "Select an image:"
    End Sub

    Sub ResizeFileName(ByVal LongFileName As String, ByVal ShortFileName As String)
        If LongFileName.Length > 65 Then
            Dim LongFileNameSize As Integer = LongFileName.Length
            Dim ShortFileNameSize As Integer = ShortFileName.Length
            Dim Cut As Integer = 65 - (5 + ShortFileNameSize)
            Dim i As Integer
            updateTxtFilenameSafe(String.Empty)
            For i = 0 To (Cut) - 1
                updateTxtFilenameSafe(txtFilename.Text & LongFileName.Chars(i))
            Next
            For i = 0 To 4
                updateTxtFilenameSafe(txtFilename.Text & ".")
            Next
            For i = 0 To (ShortFileNameSize - 1)
                updateTxtFilenameSafe(txtFilename.Text & ShortFileName(i))
            Next
        Else
            updateTxtFilenameSafe(LongFileName)
        End If

    End Sub

End Class
