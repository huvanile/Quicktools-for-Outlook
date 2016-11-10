Imports Microsoft.Win32

Public Class RegistryHelpers

    Public Const RegistryFolder As String = "SOFTWARE\Gtus\OutlookQuicktools\"

    Public Shared Function GetSetting(subFolder As String, keyName As String)
        Dim myKey As RegistryKey = Registry.LocalMachine.OpenSubKey(RegistryFolder + subFolder + "\", True)
        If Not IsNothing(myKey) Then
            Dim keyObject As Object
            keyObject = myKey.GetValue(keyName)
            myKey.Close()
            If IsNothing(keyObject) Then
                Return ""
            Else
                Return keyObject.ToString()
            End If
        Else
            Return ""
        End If
    End Function

    Public Shared Sub SaveSetting(subFolder As String, keyName As String, keyValue As String)
        Registry.LocalMachine.CreateSubKey(RegistryFolder + subFolder + "\")
        Dim myKey As RegistryKey = Registry.LocalMachine.OpenSubKey(RegistryFolder + subFolder + "\", True)
        If Not IsNothing(myKey) Then
            myKey.SetValue(keyName, keyValue, RegistryValueKind.String)
            myKey.Close()
        End If
    End Sub

End Class
