Imports System.Drawing
Imports System.Threading.Tasks
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

#Region "Thread-safe GUI Updaters"
    Public Delegate Sub setTextSafeCallback([theText] As String)
    Public Delegate Sub disableControlSafeCallback([theName] As String)
    Public Delegate Sub enableControlSafeCallback([theName] As String)

    Public Sub enableControlSafe([theName] As String)
        Try
            If Not IsNothing(Ribbon1.taskpaneRCSStart.Controls(theName)) Then
                If Ribbon1.taskpaneRCSStart.Controls(theName).InvokeRequired Then
                    Dim d As New enableControlSafeCallback(AddressOf enableControlSafe)
                    Ribbon1.taskpaneRCSStart.Invoke(d, New Object() {[theName]})
                    d = Nothing
                Else
                    With Ribbon1.taskpaneRCSStart.Controls(theName)
                        If .Enabled <> True Then .Enabled = True
                        If .Visible <> True Then .Visible = True
                        .Refresh()
                    End With
                End If
            End If
        Catch exAll As Exception : End Try
    End Sub

    Public Sub disableControlSafe([theName] As String)
        Try
            If Not IsNothing(Ribbon1.taskpaneRCSStart.Controls(theName)) Then
                If Ribbon1.taskpaneRCSStart.Controls(theName).InvokeRequired Then
                    Dim d As New disableControlSafeCallback(AddressOf disableControlSafe)
                    Ribbon1.taskpaneRCSStart.Invoke(d, New Object() {[theName]})
                    d = Nothing
                Else
                    With Ribbon1.taskpaneRCSStart.Controls(theName)
                        If .Enabled <> False Then .Enabled = False
                        .BackColor = Color.Transparent
                        .Refresh()
                    End With
                End If
            End If
        Catch exAll As Exception : End Try
    End Sub

    Public Sub updateTxtEntitiesSafe(theText As String)
        Try
            With Ribbon1.taskpaneRCSStart.txtEntities
                If .InvokeRequired Then
                    Dim d As New setTextSafeCallback(AddressOf updateTxtEntitiesSafe)
                    Ribbon1.taskpaneRCSStart.Invoke(d, New Object() {[theText]})
                    d = Nothing
                Else
                    .Visible = True
                    .Text = theText
                    .Refresh()
                    .Invalidate()
                End If
            End With
        Catch exAll As Exception : End Try

    End Sub

    Public Sub updateLblQuestionSafe(theText As String)
        Try
            With Ribbon1.taskpaneRCSStart.lblQuestion
                If .InvokeRequired Then
                    Dim d As New setTextSafeCallback(AddressOf updateLblQuestionSafe)
                    Ribbon1.taskpaneRCSStart.Invoke(d, New Object() {[theText]})
                    d = Nothing
                Else
                    .Text = theText
                    .Refresh()
                    .Invalidate()
                End If
            End With
        Catch exAll As Exception : End Try

    End Sub

    Public Sub updateLblStatusSafe(theText As String)
        Try
            With Ribbon1.taskpaneRCSStart.lblStatus
                If .InvokeRequired Then
                    Dim d As New setTextSafeCallback(AddressOf updateLblStatusSafe)
                    Ribbon1.taskpaneRCSStart.Invoke(d, New Object() {[theText]})
                    d = Nothing
                Else
                    .Text = theText
                    .Refresh()
                    .Invalidate()
                End If
            End With
        Catch exAll As Exception : End Try

    End Sub

#End Region

    'factory sub which does the guts of this ribbon
    Public Async Sub startRCSClearing()
        Await Task.Run(
            Sub()
                'instantiate IE
                appIE = GetIE()
                appIE.Visible = False
                'appIE.Visible = True

                'load site
                updateLblStatusSafe("Opening RCS Site in IE")
                appIE.navigate(sURL)

                'check for checks needing a response
                updateLblStatusSafe("Looking for open checks")
                waitForPageLoad()
                checkForConflictsOrExit() : If Not ThisAddIn.Proceed Then Exit Sub
                askUserIfWantToClear() : If Not ThisAddIn.Proceed Then Exit Sub

            End Sub)
    End Sub

    Public Async Sub finishRCSClearing()
#Disable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
        Task.Run(
            Sub()
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

                updateLblQuestionSafe("Working...")
                disableControlSafe("btnOK")
                disableControlSafe("btnCancel")

                'go into the detail page for each conflict
loadFirstPage:

                If checkCount = 0 Then
                    updateLblStatusSafe("Something went wrong.  Check your connectivity to the GT network and try again.")
                    Exit Sub
                End If
                i += 1
                If Not i > checkCount Then
                    updateLblStatusSafe("Clearing check " & i & " of " & checkCount)
                Else
                    updateLblStatusSafe("Clearing check " & checkCount & " of " & checkCount)
                End If


                waitForPageLoad()
                checkForConflictsOrExit() : If Not ThisAddIn.Proceed Then Exit Sub
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
                    updateLblQuestionSafe("Done!")
                    updateLblStatusSafe(clearCount & " checks cleared!")
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
            End Sub)
#Enable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
    End Sub

    Sub checkForConflictsOrExit()
        'make sure there are some conflicts that need clearing AND/OR exit gracefully
        Dim fontTag As Object = Nothing
        Dim ElementCol As Object = appIE.document.getElementsByTagName("font")
        For Each fontTag In ElementCol
            If fontTag.innerHTML Like "*There are no checks that require response*" Then
                If clearCount > 0 Then
                    updateLblQuestionSafe("Done!")
                    updateLblStatusSafe(clearCount & " checks cleared!")
                Else
                    updateLblStatusSafe("There are no checks that require response")
                    updateLblQuestionSafe("No checks need clearing at this time")
                    enableControlSafe("btnOK")
                End If
                appIE.Quit()
                appIE = Nothing
                ThisAddIn.Proceed = False
                Exit Sub
            End If
        Next fontTag
    End Sub

    'ask the user if they want to clear the conflicts
    Sub askUserIfWantToClear()
        Dim tData As Object = Nothing       ' td
        Dim splitholder
        Dim tmpName As String
        Dim ElementCol As Object = appIE.document.getElementsByTagName("td")
        For Each tData In ElementCol
            If tData.innerhtml Like "*<BR>*" Then 'every available check has a line break between client name and country name
                If Not tData.innerhtml Like "*Confidentiality*" Then
                    splitholder = Split(tData.innerhtml, "<BR>")
                    tmpName = Trim(splitholder(0))
                    tmpName = Replace(tmpName, "<DIV class=RedText>", "")
                    checkList = checkList & " - " & tmpName & vbCrLf
                    checkCount += 1
                End If
            End If
        Next tData
        If checkCount > 0 Then
            updateTxtEntitiesSafe(checkList)
            updateLblQuestionSafe("Clear the following relationship checks?")
            enableControlSafe("btnCancel")
            enableControlSafe("btnOK")
            updateLblStatusSafe("Pending relationship checks:")
        Else
            checkForConflictsOrExit()
        End If
    End Sub

End Class