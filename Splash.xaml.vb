Imports System.IO
Imports System.Net
Imports System.ComponentModel

Public Class Splash
    Public Shared news As String = MyFunction.URL + "news.txt"
    Public Shared urlConfig As String = MyFunction.URL + "Launcher/config.txt"
    Public Shared websiteAddress As String = MyFunction.URL + "Launcher/"
    Public Shared patchList() As String = Nothing
    Public Shared configFile() As String = Nothing
    Public Shared configDic As New Dictionary(Of String, String)()
    Private wc As New WebClient
    Private MyFunction As New MyFunction

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim MainWindow As New MainWindow
        Try
            MainWindow.textBlock1.Text = wc.DownloadString(news)
        Catch
            MessageBox.Show("Some Student has disconnected our LAN port. Please check back later..")
            Environment.Exit(1)
        End Try
        If Not File.Exists("Updater.exe") Then
            wc.DownloadFile(MyFunction.URL + "Launcher/Updater.exe", "Updater.exe")
        End If

        configFile = wc.DownloadString(urlConfig).Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim ExternalVersion As Double = Double.Parse(Splash.configFile(0).Substring(Splash.configFile(0).IndexOf("=") + 1), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo)
        If My.Settings.InternalVersion < ExternalVersion Then
            Process.Start("Updater.exe")
            Environment.Exit(0)
        End If

        patchList = wc.DownloadString(Splash.websiteAddress & "list.txt").Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        MainWindow.ServerVersionLabel.Content = MyFunction.CountPatches(websiteAddress & "\list.txt")

        If File.Exists("Config.co") Then
            For Each s As String In MyFunction.Decrypt(File.ReadAllText("Config.co")).Split(vbNewLine)
                Dim key As String = s.Substring(0, s.IndexOf("="))
                Dim value As String = s.Substring(s.IndexOf("=") + 1)
                configDic.Add(key, value)
            Next
        End If

        Me.Hide()
        MainWindow.ShowDialog()


    End Sub


End Class
