Imports System.Text

Public Class clsImpressaoWeb

    Private Property html As New StringBuilder

    Public Function RetornaPagina(pFiltro As clsAtividade) As String
        Return RetornaHTML(pFiltro)
    End Function

    Private Function RetornaHTML(pFiltro As clsAtividade) As String

        Dim html As String
        html = My.Resources.Impressao

        html = html.Replace("{p_dados_impresso}", funRetornaSolicitacos(pFiltro))
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
                html.AppendLine(clsHTMLTools.Imprime(data))
                locdata = item.Data
            End If

            objeto.subImprimeAtividade(item, html, New clsIni().funCarregaIni())
        Next
    End Sub


End Class

Public Interface IListaAtividadesWeb
    Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni)
End Interface

Public Class clsListaSolicitacaoWeb
    Implements IListaAtividadesWeb

    Public Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni) Implements IListaAtividadesWeb.subImprimeAtividade


        html.AppendLine(clsHTMLTools.Imprime(pAtividade.TIPO_DESCRICAO))

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Horas))
        html.Append(clsHTMLTools.Imprime(pAtividade.Horas))

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Horas))
        html.Append(clsHTMLTools.Imprime(pAtividade.Horas))

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo And pAtividade.Periodos.Count > 0 Then
            'imprime periodos
        End If

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Descricao))
        html.Append(clsHTMLTools.Imprime(pAtividade.Descricao))

        html.AppendLine("")

    End Sub
End Class


Public Class clsListaDemaisAtividades
    Implements IListaAtividadesWeb

    Public Sub subImprimeAtividade(pAtividade As clsConsultaAtividades, ByRef html As StringBuilder, ini As clsParametrosIni) Implements IListaAtividadesWeb.subImprimeAtividade
        'Outros       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      


        html.AppendLine(clsHTMLTools.Imprime(pAtividade.TIPO_DESCRICAO))

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Horas))
        html.Append(clsHTMLTools.Imprime(pAtividade.Horas))

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Horas))
        html.Append(clsHTMLTools.Imprime(pAtividade.Horas))

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo And pAtividade.Periodos.Count > 0 Then
            'imprime periodos
        End If

        html.AppendLine(clsHTMLTools.Imprime(enuCamposImpressao.Descricao))
        html.Append(clsHTMLTools.Imprime(pAtividade.Descricao))

        html.AppendLine("")

    End Sub
End Class
