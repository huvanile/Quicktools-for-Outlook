Imports Microsoft.Office.Tools.Ribbon
Imports Microsoft.Office.Interop.Outlook
Imports Quicktools.EmailHelpers
Imports Quicktools.ExcelHelpers

Public Class ListInboxInExcel
    Dim oExcel As Microsoft.Office.Interop.Excel.Application

    Public Sub BuildExcelList()
        Const lastCol As String = "l"
        oExcel = GetExcel()
        Dim oOutlook As Outlook.Application : oOutlook = GetOutlook()
        Dim oNs As Outlook.NameSpace : oNs = oOutlook.GetNamespace("MAPI")
        Dim oFldr As Outlook.MAPIFolder : oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox)
        Dim oMessage As Object
        Dim r As Integer : r = 2
        Dim subjects As String : subjects = ""
        oExcel.Workbooks.Add()
        Dim age As Integer : age = 0

        'write column titles
        With oExcel.ActiveWorkbook.ActiveSheet
            .Name = "LEGEND and TIPS"

            .Columns("A").ColumnWidth = 2
            .Columns("b").ColumnWidth = 15
            .Columns("c").ColumnWidth = 30
            .Range("b2") = "Flag"
            .Range("c2") = "Meaning"
            .Range("b2:c2").Interior.ColorIndex = 1
            .Range("b2:c2").Font.ColorIndex = 2
            .Range("b3") = "Peach fill"
            .Range("b3:c3").Interior.Color = 10086143
            .Range("c3") = "Discussing a meet"
            .Range("b4").Value = "Bold font"
            .Range("b4:c4").Font.Bold = True
            .Range("c4") = "Important / urgent"
            .Range("b5") = "Red font"
            .Range("c5") = "From a VIP"
            .Range("B5:c5").Font.ColorIndex = 3

            .Columns("d").ColumnWidth = 2
            .Columns("e").ColumnWidth = 40
            .Range("e2") = "Filtering ideas"
            .Range("e2").Interior.ColorIndex = 1
            .Range("e2").Font.ColorIndex = 2
            .Range("e3") = "Message type <> 'IPM.Note'"
            .Range("e4") = "Not part of a conversation + I'm just CC'd"
            .Range("e5") = "Peach shading"
            .Range("e5").Interior.Color = 10086143
            .Range("E6") = "Red font"
            .Range("E6").Font.ColorIndex = 3
            .Range("E7") = "Is short email + I'm just CC'd"
            .Range("e8") = "Is short email"
            .Range("E9") = "I'm just CC'd"
            .Range("e10") = "Is unread"
            .Range("e11") = "Part of a conversation + I'm just CC'd"
            .Range("e12") = "To just me + Is short email"
            .Range("E13") = "Not to just me + Is short email + Not just CC'd"
            .Range("e14") = "Is not over 2 weeks old"

            .Columns("f").ColumnWidth = 2
            .Columns("g").ColumnWidth = 40
            .Range("g2") = "Sorting ideas"
            .Range("g2").Interior.ColorIndex = 1
            .Range("g2").Font.ColorIndex = 2
            .Range("g3") = "Most attachments to least"
            .Range("g4") = "Youngest to oldest"

        End With


        'write color legend sheet
        oExcel.Worksheets.Add()

        'write column titles
        With oExcel.ActiveWorkbook.ActiveSheet
            .Name = "INBOX"
            .Range("a1").Value = "Received"
            .Range("b1").Value = "Message Type"
            .Range("c1").Value = "Subject"
            .Range("d1").Value = "Sender Name"
            .Range("e1").Value = "To"
            .Range("f1").Value = "To just me?"
            .Range("g1").Value = "Am I just CC'd?"
            .Range("h1").Value = "Unread"
            .Range("i1").Value = "Attachments"
            .Range("j1").Value = "Part of a Conversation?"
            .Range("k1").Value = "Short email?"
            .Range("l1").Value = "Category"
            .Range("m1").Value = "Age"
            .Range("n1").Value = ">2 Weeks Old"
        End With

        'write to excel
        For Each oMessage In oFldr.Items
            With oMessage
                If Not .MessageClass Like "*Recall*" Then

                    'content
                    writeToExcel("a" & r, .ReceivedTime, oExcel)
                    writeToExcel("b" & r, .MessageClass, oExcel)
                    writeToExcel("c" & r, .Subject, oExcel)
                    writeToExcel("d" & r, .SenderName, oExcel)
                    Select Case .MessageClass
                        Case "IPM.Schedule.Meeting.Request", "IPM.Schedule.Meeting.Resp.Neg"
                            writeToExcel("e" & r, "'-", oExcel)
                            writeToExcel("f" & r, "'-", oExcel)
                            writeToExcel("g" & r, "'-", oExcel)
                        Case Else
                            writeToExcel("e" & r, .To, oExcel)
                            If .To = oOutlook.Application.Session.CurrentUser.Name Then
                                writeToExcel("f" & r, "Yes", oExcel)
                            Else
                                writeToExcel("f" & r, "'-", oExcel)
                            End If

                            If .CC Like "*" & oOutlook.Application.Session.CurrentUser.Name & "*" And Not .To Like "*" & oOutlook.Application.Session.CurrentUser.Name & "*" Then
                                writeToExcel("g" & r, "Yes", oExcel)
                            Else
                                writeToExcel("g" & r, "'-", oExcel)
                            End If
                    End Select
                    writeToExcel("h" & r, .UnRead, oExcel)
                    writeToExcel("i" & r, .Attachments.Count, oExcel)

                    'flags
                    If justCurrentEmail(LCase(.Body)) Like "*meet*" _
                    Or justCurrentEmail(LCase(.Body)) Like "*appointment*" _
                    Or justCurrentEmail(LCase(.Body)) Like "*lunch*" _
                    Or justCurrentEmail(LCase(.Body)) Like "*breakfast*" _
                    Or justCurrentEmail(LCase(.Body)) Like "*invite*" Then
                        oExcel.ActiveWorkbook.ActiveSheet.Range("a" & r & ":" & lastCol & r).Interior.Color = 10086143
                    End If

                    'from a VIP
                    If LCase(oMessage.SenderName) Like "*" & ThisAddIn.Vip1 & "*" _
                    Or LCase(oMessage.SenderName) Like "*" & ThisAddIn.Vip2 & "*" _
                    Or LCase(oMessage.SenderName) Like "*" & ThisAddIn.Vip3 & "*" Then
                        oExcel.ActiveWorkbook.ActiveSheet.Range("a" & r & ":" & lastCol & r).Font.ColorIndex = 3
                    End If

                    'important
                    If LCase(.Subject) Like "*urgent*" _
                    Or LCase(.Subject) Like "*important*" _
                    Or LCase(.Subject) Like "*immediate*" Then
                        oExcel.ActiveWorkbook.ActiveSheet.Range("a" & r & ":" & lastCol & r).Font.Bold = True
                    End If

                    'conversation
                    If LCase(.Subject) Like "re:*" Or LCase(.Subject) Like "fw:*" Then
                        writeToExcel("j" & r, "Yes", oExcel)
                    Else
                        writeToExcel("j" & r, "'-", oExcel)
                    End If

                    'short email
                    If Len(justCurrentEmail(.Body)) < 600 Then
                        writeToExcel("k" & r, "Yes", oExcel)
                    Else
                        writeToExcel("k" & r, "'-", oExcel)
                    End If

                    'category
                    writeToExcel("l" & r, .Categories, oExcel)

                    'age
                    age = DateDiff("d", .ReceivedTime, Now())
                    writeToExcel("m" & r, CStr(age), oExcel)
                    If age > 14 Then writeToExcel("n" & r, "Yes", oExcel) Else writeToExcel("n" & r, "'-", oExcel)

                End If
            End With
            r = r + 1
        Next oMessage

        'excel formatting
        oExcel.Application.Visible = True
        oExcel.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
        With oExcel.ActiveWorkbook.ActiveSheet
            .Cells.Select
            .Cells.EntireColumn.AutoFit
            .Rows("1:1").AutoFilter
            .Rows("1:1").Font.Bold = True
            .Rows("2:2").Select
            .Columns("e").ColumnWidth = 15
            oExcel.ActiveWindow.FreezePanes = True
            .Range("a1").Select
        End With

        oExcel.Sheets("Inbox").Activate

        'clear memory
        oMessage = Nothing
        oFldr = Nothing
        oNs = Nothing
        oOutlook = Nothing
        oExcel = Nothing

    End Sub


End Class
