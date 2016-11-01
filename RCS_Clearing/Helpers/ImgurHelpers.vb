Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Drawing

Public Class ImgurHelpers
    Public Function GetRandomImg() As String
tryagain:
        Dim client As New WebClient()
        Dim rndimg As String = ""
        Dim downloadString As String = client.DownloadString("http://imgur.com/")
        Dim input As String = downloadString
        Dim regexcode As String = "(i.img)([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])"
        Dim regex As Regex = New Regex(regexcode)
        Dim r As Random = New Random()
        Dim rInt As Int64 = r.Next(0, regex.Matches(input).Count)
        rndimg = Replace(regex.Matches(input)(rInt).ToString, "b.jpg", ".gif")
        Do Until Not rndimg Like "*.mp4" And Not rndimg Like "*.png"
            rInt = r.Next(0, regex.Matches(input).Count)
            rndimg = Replace(regex.Matches(input)(rInt).ToString, "b.jpg", ".gif")
        Loop
        If Not LCase(rndimg) Like "*http://*" Then rndimg = "http://" & rndimg
        If rndimg = "http://imgur.com" Then GoTo tryagain
        client = Nothing
        regex = Nothing
        r = Nothing
        Return rndimg
    End Function

    Public Function webDownloadImage(ByVal Url As String, Optional ByVal saveFile As Boolean = False, Optional ByVal location As String = "C:") As Image
        Dim webClient As New System.Net.WebClient
        Dim saveName As String : saveName = Split(Url, "/")(3)
        Dim bytes() As Byte = webClient.DownloadData(Url)
        Dim stream As New IO.MemoryStream(bytes)
        If saveFile Then My.Computer.FileSystem.WriteAllBytes(location & saveName, bytes, False)
        Return New System.Drawing.Bitmap(stream)
        stream = Nothing
        webClient = Nothing
    End Function
End Class
