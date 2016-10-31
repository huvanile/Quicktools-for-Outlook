Imports System.Threading
Imports System.Drawing
Imports Quicktools.EmailHelpers

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
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\"
        Dim getImgurImage As New ImgurHelpers
        Dim randPicPath As String = getImgurImage.GetRandomImg
        PictureBox1.Image = getImgurImage.webDownloadImage(randPicPath, True, dlLocation)
        PicBuffer = New System.IO.FileInfo(dlLocation & Split(randPicPath, "/")(3))
        ResizeFileName(dlLocation & randPicPath, Split(randPicPath, "/")(3))
    End Sub

    Private Sub btnDoSteg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoSteg.Click
        Dim Ready As Boolean = True
        Try
            PicFileStream = PicBuffer.OpenRead
        Catch ex As Exception
            Ready = False
            updateTxtFilenameSafe("Please load a picture before clicking proceed")
        End Try
        If Ready = True Then
            StegHelpers.BecomeSteggedImage(PicFileStream, PicBuffer, ThisAddIn.appOutlook.ActiveInspector.CurrentItem)
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
