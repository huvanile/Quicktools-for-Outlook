Imports System.Threading
Imports System.Drawing
Imports Quicktools.EmailHelpers
Imports System.IO

Public Class tpnStegUnsteg
    Dim PicBuffer As System.IO.FileInfo
    Dim PicFileStream As System.IO.FileStream

#Region "Thread-safe GUI Updaters"
    Public Delegate Sub setTextSafeCallback([theText] As String)
    Public Delegate Sub clearImageSafeCallback([theImagePath] As String)

    Private Sub clearPBoxSafe(theImagePath As String)
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

    Private Sub updateTxtRecoveredTextSafe(theText As String)
        Try
            With txtRecoveredText
                If .InvokeRequired Then
                    Dim d As New setTextSafeCallback(AddressOf updateTxtRecoveredTextSafe)
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

    Private Sub tpnStegUnsteg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboAttachments.Items.AddRange(SelectedEmailAttachedImages.ToArray)
        cboAttachments.SelectedIndex = 0
    End Sub

    Private Sub RecoverSteggedText(picFileStream As System.IO.FileStream, picBuffer As System.IO.FileInfo)
        Try
            Dim PicBytes As Long = picFileStream.Length
            Dim PicExt As String = picBuffer.Extension
            Dim PicByteArray(PicBytes) As Byte
            picFileStream.Read(PicByteArray, 0, PicBytes)
            Dim SentinelString() As Byte = {73, 116, 83, 116, 97, 114, 116, 115, 72, 101, 114, 101}
            Dim OutterSearch, InnerSearch, StopSearch As Boolean
            OutterSearch = True
            InnerSearch = True
            StopSearch = False
            Dim count As Long = 0
            Dim leftCounter As Long
            Dim rightCounter As Integer
            leftCounter = 0
            rightCounter = 0
            Do While (count < (PicBytes - SentinelString.Length) And StopSearch = False)
                If (PicByteArray(count) = SentinelString(0)) Then
                    leftCounter = count + 1
                    rightCounter = 1
                    InnerSearch = True
                    Do While (InnerSearch = True) And (rightCounter < SentinelString.Length) _
                And (leftCounter < PicByteArray.Length)
                        If (PicByteArray(leftCounter) = SentinelString(rightCounter)) Then
                            rightCounter += 1
                            leftCounter += 1
                            If (rightCounter = (SentinelString.Length - 1)) Then
                                StopSearch = True
                            End If
                        Else
                            InnerSearch = False
                            count += 1
                        End If
                    Loop
                Else
                    count += 1
                End If
            Loop
            If StopSearch = True Then
                'leftCounter contains the starting string that is being retrieved
                Do While (leftCounter < PicBytes)
                    'Bytes need to be converted to an integer 
                    'then to an unicode character which will be the plaintext
                    updateTxtRecoveredTextSafe(txtRecoveredText.Text & ChrW(CInt(PicByteArray(leftCounter))))
                    leftCounter += 1
                Loop
            Else
                updateTxtRecoveredTextSafe("The Picture does not contain any text")
            End If
        Catch ex As Exception
            updateTxtRecoveredTextSafe("The picture does not contain any text and/or the tool was not able to read it")
        End Try
    End Sub

    Private Sub cboAttachments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAttachments.SelectedIndexChanged
        updateTxtRecoveredTextSafe(String.Empty)
        clearPBoxSafe("asdf")
        If cboAttachments.SelectedItem.ToString Like "*jpg" _
        Or cboAttachments.SelectedItem.ToString Like "*gif" _
        Or cboAttachments.SelectedItem.ToString Like "*bmp" Then
            Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
            Dim selMail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveExplorer().Selection(1)
            Dim attachments As Outlook.Attachments = selMail.Attachments
            If selMail.Attachments.Count > 0 Then
                Dim attachment As Outlook.Attachment
                For Each attachment In attachments
                    If attachment.FileName = cboAttachments.SelectedItem.ToString Then
                        If Not File.Exists(dlLocation & attachment.FileName) Then attachment.SaveAsFile(dlLocation & attachment.FileName)
                        PictureBox1.ImageLocation = dlLocation & attachment.FileName
                        PicBuffer = New System.IO.FileInfo(dlLocation & attachment.FileName)
                        PicFileStream = PicBuffer.OpenRead
                        RecoverSteggedText(PicFileStream, PicBuffer)
                    End If
                Next
            End If
        End If
    End Sub
End Class
