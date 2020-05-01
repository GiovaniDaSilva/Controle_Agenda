<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.pMenu = New System.Windows.Forms.Panel()
        Me.btnVersaoWeb = New System.Windows.Forms.Button()
        Me.btnGraficoMensal = New System.Windows.Forms.Button()
        Me.btnAbreCausaErros = New System.Windows.Forms.Button()
        Me.pHorasAtividade = New System.Windows.Forms.Panel()
        Me.lblHorasAtividade = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pHorasDia = New System.Windows.Forms.Panel()
        Me.lblHorasDia = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnVersao = New System.Windows.Forms.Button()
        Me.btnApontarHoras = New System.Windows.Forms.Button()
        Me.btnConfiguracao = New System.Windows.Forms.Button()
        Me.btnAbaixarFiltro = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnAtualiza = New System.Windows.Forms.Button()
        Me.btnAdicinar = New System.Windows.Forms.Button()
        Me.pFiltro = New System.Windows.Forms.Panel()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.lblcodigo = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnSubirFiltro = New System.Windows.Forms.Button()
        Me.txtApartirDe = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.TimerAnimacaoMenu = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.menuIconeBandeja = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerNotificacao = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDescricao = New System.Windows.Forms.RichTextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.gridAtividades = New System.Windows.Forms.DataGridView()
        Me.Editar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menuGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirPeriodosDoDiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirAividadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirSolPBIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerControleGeral = New System.Windows.Forms.Timer(Me.components)
        Me.pMenu.SuspendLayout()
        Me.pHorasAtividade.SuspendLayout()
        Me.pHorasDia.SuspendLayout()
        Me.pFiltro.SuspendLayout()
        Me.menuIconeBandeja.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridAtividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'pMenu
        '
        Me.pMenu.Controls.Add(Me.btnVersaoWeb)
        Me.pMenu.Controls.Add(Me.btnGraficoMensal)
        Me.pMenu.Controls.Add(Me.btnAbreCausaErros)
        Me.pMenu.Controls.Add(Me.pHorasAtividade)
        Me.pMenu.Controls.Add(Me.pHorasDia)
        Me.pMenu.Controls.Add(Me.btnVersao)
        Me.pMenu.Controls.Add(Me.btnApontarHoras)
        Me.pMenu.Controls.Add(Me.btnConfiguracao)
        Me.pMenu.Controls.Add(Me.btnAbaixarFiltro)
        Me.pMenu.Controls.Add(Me.btnListar)
        Me.pMenu.Controls.Add(Me.btnAtualiza)
        Me.pMenu.Controls.Add(Me.btnAdicinar)
        Me.pMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pMenu.Location = New System.Drawing.Point(0, 0)
        Me.pMenu.Name = "pMenu"
        Me.pMenu.Size = New System.Drawing.Size(998, 77)
        Me.pMenu.TabIndex = 0
        '
        'btnVersaoWeb
        '
        Me.btnVersaoWeb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVersaoWeb.BackColor = System.Drawing.Color.Gold
        Me.btnVersaoWeb.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnVersaoWeb.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnVersaoWeb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnVersaoWeb.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVersaoWeb.Location = New System.Drawing.Point(494, 15)
        Me.btnVersaoWeb.Name = "btnVersaoWeb"
        Me.btnVersaoWeb.Size = New System.Drawing.Size(95, 50)
        Me.btnVersaoWeb.TabIndex = 11
        Me.btnVersaoWeb.Text = "Versão Web"
        Me.ToolTip1.SetToolTip(Me.btnVersaoWeb, "Versão web em desenvolvimento, se encontrar problemas reporte. Obrigado.")
        Me.btnVersaoWeb.UseVisualStyleBackColor = False
        '
        'btnGraficoMensal
        '
        Me.btnGraficoMensal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGraficoMensal.BackColor = System.Drawing.SystemColors.Control
        Me.btnGraficoMensal.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnGraficoMensal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnGraficoMensal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnGraficoMensal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGraficoMensal.Image = CType(resources.GetObject("btnGraficoMensal.Image"), System.Drawing.Image)
        Me.btnGraficoMensal.Location = New System.Drawing.Point(658, 15)
        Me.btnGraficoMensal.Name = "btnGraficoMensal"
        Me.btnGraficoMensal.Size = New System.Drawing.Size(57, 50)
        Me.btnGraficoMensal.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnGraficoMensal, "Gráfico de Atividades")
        Me.btnGraficoMensal.UseVisualStyleBackColor = False
        '
        'btnAbreCausaErros
        '
        Me.btnAbreCausaErros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbreCausaErros.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbreCausaErros.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnAbreCausaErros.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnAbreCausaErros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAbreCausaErros.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAbreCausaErros.Image = CType(resources.GetObject("btnAbreCausaErros.Image"), System.Drawing.Image)
        Me.btnAbreCausaErros.Location = New System.Drawing.Point(721, 15)
        Me.btnAbreCausaErros.Name = "btnAbreCausaErros"
        Me.btnAbreCausaErros.Size = New System.Drawing.Size(57, 50)
        Me.btnAbreCausaErros.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.btnAbreCausaErros, "Abrir sistema GOVBR Sol Control")
        Me.btnAbreCausaErros.UseVisualStyleBackColor = False
        '
        'pHorasAtividade
        '
        Me.pHorasAtividade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pHorasAtividade.Controls.Add(Me.lblHorasAtividade)
        Me.pHorasAtividade.Controls.Add(Me.Label5)
        Me.pHorasAtividade.Location = New System.Drawing.Point(299, 12)
        Me.pHorasAtividade.Name = "pHorasAtividade"
        Me.pHorasAtividade.Size = New System.Drawing.Size(123, 58)
        Me.pHorasAtividade.TabIndex = 8
        Me.pHorasAtividade.Visible = False
        '
        'lblHorasAtividade
        '
        Me.lblHorasAtividade.AutoSize = True
        Me.lblHorasAtividade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorasAtividade.ForeColor = System.Drawing.Color.Navy
        Me.lblHorasAtividade.Location = New System.Drawing.Point(42, 35)
        Me.lblHorasAtividade.Name = "lblHorasAtividade"
        Me.lblHorasAtividade.Size = New System.Drawing.Size(39, 13)
        Me.lblHorasAtividade.TabIndex = 1
        Me.lblHorasAtividade.Text = "00:00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Total da Atividade"
        '
        'pHorasDia
        '
        Me.pHorasDia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pHorasDia.Controls.Add(Me.lblHorasDia)
        Me.pHorasDia.Controls.Add(Me.Label3)
        Me.pHorasDia.Location = New System.Drawing.Point(201, 12)
        Me.pHorasDia.Name = "pHorasDia"
        Me.pHorasDia.Size = New System.Drawing.Size(92, 58)
        Me.pHorasDia.TabIndex = 3
        '
        'lblHorasDia
        '
        Me.lblHorasDia.AutoSize = True
        Me.lblHorasDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorasDia.ForeColor = System.Drawing.Color.Navy
        Me.lblHorasDia.Location = New System.Drawing.Point(25, 35)
        Me.lblHorasDia.Name = "lblHorasDia"
        Me.lblHorasDia.Size = New System.Drawing.Size(39, 13)
        Me.lblHorasDia.TabIndex = 1
        Me.lblHorasDia.Text = "00:00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total do Dia"
        '
        'btnVersao
        '
        Me.btnVersao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnVersao.BackColor = System.Drawing.SystemColors.Control
        Me.btnVersao.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnVersao.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnVersao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnVersao.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVersao.Image = CType(resources.GetObject("btnVersao.Image"), System.Drawing.Image)
        Me.btnVersao.Location = New System.Drawing.Point(138, 15)
        Me.btnVersao.Name = "btnVersao"
        Me.btnVersao.Size = New System.Drawing.Size(57, 50)
        Me.btnVersao.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnVersao, "Novidades")
        Me.btnVersao.UseVisualStyleBackColor = False
        '
        'btnApontarHoras
        '
        Me.btnApontarHoras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApontarHoras.BackColor = System.Drawing.SystemColors.Control
        Me.btnApontarHoras.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnApontarHoras.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnApontarHoras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnApontarHoras.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnApontarHoras.Image = CType(resources.GetObject("btnApontarHoras.Image"), System.Drawing.Image)
        Me.btnApontarHoras.Location = New System.Drawing.Point(784, 15)
        Me.btnApontarHoras.Name = "btnApontarHoras"
        Me.btnApontarHoras.Size = New System.Drawing.Size(57, 50)
        Me.btnApontarHoras.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnApontarHoras, "Abrir Apontamento de Horas")
        Me.btnApontarHoras.UseVisualStyleBackColor = False
        '
        'btnConfiguracao
        '
        Me.btnConfiguracao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfiguracao.BackColor = System.Drawing.SystemColors.Control
        Me.btnConfiguracao.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnConfiguracao.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnConfiguracao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnConfiguracao.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfiguracao.Image = CType(resources.GetObject("btnConfiguracao.Image"), System.Drawing.Image)
        Me.btnConfiguracao.Location = New System.Drawing.Point(75, 15)
        Me.btnConfiguracao.Name = "btnConfiguracao"
        Me.btnConfiguracao.Size = New System.Drawing.Size(57, 50)
        Me.btnConfiguracao.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnConfiguracao, "Configurações")
        Me.btnConfiguracao.UseVisualStyleBackColor = False
        '
        'btnAbaixarFiltro
        '
        Me.btnAbaixarFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbaixarFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbaixarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnAbaixarFiltro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnAbaixarFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAbaixarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAbaixarFiltro.Image = CType(resources.GetObject("btnAbaixarFiltro.Image"), System.Drawing.Image)
        Me.btnAbaixarFiltro.Location = New System.Drawing.Point(12, 15)
        Me.btnAbaixarFiltro.Name = "btnAbaixarFiltro"
        Me.btnAbaixarFiltro.Size = New System.Drawing.Size(57, 50)
        Me.btnAbaixarFiltro.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAbaixarFiltro, "Abrir Filtro")
        Me.btnAbaixarFiltro.UseVisualStyleBackColor = False
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
        Me.btnListar.Image = CType(resources.GetObject("btnListar.Image"), System.Drawing.Image)
        Me.btnListar.Location = New System.Drawing.Point(847, 15)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(57, 50)
        Me.btnListar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnListar, "Listar Atividades")
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
        Me.btnAtualiza.Location = New System.Drawing.Point(595, 15)
        Me.btnAtualiza.Name = "btnAtualiza"
        Me.btnAtualiza.Size = New System.Drawing.Size(57, 50)
        Me.btnAtualiza.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnAtualiza, "Atualizar")
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
        Me.btnAdicinar.Location = New System.Drawing.Point(929, 15)
        Me.btnAdicinar.Name = "btnAdicinar"
        Me.btnAdicinar.Size = New System.Drawing.Size(57, 50)
        Me.btnAdicinar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnAdicinar, "Cadastrar Atividade")
        Me.btnAdicinar.UseVisualStyleBackColor = False
        '
        'pFiltro
        '
        Me.pFiltro.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pFiltro.Controls.Add(Me.cbTipo)
        Me.pFiltro.Controls.Add(Me.Label2)
        Me.pFiltro.Controls.Add(Me.txtCodigo)
        Me.pFiltro.Controls.Add(Me.lblcodigo)
        Me.pFiltro.Controls.Add(Me.btnFiltrar)
        Me.pFiltro.Controls.Add(Me.btnSubirFiltro)
        Me.pFiltro.Controls.Add(Me.txtApartirDe)
        Me.pFiltro.Controls.Add(Me.Label1)
        Me.pFiltro.Controls.Add(Me.btnLimpar)
        Me.pFiltro.Location = New System.Drawing.Point(112, 83)
        Me.pFiltro.Name = "pFiltro"
        Me.pFiltro.Size = New System.Drawing.Size(823, 77)
        Me.pFiltro.TabIndex = 4
        Me.pFiltro.Visible = False
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
        Me.cbTipo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(352, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tipo"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Location = New System.Drawing.Point(230, 33)
        Me.txtCodigo.Mask = "0000000"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(82, 20)
        Me.txtCodigo.TabIndex = 4
        Me.txtCodigo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCodigo.ValidatingType = GetType(Integer)
        '
        'lblcodigo
        '
        Me.lblcodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblcodigo.AutoSize = True
        Me.lblcodigo.Location = New System.Drawing.Point(227, 17)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblcodigo.TabIndex = 3
        Me.lblcodigo.Text = "Código"
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
        Me.btnFiltrar.Location = New System.Drawing.Point(754, 17)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 50)
        Me.btnFiltrar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.btnFiltrar, "Aplicar Filtro")
        Me.btnFiltrar.UseVisualStyleBackColor = False
        '
        'btnSubirFiltro
        '
        Me.btnSubirFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSubirFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.btnSubirFiltro.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnSubirFiltro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal
        Me.btnSubirFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSubirFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubirFiltro.Image = CType(resources.GetObject("btnSubirFiltro.Image"), System.Drawing.Image)
        Me.btnSubirFiltro.Location = New System.Drawing.Point(12, 17)
        Me.btnSubirFiltro.Name = "btnSubirFiltro"
        Me.btnSubirFiltro.Size = New System.Drawing.Size(57, 50)
        Me.btnSubirFiltro.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnSubirFiltro, "Fechar Filtro")
        Me.btnSubirFiltro.UseVisualStyleBackColor = False
        '
        'txtApartirDe
        '
        Me.txtApartirDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtApartirDe.Location = New System.Drawing.Point(101, 33)
        Me.txtApartirDe.Mask = "00/00/0000"
        Me.txtApartirDe.Name = "txtApartirDe"
        Me.txtApartirDe.Size = New System.Drawing.Size(80, 20)
        Me.txtApartirDe.TabIndex = 2
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
        Me.Label1.TabIndex = 1
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
        Me.btnLimpar.Location = New System.Drawing.Point(681, 17)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(57, 50)
        Me.btnLimpar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnLimpar, "Limpar Filtro")
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'TimerAnimacaoMenu
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.menuIconeBandeja
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Agenda"
        Me.NotifyIcon1.Visible = True
        '
        'menuIconeBandeja
        '
        Me.menuIconeBandeja.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.ToolStripMenuItem1, Me.SairToolStripMenuItem})
        Me.menuIconeBandeja.Name = "ContextMenuStrip1"
        Me.menuIconeBandeja.Size = New System.Drawing.Size(101, 54)
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(97, 6)
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'TimerNotificacao
        '
        Me.TimerNotificacao.Interval = 10800000
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txtDescricao)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.gridAtividades)
        Me.Panel1.Location = New System.Drawing.Point(10, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(977, 556)
        Me.Panel1.TabIndex = 5
        '
        'txtDescricao
        '
        Me.txtDescricao.BackColor = System.Drawing.Color.Linen
        Me.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescricao.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricao.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtDescricao.HideSelection = False
        Me.txtDescricao.Location = New System.Drawing.Point(0, 338)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtDescricao.Size = New System.Drawing.Size(977, 218)
        Me.txtDescricao.TabIndex = 6
        Me.txtDescricao.Tag = ""
        Me.txtDescricao.Text = ""
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 328)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(977, 10)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = False
        '
        'gridAtividades
        '
        Me.gridAtividades.AllowUserToAddRows = False
        Me.gridAtividades.AllowUserToDeleteRows = False
        Me.gridAtividades.AllowUserToResizeColumns = False
        Me.gridAtividades.AllowUserToResizeRows = False
        Me.gridAtividades.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridAtividades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAtividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Editar})
        Me.gridAtividades.ContextMenuStrip = Me.menuGrid
        Me.gridAtividades.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAtividades.Location = New System.Drawing.Point(0, 0)
        Me.gridAtividades.MultiSelect = False
        Me.gridAtividades.Name = "gridAtividades"
        Me.gridAtividades.ReadOnly = True
        Me.gridAtividades.RowHeadersVisible = False
        Me.gridAtividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridAtividades.Size = New System.Drawing.Size(977, 328)
        Me.gridAtividades.TabIndex = 4
        '
        'Editar
        '
        Me.Editar.HeaderText = ""
        Me.Editar.Image = CType(resources.GetObject("Editar.Image"), System.Drawing.Image)
        Me.Editar.Name = "Editar"
        Me.Editar.ReadOnly = True
        Me.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'menuGrid
        '
        Me.menuGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirPeriodosDoDiaToolStripMenuItem, Me.ImprimirAividadeToolStripMenuItem, Me.AbrirSolPBIToolStripMenuItem})
        Me.menuGrid.Name = "menuGrid"
        Me.menuGrid.Size = New System.Drawing.Size(240, 70)
        '
        'ImprimirPeriodosDoDiaToolStripMenuItem
        '
        Me.ImprimirPeriodosDoDiaToolStripMenuItem.Name = "ImprimirPeriodosDoDiaToolStripMenuItem"
        Me.ImprimirPeriodosDoDiaToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ImprimirPeriodosDoDiaToolStripMenuItem.Text = "Imprimir Periodos do Dia"
        '
        'ImprimirAividadeToolStripMenuItem
        '
        Me.ImprimirAividadeToolStripMenuItem.Name = "ImprimirAividadeToolStripMenuItem"
        Me.ImprimirAividadeToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ImprimirAividadeToolStripMenuItem.Text = "Imprimir Atividade (Alt + Click)"
        '
        'AbrirSolPBIToolStripMenuItem
        '
        Me.AbrirSolPBIToolStripMenuItem.Name = "AbrirSolPBIToolStripMenuItem"
        Me.AbrirSolPBIToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.AbrirSolPBIToolStripMenuItem.Text = "Abrir Sol/PBI (Ctrl + Click)"
        '
        'TimerControleGeral
        '
        Me.TimerControleGeral.Interval = 7200000
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(998, 654)
        Me.Controls.Add(Me.pFiltro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda - Versão "
        Me.pMenu.ResumeLayout(false)
        Me.pHorasAtividade.ResumeLayout(false)
        Me.pHorasAtividade.PerformLayout
        Me.pHorasDia.ResumeLayout(false)
        Me.pHorasDia.PerformLayout
        Me.pFiltro.ResumeLayout(false)
        Me.pFiltro.PerformLayout
        Me.menuIconeBandeja.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        CType(Me.gridAtividades,System.ComponentModel.ISupportInitialize).EndInit
        Me.menuGrid.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents pMenu As Panel
    Friend WithEvents btnAdicinar As Button
    Friend WithEvents btnAtualiza As Button
    Friend WithEvents btnListar As Button
    Friend WithEvents pFiltro As Panel
    Friend WithEvents btnAbaixarFiltro As Button
    Friend WithEvents txtApartirDe As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnSubirFiltro As Button
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents lblcodigo As Label
    Friend WithEvents txtCodigo As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTipo As ComboBox
    Friend WithEvents btnConfiguracao As Button
    Friend WithEvents TimerAnimacaoMenu As Timer
    Friend WithEvents btnApontarHoras As Button
    Friend WithEvents btnVersao As Button
    Friend WithEvents pHorasDia As Panel
    Friend WithEvents lblHorasDia As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents menuIconeBandeja As ContextMenuStrip
    Friend WithEvents AbrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimerNotificacao As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pHorasAtividade As Panel
    Friend WithEvents lblHorasAtividade As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAbreCausaErros As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtDescricao As RichTextBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents gridAtividades As DataGridView
    Friend WithEvents Editar As DataGridViewImageColumn
    Friend WithEvents btnGraficoMensal As Button
    Friend WithEvents menuGrid As ContextMenuStrip
    Friend WithEvents ImprimirPeriodosDoDiaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirAividadeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbrirSolPBIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnVersaoWeb As Button
    Friend WithEvents TimerControleGeral As Timer
End Class
