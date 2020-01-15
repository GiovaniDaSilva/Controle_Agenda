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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.gridAtividades = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clHoras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAdicinar = New System.Windows.Forms.Button()
        Me.btnAplicarApartirDe = New System.Windows.Forms.Button()
        Me.txtApartirDe = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.gridAtividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.MenuText
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.Window
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 296)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RichTextBox1.Size = New System.Drawing.Size(1014, 422)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'gridAtividades
        '
        Me.gridAtividades.AllowUserToAddRows = False
        Me.gridAtividades.AllowUserToResizeColumns = False
        Me.gridAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAtividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.clData, Me.clTipo, Me.clCodigo, Me.clHoras, Me.clDescricao})
        Me.gridAtividades.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAtividades.Location = New System.Drawing.Point(0, 77)
        Me.gridAtividades.Name = "gridAtividades"
        Me.gridAtividades.ReadOnly = True
        Me.gridAtividades.Size = New System.Drawing.Size(1014, 205)
        Me.gridAtividades.TabIndex = 1
        '
        'clID
        '
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        '
        'clData
        '
        Me.clData.HeaderText = "Data"
        Me.clData.Name = "clData"
        Me.clData.ReadOnly = True
        '
        'clTipo
        '
        Me.clTipo.HeaderText = "Tipo"
        Me.clTipo.Name = "clTipo"
        Me.clTipo.ReadOnly = True
        Me.clTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clCodigo
        '
        Me.clCodigo.HeaderText = "Código"
        Me.clCodigo.Name = "clCodigo"
        Me.clCodigo.ReadOnly = True
        '
        'clHoras
        '
        Me.clHoras.HeaderText = "Horas"
        Me.clHoras.Name = "clHoras"
        Me.clHoras.ReadOnly = True
        '
        'clDescricao
        '
        Me.clDescricao.HeaderText = "Descrição"
        Me.clDescricao.Name = "clDescricao"
        Me.clDescricao.ReadOnly = True
        Me.clDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clDescricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clDescricao.Width = 500
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 282)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1014, 14)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAdicinar)
        Me.Panel1.Controls.Add(Me.btnAplicarApartirDe)
        Me.Panel1.Controls.Add(Me.txtApartirDe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 77)
        Me.Panel1.TabIndex = 4
        '
        'btnAdicinar
        '
        Me.btnAdicinar.Location = New System.Drawing.Point(945, 23)
        Me.btnAdicinar.Name = "btnAdicinar"
        Me.btnAdicinar.Size = New System.Drawing.Size(57, 43)
        Me.btnAdicinar.TabIndex = 3
        Me.btnAdicinar.Text = "+"
        Me.btnAdicinar.UseVisualStyleBackColor = True
        '
        'btnAplicarApartirDe
        '
        Me.btnAplicarApartirDe.Location = New System.Drawing.Point(101, 23)
        Me.btnAplicarApartirDe.Name = "btnAplicarApartirDe"
        Me.btnAplicarApartirDe.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarApartirDe.TabIndex = 2
        Me.btnAplicarApartirDe.Text = "Aplicar"
        Me.btnAplicarApartirDe.UseVisualStyleBackColor = True
        '
        'txtApartirDe
        '
        Me.txtApartirDe.Location = New System.Drawing.Point(15, 25)
        Me.txtApartirDe.Mask = "00/00/0000"
        Me.txtApartirDe.Name = "txtApartirDe"
        Me.txtApartirDe.Size = New System.Drawing.Size(80, 20)
        Me.txtApartirDe.TabIndex = 1
        Me.txtApartirDe.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A partir de:"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 718)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.gridAtividades)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPrincipal"
        Me.Text = "Agenda - Versão 0.1 - BETA"
        CType(Me.gridAtividades,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents gridAtividades As DataGridView
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAplicarApartirDe As Button
    Friend WithEvents txtApartirDe As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdicinar As Button
    Friend WithEvents clID As DataGridViewTextBoxColumn
    Friend WithEvents clData As DataGridViewTextBoxColumn
    Friend WithEvents clTipo As DataGridViewTextBoxColumn
    Friend WithEvents clCodigo As DataGridViewTextBoxColumn
    Friend WithEvents clHoras As DataGridViewTextBoxColumn
    Friend WithEvents clDescricao As DataGridViewTextBoxColumn
End Class
