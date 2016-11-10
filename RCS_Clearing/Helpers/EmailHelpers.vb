Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Outlook

Public Class EmailHelpers

    Public Shared Sub SwapAndSteg(mail As Outlook.MailItem, steggedImage As String)
        If Not String.IsNullOrEmpty(mail.HTMLBody) AndAlso mail.HTMLBody.ToLower().Contains("</body>") Then
            mail.Attachments.Add(steggedImage, OlAttachmentType.olEmbeddeditem)
            If mail.Subject = "" Then mail.Subject = "See attached pic"
            mail.Body = "Hey, please check out the attached pic."
            mail.Save()
        End If
    End Sub

    Public Shared Property WIPEmailHTMLBody As String
        Get
            Dim mail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveInspector.CurrentItem
            Return mail.HTMLBody
        End Get
        Set(value As String)

        End Set
    End Property

    Public Shared Property SelectedEmailAttachedImages() As List(Of String)
        Get
            Dim tmp As New List(Of String)
            If ThisAddIn.appOutlook.ActiveExplorer().Selection.Count > 0 Then
                Dim selMail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveExplorer().Selection(1)
                Dim attachments As Outlook.Attachments = selMail.Attachments
                If selMail.Attachments.Count > 0 Then
                    Dim attachment As Outlook.Attachment
                    For Each attachment In attachments
                        If attachment.FileName Like "*jpg" _
                        Or attachment.FileName Like "*bmp" _
                        Or attachment.FileName Like "*gif" Then
                            tmp.Add(attachment.FileName)
                        End If
                    Next
                    If tmp.Count = 0 Then tmp.Add("Selected email has no images attached")
                Else
                        tmp.Add("Selected email has no images attached")
                End If
            Else
                tmp.Add("Selected item is not an email")
            End If
            Return tmp
        End Get
        Set(value As List(Of String))

        End Set
    End Property

    Public Shared Property SelectedEmailHTMLBody As String
        Get
            If ThisAddIn.appOutlook.ActiveExplorer().Selection.Count > 0 Then
                Dim selMail As Outlook.MailItem = ThisAddIn.appOutlook.ActiveExplorer().Selection(1)
                Return selMail.HTMLBody
            Else
                Debug.Print("selection is not a mailitem")
                Return String.Empty
            End If
        End Get
        Set(value As String)

        End Set
    End Property

    Public Shared Function justCurrentEmail(ByVal str As String) As String
        Dim endOfMsg
        endOfMsg = InStr(str, "From:")
        If endOfMsg = 0 Then
            justCurrentEmail = str
        Else
            justCurrentEmail = Left(str, endOfMsg)
        End If
    End Function

    ''' <summary>
    ''' Builds, but does not send, an email in outlook
    ''' </summary>
    ''' <param name="subject">Email subject</param>
    ''' <param name="body">Email body</param>
    Public Shared Sub BuildEmail(ByVal subject As String, body As StringBuilder, Optional recipient As String = "")
        Dim mail As Outlook.MailItem = Nothing
        Try
            mail = ThisAddIn.appOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            mail.Subject = "Check out this Outlook Add-in"
            body.AppendLine(GetHTMLSignature)
            mail.HTMLBody = body.ToString
            mail.To = recipient
            mail.Save()
            mail.Display(True)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the user's HTML signature from Outlook
    ''' </summary>
    ''' <returns>the user's HTML signature from Outlook</returns>
    Public Shared Function GetHTMLSignature() As String
        Dim s As String
        s = Environ("appdata") & "\Microsoft\Signatures\"
        If Dir(s, vbDirectory) <> vbNullString Then s = s & Dir$(s & "*.htm") Else s = ""
        s = CreateObject("Scripting.FileSystemObject").GetFile(s).OpenAsTextStream(1, -2).ReadAll
        Return s
    End Function

    ''' <summary>
    ''' Gets the current instance of Outlook if it can, otherwise gets a new one
    ''' </summary>
    ''' <returns>An object for the Outlook application</returns>
    Public Shared Function GetOutlook() As Outlook.Application
        Dim application As Outlook.Application

        ' Check whether there is an Outlook process running.
        If Process.GetProcessesByName("OUTLOOK").Count() > 0 Then

            ' If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
            Try
                application = DirectCast(Marshal.GetActiveObject("Outlook.Application"), Outlook.Application)
            Catch ex As system.Exception
                ' If fails, create a new instance of Outlook and log on to the default profile.
                application = New Outlook.Application()
                Dim ns As Outlook.NameSpace = application.GetNamespace("MAPI")
                ns.Logon("", "", Missing.Value, Missing.Value)
                ns = Nothing
            End Try
        Else

            ' If not, create a new instance of Outlook and log on to the default profile.
            application = New Outlook.Application()
            Dim ns As Outlook.NameSpace = application.GetNamespace("MAPI")
            ns.Logon("", "", Missing.Value, Missing.Value)
            ns = Nothing
        End If

        ' Return the Outlook Application object.
        Return application
    End Function
End Class
