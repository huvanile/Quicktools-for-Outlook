'Option Strict On

Imports Microsoft.Office.Tools.Ribbon
Imports RCS_Clearing.globalVariables


Public Class Ribbon1

    Dim progressForm As New frmProgressbox
    Dim doneForm As New frmDone
    Dim appIE As Object
    Dim badTryCount As Integer

    Private Sub btnRCSCheck_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRCSCheck.Click
        If MsgBox("Clear RCS stuff?", vbYesNoCancel, title) = vbYes Then clearRCAStuff()
    End Sub

    ' loop until the page finishes loading``
    Private Sub waitForPageLoad()
        Dim currenttime As System.DateTime : currenttime = System.DateTime.Now
        Dim duration As System.TimeSpan : duration = New System.TimeSpan(0, 0, 3)

        Do
            Do Until currenttime + duration <= System.DateTime.Now
            Loop
        Loop Until appIE.readyState = 4 And Not appIE.Busy ' 4 means "READYSTATE_COMPLETE"
    End Sub


    Private Function GetIE() As Object
        On Error Resume Next
        GetIE = CreateObject("InternetExplorer.Application")
    End Function

    Public Sub clearRCAStuff()
        Dim i As Single : i = 25
        Dim sURL As String : sURL = "https://rcs.gt.com/ResponderDashboardStatusDetail/DisplayResponderDashboardDetailList?pageType=DashboardResponder"
        Dim clicked As Boolean
        Dim clicked2 As Boolean
        Dim myLink As Object
        Dim Element As Object ' HTMLButtonElement
        Dim btnInput As Object ' MSHTML.HTMLInputElement
        Dim myLocation As Object 'MSHTML.HTMLOptionElement
        Dim ElementCol As Object ' MSHTML.IHTMLElementCollection
        Dim Link As Object ' MSHTML.HTMLAnchorElement
        Dim fontTag As Object
        Dim clearCount As Single : clearCount = 0
        appIE = GetIE()
        appIE.Visible = False
        'appIE.Visible = True
        progressForm.Show()
        progressForm.ProgressBar1.Increment(1)
        progressForm.lblStatus.Text = "Opening RCS Site in Internet Explorer"
        appIE.navigate(sURL)
        progressForm.ProgressBar1.Increment(5)
        progressForm.lblStatus.Text = "Checking for checks that require a response"

loadFirstPage:
        waitForPageLoad()

        'make sure there are some conflicts that need clearing
        clicked = False
        ElementCol = appIE.document.getElementsByTagName("font")
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
                Exit Sub
            End If
        Next fontTag

        'appIE.Visible = True

        'click the use plaintext formatting button so we can populate the body correctly
        clicked = False
        ElementCol = appIE.document.getElementsByTagName("a")
        myLink = appIE.document.getElementsByTagName("a")
        For Each Link In ElementCol
            If Link.innerHTML Like "*Open Check*" Then
                i = i + 1
                progressForm.ProgressBar1.Increment(CSng(i + clearCount))
                progressForm.lblStatus.Text = "Clearing checks"
                Link.Click()
                clicked = True
                Exit For
            End If
        Next Link

        If Not clicked Then 'try again
            waitForPageLoad()
            ElementCol = appIE.document.getElementsByTagName("a")
            myLink = appIE.document.getElementsByTagName("a")
            For Each Link In ElementCol
                If Link.innerHTML Like "*Open Check*" Then
                    i = i + 1
                    progressForm.ProgressBar1.Increment(CSng(i + clearCount))
                    progressForm.lblStatus.Text = "Clearing checks"
                    Link.Click()
                    clicked = True
                    Exit For
                End If
            Next Link
        End If

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
        clicked2 = False
        waitForPageLoad()

        ' loop through all 'input' elements and find the one with the value "Submit"
        ElementCol = appIE.document.getElementsByTagName("INPUT")
        For Each btnInput In ElementCol
            If btnInput.Value = "Reporting Complete" Then
                btnInput.Click()
                clicked2 = True
                clearCount = clearCount + 1
                i = i + 1
                progressForm.ProgressBar1.Increment(CSng(i + clearCount))
                progressForm.lblStatus.Text = "Clearing checks"
                Exit For
            End If
        Next btnInput

        If Not clicked2 Then 'try again after waiting
            waitForPageLoad()
            ElementCol = appIE.document.getElementsByTagName("INPUT")
            For Each btnInput In ElementCol
                If btnInput.Value = "Reporting Complete" Then
                    btnInput.Click()
                    clicked2 = True
                    clearCount = clearCount + 1
                    i = i + 1
                    progressForm.ProgressBar1.Increment(CSng(i + clearCount))
                    progressForm.lblStatus.Text = "Clearing checks"
                    Exit For
                End If
            Next btnInput
        End If

        GoTo loadFirstPage

badTryFirstPage:
        waitForPageLoad()
        If badTryCount > 4 Then
            progressForm.ProgressBar1.Increment(0)
            progressForm.lblStatus.Text = "Problems were encountered (code 1).  Please try again from a faster Internet connection."
            MsgBox("Problems were encountered (code 1).  Please try again from a faster Internet connection.", vbCritical, title)
            appIE = Nothing
            Exit Sub
        Else
            badTryCount = badTryCount + 1
            Resume loadFirstPage
        End If

badTrySecondPage:
        waitForPageLoad()
        If badTryCount > 4 Then
            progressForm.ProgressBar1.Increment(0)
            progressForm.lblStatus.Text = "Problems were encountered (code 2).  Please try again from a faster Internet connection."
            MsgBox("Problems were encountered (code 2).  Please try again from a faster Internet connection.", vbCritical, title)
            appIE = Nothing
            Exit Sub
        Else
            badTryCount = badTryCount + 1
            Resume loadSecondPage
        End If

    End Sub

End Class
