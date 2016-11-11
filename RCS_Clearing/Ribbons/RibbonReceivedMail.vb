Imports Microsoft.Office.Tools.Ribbon
Imports System.IO

Public Class RibbonReceivedMail
    Public Shared taskpaneStegUnsteg As tpnStegUnsteg : Public Shared ctpStegUnsteg As Microsoft.Office.Tools.CustomTaskPane
    Public Shared taskpaneEncTools As tpnEncryptionTools : Public Shared ctpEncSteg As Microsoft.Office.Tools.CustomTaskPane

    Private Sub btnRecoverSteg_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRecoverSteg.Click
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
        taskpaneStegUnsteg = New tpnStegUnsteg
        ctpStegUnsteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneStegUnsteg, "QuickTools")
        ctpStegUnsteg.Width = 400
        ctpStegUnsteg.Control.Width = 400
        ctpStegUnsteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpStegUnsteg.Visible = True
    End Sub

    Private Sub btnDecryptEmail(sender As Object, e As RibbonControlEventArgs) Handles btnDecryptMessage.Click
        taskpaneEncTools = New tpnEncryptionTools
        ctpEncSteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneEncTools, "Email Encryption Tools")
        ctpEncSteg.Width = 300
        ctpEncSteg.Control.Width = 300
        ctpEncSteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpEncSteg.Visible = True
    End Sub
End Class
