Imports System.Text

Public Class clsImpressaoWeb

    Public Enum enuEstiloImpressao
        Data = 1
        Titulo = 2
        Titulo_Destaque = 3
        Informacao = 4
        Informacao_Destaque = 5
    End Enum

    Private Property html As New StringBuilder

    Public Function RetornaPagina(pFiltro As clsAtividade) As String
        Return RetornaHTML(pFiltro)
    End Function

    Private Function RetornaHTML(pFiltro As clsAtividade) As String

        Dim html As String
        html = My.Resources.Impressao

        html = html.Replace("{p_dados_impresso}", funRetornaSolicitacos(pFiltro))
        html = html.Replace("{p_tipos_atividades_filtro}", clsHTMLComum.RetornaTiposAtividadesFiltro(parametros))

        Return html
    End Function

    Private Function funRetornaSolicitacos(pFiltro As clsAtividade) As String
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


End Class

Public Interface IListaAtividadesWeb
    Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni)
End Interface

Public Class clsListaSolicitacaoWeb
    Implements IListaAtividadesWeb

    Public Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni) Implements IListaAtividadesWeb.subImprimeAtividade


        clsHTMLTools.Imprime(html, pAtividade.TIPO_DESCRICAO, clsHTMLTools.enuEstiloImpressao.Titulo_Destaque, True)

        clsHTMLTools.Imprime(html, "Código: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Codigo, clsHTMLTools.enuEstiloImpressao.Informacao)

        clsHTMLTools.Imprime(html, "Horas: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Horas, clsHTMLTools.enuEstiloImpressao.Informacao_Destaque)

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo And pAtividade.Periodos.Count > 0 Then
            'imprime periodos
        End If

        clsHTMLTools.Imprime(html, "Descrição: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Descricao, clsHTMLTools.enuEstiloImpressao.Informacao)

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
            'imprime periodos
        End If

        clsHTMLTools.Imprime(html, "Descrição: &nbsp", clsHTMLTools.enuEstiloImpressao.Titulo, True)
        clsHTMLTools.Imprime(html, pAtividade.Descricao, clsHTMLTools.enuEstiloImpressao.Informacao)
    End Sub
End Class
