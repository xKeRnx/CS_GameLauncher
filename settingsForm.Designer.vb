<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settingsForm))
        Me.repatchbtn = New System.Windows.Forms.Button()
        Me.resolutionbtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'repatchbtn
        '
        Me.repatchbtn.Location = New System.Drawing.Point(12, 12)
        Me.repatchbtn.Name = "repatchbtn"
        Me.repatchbtn.Size = New System.Drawing.Size(75, 23)
        Me.repatchbtn.TabIndex = 0
        Me.repatchbtn.Text = "Repatch"
        Me.repatchbtn.UseVisualStyleBackColor = True
        '
        'resolutionbtn
        '
        Me.resolutionbtn.Location = New System.Drawing.Point(142, 12)
        Me.resolutionbtn.Name = "resolutionbtn"
        Me.resolutionbtn.Size = New System.Drawing.Size(75, 23)
        Me.resolutionbtn.TabIndex = 1
        Me.resolutionbtn.Text = "Resolution"
        Me.resolutionbtn.UseVisualStyleBackColor = True
        '
        'settingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(229, 43)
        Me.Controls.Add(Me.resolutionbtn)
        Me.Controls.Add(Me.repatchbtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "settingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Launcher Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents repatchbtn As System.Windows.Forms.Button
    Friend WithEvents resolutionbtn As System.Windows.Forms.Button
End Class
