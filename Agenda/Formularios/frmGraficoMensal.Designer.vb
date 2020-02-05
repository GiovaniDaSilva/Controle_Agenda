<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraficoMensal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraficoMensal))
        Me.txtDataInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'txtDataInicial
        '
        Me.txtDataInicial.Location = New System.Drawing.Point(23, 36)
        Me.txtDataInicial.Mask = "00/00/0000"
        Me.txtDataInicial.Name = "txtDataInicial"
        Me.txtDataInicial.Size = New System.Drawing.Size(81, 20)
        Me.txtDataInicial.TabIndex = 3
        Me.txtDataInicial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDataInicial.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(20, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Data inicial"
        '
        'txtDataFinal
        '
        Me.txtDataFinal.Location = New System.Drawing.Point(163, 36)
        Me.txtDataFinal.Mask = "00/00/0000"
        Me.txtDataFinal.Name = "txtDataFinal"
        Me.txtDataFinal.Size = New System.Drawing.Size(81, 20)
        Me.txtDataFinal.TabIndex = 5
        Me.txtDataFinal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDataFinal.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(160, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data Final"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"),System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(23, 84)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(57, 50)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.UseVisualStyleBackColor = false
        '
        'frmGraficoMensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(316, 146)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtDataFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDataInicial)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmGraficoMensal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gráfico de Atividades"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtDataInicial As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataFinal As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnImprimir As Button
End Class
