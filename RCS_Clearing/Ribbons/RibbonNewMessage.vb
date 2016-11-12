Imports Microsoft.Office.Tools.Ribbon
Imports System.IO

Public Class RibbonNewMessage
    Public Shared taskpaneStegSteg As tpnStegSteg : Public Shared ctpStegSteg As Microsoft.Office.Tools.CustomTaskPane
    Public Shared taskpaneEncTools As tpnEncryptionTools : Public Shared ctpEncSteg As Microsoft.Office.Tools.CustomTaskPane

    Private Sub btnStegEmail_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStegEmail.Click
        Try
            Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
            taskpaneStegSteg = New tpnStegSteg
            ctpStegSteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneStegSteg, "Hide Email in an Image")
            ctpStegSteg.Width = 400
            ctpStegSteg.Control.Width = 400
            ctpStegSteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
            ctpStegSteg.Visible = True
        Catch ex As Exception
            MsgBox("An error occurred :(", vbCritical, ThisAddIn.Title)
        End Try
    End Sub

    Private Sub btnEncryptEmail(sender As Object, e As RibbonControlEventArgs) Handles btnEncryptMessage.Click
        Try
            taskpaneEncTools = New tpnEncryptionTools
            ctpEncSteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneEncTools, "Email Encryption Tools")
            ctpEncSteg.Width = 300
            ctpEncSteg.Control.Width = 300
            ctpEncSteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
            ctpEncSteg.Visible = True
        Catch ex As Exception
            MsgBox("An error occurred :(", vbCritical, ThisAddIn.Title)
        End Try
    End Sub
End Class
