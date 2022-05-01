<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResolutionEditor
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResolutionEditor))
        Me.Savebtn = New System.Windows.Forms.Button()
        Me.WindowModechkbx = New System.Windows.Forms.CheckBox()
        Me.Resolutioncmbox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Savebtn
        '
        Me.Savebtn.Location = New System.Drawing.Point(267, 10)
        Me.Savebtn.Name = "Savebtn"
        Me.Savebtn.Size = New System.Drawing.Size(75, 23)
        Me.Savebtn.TabIndex = 0
        Me.Savebtn.Text = "Save"
        Me.Savebtn.UseVisualStyleBackColor = True
        '
        'WindowModechkbx
        '
        Me.WindowModechkbx.AutoSize = True
        Me.WindowModechkbx.Location = New System.Drawing.Point(12, 14)
        Me.WindowModechkbx.Name = "WindowModechkbx"
        Me.WindowModechkbx.Size = New System.Drawing.Size(95, 17)
        Me.WindowModechkbx.TabIndex = 1
        Me.WindowModechkbx.Text = "Window Mode"
        Me.WindowModechkbx.UseVisualStyleBackColor = True
        '
        'Resolutioncmbox
        '
        Me.Resolutioncmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Resolutioncmbox.FormattingEnabled = True
        Me.Resolutioncmbox.Location = New System.Drawing.Point(127, 12)
        Me.Resolutioncmbox.Name = "Resolutioncmbox"
        Me.Resolutioncmbox.Size = New System.Drawing.Size(121, 21)
        Me.Resolutioncmbox.TabIndex = 2
        '
        'ResolutionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 46)
        Me.Controls.Add(Me.Resolutioncmbox)
        Me.Controls.Add(Me.WindowModechkbx)
        Me.Controls.Add(Me.Savebtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ResolutionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ResolutionEditor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Savebtn As System.Windows.Forms.Button
    Friend WithEvents WindowModechkbx As System.Windows.Forms.CheckBox
    Friend WithEvents Resolutioncmbox As System.Windows.Forms.ComboBox
End Class
