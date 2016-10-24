Imports Quicktools.browserHelpers

Public Class rcs

    'configuration parameters
    Const sURL As String = "https://rcs.gt.com/ResponderDashboardStatusDetail/DisplayResponderDashboardDetailList?pageType=DashboardResponder"
    Const tryCount As Integer = 3       'maximum tries to load a page during the clearing process before giving up

    'class-wide variables
    Dim clearCount As Single = 0        ' running count of all checks cleared
    Dim checkList As String = ""        ' list of all names of checks to clear
    Dim checkCount As Integer = 0       ' total of all checks available to be cleared
    Public inProgress As Boolean

    'factory sub which does the guts of this ribbon
    Public Sub startRCSClearing()

        'instantiate IE
        appIE = GetIE()
        appIE.Visible = False
        'appIE.Visible = True

        'load site
        Ribbon1.taskpaneRCSStart.lblStatus.Text = "Opening RCS Site in IE"
        appIE.navigate(sURL)

        'check for checks needing a response
        Ribbon1.taskpaneRCSStart.lblStatus.Text = "Looking for open checks"
        waitForPageLoad()
        checkForConflictsOrExit() : If Not ThisAddIn.proceed Then Exit Sub
        askUserIfWantToClear() : If Not ThisAddIn.proceed Then Exit Sub

    End Sub

    Public Sub finishRCSClearing()
        'variable declaration
        Dim clicked As Boolean = False
        Dim clicked2 As Boolean = False
        Dim attempts As Integer = 0
        Dim attempts2 As Integer = 0
        Dim myLinks As Object = Nothing
        Dim btnInput As Object = Nothing    ' MSHTML.HTMLInputElement
        Dim Link As Object = Nothing        ' MSHTML.HTMLAnchorElement
        Dim ElementCol As Object = Nothing  ' MSHTML.IHTMLElementCollection
        Dim i As Integer = 0               ' counter used for status bar incrementing

        'go into the detail page for each conflict
loadFirstPage:

        If checkCount = 0 Then
            Ribbon1.taskpaneRCSStart.lblStatus.Text = "Something went wrong.  Check your connectivity to the GT network and try again."
            Exit Sub
        End If
        i += 1
        Ribbon1.taskpaneRCSStart.lblStatus.Text = "Clearing check " & i & " of " & checkCount

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
            Ribbon1.taskpaneRCSStart.lblQuestion.Text = "Done!"
            Ribbon1.taskpaneRCSStart.lblStatus.Text = clearCount & " checks cleared!"
            Exit Sub
        End If

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
                    Ribbon1.taskpaneRCSStart.lblQuestion.Text = "Done!"
                    Ribbon1.taskpaneRCSStart.lblStatus.Text = clearCount & " checks cleared!"
                Else
                    Ribbon1.taskpaneRCSStart.lblStatus.Text = "There are no checks that require response"
                    Ribbon1.taskpaneRCSStart.lblQuestion.Text = "No checks need clearing at this time"
                    Ribbon1.taskpaneRCSStart.btnOK.Visible = True
                End If
                appIE.Quit()
                appIE = Nothing
                ThisAddIn.proceed = False
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
        If checkCount > 0 Then
            With Ribbon1.taskpaneRCSStart.txtEntities
                .Text = checkList
                .Visible = True
            End With
            Ribbon1.taskpaneRCSStart.lblQuestion.Text = "Clear the following relationship checks?"
            Ribbon1.taskpaneRCSStart.btnCancel.Visible = True
            Ribbon1.taskpaneRCSStart.btnOK.Visible = True
            Ribbon1.taskpaneRCSStart.lblStatus.Text = "Pending relationship checks:"
        Else
            checkForConflictsOrExit()
        End If
    End Sub

End Class
