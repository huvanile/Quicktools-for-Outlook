Imports System.Diagnostics

Public Class tpnEncryptionTools
    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click

        'Get the current email text to encrypt
        Dim mail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveInspector.CurrentItem

        'Encryption Object
        Dim encryptionHelpers As EncryptionHelpers = New EncryptionHelpers
        Dim encryptedMessage As String = ""
        Dim messageBody As String = removeEndLinebreak(mail.Body.Trim)

        'Perform the encryption
        If (rbSingleLine.Checked) Then
            'Perform the encryption with single cipher
            encryptedMessage = encryptionHelpers.StringToHex(encryptionHelpers.CryptRC4(messageBody, txtCipherText.Text))
        ElseIf (rbMultiline.Checked) Then
            encryptedMessage = messageBody
            'Perform the encryption with multi line cipher
            For Each line As String In txtMultilineCipher.Text.Split(vbLf)
                encryptedMessage = encryptionHelpers.StringToHex(encryptionHelpers.CryptRC4(encryptedMessage, line.Replace(vbCr, "").Replace(vbLf, "")))
            Next
        End If

        'Debug.WriteLine(encryptedMessage)

        'change the message body
        mail.Body = encryptedMessage

    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        'Get the current email text to encrypt
        Dim mail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveInspector.CurrentItem

        'Encryption Object
        Dim encryptionHelpers As EncryptionHelpers = New EncryptionHelpers
        Dim decryptedMessage As String = ""
        Dim messageBody As String = removeEndLinebreak(mail.Body.Trim)

        'Perform the decryption
        If (rbSingleLine.Checked) Then
            'Perform the decryption with single cipher
            decryptedMessage = encryptionHelpers.CryptRC4(encryptionHelpers.HexToString(messageBody), txtCipherText.Text)
        ElseIf (rbMultiline.Checked) Then
            decryptedMessage = messageBody
            Dim cipherText As String

            'Perform the decryption with multi line cipher 
            For Each line As String In txtMultilineCipher.Text.Split(vbLf).Reverse  'we move through the cipher in reverse
                cipherText = line.Trim.Replace(vbCr, "").Replace(vbLf, "")
                decryptedMessage = encryptionHelpers.CryptRC4(encryptionHelpers.HexToString(decryptedMessage), cipherText)
            Next
        End If

        'Debug.WriteLine(decryptedMessage)

        'change the message body
        mail.Body = decryptedMessage
    End Sub

    Private Sub rbSingleLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbSingleLine.CheckedChanged
        lblCipherText.Enabled = True
        txtCipherText.Enabled = True

        lblMultilineCipher.Enabled = False
        txtMultilineCipher.Enabled = False
    End Sub

    Private Sub rbMultiline_CheckedChanged(sender As Object, e As EventArgs) Handles rbMultiline.CheckedChanged
        lblMultilineCipher.Enabled = True
        txtMultilineCipher.Enabled = True

        lblCipherText.Enabled = False
        txtCipherText.Enabled = False
    End Sub

    Private Sub tpnEncryptionTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbSingleLine.Checked = True
        lblCipherText.Enabled = True
        txtCipherText.Enabled = True

        'Multiline is disabled at first
        rbMultiline.Checked = False
        lblMultilineCipher.Enabled = False
        txtMultilineCipher.Enabled = False


    End Sub

    Private Function removeEndLinebreak(myString As String) As String
        If Len(myString) <> 0 Then
            If myString.EndsWith(vbCrLf) Or myString.EndsWith(vbNewLine) Then
                myString = myString.Substring(0, Len(myString) - 2)
            End If
        End If
        Return myString
    End Function
End Class
