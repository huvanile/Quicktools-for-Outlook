Imports Microsoft.Office.Tools.Ribbon
Imports System.IO

Public Class RibbonReceivedMail
    Public Shared taskpaneStegUnsteg As tpnStegUnsteg : Public Shared ctpStegUnsteg As Microsoft.Office.Tools.CustomTaskPane

    Private Sub btnRecoverSteg_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRecoverSteg.Click
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
        taskpaneStegUnsteg = New tpnStegUnsteg
        ctpStegUnsteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneStegUnsteg, "QuickTools")
        ctpStegUnsteg.Width = 400
        ctpStegUnsteg.Control.Width = 400
        ctpStegUnsteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpStegUnsteg.Visible = True
    End Sub

End Class
