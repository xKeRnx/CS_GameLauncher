Imports System.IO
Public Class settingsForm

    Private Sub repatchbtn_Click(sender As Object, e As EventArgs) Handles repatchbtn.Click
        If MessageBox.Show("Do you want to Repatch???", "KeRn Repatch!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) = MessageBoxResult.Yes Then
            If File.Exists("KeRn.co") Then
                File.Delete("KeRn.co")
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location)
                Application.Current.Shutdown()
            End If
        End If
    End Sub

    Private Sub resolutionbtn_Click(sender As Object, e As EventArgs) Handles resolutionbtn.Click
        Dim frm As New ResolutionEditor
        frm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub settingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class