﻿Imports Microsoft.Office.Tools.Ribbon
Imports Microsoft.Office.Interop.Outlook
Imports Quicktools.EmailHelpers
Imports Quicktools.ExcelHelpers
Imports Quicktools.RegistryHelpers
Imports Quicktools.browserHelpers
Imports System.Threading
Imports System.IO

Public Class Ribbon1
    Dim ribbon As Microsoft.Office.Core.IRibbonUI
    Public Shared taskpaneRCSStart As tpnRCSStart : Public Shared ctpRCSStart As Microsoft.Office.Tools.CustomTaskPane

    'click handler
    Private Sub btnRCSCheck_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRCSCheck.Click
        taskpaneRCSStart = New tpnRCSStart
        ctpRCSStart = Globals.ThisAddIn.CustomTaskPanes.Add(taskpaneRCSStart, "QuickTools")
        ctpRCSStart.Width = 300
        ctpRCSStart.Control.Width = 300
        ctpRCSStart.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        ctpRCSStart.Visible = True
    End Sub

    Private Sub btnShare_Click(sender As Object, e As RibbonControlEventArgs) Handles btnShare.Click
        Dim sBuilder As New StringBuilder
        sBuilder.Append("<p>Hi,</p>").AppendLine()
        sBuilder.Append("<p>I thought you'd be interested in using an Outlook add-in called the ""QuickTools for Outlook"" that I find useful. I use it to save time in Outlook.</p>").AppendLine()
        sBuilder.Append("<p>To install it, simply run <a href='\\dal-fs-001\bas$\eTools\rcsOutlook\current\setup.exe'>this installer</a> while on the GT network (i.e., on VPN or at the office). Be sure to hit ""Open"" and not ""Save"" at the prompt. Note that the installer takes a moment to appear after you double-click on it.</p>").AppendLine()
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

    Private Sub btnOpenRandomEmail_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOpenRandomEmail.Click
        Dim appExcel As Microsoft.Office.Interop.Excel.Application : appExcel = GetExcel()
        Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
        Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
        oFldr.Items(appExcel.Application.WorksheetFunction.RandBetween(1, oFldr.Items.Count)).Display
        oFldr = Nothing
        oNs = Nothing
        appExcel = Nothing
    End Sub

    Private Sub btnOpenCalReplies_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOpenCalReplies.Click
        Dim theCount As Short : theCount = 0
        Dim proceed As Boolean = True
        Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
        Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
        Dim oMessage As Object

        'first get the count
        For Each oMessage In oFldr.Items
            If oMessage.MessageClass = "IPM.Schedule.Meeting.Canceled" _
            Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Neg" _
            Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Pos" _
            Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Tent" Then
                theCount += 1
            End If
        Next oMessage

        'then do the opening
        If theCount >= 15 Then
            If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                proceed = False
            End If
        End If
        If proceed And theCount > 0 Then
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Schedule.Meeting.Canceled" _
                Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Neg" _
                Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Pos" _
                Or oMessage.MessageClass = "IPM.Schedule.Meeting.Resp.Tent" Then
                    oMessage.Display
                End If
            Next oMessage
        End If
        oMessage = Nothing
        oFldr = Nothing
        oNs = Nothing
        If theCount = 0 Then MsgBox("No calendar responses found in the inbox", vbInformation, ThisAddIn.Title)
    End Sub

    Private Sub btnOpenVoicemails_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOpenVoicemails.Click
        Dim theCount As Short : theCount = 0
        Dim proceed As Boolean = True
        Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
        Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
        Dim oMessage As Object

        'first get the count
        For Each oMessage In oFldr.Items
            If oMessage.MessageClass = "IPM.Note.Microsoft.Voicemail.UM.CA" Then
                theCount += 1
            End If
        Next oMessage

        'then do the opening
        If theCount >= 15 Then
            If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                proceed = False
            End If
        End If
        If proceed And theCount > 0 Then
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Note.Microsoft.Voicemail.UM.CA" Then
                    oMessage.Display
                End If
            Next oMessage
        End If

        oMessage = Nothing
        oFldr = Nothing
        oNs = Nothing
        If theCount = 0 Then MsgBox("No voicemails items found in the inbox", vbInformation, ThisAddIn.Title)
    End Sub

    Private Sub btnOpenCalInvites_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOpenCalInvites.Click
        Dim theCount As Short : theCount = 0
        Dim proceed As Boolean = True
        Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
        Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
        Dim oMessage As Object

        'first get the count
        For Each oMessage In oFldr.Items
            If oMessage.MessageClass = "IPM.Schedule.Meeting.Request" Then
                theCount += 1
            End If
        Next oMessage

        'then do the opening
        If theCount >= 15 Then
            If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                proceed = False
            End If
        End If
        If proceed And theCount > 0 Then
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Schedule.Meeting.Request" Then
                    oMessage.Display
                End If
            Next oMessage
        End If

        oMessage = Nothing
        oFldr = Nothing
        oNs = Nothing
        If theCount = 0 Then MsgBox("No calendar items found in the inbox", vbInformation, ThisAddIn.Title)
    End Sub

    Private Sub btnInboxToExcel_Click(sender As Object, e As RibbonControlEventArgs) Handles btnInboxToExcel.Click
        If MsgBox("Would you like to list out the contents of your inbox in Excel?", vbYesNoCancel, ThisAddIn.title) = vbYes Then
            Dim listInboxInExcel As New ListInboxInExcel
            listInboxInExcel.BuildExcelList()
            listInboxInExcel = Nothing
        End If
    End Sub

    Private Sub xboxVIP1_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles xboxVIP1.TextChanged
        ThisAddIn.Vip1 = xboxVIP1.Text
        SaveSetting("Preferences", "vip1", xboxVIP1.Text)
    End Sub

    Private Sub xboxVIP2_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles xboxVIP2.TextChanged
        ThisAddIn.Vip2 = xboxVIP2.Text
        SaveSetting("Preferences", "vip2", xboxVIP2.Text)
    End Sub

    Private Sub xboxVIP3_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles xboxVIP3.TextChanged
        ThisAddIn.Vip3 = xboxVIP3.Text
        SaveSetting("Preferences", "vip3", xboxVIP3.Text)
    End Sub

    Private Sub Ribbon1_Load(sender As Object, e As RibbonUIEventArgs) Handles MyBase.Load
        'set prefs
        xboxVIP1.Text = GetSetting("Preferences", "vip1")
        ThisAddIn.Vip1 = GetSetting("Preferences", "vip1")
        xboxVIP2.Text = GetSetting("Preferences", "vip2")
        ThisAddIn.Vip2 = GetSetting("Preferences", "vip2")
        xboxVIP3.Text = GetSetting("Preferences", "vip3")
        ThisAddIn.Vip3 = GetSetting("Preferences", "vip3")

        'folder and file work
        Dim dlLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\OutlookQuickTools\"
        If Not Directory.Exists(dlLocation) Then MkDir(dlLocation)
        Dim files() As String
        files = Directory.GetFileSystemEntries(dlLocation)
        For Each element As String In files
            If (Not Directory.Exists(element)) Then
                File.Delete(Path.Combine(dlLocation, Path.GetFileName(element)))
            End If
        Next
    End Sub

    Private Sub btnVIP3_Click(sender As Object, e As RibbonControlEventArgs) Handles btnVIP3.Click
        If Not String.IsNullOrEmpty(ThisAddIn.Vip3) Then
            Dim theCount As Short : theCount = 0
            Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
            Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
            Dim oMessage As Object
            Dim proceed As Boolean : proceed = True

            'first get the count
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.sendername) Like "*" & LCase(ThisAddIn.Vip3) & "*" Then
                    theCount += 1
                End If
            Next oMessage

            'then do the opening
            If theCount >= 15 Then
                If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                    proceed = False
                End If
            End If
            If proceed And theCount > 0 Then
                For Each oMessage In oFldr.Items
                    If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.sendername) Like "*" & LCase(ThisAddIn.Vip3) & "*" Then
                        oMessage.Display()
                    End If
                Next oMessage
            End If

            oMessage = Nothing
            oFldr = Nothing
            oNs = Nothing
            If Not theCount > 0 Then MsgBox("No emails matching this search criteria were found in the inbox.", vbInformation, ThisAddIn.Title)
        Else
            MsgBox("Please populate the field in the ribbon adjacent to the button you just pressed and try again.", vbInformation, ThisAddIn.Title)
        End If
    End Sub

    Private Sub btnVIP2_Click(sender As Object, e As RibbonControlEventArgs) Handles btnVIP2.Click
        If Not String.IsNullOrEmpty(ThisAddIn.Vip2) Then
            Dim theCount As Short : theCount = 0
            Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
            Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
            Dim oMessage As Object
            Dim proceed As Boolean : proceed = True

            'first get the count
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.Subject) Like "*" & LCase(ThisAddIn.Vip2) & "*" Then
                    theCount += 1
                End If
            Next oMessage

            'then do the opening
            If theCount >= 15 Then
                If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                    proceed = False
                End If
            End If
            If proceed And theCount > 0 Then
                For Each oMessage In oFldr.Items
                    If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.Subject) Like "*" & LCase(ThisAddIn.Vip2) & "*" Then
                        oMessage.Display()
                    End If
                Next oMessage
            End If

            oMessage = Nothing
            oFldr = Nothing
            oNs = Nothing
            If Not theCount > 0 Then MsgBox("No emails matching this search criteria were found in the inbox.", vbInformation, ThisAddIn.Title)
        Else
            MsgBox("Please populate the field in the ribbon adjacent to the button you just pressed and try again.", vbInformation, ThisAddIn.Title)
        End If
    End Sub

    ''' <summary>
    ''' This opens all inbox items with specific text in the email body
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnVIP1_Click(sender As Object, e As RibbonControlEventArgs) Handles btnVIP1.Click
        If Not String.IsNullOrEmpty(ThisAddIn.Vip1) Then
            Dim theCount As Short : theCount = 0
            Dim oNs As Outlook.NameSpace : oNs = ThisAddIn.appOutlook.GetNamespace("MAPI")
            Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
            Dim oMessage As Object
            Dim proceed As Boolean : proceed = True

            'first get the count
            For Each oMessage In oFldr.Items
                If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.Body) Like "*" & LCase(ThisAddIn.Vip1) & "*" Then
                    theCount += 1
                End If
            Next oMessage

            'then do the opening
            If theCount >= 15 Then
                If MsgBox("At least 15 inbox emails are about to be opened, are you sure you'd like to proceed?", vbYesNoCancel) <> vbYes Then
                    proceed = False
                End If
            End If
            If proceed And theCount > 0 Then
                For Each oMessage In oFldr.Items
                    If oMessage.MessageClass = "IPM.Note" And LCase(oMessage.Body) Like "*" & LCase(ThisAddIn.Vip1) & "*" Then
                        oMessage.Display()
                    End If
                Next oMessage
            End If

            oMessage = Nothing
            oFldr = Nothing
            oNs = Nothing
            If Not theCount > 0 Then MsgBox("No emails matching this search criteria were found in the inbox.", vbInformation, ThisAddIn.Title)
        Else
            MsgBox("Please populate the field in the ribbon adjacent to the button you just pressed and try again.", vbInformation, ThisAddIn.Title)
        End If
    End Sub

    Private Sub btnCoffee_Click(sender As Object, e As RibbonControlEventArgs) Handles btnCoffee.Click

        'instantiate IE
        appIE = GetIE()
        appIE.Visible = True

        'load site
        appIE.navigate("https://ko-fi.com/etools")

    End Sub
End Class