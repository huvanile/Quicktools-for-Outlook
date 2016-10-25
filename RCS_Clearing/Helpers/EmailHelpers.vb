Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class EmailHelpers

    ''' <summary>
    ''' Builds, but does not send, an email in outlook
    ''' </summary>
    ''' <param name="subject">Email subject</param>
    ''' <param name="body">Email body</param>
    Public Shared Sub BuildEmail(ByVal subject As String, body As StringBuilder, Optional recipient As String = "")
        Dim appOutlook As Outlook.Application : appOutlook = GetOutlook()
        Dim mail As Outlook.MailItem = Nothing
        Try
            mail = appOutlook.CreateItem(Outlook.OlItemType.olMailItem)
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
            Catch ex As Exception
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
