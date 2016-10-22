Public Class frmStart

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ThisAddIn.proceed = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ThisAddIn.proceed = False
        Me.Close()
    End Sub

    Private Sub frmDone_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ThisAddIn.title
    End Sub

End Class