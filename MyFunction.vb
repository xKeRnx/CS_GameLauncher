Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Class MyFunction
    Public Shared LName As String = "KeRnPatcher"
    Public Shared URL As String = "https://cdn1.kernfiesta.com/"

    Public Sub StartGame(ByVal sFile As String, ByVal IP As String)
        If File.Exists(sFile) Then
            Dim p As New Process
            p.StartInfo.FileName = sFile
            p.StartInfo.Arguments = "-i " + IP
            p.Start()
            Environment.Exit(0)
        Else
            MessageBox.Show(sFile + " doesn't exist!!!", "RS:1", MessageBoxButton.OK, MessageBoxImage.Error)
            Environment.Exit(0)
        End If
    End Sub

    Public Function Encrypt(ByVal strText As String) As String
        Dim strEncrKey As String = "c8YXEft&+fMs@]ntv2!JyUuFs[#xgXek"
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H33, &H62, &H57, &H33, &H23, &H40, &H6A, &H75, &H72, &H5B, &H5F, &H42, &H50, &H55, &H76, &H73}
        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 16))

            Dim rijndael As New RijndaelManaged()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, rijndael.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
    Public Function Decrypt(ByVal strText As String) As String
        Dim sDecrKey As String = "c8YXEft&+fMs@]ntv2!JyUuFs[#xgXek"
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H33, &H62, &H57, &H33, &H23, &H40, &H6A, &H75, &H72, &H5B, &H5F, &H42, &H50, &H55, &H76, &H73}
        Dim inputByteArray(strText.Length) As Byte

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 16))
            Dim rijn As New RijndaelManaged()
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, rijn.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

            Return encoding.GetString(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function MD5StringHash(ByVal strString As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Data As Byte()
        Dim Result As Byte()
        Dim Res As String = ""
        Dim Tmp As String = ""

        Data = Encoding.ASCII.GetBytes(strString)
        Result = MD5.ComputeHash(Data)
        For i As Integer = 0 To Result.Length - 1
            Tmp = Hex(Result(i))
            If Len(Tmp) = 1 Then Tmp = "0" & Tmp
            Res += Tmp
        Next
        Return Res
    End Function
    Public Function CountPatches(ByVal s As String) As Integer
        Dim wc As New Net.WebClient
        Dim Content As Integer = wc.DownloadString(s).Split(vbNewLine).Length
        Return Content - 1
    End Function
    Public Function MD5FileHash(sFile As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim FN As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        MD5.ComputeHash(FN)
        FN.Close()
        Return BitConverter.ToString(MD5.Hash).Replace("-", "").ToLower()
    End Function

    Public Sub WriteConfig(ByVal key As String, ByVal value As String)
        Dim MyFunction As New MyFunction
        If Splash.configDic.ContainsKey(key) Then
            Splash.configDic(key) = value
        Else
            Splash.configDic.Add(key, value)
        End If
        Dim tmpList As New List(Of String)
        For i As Integer = 0 To Splash.configDic.Count - 1
            tmpList.Add(Splash.configDic.Keys(i) & "=" & Splash.configDic.Values(i))
        Next
        File.WriteAllText("KeRn.co", MyFunction.Encrypt(String.Join(vbNewLine, tmpList)))
    End Sub

    Public Function ReadConfig(ByVal key As String, Optional defaultValue As String = "")
        If Splash.configDic.ContainsKey(key) Then
            Return Splash.configDic(key)
        Else
            If defaultValue.Length > 0 Then
                Splash.configDic.Add(key, defaultValue)
            Else
                Splash.configDic.Add(key, 0)
            End If
            Return Splash.configDic(key)
        End If
    End Function

    Public Sub deleteFiles()
        If File.Exists("removeFiles.kern") Then
            Dim sLines() As String = Decrypt(File.ReadAllText("removeFiles.kern")).Split(Environment.NewLine)
            For Each s As String In sLines
                If File.Exists(s) Then
                    File.Delete(s)
                End If
            Next
            File.Delete("removeFiles.kern")
        End If
    End Sub
End Class