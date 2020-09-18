Imports System.Text
Imports Agenda

Public Class clsPrincipal




    Public Sub Adicionar(ByVal parIni As clsParametrosIni, Optional parAtividade As clsAtividade = Nothing)
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ChamaFormulario(parIni, parAtividade)
    End Sub

    Public Function funCarregarAtividades(ByVal parFiltro As clsFiltroAtividades, parParametrosIni As clsParametrosIni) As List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades(parFiltro, parParametrosIni)
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsConsultaAtividades), parIni As clsParametrosIni, Optional ByVal pHTML As String = vbNullString)
        Dim objeto As clsIListaAtividades
        Dim locExisteSolicitacao As Boolean
        Dim listaSolicitacao As New List(Of clsSolicitacao)
        Dim locData As String = vbNullString

        Dim i = lista.FindIndex(Function(X) X.ID_TIPO_ATIVIDADE = enuTipoAtividades.SOLICITACAO)
        locExisteSolicitacao = (i >= 0)

        txtTela.Clear()
        If locExisteSolicitacao Then
            listaSolicitacao = clsSolicitacao.funCarregaDetalhesSolicitacoes(pHTML)
        End If


        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case enuTipoAtividades.SOLICITACAO
                    objeto = New clsListaSolictacao(listaSolicitacao)
                Case enuTipoAtividades.PBI
                    objeto = New clsListaPBI
                Case enuTipoAtividades.REUNIAO
                    objeto = New clsListaReuniao
                Case enuTipoAtividades.AUSENTE
                    objeto = New clsListaAusente
                Case Else
                    objeto = New clsListaOutros(item.TIPO_DESCRICAO)
            End Select

            If locData = vbNullString OrElse locData <> item.Data Then
                Dim data As String
                data = item.Data & " - " & Strings.StrConv(String.Format("{0:dddd}", item.Data), VbStrConv.ProperCase)
                RichAddLineFmt(txtTela, funRetornaDataFormatada(data) & vbNewLine)
                locData = item.Data
            End If


            objeto.subListaAtividade(txtTela, item, parIni)
        Next
    End Sub

    Private Function funRetornaDataFormatada(pData As String) As String
        Return "<fs:13><fc:Green><b><u>" & pData & "<u></b></fc></fs>"
    End Function

    Public Sub GravaDescricao(pAtividade As clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        DAO.gravarAtividade(pAtividade)
    End Sub

    Public Sub CarregaComboTipo(pTipo As ComboBox)
        Dim locAdicionar As New clsAdicionar
        locAdicionar.CarregaComboTipo(pTipo)
    End Sub

    Friend Sub Configurar()
        Dim locForm As New frmConfiguracoes
        locForm.funChamaConfiguracao()
    End Sub

    Friend Function funCarregaArquivoIni() As clsParametrosIni
        Dim locIni As New clsIni
        Return locIni.funCarregaIni
    End Function

    Public Function funRetornaTotalHorasDia(pData As Date) As String
        Dim listaAtividade As New List(Of clsConsultaAtividades)
        listaAtividade = New clsAdicionarDAO().carregarAtividades(CDate(pData), CDate(pData))

        Return New clsPrincipal().funRetornaTotalHorasDia(listaAtividade, pData)
    End Function

    Public Function funRetornaTotalHorasDia(atividades As List(Of clsConsultaAtividades), pData As Date) As String
        Dim locDia As New List(Of clsConsultaAtividades)
        Dim locTime As TimeSpan
        Dim somaAusente As Boolean = funCarregaArquivoIni.ConsideraTipoAusenteTotal

        locDia = atividades.FindAll(Function(X) X.Data = pData)

        For Each item In locDia

            If Not somaAusente And item.ID_TIPO_ATIVIDADE = enuTipoAtividades.AUSENTE Then
                Continue For
            End If

            If Trim(item.Horas) <> ":" AndAlso Trim(item.Horas) <> vbNullString Then
                locTime = locTime.Add(TimeSpan.Parse(item.Horas))
            End If
        Next
        Return Mid(locTime.ToString(), 1, 5)

    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef item As clsConsultaAtividades, parIni As clsParametrosIni)
        Dim lista As New List(Of clsConsultaAtividades)
        lista.Add(item)
        subListarAtivdades(txtTela, lista, parIni)
    End Sub

    Public Shared Function funRetornaToolTipoPeriodo(periodos As List(Of clsPeriodo), Optional parTab As Integer = 0) As String
        Dim locResult As New StringBuilder(String.Empty)
        Dim i As Integer = 0
        If periodos.Count = 0 Then Return vbNullString

        For Each item In periodos
            i += 1
            locResult.Append(IIf(i > 1, Space(parTab), "") & item.Hora_Inicial & " - " & item.Hora_Final & IIf(i < periodos.Count, vbNewLine, ""))
        Next

        Return locResult.ToString
    End Function

    Public Shared Function funRetornaFormatadoDestaque(pValor As String) As String
        Return "<fc:Red>" & pValor & "</fc>"
    End Function

    Public Sub funChamaHTMLVersao()
        clsRequisicoesWeb.ChamaPagina(clsPaginasWeb.Versoes)
    End Sub

    Friend Sub subExibeNotificacao(notifyIcon1 As NotifyIcon)
        notifyIcon1.ShowBalloonTip(500, "Agenda", "Lembre-se de atualizar o apontamento de horas.", ToolTipIcon.Info)
    End Sub

    Public Sub subConfiguraTimer(pTimer As Timer, parametrosini As clsParametrosIni)
        Const minutoTimer = 60000
        pTimer.Stop()
        Select Case parametrosini.TempoNotificacao
            Case enuTempoNotificacao.Hora1 : pTimer.Interval = (60 * minutoTimer)
            Case enuTempoNotificacao.Hora2 : pTimer.Interval = (120 * minutoTimer)
            Case enuTempoNotificacao.Hora3 : pTimer.Interval = (180 * minutoTimer)
            Case enuTempoNotificacao.Hora4 : pTimer.Interval = (240 * minutoTimer)
            Case Else
                Return
        End Select
        pTimer.Start()
    End Sub

    Friend Function funRetornaTotalHorasAtividade(codigo As String) As String
        Dim DAO As New clsAdicionarDAO
        Dim locTime As New TimeSpan 
        dim locAtividades = DAO.carregarAtividades(codigo)
       
        For Each item In locAtividades
            If Trim(item.Horas) <> ":" Then
                locTime = locTime.Add(TimeSpan.Parse(item.Horas))
            End If
        Next

        Dim x As String
        Dim horas As double = 0
        horas = locTime.Days * 24
        x = (locTime.Hours + horas).ToString("00")
        x &= ":" & format(locTime.Minutes, "00") 
        Return x
        
    End Function

    Friend Sub imprimePeriodoDia(txtDescricao As RichTextBox, data As Date)
        Dim adicionar As New clsAdicionar
        txtDescricao.Clear()
        RichAddLineFmt(txtDescricao, funRetornaDataFormatada(Strings.StrConv(String.Format("{0:dddd}", data), VbStrConv.ProperCase) & " - " & clsTools.funFormataData(data)) & vbNewLine)
        RichAddLineFmt(txtDescricao, adicionar.RetornaToolTipPeriodosDia(data))
    End Sub

    Public Sub ExecutaValidacoesTimerGeral()
        Dim validacoes As New clsVerificacoesTimerGeral
        validacoes.ExecutaValidacoes()
    End Sub
