﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.gridAtividades = New System.Windows.Forms.DataGridView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAdicinar = New System.Windows.Forms.Button()
        Me.btnAplicarApartirDe = New System.Windows.Forms.Button()
        Me.txtApartirDe = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescricao = New System.Windows.Forms.RichTextBox()
        CType(Me.gridAtividades,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'gridAtividades
        '
        Me.gridAtividades.AllowUserToAddRows = false
        Me.gridAtividades.AllowUserToResizeColumns = false
        Me.gridAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAtividades.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAtividades.Location = New System.Drawing.Point(0, 77)
        Me.gridAtividades.Name = "gridAtividades"
        Me.gridAtividades.ReadOnly = true
        Me.gridAtividades.Size = New System.Drawing.Size(823, 205)
        Me.gridAtividades.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 282)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(823, 14)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = false
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnListar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnAdicinar)
        Me.Panel1.Controls.Add(Me.btnAplicarApartirDe)
        Me.Panel1.Controls.Add(Me.txtApartirDe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 77)
        Me.Panel1.TabIndex = 4
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(250, 48)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(75, 23)
        Me.btnListar.TabIndex = 5
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(250, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Carregar"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'btnAdicinar
        '
        Me.btnAdicinar.Location = New System.Drawing.Point(501, 22)
        Me.btnAdicinar.Name = "btnAdicinar"
        Me.btnAdicinar.Size = New System.Drawing.Size(57, 43)
        Me.btnAdicinar.TabIndex = 3
        Me.btnAdicinar.Text = "+"
        Me.btnAdicinar.UseVisualStyleBackColor = true
        '
        'btnAplicarApartirDe
        '
        Me.btnAplicarApartirDe.Location = New System.Drawing.Point(101, 22)
        Me.btnAplicarApartirDe.Name = "btnAplicarApartirDe"
        Me.btnAplicarApartirDe.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicarApartirDe.TabIndex = 2
        Me.btnAplicarApartirDe.Text = "Aplicar"
        Me.btnAplicarApartirDe.UseVisualStyleBackColor = true
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
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A partir de:"
        '
        'txtDescricao
        '
        Me.txtDescricao.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtDescricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescricao.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtDescricao.Location = New System.Drawing.Point(0, 296)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtDescricao.Size = New System.Drawing.Size(823, 272)
        Me.txtDescricao.TabIndex = 5
        Me.txtDescricao.Text = ""
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 568)
        Me.Controls.Add(Me.txtDescricao)
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
    Friend WithEvents gridAtividades As DataGridView
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAplicarApartirDe As Button
    Friend WithEvents txtApartirDe As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdicinar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnListar As Button
    Friend WithEvents txtDescricao As RichTextBox
End Class
