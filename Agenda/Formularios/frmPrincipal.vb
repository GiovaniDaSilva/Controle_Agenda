Imports System.Text.RegularExpressions
Imports Agenda
Imports HtmlAgilityPack

Public Class frmPrincipal
    Private controle As New clsPrincipal
    Dim lista As List(Of clsConsultaAtividades)
    Dim ParametrosIni As clsParametrosIni
    Const MODO_IMPRESSAO = "MODO_IMPRESSAO"
    Const MODO_NORMAL = ""

    Private Enum enuPosicaoColunas
        DATA = 1
        TIPO = 2
        CODIGO = 3
        HORA = 4
        DESCRICAO = 5
        EDITAR = 6
    End Enum

    Private Enum enuIndexColunas
        EDITAR = 0
        DATA = 3
        TIPO = 1
        CODIGO = 4
        HORA = 5
        DESCRICAO = 6
    End Enum


    Private Sub btnAdicinar_Click(sender As Object, e As EventArgs) Handles btnAdicinar.Click
        subRemoveSelecao()
        controle.Adicionar()

        subAtualizaLista()
    End Sub

    Private Sub subRemoveSelecao()
        If Not gridAtividades.CurrentRow Is Nothing Then
            gridAtividades.CurrentRow.Selected = False
        End If

        txtDescricao.Clear()
    End Sub

    Private Sub btnAtualiza_Click(sender As Object, e As EventArgs) Handles btnAtualiza.Click
        subAtualizaLista()
    End Sub

    Private Sub subAtualizaLista()
        subConfiguraDescricao(MODO_NORMAL)
        lista = controle.funCarregarAtividades(funMontaFiltro, ParametrosIni)

        gridAtividades.DataSource = lista
        subConfiguraGridAtividade()
        subRemoveSelecao()
    End Sub

    Private Sub subConfiguraGridAtividade()
        gridAtividades.Columns("ID").Visible = False
        gridAtividades.Columns("ID_TIPO_ATIVIDADE").Visible = False

        gridAtividades.Columns("DESCRICAO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        gridAtividades.Columns("DESCRICAO").HeaderText = "Descrição"
        gridAtividades.Columns("TIPO_DESCRICAO").HeaderText = "Tipo"
        gridAtividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'Sequencia de colunas
        gridAtividades.Columns("DATA").DisplayIndex = enuPosicaoColunas.DATA
        gridAtividades.Columns("TIPO_DESCRICAO").DisplayIndex = enuPosicaoColunas.TIPO
        gridAtividades.Columns("CODIGO").DisplayIndex = enuPosicaoColunas.CODIGO
        gridAtividades.Columns("HORAS").DisplayIndex = enuPosicaoColunas.HORA
        gridAtividades.Columns("DESCRICAO").DisplayIndex = enuPosicaoColunas.DESCRICAO
        gridAtividades.Columns("EDITAR").DisplayIndex = enuPosicaoColunas.EDITAR
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        subConfiguraDescricao(MODO_IMPRESSAO)
        Dim locHTML As String = vbNullString

        If ParametrosIni.SolicitarHTML Then
            locHTML = frmHTML.RetornarHTML
        End If

        controle.subListarAtivdades(txtDescricao, lista, locHTML)
    End Sub

    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave
        Dim locAlterou As Boolean = Not lista(gridAtividades.CurrentCell.RowIndex).Descricao.Equals(txtDescricao.Text)
        If txtDescricao.Tag = MODO_IMPRESSAO Then
            Exit Sub
        End If

        lista(gridAtividades.CurrentCell.RowIndex).Descricao = txtDescricao.Text
        gridAtividades.Refresh()

        If locAlterou Then controle.GravaDescricao(lista(gridAtividades.CurrentCell.RowIndex))
    End Sub


    Private Sub gridAtividades_Click(sender As Object, e As EventArgs) Handles gridAtividades.Click
        subAtualizaDescricao()
    End Sub

    Private Sub subAtualizaDescricao()
        txtDescricao.Clear()
        subConfiguraDescricao(MODO_NORMAL)
        If lista.Count > 0 Then
            txtDescricao.Text = lista(gridAtividades.CurrentCell.RowIndex).Descricao
        End If
    End Sub

    Private Sub gridAtividades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridAtividades.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If (e.ColumnIndex = enuIndexColunas.EDITAR) Then
            subChamaFormularioAdicionarEdicao(e.RowIndex)
        End If
    End Sub

    Private Sub subChamaFormularioAdicionarEdicao(i As Integer)
        controle.Adicionar(New clsAtividade(lista(i).ID, lista(i).Data, lista(i).Codigo, lista(i).Horas, lista(i).Descricao, lista(i).ID_TIPO_ATIVIDADE))
        subAtualizaLista()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        subCarregaIni()
        subCarregaComboTipo(cbTipo)

        If ParametrosIni.InicializarCampoApartirDe = "Atual" Then
            txtApartirDe.Text = Now
        End If

        subAtualizaLista()
    End Sub

    Private Sub subCarregaIni()
        ParametrosIni = controle.funCarregaArquivoIni()
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs)
        subLimpaFiltro()
    End Sub

    Private Sub subLimpaFiltro()
        txtApartirDe.Clear()
        cbTipo.SelectedIndex = -1
        txtCodigo.Clear()
    End Sub



    Private Sub gridAtividades_KeyDown(sender As Object, e As KeyEventArgs) Handles gridAtividades.KeyDown
        subAtualizaDescricao()
    End Sub

    Private Sub gridAtividades_KeyUp(sender As Object, e As KeyEventArgs) Handles gridAtividades.KeyUp
        subAtualizaDescricao()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        subOcultaFiltro()
    End Sub

    Private Sub subOcultaFiltro()
        pFiltro.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pFiltro.Visible = True
        pFiltro.Height = pMenu.Height
        pFiltro.Width = pMenu.Width
        pFiltro.Top = pMenu.Top
        pFiltro.Left = pMenu.Left
    End Sub

    Private Sub subCarregaComboTipo(pTipo As ComboBox)
        controle.CarregaComboTipo(pTipo)
        pTipo.SelectedIndex = -1
    End Sub

    Private Sub btnLimpar_Click_1(sender As Object, e As EventArgs) Handles btnLimpar.Click
        subLimpaFiltro()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        subOcultaFiltro()
        subAtualizaLista()
    End Sub

    Private Function funMontaFiltro() As clsAtividade
        Dim locAividade As New clsAtividade

        locAividade.Codigo = Val(txtCodigo.Text)
        locAividade.Data = clsTools.funRetornaData(txtApartirDe)
        locAividade.ID_TIPO_ATIVIDADE = cbTipo.SelectedValue()

        Return locAividade
    End Function

    Private Sub subConfiguraDescricao(pTipo As String)
        If pTipo = MODO_IMPRESSAO Then
            txtDescricao.Tag = MODO_IMPRESSAO
            txtDescricao.BackColor = Color.LightCyan
            txtDescricao.ReadOnly = True
        Else
            txtDescricao.Tag = MODO_NORMAL
            txtDescricao.BackColor = Color.Linen
            txtDescricao.ReadOnly = False
        End If
    End Sub

    Public Function limpaHTML_Recursiva(ByVal sTexto As String, ByVal j As Integer) As String
        If j = 0 Then
            Return sTexto
        End If
        Dim i As Integer = 0
        i = InStr(sTexto, "<")
        j = InStr(sTexto, ">")
        If i > 0 Then
            i -= 1
        End If
        sTexto = Strings.Left(sTexto, i) & Strings.Right(sTexto, sTexto.Length - j)
        Return (limpaHTML_Recursiva(sTexto, j))
    End Function

    Private Sub btnConfiguracao_Click(sender As Object, e As EventArgs) Handles btnConfiguracao.Click
        subRemoveSelecao()
        controle.Configurar(ParametrosIni)
        subCarregaIni()
    End Sub
End Class



