Imports System.Net
Imports System.Text

Public Class clsCadastroAtividadeWeb
    Dim glfDuplicarAtividade As Boolean

    Public Function RetornaPaginaCadastroAtividade(pAtividade As clsAtividade, pDuplicarAtividade As Boolean) As String
        glfDuplicarAtividade = pDuplicarAtividade
        Return RetornaHTML(pAtividade)
    End Function


    Private Function RetornaHTML(pAtividade As clsAtividade) As String
        Dim html As String
        html = My.Resources.CadastroAtividade
        html = html.Replace("[p_inicializa_campos_atividade]", RetornaLinhasInicializacaoCampos(pAtividade))
        html = html.Replace("[p_id_atividade]", pAtividade.ID)
        html = html.Replace("{p_lista_tipo_atividade}", RetornaListaTipoAtividade(pAtividade))
        html = html.Replace("{p_linhas_tabela_periodo}", RetornaLinhasTabelaPeriodo(pAtividade))
        html = html.Replace("{p_retorna_botao_excluir_atividade}", RetornaBotaoExcluirAtividade(pAtividade))
        html = html.Replace("{p_linhas_tabela_periodo_dia}", clsHTMLComum.RetornaTabelaPeriodosDia(vbNullString))
        html = html.Replace("[p_duplicar_atividade]", If(glfDuplicarAtividade, "true", "false"))
        html = html.Replace("[p_pagina]", clsPaginasWeb.CadastroAtividade)

        Return html
    End Function



    Private Function RetornaLinhasInicializacaoCampos(pAtividade As clsAtividade) As String
        Dim texto As New StringBuilder(vbNullString)

        If pAtividade.ID = 0 Then Return ""

        Dim locHora As String = vbNullString

        If Not Trim(pAtividade.Horas).Replace(":", "") = vbNullString Then
            locHora = pAtividade.Horas
        End If

        If glfDuplicarAtividade Then
            locHora = vbNullString
            pAtividade.Data = Now
        End If

        texto.AppendFormat("
            document.getElementById('dataAtividade').value = ""{0}"";
            document.getElementById('codigoAtividade').value = ""{1}"";
            document.getElementById('horaTotal').value = ""{2}"";            

        ", clsTools.funAjustaDataSQL(pAtividade.Data), pAtividade.Codigo, locHora, pAtividade.ID)
        Return texto.ToString
    End Function

    Friend Function funRetornaCadastroAtividade_Detalhes(Detalhes As clsParametrosDetalhesAtividadeWeb) As String
        Dim locDetalhes As New clsDetalhesAtividadeWeb
        Dim atividade As New clsAtividade(Detalhes.id)


        locDetalhes.Descricao = funRetornaDescricaoAtividade(Detalhes.id)
        locDetalhes.TotalHoraDia = New clsPrincipal().funRetornaTotalHorasDia(Detalhes.data)
        locDetalhes.TotalHorasAtividade = IIf(Val(Detalhes.codigo) <= 0, atividade.Horas, New clsPrincipal().funRetornaTotalHorasAtividade(Detalhes.codigo))

        Return Newtonsoft.Json.JsonConvert.SerializeObject(locDetalhes)

    End Function

    ''' <summary>
    ''' Retorna a descrição da atividade da pagina hora atraves de ajax
    ''' </summary>
    ''' <param name="pId"></param>
    ''' <returns></returns>
    Private Function funRetornaDescricaoAtividade(pId As Long) As String
        Dim DAO As New clsAdicionarDAO
        Dim locDescricao As String = vbNullString

        locDescricao = clsTools.RetornaCampoTabela("ATIVIDADES", "DESCRICAO", "ID = " & pId)
        Return locDescricao
    End Function


    Friend Function funRetornaCadastroAtividade_Excluir(id As Long) As String
        Return New clsAdicionarDAO().Excluir(id)
    End Function

    Friend Function RetornaCadastroAtividade_Salvar(json As String) As String
        RetornaCadastroAtividade_Salvar = "Erro"

        Dim controle As New clsAdicionar
        Dim atividadejson = DeserializarNewtonsoft(json)
        Dim atividade = funRetornaAtividade(atividadejson)

        If controle.Gravar(atividade) Then
            Return "Sucesso"
        End If


    End Function



    Private Function DeserializarNewtonsoft(json As String) As clsAtividadeWeb
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsAtividadeWeb)(json)
    End Function

    Private Function funRetornaAtividade(atividade As clsAtividadeWeb) As clsAtividade
        Dim locAtividade As New clsAtividade
        Dim locPeriodos As New List(Of clsPeriodo)

        For Each periodo In atividade.Periodo

            If Not funValidaPeriodo(periodo) Then Continue For

            Dim aux As New clsPeriodo
            aux.Hora_Inicial = periodo.De
            aux.Hora_Final = periodo.Ate
            aux.Total = periodo.Total
            locPeriodos.Add(aux)
        Next

        With locAtividade
            .ID = Val(atividade.id_atividade)
            .Codigo = IIf(atividade.codigoAtividade = vbNullString, "0", atividade.codigoAtividade)
            .Data = atividade.dataAtividade
            .Horas = IIf(atividade.horaTotal = vbNullString, "  :  ", atividade.horaTotal) 'informado : para mander o padrao do desktop
            .ID_TIPO_ATIVIDADE = atividade.tipoAtividade
            .Descricao = atividade.descricaoAtividade
            .Periodos = locPeriodos
        End With

        Return locAtividade
    End Function



    Private Function funValidaPeriodo(periodo As clsPeriodoWeb) As Boolean
        Try
            clsTools.funValidaHora(periodo.De)
            clsTools.funValidaHora(periodo.Ate)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function RetornaListaTipoAtividade(pAtividadade As clsAtividade) As String
        Dim retorno As New StringBuilder(vbNullString)
        Dim selected As String = "selected"
        Dim tipos As List(Of clsTipo)

        tipos = New clsAdicionarDAO().CarregaTipos()

        For Each tipo In tipos
            retorno.AppendFormat("<option value = ""{0}"" {1}> {2}</Option>", tipo.ID, IIf(pAtividadade.ID_TIPO_ATIVIDADE = tipo.ID, selected, ""), tipo.DESCRICAO)
        Next

        Return retorno.ToString

    End Function

    Private Function RetornaLinhasTabelaPeriodo(pAtividade As clsAtividade) As String
        Dim locRetorno As String = vbNullString

        If pAtividade.ID = 0 Then Return ""
        If pAtividade.Periodos.Count = 0 Then Return ""
        If glfDuplicarAtividade Then Return ""

        For Each periodo In pAtividade.Periodos
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(periodo.ID))
            linha.Add(New clsColunasTabela(periodo.Hora_Inicial))
            linha.Add(New clsColunasTabela(periodo.Hora_Final))
            linha.Add(New clsColunasTabela(periodo.Total))
            linha.Add(New clsColunasTabela("<button type='button' class='btn btn-outline-danger' id='btnExcluirPeriodo' onclick='excluiPeriodo()' >Excluir</button>"))

            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function

    Private Function RetornaBotaoExcluirAtividade(pAtividade As clsAtividade) As String
        Dim texto As New StringBuilder(vbNullString)

        If pAtividade.ID = 0 Then Return ""
        If glfDuplicarAtividade Then Return ""

        texto.AppendFormat("
            <input id=""btnExcluir"" type=""button"" value=""Excluir"" form=""form_dados"" class="" btn btn-danger"" data-toggle=""modal"" data-target=""#confirmaExclusao"" />        
        ")
        Return texto.ToString
    End Function

End Class


''' <summary>
''' Classes para carregar a partir do json
''' </summary>
Public Class clsAtividadeWeb
    Public Property id_atividade As String
    Public Property dataAtividade As String
    Public Property tipoAtividade As Integer
    Public Property codigoAtividade As String
    Public Property horaTotal As String
    Public Property horaInicio As String
    Public Property horaFinal As String
    Public Property descricaoAtividade As String

    Public Property Periodo As IEnumerable(Of clsPeriodoWeb)

End Class

Public Class clsPeriodoWeb
    Public Property ID As String
    Public Property De As String
    Public Property Ate As String
    Public Property Total As String
End Class
