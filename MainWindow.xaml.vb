Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Windows.Threading
Imports SharpCompress.Archives
Imports SharpCompress.Common
Imports System.Threading

Class MainWindow
    Friend WithEvents downloader As New WebClient
    WithEvents lostdown As New WebClient
    Private wc As New WebClient
    Private MyFunction As New MyFunction
    Private WebRessource As String() = Nothing
    Public Shared Token As String

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ClientVersionLabel.Content = MyFunction.ReadConfig("LauncherVersion", 0)
        WebRessource = wc.DownloadString(MyFunction.URL + "Launcher/Compare/Files.txt").Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        SyncFiles()
    End Sub

    Private Sub SyncFiles()
        Dim filesMistake As Boolean = False
        For Each s As String In WebRessource
            Dim ffile As String = s.Split("#")(0)
            Dim ffilehash As String = s.Split("#")(1)
            If File.Exists(ffile) Then
                If Not MyFunction.MD5FileHash(ffile) = ffilehash Then
                    If Not Path.GetDirectoryName(ffile).Length = 0 AndAlso Not Directory.Exists(Path.GetDirectoryName(ffile)) Then
                        StatusLabel.Content = "Creating directorys..."
                        Directory.CreateDirectory(Path.GetDirectoryName(ffile))
                    End If
                    StatusLabel.Content = "Downloading File " & ffile & "..."
                    lostdown.DownloadFileAsync(New Uri(MyFunction.URL + "/Compare/" + ffile), ffile)
                    filesMistake = True
                    Exit For
                End If
            Else
                If Not Path.GetDirectoryName(ffile).Length = 0 AndAlso Not Directory.Exists(Path.GetDirectoryName(ffile)) Then
                    StatusLabel.Content = "Creating directorys..."
                    Directory.CreateDirectory(Path.GetDirectoryName(ffile))
                End If
                StatusLabel.Content = "Downloading File " & ffile & "..."
                lostdown.DownloadFileAsync(New Uri(MyFunction.URL + "Launcher/Compare/" + ffile), ffile)
                filesMistake = True
                Exit For
            End If
        Next
        If filesMistake = False Then
            downloadPatches()
        End If
    End Sub

    Private Sub lostdown_DownloadFileCompleted(sender As Object, e As ComponentModel.AsyncCompletedEventArgs) Handles lostdown.DownloadFileCompleted
        StatusLabel.Content = "File Download complete.."
        progressBar1.Value = 0
        SyncFiles()
    End Sub

    Private Sub lostdown_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles lostdown.DownloadProgressChanged
        If Not progressBar1.Value = 0 Then
        End If
        progressBar1.Value = e.ProgressPercentage
    End Sub

    Public Sub downloadPatches()
        If ServerVersionLabel.Content = ClientVersionLabel.Content Then
            LaunchBtn.IsEnabled = True
            StatusLabel.Content = "No new Updates avaiable!"
            PatchProgressLabel.Visibility = Windows.Visibility.Hidden
            progressBar1.Visibility = Windows.Visibility.Hidden
        ElseIf Val(ClientVersionLabel.Content) > Val(ServerVersionLabel.Content) Then
            MessageBox.Show("Overpatched. I'll restart now to repatch.", MyFunction.LName + " :: Error")
            If File.Exists("Config.co") Then
                File.Delete("Config.co")
            End If
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location)
            Application.Current.Shutdown()
        Else
            StatusLabel.Content = "Getting Patch: " & ClientVersionLabel.Content
            progressBar1.Value = 0
            downloader.DownloadFileAsync(New Uri(Splash.patchList(ClientVersionLabel.Content + 1).Split(vbTab)(1)), "patch.rar")
        End If
    End Sub

    Private Sub downloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As ComponentModel.AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        If (File.Exists("patch.rar")) Then
            Dim archive As IArchive = ArchiveFactory.Open("patch.rar")
            For Each entry In archive.Entries
                If Not entry.IsDirectory Then
                    StatusLabel.Content = entry.Key
                    refreshContent()
                    Dim options As New ExtractionOptions With {
                        .ExtractFullPath = True,
                        .Overwrite = True
                    }
                    entry.WriteToDirectory(Environment.CurrentDirectory(), options)
                End If
            Next
            archive.Dispose()
            File.Delete("patch.rar")
            ClientVersionLabel.Content += 1
            MyFunction.WriteConfig("LauncherVersion", ClientVersionLabel.Content)
            MyFunction.deleteFiles()
        Else
            MessageBox.Show("Patch does not exist!!!", MyFunction.LName + " :: Error")
        End If
        downloadPatches()
    End Sub

    Private Sub downloader_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        PatchProgressLabel.Content = e.ProgressPercentage & "%"
        progressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Application.Current.Shutdown()
    End Sub

    Private Sub Window_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If Mouse.LeftButton = MouseButtonState.Pressed Then
            DragMove()
        End If
    End Sub


    Private Sub Launch()
        MyFunction.StartGame("Fiesta.exe", "82.165.67.50")
    End Sub

    Private Sub LaunchBtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles LaunchBtn.MouseDown
        Launch()
    End Sub

    Private Sub XBtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles XBtn.MouseDown
        Application.Current.Shutdown()
    End Sub

    Private Sub Repatch_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Repatch.MouseDown
        Dim frm As New settingsForm
        frm.ShowDialog()
    End Sub

    Public Sub refreshContent()
        Dim frame As New DispatcherFrame()
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf ExitFrame), frame)
        Dispatcher.PushFrame(frame)
    End Sub
    Public Function ExitFrame(ByVal f As Object) As Object
        CType(f, DispatcherFrame).Continue = False

        Return Nothing
    End Function

    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        If (e.Key = Key.Return) Then
            Launch()
        End If
    End Sub

End Class
