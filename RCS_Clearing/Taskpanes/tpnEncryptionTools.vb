Imports System.Diagnostics

Public Class tpnEncryptionTools

    'Get the current email text to encrypt
    Dim mail As Outlook.MailItem
    Dim encryptionHelpers As EncryptionHelpers
    Dim messageBody As String

    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click

        'Encryption Object
        Dim encryptedMessage As String = ""
        messageBody = removeEndLinebreak(mail.Body.Trim)

        'Perform the encryption
        If (rbSingleLine.Checked) Then
            'Perform the encryption with single cipher
            encryptedMessage = EncryptionHelpers.StringToHex(encryptionHelpers.CryptRC4(messageBody, txtCipherText.Text))
        ElseIf (rbMultiline.Checked) Then
            encryptedMessage = messageBody
            'Perform the encryption with multi line cipher
            For Each line As String In txtMultilineCipher.Text.Split(vbLf)
                encryptedMessage = EncryptionHelpers.StringToHex(encryptionHelpers.CryptRC4(encryptedMessage, line.Replace(vbCr, "").Replace(vbLf, "")))
            Next
        End If

        'change the message body
        mail.Body = encryptedMessage

    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        messageBody = removeEndLinebreak(mail.Body.Trim)
        decryptBody()
    End Sub

    Private Sub decryptBody()

        'Encryption Object
        Dim decryptedMessage As String = ""

        'Perform the decryption
        If (rbSingleLine.Checked) Then
            'Perform the decryption with single cipher
            decryptedMessage = encryptionHelpers.CryptRC4(EncryptionHelpers.HexToString(messageBody), txtCipherText.Text)
        ElseIf (rbMultiline.Checked) Then
            decryptedMessage = messageBody
            Dim cipherText As String

            'Perform the decryption with multi line cipher 
            For Each line As String In txtMultilineCipher.Text.Split(vbLf).Reverse  'we move through the cipher in reverse
                If line.Length > 0 Then
                    cipherText = line.Trim.Replace(vbCr, "").Replace(vbLf, "")
                    decryptedMessage = encryptionHelpers.CryptRC4(EncryptionHelpers.HexToString(decryptedMessage), cipherText)
                End If
            Next
        End If

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

        'populate variables
        mail = ThisAddIn.appOutlook.ActiveInspector.CurrentItem
        encryptionHelpers = New EncryptionHelpers
        messageBody = removeEndLinebreak(mail.Body.Trim)
    End Sub

    Private Function removeEndLinebreak(myString As String) As String
        If Len(myString) <> 0 Then
            If myString.EndsWith(vbCrLf) Or myString.EndsWith(vbNewLine) Then
                myString = myString.Substring(0, Len(myString) - 2)
            End If
        End If
        Return myString
    End Function

    Private Sub txtCipherText_TextChanged(sender As Object, e As EventArgs) Handles txtCipherText.TextChanged
        If mail.Sent Then
            If txtCipherText.Text.Length > 0 And messageBody.Length > 0 Then decryptBody()
        End If
    End Sub

End Class
