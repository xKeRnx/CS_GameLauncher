Imports System.IO
Imports System.Windows.Forms
Public Class ResolutionEditor
    Private resoDic As New Dictionary(Of Integer, String)()
    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If File.Exists("ressystem/option.mco") Then
            Dim binaryWriter As New BinaryWriter(File.Open("ressystem/option.mco", FileMode.Open, FileAccess.ReadWrite))
            If (WindowModechkbx.Checked = False) Then
                binaryWriter.BaseStream.Seek(47L, SeekOrigin.Begin)
                binaryWriter.Write(Convert.ToInt16(0))
            Else
                binaryWriter.BaseStream.Seek(47L, SeekOrigin.Begin)
                binaryWriter.Write(Convert.ToInt16(1))
            End If
            binaryWriter.BaseStream.Seek(39L, SeekOrigin.Begin)
            binaryWriter.Write(Convert.ToInt16(Resolutioncmbox.SelectedItem.Split("x")(0)))
            binaryWriter.BaseStream.Seek(43L, SeekOrigin.Begin)
            binaryWriter.Write(Convert.ToInt16(Resolutioncmbox.SelectedItem.Split("x")(1)))
            binaryWriter.Close()
            MessageBox.Show("Successfully changed resolution to " & Resolutioncmbox.SelectedItem, "Resolution Editor - 2015 © PureGames", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("Please start your Game one time and then come back to use this feature!", "RSError::3", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Close()
    End Sub

    Private Sub ResolutionEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resoDic.Add(resoDic.Count + 1, "320x240")
        resoDic.Add(resoDic.Count + 1, "640x480")
        resoDic.Add(resoDic.Count + 1, "800x600")
        resoDic.Add(resoDic.Count + 1, "1024x768")
        resoDic.Add(resoDic.Count + 1, "1152x864")
        resoDic.Add(resoDic.Count + 1, "1280x1024")
        resoDic.Add(resoDic.Count + 1, "1360x1024")
        resoDic.Add(resoDic.Count + 1, "1400x1050")
        resoDic.Add(resoDic.Count + 1, "1600x1200")
        resoDic.Add(resoDic.Count + 1, "2048x1536")
        resoDic.Add(resoDic.Count + 1, "3200x2400")
        resoDic.Add(resoDic.Count + 1, "4096x3072")
        resoDic.Add(resoDic.Count + 1, "6400x4800")
        resoDic.Add(resoDic.Count + 1, "800x480")
        resoDic.Add(resoDic.Count + 1, "400x240")
        resoDic.Add(resoDic.Count + 1, "1280x768")
        resoDic.Add(resoDic.Count + 1, "854x480")
        resoDic.Add(resoDic.Count + 1, "1024x600")
        resoDic.Add(resoDic.Count + 1, "1280x720")
        resoDic.Add(resoDic.Count + 1, "1360x768")
        resoDic.Add(resoDic.Count + 1, "1366x768")
        resoDic.Add(resoDic.Count + 1, "1600x900")
        resoDic.Add(resoDic.Count + 1, "1920x1080")
        resoDic.Add(resoDic.Count + 1, "2048x1152")
        resoDic.Add(resoDic.Count + 1, "2560x1440")
        resoDic.Add(resoDic.Count + 1, "1440x900")
        resoDic.Add(resoDic.Count + 1, "1280x800")
        resoDic.Add(resoDic.Count + 1, "1680x1050")
        resoDic.Add(resoDic.Count + 1, "1920x1200")
        resoDic.Add(resoDic.Count + 1, "2560x1600")
        resoDic.Add(resoDic.Count + 1, "3840x2400")
        resoDic.Add(resoDic.Count + 1, "5120x3200")
        resoDic.Add(resoDic.Count + 1, "7680x4800")
        If Not resoDic.ContainsValue(Screen.PrimaryScreen.Bounds.Width & "x" & Screen.PrimaryScreen.Bounds.Height) Then
            resoDic.Add(resoDic.Count + 1, Screen.PrimaryScreen.Bounds.Width & "x" & Screen.PrimaryScreen.Bounds.Height)
        End If
        For Each s As String In resoDic.Values
            Resolutioncmbox.Items.Add(s)
        Next
        Resolutioncmbox.SelectedIndex = Resolutioncmbox.FindStringExact(Screen.PrimaryScreen.Bounds.Width & "x" & Screen.PrimaryScreen.Bounds.Height)
    End Sub
End Class