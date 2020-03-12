<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfiguracoes
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracoes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbTempoNotificacao = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbPeriodo = New System.Windows.Forms.RadioButton()
        Me.rbHorasTrabalhadas = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbSeteDias = New System.Windows.Forms.RadioButton()
        Me.rbDataAtual = New System.Windows.Forms.RadioButton()
        Me.rbEmbranco = New System.Windows.Forms.RadioButton()
        Me.cbInicializarWindows = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCaminhoBase = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbNaoHTML = New System.Windows.Forms.RadioButton()
        Me.rbSimHTML = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbDecrescente = New System.Windows.Forms.RadioButton()
        Me.rbCrescente = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnExecutarBackup = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeAtividadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbTempoNotificacao)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.cbInicializarWindows)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 141)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Geral"
        '
        'cbTempoNotificacao
        '
        Me.cbTempoNotificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTempoNotificacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbTempoNotificacao.FormattingEnabled = True
        Me.cbTempoNotificacao.Items.AddRange(New Object() {"1 Hora", "2 Horas", "3 Horas", "4 Horas", "Não Usar"})
        Me.cbTempoNotificacao.Location = New System.Drawing.Point(16, 65)
        Me.cbTempoNotificacao.Name = "cbTempoNotificacao"
        Me.cbTempoNotificacao.Size = New System.Drawing.Size(136, 21)
        Me.cbTempoNotificacao.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tempo Entre as Notificações"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbPeriodo)
        Me.GroupBox6.Controls.Add(Me.rbHorasTrabalhadas)
        Me.GroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox6.Location = New System.Drawing.Point(256, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(295, 43)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Atividades por"
        '
        'rbPeriodo
        '
        Me.rbPeriodo.AutoSize = True
        Me.rbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbPeriodo.Location = New System.Drawing.Point(199, 19)
        Me.rbPeriodo.Name = "rbPeriodo"
        Me.rbPeriodo.Size = New System.Drawing.Size(62, 17)
        Me.rbPeriodo.TabIndex = 2
        Me.rbPeriodo.Text = "Período"
        Me.rbPeriodo.UseVisualStyleBackColor = True
        '
        'rbHorasTrabalhadas
        '
        Me.rbHorasTrabalhadas.AutoSize = True
        Me.rbHorasTrabalhadas.Checked = True
        Me.rbHorasTrabalhadas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbHorasTrabalhadas.Location = New System.Drawing.Point(69, 19)
        Me.rbHorasTrabalhadas.Name = "rbHorasTrabalhadas"
        Me.rbHorasTrabalhadas.Size = New System.Drawing.Size(110, 17)
        Me.rbHorasTrabalhadas.TabIndex = 1
        Me.rbHorasTrabalhadas.TabStop = True
        Me.rbHorasTrabalhadas.Text = "Horas trabalhadas"
        Me.rbHorasTrabalhadas.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbSeteDias)
        Me.GroupBox4.Controls.Add(Me.rbDataAtual)
        Me.GroupBox4.Controls.Add(Me.rbEmbranco)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox4.Location = New System.Drawing.Point(256, 68)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(295, 56)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Inicializar com campo A partir de"
        '
        'rbSeteDias
        '
        Me.rbSeteDias.AutoSize = True
        Me.rbSeteDias.Checked = True
        Me.rbSeteDias.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbSeteDias.Location = New System.Drawing.Point(189, 26)
        Me.rbSeteDias.Name = "rbSeteDias"
        Me.rbSeteDias.Size = New System.Drawing.Size(89, 17)
        Me.rbSeteDias.TabIndex = 2
        Me.rbSeteDias.TabStop = True
        Me.rbSeteDias.Text = "Ultimos 7 dias"
        Me.rbSeteDias.UseVisualStyleBackColor = True
        '
        'rbDataAtual
        '
        Me.rbDataAtual.AutoSize = True
        Me.rbDataAtual.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbDataAtual.Location = New System.Drawing.Point(109, 26)
        Me.rbDataAtual.Name = "rbDataAtual"
        Me.rbDataAtual.Size = New System.Drawing.Size(74, 17)
        Me.rbDataAtual.TabIndex = 1
        Me.rbDataAtual.Text = "Data Atual"
        Me.rbDataAtual.UseVisualStyleBackColor = True
        '
        'rbEmbranco
        '
        Me.rbEmbranco.AutoSize = True
        Me.rbEmbranco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbEmbranco.Location = New System.Drawing.Point(27, 26)
        Me.rbEmbranco.Name = "rbEmbranco"
        Me.rbEmbranco.Size = New System.Drawing.Size(76, 17)
        Me.rbEmbranco.TabIndex = 0
        Me.rbEmbranco.Text = "Em Branco"
        Me.rbEmbranco.UseVisualStyleBackColor = True
        '
        'cbInicializarWindows
        '
        Me.cbInicializarWindows.AutoSize = True
        Me.cbInicializarWindows.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbInicializarWindows.Location = New System.Drawing.Point(16, 19)
        Me.cbInicializarWindows.Name = "cbInicializarWindows"
        Me.cbInicializarWindows.Size = New System.Drawing.Size(192, 17)
        Me.cbInicializarWindows.TabIndex = 1
        Me.cbInicializarWindows.Text = "Inicializar aplicação com o windows"
        Me.cbInicializarWindows.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCaminhoBase)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(12, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 144)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dados"
        '
        'txtCaminhoBase
        '
        Me.txtCaminhoBase.Location = New System.Drawing.Point(32, 110)
        Me.txtCaminhoBase.Name = "txtCaminhoBase"
        Me.txtCaminhoBase.Size = New System.Drawing.Size(662, 20)
        Me.txtCaminhoBase.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Caminho da base:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbNaoHTML)
        Me.GroupBox5.Controls.Add(Me.rbSimHTML)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox5.Location = New System.Drawing.Point(443, 31)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(251, 51)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Solicitar HTML ao imprimir atividades?"
        '
        'rbNaoHTML
        '
        Me.rbNaoHTML.AutoSize = True
        Me.rbNaoHTML.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbNaoHTML.Location = New System.Drawing.Point(155, 25)
        Me.rbNaoHTML.Name = "rbNaoHTML"
        Me.rbNaoHTML.Size = New System.Drawing.Size(44, 17)
        Me.rbNaoHTML.TabIndex = 1
        Me.rbNaoHTML.Text = "Não"
        Me.rbNaoHTML.UseVisualStyleBackColor = True
        '
        'rbSimHTML
        '
        Me.rbSimHTML.AutoSize = True
        Me.rbSimHTML.Checked = True
        Me.rbSimHTML.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbSimHTML.Location = New System.Drawing.Point(73, 25)
        Me.rbSimHTML.Name = "rbSimHTML"
        Me.rbSimHTML.Size = New System.Drawing.Size(41, 17)
        Me.rbSimHTML.TabIndex = 0
        Me.rbSimHTML.TabStop = True
        Me.rbSimHTML.Text = "Sim"
        Me.rbSimHTML.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbDecrescente)
        Me.GroupBox3.Controls.Add(Me.rbCrescente)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox3.Location = New System.Drawing.Point(32, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(251, 51)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ordenação das atividades por data"
        '
        'rbDecrescente
        '
        Me.rbDecrescente.AutoSize = True
        Me.rbDecrescente.Checked = True
        Me.rbDecrescente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbDecrescente.Location = New System.Drawing.Point(155, 25)
        Me.rbDecrescente.Name = "rbDecrescente"
        Me.rbDecrescente.Size = New System.Drawing.Size(85, 17)
        Me.rbDecrescente.TabIndex = 1
        Me.rbDecrescente.TabStop = True
        Me.rbDecrescente.Text = "Decrescente"
        Me.rbDecrescente.UseVisualStyleBackColor = True
        '
        'rbCrescente
        '
        Me.rbCrescente.AutoSize = True
        Me.rbCrescente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbCrescente.Location = New System.Drawing.Point(44, 25)
        Me.rbCrescente.Name = "rbCrescente"
        Me.rbCrescente.Size = New System.Drawing.Size(72, 17)
        Me.rbCrescente.TabIndex = 0
        Me.rbCrescente.Text = "Crescente"
        Me.rbCrescente.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(592, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 141)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'BtnExecutarBackup
        '
        Me.BtnExecutarBackup.BackColor = System.Drawing.SystemColors.Control
        Me.BtnExecutarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExecutarBackup.Image = CType(resources.GetObject("BtnExecutarBackup.Image"), System.Drawing.Image)
        Me.BtnExecutarBackup.Location = New System.Drawing.Point(12, 417)
        Me.BtnExecutarBackup.Name = "BtnExecutarBackup"
        Me.BtnExecutarBackup.Size = New System.Drawing.Size(57, 50)
        Me.BtnExecutarBackup.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.BtnExecutarBackup, "Realizar backup da base de dados")
        Me.BtnExecutarBackup.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.SkyBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(739, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TipoDeAtividadeToolStripMenuItem})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'TipoDeAtividadeToolStripMenuItem
        '
        Me.TipoDeAtividadeToolStripMenuItem.Name = "TipoDeAtividadeToolStripMenuItem"
        Me.TipoDeAtividadeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TipoDeAtividadeToolStripMenuItem.Text = "Tipo de Atividade"
        '
        'frmConfiguracoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(739, 475)
        Me.Controls.Add(Me.BtnExecutarBackup)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmConfiguracoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurações"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbInicializarWindows As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbDecrescente As RadioButton
    Friend WithEvents rbCrescente As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbDataAtual As RadioButton
    Friend WithEvents rbEmbranco As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rbNaoHTML As RadioButton
    Friend WithEvents rbSimHTML As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtCaminhoBase As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbSeteDias As RadioButton
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents rbPeriodo As RadioButton
    Friend WithEvents rbHorasTrabalhadas As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTempoNotificacao As ComboBox
    Friend WithEvents BtnExecutarBackup As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CadastroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipoDeAtividadeToolStripMenuItem As ToolStripMenuItem
End Class
