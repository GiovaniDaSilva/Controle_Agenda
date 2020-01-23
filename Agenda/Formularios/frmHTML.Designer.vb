<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHTML
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHTML))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btAbriSistemaSol = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 55)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RichTextBox1.Size = New System.Drawing.Size(637, 361)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Location = New System.Drawing.Point(285, 424)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 58)
        Me.btnOK.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnOK, "Prosseguir para Impressão")
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(637, 37)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "- Com a consulta de Solicitações carregada, clique com o botão direito e vá para " &
    "Exibir Código Fonte. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Copie todo o conteudo e cole abaixo."
        '
        'btAbriSistemaSol
        '
        Me.btAbriSistemaSol.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btAbriSistemaSol.BackColor = System.Drawing.SystemColors.Control
        Me.btAbriSistemaSol.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAbriSistemaSol.Image = CType(resources.GetObject("btAbriSistemaSol.Image"), System.Drawing.Image)
        Me.btAbriSistemaSol.Location = New System.Drawing.Point(12, 424)
        Me.btAbriSistemaSol.Name = "btAbriSistemaSol"
        Me.btAbriSistemaSol.Size = New System.Drawing.Size(75, 58)
        Me.btAbriSistemaSol.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btAbriSistemaSol, "Abrir Consulta de Solicitações")
        Me.btAbriSistemaSol.UseVisualStyleBackColor = False
        '
        'frmHTML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(661, 494)
        Me.Controls.Add(Me.btAbriSistemaSol)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHTML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe o HTML da Consulta de Solicitações"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btAbriSistemaSol As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
