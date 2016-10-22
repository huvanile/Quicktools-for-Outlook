Imports Quicktools.browserHelpers

Public Class rcs

    'configuration parameters
    Const sURL As String = "https://rcs.gt.com/ResponderDashboardStatusDetail/DisplayResponderDashboardDetailList?pageType=DashboardResponder"
    Const tryCount As Integer = 3       'maximum tries to load a page during the clearing process before giving up

    'class-wide variables
    Dim progressForm As New frmProgressbox
    Dim doneForm As New frmDone
    Dim clearCount As Single = 0        ' running count of all checks cleared
    Dim checkList As String = ""        ' list of all names of checks to clear
    Dim checkCount As Integer = 0       ' total of all checks available to be cleared

    'factory sub which does the guts of this ribbon
    Public Sub clearRCAStuff()

        'variable declaration
        Dim clicked As Boolean = False
        Dim clicked2 As Boolean = False
        Dim attempts As Integer = 0
        Dim attempts2 As Integer = 0
        Dim myLinks As Object = Nothing
        Dim btnInput As Object = Nothing    ' MSHTML.HTMLInputElement
        Dim Link As Object = Nothing        ' MSHTML.HTMLAnchorElement
        Dim ElementCol As Object = Nothing  ' MSHTML.IHTMLElementCollection
        Dim i As Integer = 50                ' counter used for status bar incrementing

        'instantiate IE
        appIE = GetIE()
        appIE.Visible = False
        'appIE.Visible = True

        'load site
        progressForm.ProgressBar1.Increment(10)
        progressForm.lblStatus.Text = "Opening RCS Site in IE"
        progressForm.Show()
        appIE.navigate(sURL)

        'check for checks needing a response
        progressForm.ProgressBar1.Increment(50)
        progressForm.lblStatus.Text = "Looking for open checks"
        waitForPageLoad()
        checkForConflictsOrExit() : If Not ThisAddIn.proceed Then Exit Sub
        askUserIfWantToClear() : If Not ThisAddIn.proceed Then Exit Sub

        'go into the detail page for each conflict
loadFirstPage:

        '''' not sure where these next 4 lines should go...
        If checkCount = 0 Then
            MsgBox("Something went wrong.  Please make sure that you're on VPN and that you can access the RCS site in an Internet browser (https://rcs.gt.com). If this problem persists please contact the developer.", vbCritical, ThisAddIn.title)
            Exit Sub
        End If
        i += 1
        progressForm.ProgressBar1.Increment(i / checkCount)
        progressForm.lblStatus.Text = "Clearing check " & i & " of " & checkCount
        progressForm.Show()
        '''' 

        waitForPageLoad()
        checkForConflictsOrExit() : If Not ThisAddIn.proceed Then Exit Sub
        clicked = False
        attempts = 0
        Do Until clicked = True Or attempts > tryCount
            waitForPageLoad()
            myLinks = appIE.document.getElementsByTagName("a")
            For Each Link In myLinks
                If Link.innerHTML Like "*Open Check*" Then
                    Link.Click() 'click the use plaintext formatting button so we can populate the body correctly
                    clicked = True
                    Exit For
                End If
            Next Link
            attempts += 1
        Loop

        'exit gracefully if needed
        If Not clicked Then
            appIE = Nothing
            progressForm.ProgressBar1.Increment(100)
            progressForm.lblStatus.Text = "Done! " & clearCount & " checks cleared!"
            progressForm.Hide()
            doneForm.lblCount.Text = clearCount
            doneForm.ShowDialog()
            Exit Sub
        End If

        On Error GoTo 0

loadSecondPage:

        ' loop through all 'input' elements and find the one with the value "Submit"
        clicked2 = False
        attempts2 = 0
        Do Until clicked2 = True Or attempts2 > tryCount
            waitForPageLoad()
            ElementCol = appIE.document.getElementsByTagName("INPUT")
            For Each btnInput In ElementCol
                If btnInput.Value = "Reporting Complete" Then
                    btnInput.Click()
                    clicked2 = True
                    clearCount = clearCount + 1
                    Exit For
                End If
            Next btnInput
            attempts2 += 1
        Loop

        GoTo loadFirstPage

    End Sub

    Sub checkForConflictsOrExit()
        'make sure there are some conflicts that need clearing AND/OR exit gracefully
        Dim fontTag As Object = Nothing
        Dim ElementCol As Object = appIE.document.getElementsByTagName("font")
        For Each fontTag In ElementCol
            If fontTag.innerHTML Like "*There are no checks that require response*" Then
                If clearCount > 0 Then
                    progressForm.ProgressBar1.Increment(100)
                    progressForm.lblStatus.Text = "Done! " & clearCount & " checks cleared!"
                    progressForm.Hide()
                    doneForm.lblCount.Text = clearCount
                    doneForm.ShowDialog()
                Else
                    progressForm.ProgressBar1.Increment(100)
                    progressForm.lblStatus.Text = "There are no checks that require response"
                    progressForm.Hide()
                    doneForm.lblTitle.Text = "No checks" & Chr(10) & "need clearing" & Chr(10) & "@ this time"
                    doneForm.lblCount.Text = ""
                    doneForm.ShowDialog()
                End If
                appIE.Quit()
                appIE = Nothing
                ThisAddIn.proceed = False
                progressForm.Hide()
                Exit Sub
            End If
        Next fontTag
    End Sub

    'ask the user if they want to clear the conflicts
    Sub askUserIfWantToClear()
        Dim tData As Object = Nothing       ' td
        Dim splitholder
        Dim ElementCol As Object = appIE.document.getElementsByTagName("td")
        For Each tData In ElementCol
            If tData.innerhtml Like "*<BR>*" Then 'every available check has a line break between client name and country name
                If Not tData.innerhtml Like "*Confidentiality*" Then
                    splitholder = Split(tData.innerhtml, "<BR>")
                    checkList = checkList & " - " & Trim(splitholder(0)) & vbCrLf
                    checkCount += 1
                End If
            End If
        Next tData
        progressForm.Hide()
        If checkCount > 0 Then
            If MsgBox("Would you like to clear the following relationship checks?" & vbCrLf & vbCrLf & checkList, vbYesNoCancel, ThisAddIn.title) <> vbYes Then
                doneForm.lblTitle.Text = "Okay, nothing" & Chr(10) & "was touched." & Chr(10) & "Goodbye."
                doneForm.lblCount.Text = ""
                doneForm.ShowDialog()
                appIE.Quit()
                appIE = Nothing
                ThisAddIn.proceed = False
                Exit Sub
            End If
        Else
            checkForConflictsOrExit()
        End If
    End Sub

End Class
