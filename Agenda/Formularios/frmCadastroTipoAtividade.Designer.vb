<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastroTipoAtividade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroTipoAtividade))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.gridTipo = New System.Windows.Forms.DataGridView()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.MaskedTextBox()
        Me.Excluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNovo = New System.Windows.Forms.Button()
        CType(Me.gridTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(198, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Descrição"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(201, 28)
        Me.txtDescricao.MaxLength = 30
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(314, 20)
        Me.txtDescricao.TabIndex = 9
        '
        'gridTipo
        '
        Me.gridTipo.AllowUserToAddRows = False
        Me.gridTipo.AllowUserToDeleteRows = False
        Me.gridTipo.AllowUserToResizeColumns = False
        Me.gridTipo.AllowUserToResizeRows = False
        Me.gridTipo.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTipo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Excluir})
        Me.gridTipo.Location = New System.Drawing.Point(12, 82)
        Me.gridTipo.Name = "gridTipo"
        Me.gridTipo.ReadOnly = True
        Me.gridTipo.RowHeadersVisible = False
        Me.gridTipo.Size = New System.Drawing.Size(503, 289)
        Me.gridTipo.TabIndex = 10
        Me.gridTipo.TabStop = False
        '
        'btnLimpar
        '
        Me.btnLimpar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(78, 388)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(57, 50)
        Me.btnLimpar.TabIndex = 12
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.Location = New System.Drawing.Point(12, 388)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(57, 50)
        Me.btnGravar.TabIndex = 11
        Me.btnGravar.UseVisualStyleBackColor = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(103, 12)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 6
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(106, 28)
        Me.txtCodigo.Mask = "00"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(57, 20)
        Me.txtCodigo.TabIndex = 7
        Me.txtCodigo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCodigo.ValidatingType = GetType(Integer)
        '
        'Excluir
        '
        Me.Excluir.HeaderText = "Excluir"
        Me.Excluir.Image = CType(resources.GetObject("Excluir.Image"), System.Drawing.Image)
        Me.Excluir.Name = "Excluir"
        Me.Excluir.ReadOnly = True
        '
        'btnNovo
        '
        Me.btnNovo.BackColor = System.Drawing.SystemColors.Control
        Me.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.Location = New System.Drawing.Point(12, 12)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(57, 50)
        Me.btnNovo.TabIndex = 14
        Me.btnNovo.UseVisualStyleBackColor = False
        '
        'frmCadastroTipoAtividade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(528, 450)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.gridTipo)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCadastroTipoAtividade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Tipo de Atividade"
        CType(Me.gridTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents gridTipo As DataGridView
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As MaskedTextBox
    Friend WithEvents Excluir As DataGridViewImageColumn
    Friend WithEvents btnNovo As Button
End Class