End Class


Public Interface clsIListaAtividades
    Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni)
End Interface

Public Class clsListaSolictacao
    Implements clsIListaAtividades

    Public Sub New(listaSolicitacoes As List(Of clsSolicitacao))
        Me.ListaSolicitacoes = listaSolicitacoes
    End Sub

    Public Property ListaSolicitacoes As New List(Of clsSolicitacao)


    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni) Implements clsIListaAtividades.subListaAtividade
        'Solicitacao
        '       Código: xxxx           
        '       Titulo: xxxx           
        '       Horas: xx:xx
        '       SubTipo: xxxx
        '       Objeto: xxxx
        '       Situação: xxxx
        '       Descrição: xxxxxxxxxxxx      

        Dim locDetalhes As clsSolicitacao
        Dim locDetalhesBase As clsSolicitacao
        Dim locDAO As New clsSolicitacaoDAO

        locDetalhes = ListaSolicitacoes.Find(Function(X) X.Codigo = item.Codigo)
        locDetalhesBase = locDAO.consultaSolicitacao(item.Codigo)

        If Not locDetalhes Is Nothing Then
            locDetalhes.ID_ATIVIDADE = item.ID

            If Not locDetalhesBase Is Nothing Then
                locDetalhes.ID = locDetalhesBase.ID
            End If

            locDAO.gravarSolicitacao(locDetalhes)
        Else
            If Not locDetalhesBase Is Nothing Then
                locDetalhes = locDetalhesBase
            End If
        End If

        RichAddLineFmt(parCampo, enuCamposImpressao.Solicitacoes)
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Codigo & clsPrincipal.funRetornaFormatadoDestaque(item.Codigo))



        If Not locDetalhes Is Nothing Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Titulo & locDetalhes.Resumo)
        End If

        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Horas & clsPrincipal.funRetornaFormatadoDestaque(item.Horas))

        If parIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo And item.Periodos.Count > 0 Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Periodo & clsPrincipal.funRetornaToolTipoPeriodo(item.Periodos, 11))
        End If


        If Not locDetalhes Is Nothing Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Subtipo & locDetalhes.SubTipo)
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Objeto & locDetalhes.Objeto)
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Situacao & locDetalhes.Situacao)
        End If

        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Descricao & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub

