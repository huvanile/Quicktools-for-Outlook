Imports System.Runtime.InteropServices

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

    ''' <summary>
    ''' close all open custom taskpanes when a mailitem gets opened
    ''' </summary>
    ''' <param name="Item"></param>
    Private Sub OnItemLoad(Item As System.Object) Handles Application.ItemLoad
        Dim mail As Outlook.MailItem = TryCast(Item, Outlook.MailItem)
        If Not IsNothing(mail) Then
            For Each ctp In CustomTaskPanes
                ctp.Dispose()
            Next
        End If
        mail = Nothing
    End Sub

    ''' <summary>
    ''' close all open custom taskpanes when a mailitem gets sent
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <param name="Cancel"></param>
    Private Sub OnItemSend(Item As System.Object, ByRef Cancel As Boolean) Handles Application.ItemSend
        Dim mail As Outlook.MailItem = TryCast(Item, Outlook.MailItem)
        If Not IsNothing(mail) Then
            For Each ctp In CustomTaskPanes
                ctp.Dispose()
            Next
        End If
        mail = Nothing
    End Sub
End Class