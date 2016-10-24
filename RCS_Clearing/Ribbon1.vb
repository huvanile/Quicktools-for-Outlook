Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1

    Public Shared taskpaneRCSStart As tpnRCSStart
    Public Shared ctpRCSStart As Microsoft.Office.Tools.CustomTaskPane

    'click handler
    Private Sub btnRCSCheck_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRCSCheck.Click
        taskpaneRCSStart = New tpnRCSStart
        ctpRCSStart = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneRCSStart, "QuickTools")
        ctpRCSStart.Width = 250
        ctpRCSStart.Control.Width = 250
        ctpRCSStart.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpRCSStart.Visible = True
    End Sub

    Private Sub btnShare_Click(sender As Object, e As RibbonControlEventArgs) Handles btnShare.Click
        Dim AppOutlook As Outlook.Application
        Dim s As String
        AppOutlook = GetApplicationObject()
        Dim mail As Outlook.MailItem = Nothing
        S = Environ("appdata") & "\Microsoft\Signatures\"
        If Dir(S, vbDirectory) <> vbNullString Then S = S & Dir$(S & "*.htm") Else S = ""
        S = CreateObject("Scripting.FileSystemObject").GetFile(S).OpenAsTextStream(1, -2).ReadAll
        Try
            mail = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            mail.Subject = "Check out this Outlook Add-in"
            mail.HTMLBody = "<p>Hi,</p>"
            mail.HTMLBody = mail.HTMLBody & "<p>I thought you'd be interested in using an Outlook add-in called the ""QuickTools for Outlook"" that I find useful. I use it to save time in Outlook.</p>"
            mail.HTMLBody = mail.HTMLBody & "<p>To install it, simply run <a href='\\dal-fs-001\bas$\eTools\rcsOutlook\current\setup.exe'>this installer</a> while on the GT network (i.e., on VPN or at the office). Note that the installer takes a moment to appear after you double-click on it.</p>"
            mail.HTMLBody = mail.HTMLBody & "<p>Regards,</p>"
            mail.HTMLBody = mail.HTMLBody & s
            mail.Save()
            mail.Display(True)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function GetApplicationObject() As Outlook.Application

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