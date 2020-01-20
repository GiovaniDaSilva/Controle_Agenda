Public Class frmAdicionar
    Dim controle As New clsAdicionar
    Dim glfAtividade As New clsAtividade
    Dim glfIni As clsParametrosIni 

    Private Sub frmAdicionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtData.Text = vbNullString Then txtData.Text = Now
        subValidaComboTipo()
    End Sub

    Private Sub subValidaComboTipo()
        If cbTipo.Items.Count = 0 Then
            controle.CarregaComboTipo(cbTipo)
        End If
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) 
        subLimpaTela()
    End Sub

    Private Sub subLimpaTela()
        txtData.Text = Now
        cbTipo.SelectedIndex = -1
        txtCodigo.Clear()
        txtHora.Clear()
        txtDescrição.Clear()

        glfAtividade = Nothing
        btnExcluir.Visible = False
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) 
        If controle.Gravar(funRetornaAtividade) Then
            MsgBox("Atividade gravada com sucesso.", MsgBoxStyle.Information)
        End If
        Me.Close()
    End Sub

    Private Function funRetornaAtividade() As clsAtividade
        If glfAtividade Is Nothing Then glfAtividade = New clsAtividade
        glfAtividade.Codigo = Val(txtCodigo.Text)
        glfAtividade.Data = clsTools.funRetornaData(txtData)
        glfAtividade.Horas = txtHora.Text
        glfAtividade.ID_TIPO_ATIVIDADE = cbTipo.SelectedValue()
        glfAtividade.Descricao = txtDescrição.Text

        Return glfAtividade
    End Function

    Public Sub subCarregaAtividade(parAtividade As clsAtividade)

        glfAtividade = parAtividade

         gridPeriodo.DataSource = New List(Of clsPeriodo)  

        If Not glfAtividade Is Nothing Then
            subValidaComboTipo
            txtCodigo.Text = glfAtividade.Codigo
            txtData.Text = glfAtividade.Data
            txtHora.Text = glfAtividade.Horas
            cbTipo.SelectedValue = glfAtividade.ID_TIPO_ATIVIDADE
            txtDescrição.Text = glfAtividade.Descricao

            gridPeriodo.DataSource = New List(Of clsPeriodo) 

            btnExcluir.Visible = True
        End If

        subConfiguraForm() 

        Me.ShowDialog()
    End Sub

    Public Sub ChamaFormulario(byval parIni As clsParametrosIni, Optional parAtividade As clsAtividade = Nothing)
        glfIni = parIni 
        subCarregaAtividade(parAtividade)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) 
        If controle.excluir(glfAtividade.ID) Then
            MsgBox("Excluido com sucesso.", MsgBoxStyle.Information)
        End If
        Me.Close()
    End Sub

    Private Sub txtData_Leave(sender As Object, e As EventArgs) Handles txtData.Leave
        Try
            If Not IsDate(clsTools.funRetornaData(txtData)) Then
                MsgBox("Data informada não é válida.")
                txtData.Focus()
            End If
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtData.Focus()
        End Try
    End Sub

    Private Sub  subConfiguraForm()        
        If glfIni.Horastrabalhadas = "Total" Then
            pCamposMoveis.Top = 76     
            Me.Height = 371
            gbPeriodo.Visible = false
        Else
            pCamposMoveis.Top = 231
            Me.Height = 532
            txtHora.Enabled = false 
            subConfiguraGrid()
        End If 

    End Sub

    Private sub subConfiguraGrid()
        gridPeriodo.Columns("ID").Visible = False
        gridPeriodo.Columns("ID_ATIVIDADE").Visible = False
        
        gridPeriodo.Columns("HORA_INICIAL").HeaderText = "Hora Inicial"
        gridPeriodo.Columns("HORA_FINAL").HeaderText = "Hora Final"
        gridPeriodo.Columns("Total").HeaderText = "Total"

        gridPeriodo.Columns("HORA_INICIAL").Width = 90
        gridPeriodo.Columns("HORA_FINAL").Width = 90
        gridPeriodo.Columns("Total"). Width = 70

      '  gridPeriodo.SelectionMode = DataGridViewSelectionMode.FullRowSelect         
    End sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        subAdicionaPeriodo()
    End Sub

    Private Sub subAdicionaPeriodo()
        If glfAtividade Is Nothing
            glfAtividade = New clsAtividade 
            glfAtividade.Periodos  = New List(Of clsPeriodo) 
        End If
        
        glfAtividade.Periodos.Add(New clsPeriodo(glfAtividade.ID, txtInicio.Text, txtFinal.text, 0))        
        gridPeriodo.DataSource  = glfAtividade.Periodos
        subConfiguraGrid  

    End Sub
End Class