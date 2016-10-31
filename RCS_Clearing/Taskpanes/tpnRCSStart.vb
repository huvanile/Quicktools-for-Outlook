Imports Quicktools.browserHelpers
Imports System.Threading

Public Class tpnRCSStart
    Dim myRCS As rcs
    Dim t1 As Thread

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            ThisAddIn.proceed = True
            If myRCS.inProgress = False Then
                myRCS.inProgress = True
                btnCancel.Visible = False
                btnOK.Visible = False
                lblQuestion.Text = "Working..."
                myRCS.startRCSClearing()
            Else
                If lblStatus.Text Like "*no checks*" Or lblStatus.Text Like "*cleared!*" Then
                    'no checks needed clearing, so do the same action as the cancel button
                    ThisAddIn.proceed = False
                    Ribbon1.ctpRCSStart.Visible = False
                    Ribbon1.ctpRCSStart.Dispose()
                    If Not IsNothing(myRCS) Then myRCS = Nothing
                Else
                    myRCS.inProgress = True
                    t1 = Nothing
                    t1 = New Thread(AddressOf myRCS.finishRCSClearing, 8000000)
                    With t1
                        .IsBackground = True
                        .Priority = ThreadPriority.Lowest
                        .SetApartmentState(ApartmentState.STA)
                        .Start()
                    End With

                End If

            End If
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ThisAddIn.proceed = False
        Ribbon1.ctpRCSStart.Visible = False
        On Error Resume Next
        appIE.Quit()
        appIE = Nothing
        On Error GoTo 0
        Ribbon1.ctpRCSStart.Dispose()
        myRCS = Nothing
    End Sub

    Private Sub tpnRCSStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            myRCS = New rcs
            myRCS.inProgress = False
            lblStatus.Text = String.Empty
            txtEntities.Visible = False
            txtEntities.Text = String.Empty
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.InnerException.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        If IsNothing(appIE) Then appIE = GetIE()
        appIE.Visible = True
        appIE.navigate("https://paypal.me/chromepanda")
    End Sub
End Class
