Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class ExcelHelpers

    ''' <summary>
    ''' Gets the current instance of excel if it can, otherwise gets a new one
    ''' </summary>
    ''' <returns>An object for the excel application</returns>
    Public Shared Function GetExcel() As Excel.Application
        Dim application As Excel.Application
        If Process.GetProcessesByName("EXCEL").Count() > 0 Then ' Check whether there is an Outlook process running.
            Try ' If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
                application = DirectCast(Marshal.GetActiveObject("Excel.Application"), Excel.Application)
            Catch ex As System.Exception ' If fails, create a new instance of excel and log on to the default profile.
                application = New Excel.Application()
            End Try
        Else ' If not, create a new instance of excel and log on to the default profile.
            application = New Excel.Application()
        End If
        Return application ' Return the excel Application object.
    End Function

    Public Shared Sub writeToExcel(theAddr As String, theValue As String, theExcel As Excel.Application)
        theExcel.ActiveWorkbook.ActiveSheet.Range(theAddr).Value = theValue
    End Sub

End Class
