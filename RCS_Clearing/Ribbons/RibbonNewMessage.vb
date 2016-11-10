Imports Microsoft.Office.Tools.Ribbon
Imports System.IO

Public Class RibbonNewMessage
    Public Shared taskpaneStegSteg As tpnStegSteg : Public Shared ctpStegSteg As Microsoft.Office.Tools.CustomTaskPane

    Private Sub btnStegEmail_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStegEmail.Click
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
        taskpaneStegSteg = New tpnStegSteg
        ctpStegSteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneStegSteg, "Hide Email in an Image")
        ctpStegSteg.Width = 400
        ctpStegSteg.Control.Width = 400
        ctpStegSteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpStegSteg.Visible = True
    End Sub

End Class
