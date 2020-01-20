<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdicionar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdicionar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPeriodo = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pCamposMoveis = New System.Windows.Forms.Panel()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.txtDescrição = New System.Windows.Forms.RichTextBox()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.gbPeriodo.SuspendLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pCamposMoveis.SuspendLayout
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(26, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(29, 35)
        Me.txtData.Mask = "00/00/0000"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(81, 20)
        Me.txtData.TabIndex = 1
        Me.txtData.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtData.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(136, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo"
        '
        'cbTipo
        '
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbTipo.FormattingEnabled = true
        Me.cbTipo.Location = New System.Drawing.Point(139, 35)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(136, 21)
        Me.cbTipo.TabIndex = 3
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = true
        Me.lblCodigo.Location = New System.Drawing.Point(312, 18)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 4
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(315, 35)
        Me.txtCodigo.Mask = "0000000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(82, 20)
        Me.txtCodigo.TabIndex = 5
        Me.txtCodigo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCodigo.ValidatingType = GetType(Integer)
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(419, 36)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(55, 20)
        Me.txtHora.TabIndex = 7
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(416, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Horas trabalhadas:"
        '
        'gbPeriodo
        '
        Me.gbPeriodo.Controls.Add(Me.Button1)
        Me.gbPeriodo.Controls.Add(Me.Label5)
        Me.gbPeriodo.Controls.Add(Me.Label4)
        Me.gbPeriodo.Controls.Add(Me.MaskedTextBox2)
        Me.gbPeriodo.Controls.Add(Me.MaskedTextBox1)
        Me.gbPeriodo.Controls.Add(Me.DataGridView1)
        Me.gbPeriodo.Location = New System.Drawing.Point(29, 76)
        Me.gbPeriodo.Name = "gbPeriodo"
        Me.gbPeriodo.Size = New System.Drawing.Size(501, 149)
        Me.gbPeriodo.TabIndex = 8
        Me.gbPeriodo.TabStop = false
        Me.gbPeriodo.Text = "Período"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(183, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(300, 119)
        Me.DataGridView1.TabIndex = 5
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(38, 39)
        Me.MaskedTextBox1.Mask = "00:00"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(55, 20)
        Me.MaskedTextBox1.TabIndex = 1
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Location = New System.Drawing.Point(108, 39)
        Me.MaskedTextBox2.Mask = "00:00"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(57, 20)
        Me.MaskedTextBox2.TabIndex = 3
        Me.MaskedTextBox2.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(38, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "De:"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(105, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Até:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"),System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(108, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 50)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = false
        '
        'pCamposMoveis
        '
        Me.pCamposMoveis.Controls.Add(Me.btnExcluir)
        Me.pCamposMoveis.Controls.Add(Me.txtDescrição)
        Me.pCamposMoveis.Controls.Add(Me.btnLimpar)
        Me.pCamposMoveis.Controls.Add(Me.btnGravar)
        Me.pCamposMoveis.Controls.Add(Me.lblDescricao)
        Me.pCamposMoveis.Location = New System.Drawing.Point(12, 231)
        Me.pCamposMoveis.Name = "pCamposMoveis"
        Me.pCamposMoveis.Size = New System.Drawing.Size(539, 250)
        Me.pCamposMoveis.TabIndex = 9
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"),System.Drawing.Image)
        Me.btnExcluir.Location = New System.Drawing.Point(464, 185)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(57, 50)
        Me.btnExcluir.TabIndex = 4
        Me.btnExcluir.UseVisualStyleBackColor = false
        Me.btnExcluir.Visible = false
        '
        'txtDescrição
        '
        Me.txtDescrição.BackColor = System.Drawing.Color.Linen
        Me.txtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescrição.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtDescrição.Location = New System.Drawing.Point(17, 26)
        Me.txtDescrição.Name = "txtDescrição"
        Me.txtDescrição.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtDescrição.Size = New System.Drawing.Size(501, 153)
        Me.txtDescrição.TabIndex = 1
        Me.txtDescrição.Text = ""
        '
        'btnLimpar
        '
        Me.btnLimpar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"),System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(83, 185)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(57, 50)
        Me.btnLimpar.TabIndex = 3
        Me.btnLimpar.UseVisualStyleBackColor = false
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"),System.Drawing.Image)
        Me.btnGravar.Location = New System.Drawing.Point(17, 185)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(57, 50)
        Me.btnGravar.TabIndex = 2
        Me.btnGravar.UseVisualStyleBackColor = false
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = true
        Me.lblDescricao.Location = New System.Drawing.Point(14, 10)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(55, 13)
        Me.lblDescricao.TabIndex = 0
        Me.lblDescricao.Text = "Descrição"
        '
        'frmAdicionar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(563, 493)
        Me.Controls.Add(Me.pCamposMoveis)
        Me.Controls.Add(Me.gbPeriodo)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.cbTipo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "frmAdicionar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adicionar Nova Atividade"
        Me.gbPeriodo.ResumeLayout(false)
        Me.gbPeriodo.PerformLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.pCamposMoveis.ResumeLayout(false)
        Me.pCamposMoveis.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtData As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As MaskedTextBox
    Friend WithEvents txtHora As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbTipo As ComboBox
    Friend WithEvents gbPeriodo As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents MaskedTextBox2 As MaskedTextBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents pCamposMoveis As Panel
    Friend WithEvents btnExcluir As Button
    Friend WithEvents txtDescrição As RichTextBox
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents lblDescricao As Label
End Class
