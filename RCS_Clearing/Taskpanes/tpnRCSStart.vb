Public Class tpnRCSStart
    Dim myRCS As New rcs

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ThisAddIn.proceed = True
        Ribbon1.ctpRCSStart.Visible = False
        Ribbon1.ctpRCSStart.Dispose()
        myRCS.clearRCAStuff()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ThisAddIn.proceed = False
        Ribbon1.ctpRCSStart.Visible = False
        Ribbon1.ctpRCSStart.Dispose()
    End Sub
End Class
