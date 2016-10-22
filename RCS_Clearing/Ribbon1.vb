Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1

    Public Shared taskpaneRCSStart As tpnRCSStart
    Public Shared ctpRCSStart As Microsoft.Office.Tools.CustomTaskPane

    'click handler
    Private Sub btnRCSCheck_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRCSCheck.Click
        taskpaneRCSStart = New tpnRCSStart
        ctpRCSStart = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneRCSStart, "RCS Clearing")
        ctpRCSStart.Width = 250
        ctpRCSStart.Control.Width = 250
        ctpRCSStart.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpRCSStart.Visible = True
    End Sub

End Class