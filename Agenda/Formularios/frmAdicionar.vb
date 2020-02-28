Public Class frmAdicionar
    Dim controle As New clsAdicionar
    Dim glfAtividade As New clsAtividade
    Dim glfIni As clsParametrosIni
    Dim locPeriodos As New List(Of clsPeriodo)

    Private Enum enuIndexColunas
        Remover = 0
        Inicio = 1
        Final = 2
        Total = 3
    End Enum


    Private Sub frmAdicionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtData.Text = vbNullString Then txtData.Text = Now
        subValidaComboTipo()
        ToolTip2.SetToolTip(imgHistorico, controle.RetornaToolTipPeriodosDia(clsTools.funRetornaData(txtData)))        
    End Sub

    Private Sub subValidaComboTipo()
        If cbTipo.Items.Count = 0 Then
            controle.CarregaComboTipo(cbTipo)
        End If
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        subLimpaTela()
    End Sub

    Private Sub subLimpaTela()
        txtData.Text = Now
        cbTipo.SelectedIndex = 0
        txtCodigo.Clear()
        txtHora.Clear()
        txtDescrição.Clear()

        glfAtividade = Nothing
        locPeriodos = New List(Of clsPeriodo)

        gridPeriodo.DataSource = Nothing

        gridPeriodo.DataSource = New List(Of clsPeriodo)
        gridPeriodo.Refresh()

        subConfiguraGrid()

        btnExcluir.Visible = False


    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click

        Try
            If controle.Gravar(funRetornaAtividade) Then
                MsgBox("Atividade gravada com sucesso.", MsgBoxStyle.Information)
            End If

            Me.Close()

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

    End Sub

    Private Function funRetornaAtividade() As clsAtividade
        If glfAtividade Is Nothing Then glfAtividade = New clsAtividade
        glfAtividade.Codigo = Val(txtCodigo.Text)
        glfAtividade.Data = clsTools.funRetornaData(txtData)
        glfAtividade.Horas = txtHora.Text
        glfAtividade.ID_TIPO_ATIVIDADE = cbTipo.SelectedValue()
        glfAtividade.Descricao = txtDescrição.Text
        glfAtividade.Periodos = locPeriodos
        Return glfAtividade
    End Function

    Public Sub subCarregaAtividade(parAtividade As clsAtividade)

        glfAtividade = parAtividade
        gridPeriodo.DataSource = New List(Of clsPeriodo)
        
        If Not glfAtividade Is Nothing Then
            subValidaComboTipo()
            txtCodigo.Text = iif(glfAtividade.Codigo > 0 ,glfAtividade.Codigo,"")
            txtData.Text = glfAtividade.Data
            txtHora.Text = glfAtividade.Horas
            cbTipo.SelectedValue = glfAtividade.ID_TIPO_ATIVIDADE
            txtDescrição.Text = glfAtividade.Descricao
            If Not glfAtividade.Periodos Is Nothing  AndAlso  glfAtividade.Periodos.Count > 0 Then
                gridPeriodo.DataSource = Nothing
                gridPeriodo.DataSource = glfAtividade.Periodos
                locPeriodos = glfAtividade.Periodos        
            End If

            gridPeriodo.Refresh()
            btnExcluir.Visible = True
        End If

        subConfiguraForm()

        Me.ShowDialog()
    End Sub

    Public Sub ChamaFormulario(ByVal parIni As clsParametrosIni, Optional parAtividade As clsAtividade = Nothing)
        glfIni = parIni
        subCarregaAtividade(parAtividade)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
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


            ToolTip2.SetToolTip(imgHistorico, controle.RetornaToolTipPeriodosDia(clsTools.funRetornaData(txtData)))

            'Garante que não ficara visivel
            Calendario.Visible = False
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtData.Focus()
        End Try
    End Sub

    Private Sub subConfiguraForm()
        If glfIni.Horastrabalhadas = enuHorasTrabalhadas.Total Then
            pCamposMoveis.Top = 76
            Me.Height = 371
            gbPeriodo.Visible = False
            gridPeriodo.Visible = False
            imgHistorico.Visible = false
        Else
            pCamposMoveis.Top = 231
            imgHistorico.Visible = true
            Me.Height = 532
            txtHora.Enabled = False
            gbPeriodo.Visible = True
            gridPeriodo.Visible = True
            subConfiguraGrid()
        End If

    End Sub

    Private Sub subConfiguraGrid()
        gridPeriodo.Columns("ID").Visible = False
        gridPeriodo.Columns("ID_ATIVIDADE").Visible = False

        gridPeriodo.Columns("HORA_INICIAL").HeaderText = "Hora Inicial"
        gridPeriodo.Columns("HORA_FINAL").HeaderText = "Hora Final"
        gridPeriodo.Columns("Total").HeaderText = "Total"

        gridPeriodo.Columns("HORA_INICIAL").Width = 90
        gridPeriodo.Columns("HORA_FINAL").Width = 90
        gridPeriodo.Columns("Total").Width = 70
        gridPeriodo.Columns("EXCLUIR").Width = 60

        gridPeriodo.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        subAdicionaPeriodo()
    End Sub

    Private Sub subAdicionaPeriodo()
        If Not subValidaHoraInicio() Then Exit Sub
        If Not subValidaHoraFinal() Then Exit Sub

        Dim Total = controle.RetornaTotalHoras(txtInicio.Text, txtFinal.Text)
        locPeriodos.Add(New clsPeriodo(0, txtInicio.Text, txtFinal.Text, Total))
        subAtualizaGrid()
        SubAtualizaHorasTotais()
    End Sub

    Private Sub SubAtualizaHorasTotais()
        Dim locTotal As TimeSpan

        For Each periodo In locPeriodos
            locTotal = locTotal.Add(TimeSpan.Parse(periodo.Total))
        Next
        txtHora.Text = locTotal.ToString
    End Sub

    Private Sub subAtualizaGrid()
        gridPeriodo.DataSource = Nothing
        gridPeriodo.DataSource = locPeriodos
        txtInicio.Clear()
        txtFinal.Clear()
        subConfiguraGrid()
    End Sub

    Private Sub gridPeriodo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPeriodo.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If (e.ColumnIndex = enuIndexColunas.Remover) Then
            locPeriodos.RemoveAt(e.RowIndex)
            subAtualizaGrid()
            SubAtualizaHorasTotais()
        End If
    End Sub


    Private Function subValidaHoraInicio() As Boolean
        Try
            If Not clsTools.funValidaHora(txtInicio.Text) Then
                txtInicio.Focus()
            End If
            Return True
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtInicio.Focus()
            Return False
        End Try
    End Function

    Private Function subValidaHoraFinal() As Boolean
        Try
            If Not clsTools.funValidaHora(txtFinal.Text) Then
                txtFinal.Focus()
            End If

            If Not clsTools.funValidaHora(txtInicio.Text) Then
                txtInicio.Focus()
            End If

            If TimeSpan.Parse(txtFinal.Text) < TimeSpan.Parse(txtInicio.Text) Then
                Throw New Exception("Hora final deve ser maior que hora inícial.")
            End If
            Return True
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
            txtFinal.Focus()
            Return False
        End Try
    End Function

    Private Sub txtHora_Leave(sender As Object, e As EventArgs) Handles txtHora.Leave
        Try
            If Not clsTools.funValidaHora(txtHora.Text, True) Then
                txtHora.Focus()
            End If
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try
    End Sub

    Private Sub ToolTip2_Draw(sender As Object, e As DrawToolTipEventArgs) Handles ToolTip2.Draw        
        dim tooltipFont As Font = new Font("consolas", 10.0f)
        Dim temptooltiptext As string
        e.DrawBackground()
        e.DrawBorder()
        temptooltiptext = e.ToolTipText
        e.Graphics.DrawString(e.ToolTipText, tooltipFont, Brushes.Black, new PointF(2, 2))


    End Sub

    Private Sub ToolTip2_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip2.Popup
         e.ToolTipSize = TextRenderer.MeasureText(toolTip2.GetToolTip(e.AssociatedControl), new Font("consolas", 10.0f))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCalendario.Click
        Calendario.Visible = Not Calendario.Visible
    End Sub

    Private Sub Calendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles Calendario.DateChanged
        txtData.Text = Calendario.SelectionStart()
        Calendario.Visible = False
        cbTipo.Focus()
    End Sub

    Private Sub Calendario_Leave(sender As Object, e As EventArgs) Handles Calendario.Leave
        Calendario.Visible = False
    End Sub
End Class