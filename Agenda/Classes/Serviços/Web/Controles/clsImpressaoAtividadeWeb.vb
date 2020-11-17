Imports System.Text

Public Class clsImpressaoAtividadeWeb

    Public Enum enuEstiloImpressao
        Data = 1
        Titulo = 2
        Titulo_Destaque = 3
        Informacao = 4
        Informacao_Destaque = 5
    End Enum

    Private Property html As New StringBuilder

    Public Function RetornaPagina(pFiltro As clsFiltroAtividades) As String
        Return RetornaHTML(pFiltro)
    End Function

    Private Function RetornaHTML(pFiltro As clsFiltroAtividades) As String

        Dim html As String
        html = My.Resources.ImpressaoAtividade

        html = html.Replace("{p_dados_impresso}", funRetornaSolicitacos(pFiltro))
        html = html.Replace("{p_tipos_atividades_filtro}", clsHTMLComum.RetornaTiposAtividadesFiltro(pFiltro.ID_TIPO_ATIVIDADE))
        html = html.Replace("[p_inicializa_campos_filtro]", RetornaInicializaCamposFiltro(pFiltro.Data, pFiltro.DataFinal))
        html = html.Replace("{p_linhas_tabela_periodo_dia}", clsHTMLComum.RetornaTabelaPeriodosDia(Now))
        html = html.Replace("{data_atual}", clsTools.funFormataData(Now))
        html = html.Replace("{p_Dec_checked}", checkDecrescente(pFiltro))
        html = html.Replace("{p_Cre_checked}", If(pFiltro.Ordenacao = clsFiltroAtividades.enuOrdenacao.Crescente, "Checked", ""))
        html = html.Replace("[p_funcoes_atalho_filtros]", clsHTMLComum.RetornaFuncoesAtalhoFiltros)



        Return html
    End Function

    Private Shared Function checkDecrescente(pFiltro As clsFiltroAtividades) As String
        Return If((pFiltro.Ordenacao = clsFiltroAtividades.enuOrdenacao.Decrescente Or
                    pFiltro.Ordenacao = 0), "Checked", "")
    End Function

    Private Function RetornaInicializaCamposFiltro(pData As Date, pDateAte As Date) As String
        Dim texto As New StringBuilder(vbNullString)


        texto.AppendFormat("
            document.getElementById('data_ini').value = ""{0}"";                  
            document.getElementById('data_ate').value = ""{1}"";
        ", clsTools.funAjustaDataSQL(pData), If(pDateAte = CDate("01/01/0001"), "", clsTools.funAjustaDataSQL(pDateAte)))
        Return texto.ToString

    End Function

    Private Function funRetornaSolicitacos(pFiltro As clsFiltroAtividades) As String
        Dim listaAtividades As New List(Of clsConsultaAtividades)

        listaAtividades = New clsAdicionarDAO().carregarAtividades(pFiltro)
        subListaSolicitacoes(listaAtividades)

        Return html.ToString
    End Function


    Public Sub subListaSolicitacoes(lista As List(Of clsConsultaAtividades))
        Dim objeto As IListaAtividadesWeb
        Dim locdata As String = vbNullString

        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case enuTipoAtividades.SOLICITACAO
                    objeto = New clsListaSolicitacaoWeb()
                Case Else
                    objeto = New clsListaDemaisAtividades()
            End Select

            If locdata = vbNullString OrElse locdata <> item.Data Then
                Dim data As String
                data = item.Data & " - " & Strings.StrConv(String.Format("{0:dddd}", item.Data), VbStrConv.ProperCase)

                clsHTMLTools.PulaLinha(html, 2)
                clsHTMLTools.Imprime(html, data, clsHTMLTools.enuEstiloImpressao.Data, True)
                clsHTMLTools.PulaLinha(html, 3)
                locdata = item.Data
            End If

            objeto.subImprimeAtividade(item, html, New clsIni().funCarregaIni())

            'Espaço entre as atividades
            clsHTMLTools.PulaLinha(html, 2)
        Next
    End Sub




    Public Shared Sub subImprimePeriodos(ByRef html As StringBuilder, periodos As List(Of clsPeriodo), Optional parTab As Integer = 0)
        Dim i As Integer = 0
        If periodos.Count = 0 Then Exit Sub

        For Each item In periodos
            i += 1

            clsHTMLTools.Imprime(html, item.Hora_Inicial & " - " & item.Hora_Final, clsHTMLTools.enuEstiloImpressao.Informacao, i > 1, If(i > 1, parTab, 0))
        Next


    End Sub
End Class

Public Interface IListaAtividadesWeb
    Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni)
