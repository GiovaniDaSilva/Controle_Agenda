﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdicionar
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
        Me.imgHistorico = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFinal = New System.Windows.Forms.MaskedTextBox()
        Me.txtInicio = New System.Windows.Forms.MaskedTextBox()
        Me.pCamposMoveis = New System.Windows.Forms.Panel()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.txtDescrição = New System.Windows.Forms.RichTextBox()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.gridPeriodo = New System.Windows.Forms.DataGridView()
        Me.Excluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCalendario = New System.Windows.Forms.Button()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Calendario = New System.Windows.Forms.MonthCalendar()
        Me.gbPeriodo.SuspendLayout()
        CType(Me.imgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pCamposMoveis.SuspendLayout()
        CType(Me.gridPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
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
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo"
        '
        'cbTipo
        '
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(153, 36)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(136, 21)
        Me.cbTipo.TabIndex = 3
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
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
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Horas trabalhadas:"
        '
        'gbPeriodo
        '
        Me.gbPeriodo.Controls.Add(Me.imgHistorico)
        Me.gbPeriodo.Controls.Add(Me.Label5)
        Me.gbPeriodo.Controls.Add(Me.Label4)
        Me.gbPeriodo.Controls.Add(Me.txtFinal)
        Me.gbPeriodo.Controls.Add(Me.txtInicio)
        Me.gbPeriodo.Location = New System.Drawing.Point(29, 76)
        Me.gbPeriodo.Name = "gbPeriodo"
        Me.gbPeriodo.Size = New System.Drawing.Size(501, 149)
        Me.gbPeriodo.TabIndex = 8
        Me.gbPeriodo.TabStop = False
        Me.gbPeriodo.Text = "Período"
        '
        'imgHistorico
        '
        Me.imgHistorico.Image = CType(resources.GetObject("imgHistorico.Image"), System.Drawing.Image)
        Me.imgHistorico.Location = New System.Drawing.Point(18, 87)
        Me.imgHistorico.Name = "imgHistorico"
        Me.imgHistorico.Size = New System.Drawing.Size(40, 40)
        Me.imgHistorico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgHistorico.TabIndex = 5
        Me.imgHistorico.TabStop = False
        Me.imgHistorico.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(85, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Até:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "De:"
        '
        'txtFinal
        '
        Me.txtFinal.Location = New System.Drawing.Point(88, 39)
        Me.txtFinal.Mask = "00:00"
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.Size = New System.Drawing.Size(57, 20)
        Me.txtFinal.TabIndex = 3
        Me.txtFinal.ValidatingType = GetType(Date)
        '
        'txtInicio
        '
        Me.txtInicio.Location = New System.Drawing.Point(18, 39)
        Me.txtInicio.Mask = "00:00"
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(57, 20)
        Me.txtInicio.TabIndex = 1
        Me.txtInicio.ValidatingType = GetType(Date)
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
        Me.pCamposMoveis.TabIndex = 10
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.Location = New System.Drawing.Point(464, 185)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(57, 50)
        Me.btnExcluir.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnExcluir, "Exclui Atividade")
        Me.btnExcluir.UseVisualStyleBackColor = False
        Me.btnExcluir.Visible = False
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
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(83, 185)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(57, 50)
        Me.btnLimpar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnLimpar, "Limpar Tela")
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.Location = New System.Drawing.Point(17, 185)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(57, 50)
        Me.btnGravar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnGravar, "Salvar Atividade")
        Me.btnGravar.UseVisualStyleBackColor = False
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(14, 10)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(55, 13)
        Me.lblDescricao.TabIndex = 0
        Me.lblDescricao.Text = "Descrição"
        '
        'gridPeriodo
        '
        Me.gridPeriodo.AllowUserToAddRows = False
        Me.gridPeriodo.AllowUserToDeleteRows = False
        Me.gridPeriodo.AllowUserToResizeColumns = False
        Me.gridPeriodo.AllowUserToResizeRows = False
        Me.gridPeriodo.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPeriodo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Excluir})
        Me.gridPeriodo.Location = New System.Drawing.Point(180, 99)
        Me.gridPeriodo.Name = "gridPeriodo"
        Me.gridPeriodo.ReadOnly = True
        Me.gridPeriodo.RowHeadersVisible = False
        Me.gridPeriodo.Size = New System.Drawing.Size(332, 120)
        Me.gridPeriodo.TabIndex = 9
        Me.gridPeriodo.TabStop = False
        '
        'Excluir
        '
        Me.Excluir.HeaderText = ""
        Me.Excluir.Image = CType(resources.GetObject("Excluir.Image"), System.Drawing.Image)
        Me.Excluir.Name = "Excluir"
        Me.Excluir.ReadOnly = True
        Me.Excluir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'btnCalendario
        '
        Me.btnCalendario.BackColor = System.Drawing.SystemColors.Control
        Me.btnCalendario.BackgroundImage = CType(resources.GetObject("btnCalendario.BackgroundImage"), System.Drawing.Image)
        Me.btnCalendario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCalendario.Location = New System.Drawing.Point(112, 35)
        Me.btnCalendario.Name = "btnCalendario"
        Me.btnCalendario.Size = New System.Drawing.Size(24, 21)
        Me.btnCalendario.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.btnCalendario, "Inserir Período")
        Me.btnCalendario.UseVisualStyleBackColor = False
        '
        'ToolTip2
        '
        Me.ToolTip2.AutoPopDelay = 15000
        Me.ToolTip2.InitialDelay = 500
        Me.ToolTip2.OwnerDraw = True
        Me.ToolTip2.ReshowDelay = 100
        '
        'Calendario
        '
        Me.Calendario.Location = New System.Drawing.Point(136, 57)
        Me.Calendario.MaxSelectionCount = 1
        Me.Calendario.Name = "Calendario"
        Me.Calendario.TabIndex = 12
        Me.Calendario.Visible = False
        '
        'frmAdicionar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(563, 493)
        Me.Controls.Add(Me.Calendario)
        Me.Controls.Add(Me.btnCalendario)
        Me.Controls.Add(Me.gridPeriodo)
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
        CType(Me.imgHistorico,System.ComponentModel.ISupportInitialize).EndInit
        Me.pCamposMoveis.ResumeLayout(false)
        Me.pCamposMoveis.PerformLayout
        CType(Me.gridPeriodo,System.ComponentModel.ISupportInitialize).EndInit
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
    Friend WithEvents txtFinal As MaskedTextBox
    Friend WithEvents txtInicio As MaskedTextBox
    Friend WithEvents pCamposMoveis As Panel
    Friend WithEvents btnExcluir As Button
    Friend WithEvents txtDescrição As RichTextBox
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents lblDescricao As Label
    Friend WithEvents gridPeriodo As DataGridView
    Friend WithEvents Excluir As DataGridViewImageColumn
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents imgHistorico As PictureBox
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents btnCalendario As Button
    Friend WithEvents Calendario As MonthCalendar
End Class
