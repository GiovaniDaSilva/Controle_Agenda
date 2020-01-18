<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.gridAtividades = New System.Windows.Forms.DataGridView()
        Me.Editar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pMenu = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnAtualiza = New System.Windows.Forms.Button()
        Me.btnAdicinar = New System.Windows.Forms.Button()
        Me.txtDescricao = New System.Windows.Forms.RichTextBox()
        Me.pFiltro = New System.Windows.Forms.Panel()
        Me.txtApartirDe = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.lblcodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        CType(Me.gridAtividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pMenu.SuspendLayout()
        Me.pFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridAtividades
        '
        Me.gridAtividades.AllowUserToAddRows = False
        Me.gridAtividades.AllowUserToDeleteRows = False
        Me.gridAtividades.AllowUserToResizeColumns = False
        Me.gridAtividades.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridAtividades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAtividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Editar})
        Me.gridAtividades.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAtividades.Location = New System.Drawing.Point(0, 77)
        Me.gridAtividades.Name = "gridAtividades"
        Me.gridAtividades.ReadOnly = True
        Me.gridAtividades.Size = New System.Drawing.Size(823, 205)
        Me.gridAtividades.TabIndex = 1
        '
        'Editar
        '
        Me.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Editar.HeaderText = "Editar"
        Me.Editar.Name = "Editar"
        Me.Editar.ReadOnly = True
        Me.Editar.Text = "Editar"
        Me.Editar.UseColumnTextForButtonValue = True
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 282)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(823, 14)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'pMenu
        '
        Me.pMenu.Controls.Add(Me.Button1)
        Me.pMenu.Controls.Add(Me.btnListar)
        Me.pMenu.Controls.Add(Me.btnAtualiza)
        Me.pMenu.Controls.Add(Me.btnAdicinar)
        Me.pMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pMenu.Location = New System.Drawing.Point(0, 0)
        Me.pMenu.Name = "pMenu"
        Me.pMenu.Size = New System.Drawing.Size(823, 77)
        Me.pMenu.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(12, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 50)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnListar
        '
        Me.btnListar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListar.BackColor = System.Drawing.SystemColors.Control
        Me.btnListar.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnListar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnListar.Location = New System.Drawing.Point(555, 15)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(75, 23)
        Me.btnListar.TabIndex = 5
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = False
        '
        'btnAtualiza
        '
        Me.btnAtualiza.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAtualiza.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtualiza.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnAtualiza.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnAtualiza.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAtualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAtualiza.Image = CType(resources.GetObject("btnAtualiza.Image"), System.Drawing.Image)
        Me.btnAtualiza.Location = New System.Drawing.Point(636, 15)
        Me.btnAtualiza.Name = "btnAtualiza"
        Me.btnAtualiza.Size = New System.Drawing.Size(57, 50)
        Me.btnAtualiza.TabIndex = 4
        Me.btnAtualiza.UseVisualStyleBackColor = False
        '
        'btnAdicinar
        '
        Me.btnAdicinar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdicinar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdicinar.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnAdicinar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnAdicinar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAdicinar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdicinar.Image = CType(resources.GetObject("btnAdicinar.Image"), System.Drawing.Image)
        Me.btnAdicinar.Location = New System.Drawing.Point(754, 15)
        Me.btnAdicinar.Name = "btnAdicinar"
        Me.btnAdicinar.Size = New System.Drawing.Size(57, 50)
        Me.btnAdicinar.TabIndex = 3
        Me.btnAdicinar.UseVisualStyleBackColor = False
        '
        'txtDescricao
        '
        Me.txtDescricao.BackColor = System.Drawing.Color.Linen
        Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescricao.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtDescricao.Location = New System.Drawing.Point(0, 296)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtDescricao.Size = New System.Drawing.Size(823, 272)
        Me.txtDescricao.TabIndex = 5
        Me.txtDescricao.Text = ""
        '
        'pFiltro
        '
        Me.pFiltro.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pFiltro.Controls.Add(Me.cbTipo)
        Me.pFiltro.Controls.Add(Me.Label2)
        Me.pFiltro.Controls.Add(Me.txtCodigo)
        Me.pFiltro.Controls.Add(Me.lblcodigo)
        Me.pFiltro.Controls.Add(Me.btnFiltrar)
        Me.pFiltro.Controls.Add(Me.Button2)
        Me.pFiltro.Controls.Add(Me.txtApartirDe)
        Me.pFiltro.Controls.Add(Me.Label1)
        Me.pFiltro.Controls.Add(Me.btnLimpar)
        Me.pFiltro.Location = New System.Drawing.Point(0, 151)
        Me.pFiltro.Name = "pFiltro"
        Me.pFiltro.Size = New System.Drawing.Size(823, 77)
        Me.pFiltro.TabIndex = 7
        Me.pFiltro.Visible = False
        '
        'txtApartirDe
        '
        Me.txtApartirDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtApartirDe.Location = New System.Drawing.Point(101, 33)
        Me.txtApartirDe.Mask = "00/00/0000"
        Me.txtApartirDe.Name = "txtApartirDe"
        Me.txtApartirDe.Size = New System.Drawing.Size(80, 20)
        Me.txtApartirDe.TabIndex = 9
        Me.txtApartirDe.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtApartirDe.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "A partir de:"
        '
        'btnLimpar
        '
        Me.btnLimpar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnLimpar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(754, 17)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(57, 50)
        Me.btnLimpar.TabIndex = 7
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(12, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 50)
        Me.Button2.TabIndex = 10
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnFiltrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.Location = New System.Drawing.Point(691, 17)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 50)
        Me.btnFiltrar.TabIndex = 11
        Me.btnFiltrar.UseVisualStyleBackColor = False
        '
        'lblcodigo
        '
        Me.lblcodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblcodigo.AutoSize = True
        Me.lblcodigo.Location = New System.Drawing.Point(227, 17)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblcodigo.TabIndex = 12
        Me.lblcodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Location = New System.Drawing.Point(230, 33)
        Me.txtCodigo.Mask = "0000000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(82, 20)
        Me.txtCodigo.TabIndex = 13
        Me.txtCodigo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCodigo.ValidatingType = GetType(Integer)
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(352, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Tipo"
        '
        'cbTipo
        '
        Me.cbTipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(355, 33)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(136, 21)
        Me.cbTipo.TabIndex = 16
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(823, 568)
        Me.Controls.Add(Me.pFiltro)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.gridAtividades)
        Me.Controls.Add(Me.pMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda - Versão 0.1 - BETA"
        CType(Me.gridAtividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pMenu.ResumeLayout(False)
        Me.pFiltro.ResumeLayout(False)
        Me.pFiltro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridAtividades As DataGridView
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents pMenu As Panel
    Friend WithEvents btnAdicinar As Button
    Friend WithEvents btnAtualiza As Button
    Friend WithEvents btnListar As Button
    Friend WithEvents txtDescricao As RichTextBox
    Friend WithEvents Editar As DataGridViewButtonColumn
    Friend WithEvents pFiltro As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents txtApartirDe As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents lblcodigo As Label
    Friend WithEvents txtCodigo As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTipo As ComboBox
End Class