End Interface

Public Class clsListaSolicitacaoWeb
    Implements IListaAtividadesWeb

    Public Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni) Implements IListaAtividadesWeb.subImprimeAtividade
        Dim locDetalhesBase = New clsSolicitacaoDAO().consultaSolicitacao(pAtividade.Codigo)

        clsHTMLTools.Imprime(html, pAtividade.TIPO_DESCRICAO, clsHTMLTools.enuEstiloImpressao.Titulo_Destaque, True)

        clsHTMLTools.Imprime(html, "Código: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Codigo, clsHTMLTools.enuEstiloImpressao.Informacao)

        If locDetalhesBase IsNot Nothing Then
            clsHTMLTools.Imprime(html, "Resumo: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsHTMLTools.Imprime(html, locDetalhesBase.Resumo, clsHTMLTools.enuEstiloImpressao.Informacao)
        End If


        clsHTMLTools.Imprime(html, "Horas: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Horas, clsHTMLTools.enuEstiloImpressao.Informacao_Destaque)

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo And pAtividade.Periodos.Count > 0 Then
            clsHTMLTools.Imprime(html, "Período: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsImpressaoAtividadeWeb.subImprimePeriodos(html, pAtividade.Periodos, 7)
        End If

        If locDetalhesBase IsNot Nothing Then
            clsHTMLTools.Imprime(html, "Subtipo: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsHTMLTools.Imprime(html, locDetalhesBase.SubTipo, clsHTMLTools.enuEstiloImpressao.Informacao)

            clsHTMLTools.Imprime(html, "Objeto: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsHTMLTools.Imprime(html, locDetalhesBase.Objeto, clsHTMLTools.enuEstiloImpressao.Informacao)

            clsHTMLTools.Imprime(html, "Situação: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsHTMLTools.Imprime(html, locDetalhesBase.Situacao, clsHTMLTools.enuEstiloImpressao.Informacao)
        End If

        clsHTMLTools.Imprime(html, "Descrição: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.funRetornaDescricaoTratada, clsHTMLTools.enuEstiloImpressao.Informacao)

    End Sub
End Class


Public Class clsListaDemaisAtividades
    Implements IListaAtividadesWeb

    Public Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni) Implements IListaAtividadesWeb.subImprimeAtividade
        'Outros       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      


        clsHTMLTools.Imprime(html, pAtividade.TIPO_DESCRICAO, clsHTMLTools.enuEstiloImpressao.Titulo_Destaque, True)

        If pAtividade.Codigo > 0 Then
            clsHTMLTools.Imprime(html, "Código: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsHTMLTools.Imprime(html, pAtividade.Codigo, clsHTMLTools.enuEstiloImpressao.Informacao)
        End If

        clsHTMLTools.Imprime(html, "Horas: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Horas, clsHTMLTools.enuEstiloImpressao.Informacao_Destaque)

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo And pAtividade.Periodos.Count > 0 Then
            clsHTMLTools.Imprime(html, "Período: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
            clsImpressaoAtividadeWeb.subImprimePeriodos(html, pAtividade.Periodos, 7)

        End If

        clsHTMLTools.Imprime(html, "Descrição: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.funRetornaDescricaoTratada, clsHTMLTools.enuEstiloImpressao.Informacao)
    End Sub
End Class
