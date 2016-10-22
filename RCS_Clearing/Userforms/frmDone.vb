Public Class frmDone

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub frmDone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = ThisAddIn.title
    End Sub

End Class