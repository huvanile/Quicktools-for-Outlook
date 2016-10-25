
Imports Microsoft.Office.Tools.Ribbon
Imports Quicktools.EmailHelpers

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
        Dim sBuilder As New StringBuilder
        sBuilder.Append("<p>Hi,</p>").AppendLine()
        sBuilder.Append("<p>I thought you'd be interested in using an Outlook add-in called the ""QuickTools for Outlook"" that I find useful. I use it to save time in Outlook.</p>").AppendLine()
        sBuilder.Append("<p>To install it, simply run <a href='\\dal-fs-001\bas$\eTools\rcsOutlook\current\setup.exe'>this installer</a> while on the GT network (i.e., on VPN or at the office). Note that the installer takes a moment to appear after you double-click on it.</p>").AppendLine()
        sBuilder.Append("<p>Regards,</p>").AppendLine()
        BuildEmail("Check out this Outlook Add-in", sBuilder)
        sBuilder = Nothing
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As RibbonControlEventArgs) Handles btnFeedback.Click
        Dim sBuilder As New StringBuilder
        sBuilder.Append("<p>Hi,</p>").AppendLine()
        sBuilder.Append("<p>I have some feedback on the QuickTools ribbon for Outlook.</p>").AppendLine()
        sBuilder.AppendLine()
        sBuilder.Append("<p>Regards,</p>").AppendLine()
        BuildEmail("Feedback on Outlook QuickTools Add-in", sBuilder, "etoolsQuestions@us.gt.com")
        sBuilder = Nothing
    End Sub
End Class