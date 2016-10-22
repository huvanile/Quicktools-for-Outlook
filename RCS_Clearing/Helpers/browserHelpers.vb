Public Class browserHelpers
    Public Shared appIE As Object

    ' loop until the page finishes loading``
    Public Shared Sub waitForPageLoad()
        Dim currenttime As Date : currenttime = Date.Now
        Dim duration As TimeSpan : duration = New TimeSpan(0, 0, 3)
        Do
            Do Until currenttime + duration <= Date.Now
            Loop
        Loop Until appIE.readyState = 4 And Not appIE.Busy ' 4 means "READYSTATE_COMPLETE"
    End Sub

    Public Shared Function GetIE() As Object
        GetIE = CreateObject("InternetExplorer.Application")
    End Function

End Class
