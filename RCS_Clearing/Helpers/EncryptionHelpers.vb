Public Class EncryptionHelpers

    Public Function CryptRC4(sText As String, sKey As String) As String
        Dim answer As String = ""

        Dim baS(0 To 255) As Byte
        Dim baK(0 To 255) As Byte
        Dim bytSwap As Byte
        Dim lI As Long
        Dim lJ As Long
        Dim lIdx As Long

        For lIdx = 0 To 255
            baS(lIdx) = lIdx
            baK(lIdx) = Asc(Mid$(sKey, 1 + (lIdx Mod Len(sKey)), 1))
        Next
        For lI = 0 To 255
            lJ = (lJ + baS(lI) + baK(lI)) Mod 256
            bytSwap = baS(lI)
            baS(lI) = baS(lJ)
            baS(lJ) = bytSwap
        Next
        lI = 0
        lJ = 0
        For lIdx = 1 To Len(sText)
            lI = (lI + 1) Mod 256
            lJ = (lJ + baS(lI)) Mod 256
            bytSwap = baS(lI)
            baS(lI) = baS(lJ)
            baS(lJ) = bytSwap
            answer = answer & Chr((pvCryptXor(baS((CLng(baS(lI)) + baS(lJ)) Mod 256), Asc(Mid$(sText, lIdx, 1)))))
        Next
        Return answer
    End Function

    Private Function pvCryptXor(ByVal lI As Long, ByVal lJ As Long) As Long
        If lI = lJ Then
            pvCryptXor = lJ
        Else
            pvCryptXor = lI Xor lJ
        End If
    End Function

    Public Function ToHexDump(sText As String) As String
        Dim answer As String = ""

        Dim lIdx As Long

        For lIdx = 1 To Len(sText)
            answer = answer & Right$("0" & Hex(Asc(Mid(sText, lIdx, 1))), 2)
        Next
        Return answer
    End Function

    Public Function FromHexDump(sText As String) As String
        Dim answer As String = ""

        Dim lIdx As Long

        For lIdx = 1 To Len(sText) Step 2
            answer = answer & Chr(CLng("&C" & Mid(sText, lIdx, 2)))
        Next
        Return answer
    End Function

    Shared Function HexToString(ByVal hex As String) As String
        Dim text As New StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function

    Shared Function StringToHex(ByVal text As String) As String
        Dim hex As New StringBuilder()
        For i As Integer = 0 To text.Length - 1
            hex.Append(Right(("0" & Asc(text.Substring(i, 1)).ToString("x").ToUpper), 2))
        Next
        Return hex.ToString
    End Function
End Class
