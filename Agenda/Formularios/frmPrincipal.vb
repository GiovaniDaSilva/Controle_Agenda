Imports System.Text.RegularExpressions
Imports Agenda
Imports HtmlAgilityPack

Public Class frmPrincipal
    Private controle As New clsPrincipal
    Dim lista As List(Of clsConsultaAtividades)
    Dim ParametrosIni As clsParametrosIni

    Dim glfServidorHTTP As New clsServidorHTTP

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
        controle.Adicionar(ParametrosIni)

        subAtualizaLista()
    End Sub

    Private Sub subRemoveSelecao()
        If Not gridAtividades.CurrentRow Is Nothing Then
            gridAtividades.CurrentRow.Selected = False
        End If

        txtDescricao.Clear()
        pHorasDia.Visible = False
        pHorasAtividade.Visible = False
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

        gridAtividades.Columns("CODIGO").DefaultCellStyle.ForeColor = Color.Blue
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        subConfiguraDescricao(MODO_IMPRESSAO)
        Dim locHTML As String = vbNullString

        If ParametrosIni.SolicitarHTML Then
            locHTML = frmHTML.RetornarHTML
        End If

        controle.subListarAtivdades(txtDescricao, lista, ParametrosIni, locHTML)
        txtDescricao.SelectionStart = 0
    End Sub

    Private Sub txtDescricao_Leave(sender As Object, e As EventArgs) Handles txtDescricao.Leave
        Dim locAlterou As Boolean = Not lista(gridAtividades.CurrentCell.RowIndex).Descricao.Equals(txtDescricao.Text)
        If txtDescricao.Tag = MODO_IMPRESSAO Then
            Exit Sub
        End If

        'Não permite excluir toda a descrição na tela inicial.
        'Contornar o problema de perder toda a descrição do primeiro registros da grid
        If txtDescricao.Text = vbNullString And lista(gridAtividades.CurrentCell.RowIndex).Descricao <> vbNullString Then
            MsgBox("Não é permitido apagar a descrição através da tela inicial." &
                    vbNewLine & "Utilize o botão alterar atividade neste caso.")
            txtDescricao.Text = lista(gridAtividades.CurrentCell.RowIndex).Descricao
            Exit Sub
        End If

        lista(gridAtividades.CurrentCell.RowIndex).Descricao = txtDescricao.Text
        gridAtividades.Refresh()

        If locAlterou Then
            controle.GravaDescricao(lista(gridAtividades.CurrentCell.RowIndex))
        End If
    End Sub


    Private Sub gridAtividades_Click(sender As Object, e As EventArgs) Handles gridAtividades.Click

        If My.Computer.Keyboard.AltKeyDown Then
            ImprimeAtividade()
        Else
            subAtualizaDescricao()
        End If


    End Sub

    Private Sub ImprimeAtividade()
        subConfiguraDescricao(MODO_IMPRESSAO)
        controle.subListarAtivdades(txtDescricao, lista(gridAtividades.CurrentCell.RowIndex), ParametrosIni)
    End Sub

    Private Sub subAtualizaDescricao()
        If txtDescricao.Tag = MODO_IMPRESSAO Then Exit Sub

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
        ElseIf (e.ColumnIndex = enuIndexColunas.CODIGO) Then
            If My.Computer.Keyboard.CtrlKeyDown Then
                AbreSolPBI(e.RowIndex)
            End If

        End If

        If e.RowIndex > lista.Count - 1 Then Exit Sub

        pHorasDia.Visible = True
        lblHorasDia.Text = controle.funRetornaTotalHorasDia(lista, lista(e.RowIndex).Data)

        subAtualizaHorasAtividade(e)

    End Sub

    Private Sub AbreSolPBI(index As Integer)
        If lista(index).ID_TIPO_ATIVIDADE = 1 Then
            clsRequisicoesWeb.ChamaPaginaExterna("http://sg.govbr.com.br/sgcetil/servlet/br.com.cetil.sg.producao.hsodetso?" & lista(index).Codigo)
        ElseIf lista(index).ID_TIPO_ATIVIDADE = 2 Then
            clsRequisicoesWeb.ChamaPaginaExterna("http://tfs.cetil.com.br:8080/tfs/CETIL/Suprimentos/_workitems?_a=edit&id=" & lista(index).Codigo)
        End If
    End Sub

    Private Sub subAtualizaHorasAtividade(e As DataGridViewCellEventArgs)
        pHorasAtividade.Visible = True
        If Val(lista(e.RowIndex).Codigo) <= 0 Then
            lblHorasAtividade.Text = lista(e.RowIndex).Horas
        Else
            lblHorasAtividade.Text = controle.funRetornaTotalHorasAtividade(lista(e.RowIndex).Codigo)
        End If
    End Sub



    Private Sub subChamaFormularioAdicionarEdicao(i As Integer, Optional duplicarAtividade As Boolean = False)

        Dim locAtividade As clsAtividade
        locAtividade = New clsAtividade(lista(i).ID, lista(i).Data, lista(i).Codigo, lista(i).Horas, lista(i).Descricao, lista(i).ID_TIPO_ATIVIDADE, lista(i).Periodos)

        If duplicarAtividade Then
            locAtividade.ID = 0
            locAtividade.Data = Now
            locAtividade.Periodos.Clear()
            locAtividade.Horas = ""
        End If


        controle.Adicionar(ParametrosIni, locAtividade)
        subAtualizaLista()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        subVerificaSenhaEmail()

        subCarregaIni()

        subAjustaBaseZerada()

        subAtualizaSistema()

        glfServidorHTTP.InicializaServidor()

        subConfiguraTela()

        subAtualizaLista()

        subVerificaNovaVersao()

        AbreFormulario()

    End Sub

    Private Sub AbreFormulario()

        If Not ParametrosIni.UtilizarVersaoWeb Then
            Me.Show()
            Return
        End If

        subExibiFormulario(False)
        clsRequisicoesWeb.ChamaPagina(clsPaginasWeb.Home)

    End Sub

    Private Shared Sub subVerificaNovaVersao()
        Try
            clsVersaoSistema.ExisteVersaoSuperiorDisponivel()
        Catch ex As Exception
            'Se der erro, não avisa nada sobre nova versao
        End Try
    End Sub

    Private Sub subAtualizaSistema()
        Me.Cursor = Cursors.WaitCursor
        Try
            clsVersaoSistema.AtualizaSistema()
        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub subAjustaBaseZerada()
        clsConexao.CaminhoBase = ParametrosIni.CaminhoBase
        If Not clsConexao.ExisteBase Then
            subChamaConfiguracoes()
        End If
    End Sub

    Private Shared Sub subVerificaSenhaEmail()
        If Not clsEmail.LoginValido() Then
            MsgBox("Login e Senha do Email Controle Agenda não informado.", vbCritical)
            End
        End If
    End Sub

    Private Sub subConfiguraTela()
        Me.Text = Me.Text & clsVersaoSistema.Versao
        subCarregaComboTipo(cbTipo)

        If ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Atual Then
            txtApartirDe.Text = Now
        ElseIf ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Dias7 Then
            txtApartirDe.Text = Now.AddDays(-7)
        End If

        controle.subConfiguraTimer(TimerNotificacao, ParametrosIni)
        TimerNotificacao.Start()

        TimerControleGeral.Interval = 120 * 60000 '120 minutos x 1 minuto do timer
        TimerControleGeral.Start()

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


    Private Sub btnSubirFiltro_Click(sender As Object, e As EventArgs) Handles btnSubirFiltro.Click
        subOcultaFiltro()
        subAtualizaLista()
    End Sub

    Private Sub subOcultaFiltro()
        locSobeDesce = False
        subMovimentaMenuFiltro()

        If pFiltro.Top <= locTopMin Then
            pFiltro.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAbaixarFiltro.Click
        'pFiltro.Visible = True
        pFiltro.Height = pMenu.Height
        pFiltro.Width = pMenu.Width
        pFiltro.Top = pMenu.Top
        pFiltro.Left = pMenu.Left


        pFiltro.Visible = True
        locSobeDesce = True
        subMovimentaMenuFiltro()
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
        subChamaConfiguracoes()
    End Sub

    Private Sub subChamaConfiguracoes()
        subRemoveSelecao()
        controle.Configurar(ParametrosIni)
        subCarregaIni()

        controle.subConfiguraTimer(TimerNotificacao, ParametrosIni)
    End Sub

    'Variaveis de Controle da Animação
    Dim locTopMax As Integer
    Dim locTopMin As Integer
    Dim locTop As Integer

    Dim locSobeDesce As Boolean 'True Sobe / False Desce

    Private Sub subMovimentaMenuFiltro()

        locTopMax = pMenu.Top
        locTopMin = pMenu.Top - pFiltro.Height
        pFiltro.Left = pMenu.Left

        If locSobeDesce Then
            pFiltro.Top = locTopMin
            locTop = locTopMin
        Else
            pFiltro.Top = locTopMax
            locTop = locTopMax
        End If

        TimerAnimacaoMenu.Interval = 1
        TimerAnimacaoMenu.Start()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerAnimacaoMenu.Tick

        If locSobeDesce Then
            subDesceMenu()
        Else
            subSobeMenu()
        End If


    End Sub

    Private Sub subDesceMenu()
        If pFiltro.Top < locTopMax Then
            locTop = locTop + 6
            If locTop > locTopMax Then
                locTop = locTopMax
            End If
            pFiltro.Top = CInt(locTop)
        Else
            TimerAnimacaoMenu.Stop()
        End If
    End Sub

    Private Sub subSobeMenu()
        If pFiltro.Top > locTopMin Then
            locTop = locTop - 6
            If locTop < locTopMin Then
                locTop = locTopMin
            End If
            pFiltro.Top = CInt(locTop)
        Else
            TimerAnimacaoMenu.Stop()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnApontarHoras.Click
        clsRequisicoesWeb.ChamaPaginaExterna("http://sah.govbr.com.br/default.asp?dtsem=")
    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles btnVersao.Click
        'frmBrowser.ShowDialog()
        controle.funChamaHTMLVersao()
    End Sub

    Private Sub gridAtividades_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridAtividades.CellFormatting

        If gridAtividades.Rows.Count = 0 Then Exit Sub

        If (e.ColumnIndex = enuIndexColunas.HORA) Then
            If Trim(e.Value) = ":" Then Exit Sub
            If ParametrosIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo Then
                gridAtividades.Rows(e.RowIndex).Cells(enuIndexColunas.HORA).ToolTipText = "Períodos:" & vbNewLine & clsPrincipal.funRetornaToolTipoPeriodo(lista(e.RowIndex).Periodos)
            End If
        ElseIf (e.ColumnIndex = enuIndexColunas.CODIGO) Then
            If e.Value = 0 Then
                e.Value = ""
            End If
        End If
    End Sub


    Private Sub subExibiFormulario(ByVal parValor As Boolean)

        If parValor Then
            Me.ShowIcon = True
            Me.ShowInTaskbar = True
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            subAtualizaLista()
        Else
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
        End If

    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ParametrosIni.TempoNotificacao <> enuTempoNotificacao.NaoUsar Then
            e.Cancel = True
            subExibiFormulario(False)
        End If
        'glfServidorHTTP.EncerraServidorHTTP 
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        subExibiFormulario(True)
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        End
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles TimerNotificacao.Tick
        controle.subExibeNotificacao(NotifyIcon1)
    End Sub

    Private Sub btnAbreCausaErros_Click(sender As Object, e As EventArgs) Handles btnAbreCausaErros.Click
        Dim i As Integer
        Dim caminho As String = "http://mtz-vconversor:8077/"

        Dim Home As String = caminho & "home"
        Dim Edicao As String = caminho & "set_demanda?id="


        If lista Is Nothing Or Not gridAtividades.CurrentRow.Selected Then
            clsRequisicoesWeb.ChamaPaginaExterna(caminho & Home)
        Else
            i = gridAtividades.CurrentCell.RowIndex
            If lista(i).ID_TIPO_ATIVIDADE = 1 Then
                clsRequisicoesWeb.ChamaPaginaExterna(Edicao & lista(i).Codigo)
            Else
                clsRequisicoesWeb.ChamaPaginaExterna(Home)
            End If
        End If
    End Sub

    Private Sub btnGraficoMensal_Click_1(sender As Object, e As EventArgs) Handles btnGraficoMensal.Click
        clsRequisicoesWeb.ChamaPagina(clsPaginasWeb.Grafico)
    End Sub

    Private Sub ImprimirPeriodosDoDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirPeriodosDoDiaToolStripMenuItem.Click

        Dim data As Date

        If Not PossuiAtividadeSeleciona() Then Exit Sub

        subConfiguraDescricao(MODO_IMPRESSAO)

        data = lista(gridAtividades.CurrentCell.RowIndex).Data
        controle.imprimePeriodoDia(txtDescricao, data)
    End Sub

    Private Function PossuiAtividadeSeleciona() As Boolean
        If lista Is Nothing Or Not gridAtividades.CurrentRow.Selected Then
            MsgBox("Nenhuma atividade selecionada!", vbExclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub ImprimirAividadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirAividadeToolStripMenuItem.Click

        If Not PossuiAtividadeSeleciona() Then Exit Sub

        ImprimeAtividade()
    End Sub

    Private Sub AbrirSolPBIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirSolPBIToolStripMenuItem.Click
        If Not PossuiAtividadeSeleciona() Then Exit Sub

        If lista(gridAtividades.CurrentCell.RowIndex).ID_TIPO_ATIVIDADE > 2 Then
            MsgBox("Seleciona uma atividade do tipo Solicitação ou PBI.", vbInformation)
            Exit Sub
        End If

        AbreSolPBI(gridAtividades.CurrentCell.RowIndex)
    End Sub

    Private Sub gridAtividades_MouseDown(sender As Object, e As MouseEventArgs) Handles gridAtividades.MouseDown

        If (e.Button = MouseButtons.Right) Then

            Dim hti = gridAtividades.HitTest(e.X, e.Y)
            gridAtividades.ClearSelection()
            If hti.RowIndex > -1 Then
                gridAtividades.CurrentCell = gridAtividades.Rows(hti.RowIndex).Cells(0)
                gridAtividades.Rows(hti.RowIndex).Selected = True
            End If
        End If


    End Sub

    Private Sub btnVersaoWeb_Click(sender As Object, e As EventArgs) Handles btnVersaoWeb.Click
        clsRequisicoesWeb.ChamaPagina(clsPaginasWeb.Home)
    End Sub

    Private Sub TimerControleGeral_Tick(sender As Object, e As EventArgs) Handles TimerControleGeral.Tick
        Me.Cursor = Cursors.WaitCursor

        controle.ExecutaValidacoesTimerGeral()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DuplicarAtividadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicarAtividadeToolStripMenuItem.Click
        Dim index As Integer
        index = gridAtividades.CurrentCell.RowIndex

        subChamaFormularioAdicionarEdicao(index, True)
    End Sub
End Class



