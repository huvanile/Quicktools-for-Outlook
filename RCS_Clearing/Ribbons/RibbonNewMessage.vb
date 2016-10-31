Imports Microsoft.Office.Tools.Ribbon

Public Class RibbonNewMessage
    Public Shared taskpaneStegSteg As tpnStegSteg : Public Shared ctpStegSteg As Microsoft.Office.Tools.CustomTaskPane

    Private Sub RibbonNewMessage_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStegEmail_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStegEmail.Click
        taskpaneStegSteg = New tpnStegSteg
        ctpStegSteg = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneStegSteg, "Hide Email in an Image")
        ctpStegSteg.Width = 400
        ctpStegSteg.Control.Width = 400
        ctpStegSteg.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpStegSteg.Visible = True
    End Sub

End Class
