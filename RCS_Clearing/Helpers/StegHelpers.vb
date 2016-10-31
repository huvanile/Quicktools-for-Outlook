Public Class StegHelpers

    Public Shared Sub BecomeSteggedImage(picFileStream As System.IO.FileStream, picBuffer As System.IO.FileInfo, theMailItem As Outlook.MailItem)
        Dim PicBytes As Long = picFileStream.Length
        Dim PicExt As String = picBuffer.Extension
        Dim tmpFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\"
        Dim PicByteArray(PicBytes) As Byte
        picFileStream.Read(PicByteArray, 0, PicBytes)
        Dim SentinelString() As Byte = {73, 116, 83, 116, 97, 114, 116, 115, 72, 101, 114, 101}

        Dim PlainTextByteArray(theMailItem.Body.Length) As Byte
        For i As Integer = 0 To (theMailItem.Body.Length - 1)
            PlainTextByteArray(i) = CByte(AscW(theMailItem.Body.Chars(i)))
            Diagnostics.Debug.Print(i & " of " & (theMailItem.Body.Length - 1))
            'Application.DoEvents()
        Next
        Dim PicAndText(PicBytes + theMailItem.Body.Length + SentinelString.Length) As Byte
        For t As Long = 0 To (PicBytes - 1)
            PicAndText(t) = PicByteArray(t)
        Next
        Dim count As Integer = 0
        For r As Long = PicBytes To (PicBytes + (SentinelString.Length) - 1)
            PicAndText(r) = SentinelString(count)
            count += 1
        Next
        count = 0
        For q As Long = (PicBytes + SentinelString.Length) To (PicBytes + SentinelString.Length + theMailItem.Body.Length - 1)
            PicAndText(q) = PlainTextByteArray(count)
            count += 1
        Next
        My.Computer.FileSystem.WriteAllBytes(tmpFolder & picBuffer.Name, PicAndText, False)
        Diagnostics.Debug.Print(tmpFolder & picBuffer.Name)
        EmailHelpers.SwapAndSteg(theMailItem, tmpFolder & picBuffer.Name)
    End Sub

    Public Shared Sub RecoverSteggedText(picFileStream As System.IO.FileStream, picBuffer As System.IO.FileInfo)
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
                    'updateTxtRecoveredTextSafe(txtRecoveredText.Text & ChrW(CInt(PicByteArray(leftCounter))))
                    leftCounter += 1
                Loop
            Else
                'updateTxtRecoveredTextSafe("The Picture does not contain any text")
            End If
        Catch ex As Exception
            'updateTxtRecoveredTextSafe("The picture does not contain any text and/or the tool was not able to read it")
        End Try
    End Sub
End Class