End Class


Public Class clsListaPBI
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni) Implements clsIListaAtividades.subListaAtividade
        'PBI
        '       Código: xxxx           
        '       Horas: xx:xx
        '       IPP: xxxx
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, enuCamposImpressao.PBI)
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Codigo & clsPrincipal.funRetornaFormatadoDestaque(item.Codigo))
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Horas & clsPrincipal.funRetornaFormatadoDestaque(item.Horas))

        If parIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo And item.Periodos.Count > 0 Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Periodo & clsPrincipal.funRetornaToolTipoPeriodo(item.Periodos, 11))
        End If

        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Descricao & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class


Public Class clsListaReuniao
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni) Implements clsIListaAtividades.subListaAtividade
        'Reuniao       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, enuCamposImpressao.Reuniao)
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Horas & clsPrincipal.funRetornaFormatadoDestaque(item.Horas))
        If parIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo And item.Periodos.Count > 0 Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Periodo & clsPrincipal.funRetornaToolTipoPeriodo(item.Periodos, 11))
        End If
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Descricao & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class

Public Class clsListaAusente
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni) Implements clsIListaAtividades.subListaAtividade
        'Ausente       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, enuCamposImpressao.Ausente)
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Horas & clsPrincipal.funRetornaFormatadoDestaque(item.Horas))
        If parIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo And item.Periodos.Count > 0 Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Periodo & clsPrincipal.funRetornaToolTipoPeriodo(item.Periodos, 11))
        End If
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Descricao & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class

Public Class clsListaOutros
    Implements clsIListaAtividades

    Private descricaoAtividade As String

    Public Sub New(Optional descricaoTipo As String = "Outros")
        descricaoAtividade = descricaoTipo
    End Sub

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades, parIni As clsParametrosIni) Implements clsIListaAtividades.subListaAtividade
        'Outros       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, enuCamposImpressao.Outros(descricaoAtividade))
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Horas & clsPrincipal.funRetornaFormatadoDestaque(item.Horas))
        If parIni.Horastrabalhadas = enuHorasTrabalhadas.Periodo And item.Periodos.Count > 0 Then
            RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Periodo & clsPrincipal.funRetornaToolTipoPeriodo(item.Periodos, 11))
        End If
        RichAddLineFmt(parCampo, clsTools.Tab & enuCamposImpressao.Descricao & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class
