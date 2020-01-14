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
        Me.clData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clTipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.clDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtApartirDe = New System.Windows.Forms.MaskedTextBox()
        Me.btnAplicarApartirDe = New System.Windows.Forms.Button()
        CType(Me.gridAtividades,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
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
        Me.gridAtividades.AllowUserToResizeColumns = false
        Me.gridAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAtividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clData, Me.clTipo, Me.clDescricao})
        Me.gridAtividades.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAtividades.Location = New System.Drawing.Point(0, 77)
        Me.gridAtividades.Name = "gridAtividades"
        Me.gridAtividades.Size = New System.Drawing.Size(1014, 205)
        Me.gridAtividades.TabIndex = 1
        '
        'clData
        '
        Me.clData.HeaderText = "Data"
        Me.clData.Name = "clData"
        '
        'clTipo
        '
        Me.clTipo.HeaderText = "Tipo"
        Me.clTipo.Items.AddRange(New Object() {"Solicitação", "PBI", "Reunião", "Ausente"})
        Me.clTipo.Name = "clTipo"
        '
        'clDescricao
        '
        Me.clDescricao.HeaderText = "Descrição"
        Me.clDescricao.Name = "clDescricao"
        Me.clDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clDescricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clDescricao.Width = 310
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 282)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1014, 14)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = false
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAplicarApartirDe)
        Me.Panel1.Controls.Add(Me.txtApartirDe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 77)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A partir de:"
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
        'btnAplicarApartirDe
        '
        Me.btnAplicarApartirDe.Location = New System.Drawing.Point(101, 23)
        Me.btnAplicarApartirDe.Name = "btnAplicarApartirDe"
        Me.btnAplicarApartirDe.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarApartirDe.TabIndex = 2
        Me.btnAplicarApartirDe.Text = "Aplicar"
        Me.btnAplicarApartirDe.UseVisualStyleBackColor = true
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
    Friend WithEvents clData As DataGridViewTextBoxColumn
    Friend WithEvents clTipo As DataGridViewComboBoxColumn
    Friend WithEvents clDescricao As DataGridViewTextBoxColumn
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAplicarApartirDe As Button
    Friend WithEvents txtApartirDe As MaskedTextBox
    Friend WithEvents Label1 As Label
End Class
