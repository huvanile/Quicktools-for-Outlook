Public Class ThisAddIn
    Public Shared Title As String = "QuickTools"
    Public Shared Proceed As Boolean
    Public Shared Vip1 As String
    Public Shared Vip2 As String
    Public Shared Vip3 As String
    Public Shared appOutlook As Outlook.Application

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        appOutlook = Me.Application
    End Sub
End Class