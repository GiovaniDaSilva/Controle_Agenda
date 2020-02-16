﻿Imports System.Text

Public Class clsCadastroAtividadeWeb

    Public Function RetornaPaginaCadastroAtividade(pAtividade As clsAtividade) As String
        Return RetornaHTML(pAtividade)
    End Function


    Private Function RetornaHTML(pAtividade As clsAtividade) As String
        Dim html As String
        html = My.Resources.CadastroAtividade
        html = html.Replace("[p_inicializa_campos_atividade]", RetornaLinhasInicializacaoCampos(pAtividade))
        html = html.Replace("[p_id_atividade]", pAtividade.ID)
        html = html.Replace("{p_lista_tipo_atividade}", RetornaListaTipoAtividade(pAtividade))
        html = html.Replace("{p_linhas_tabela_periodo}", RetornaLinhasTabelaPeriodo(pAtividade))

        Return html
    End Function

    Private Function RetornaLinhasInicializacaoCampos(pAtividade As clsAtividade) As String
        Dim texto As New StringBuilder(vbNullString)

        If pAtividade.ID = 0 Then Return ""

        texto.AppendFormat("
            document.getElementById('dataAtividade').value = ""{0}"";
            document.getElementById('codigoAtividade').value = ""{1}"";
            document.getElementById('horaTotal').value = ""{2}"";            

        ", clsTools.funAjustaDataSQL(pAtividade.Data), pAtividade.Codigo, pAtividade.Horas, pAtividade.ID)
        Return texto.ToString
    End Function

    Friend Function RetornaCadastroAtividade_Salvar(json As String) As String

        Dim atividade = DeserializarNewtonsoft(json)
        Dim controle As New clsAdicionar

        controle.Gravar(funRetornaAtividade(atividade))

        Return json.ToString
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

        For Each periodo In pAtividade.Periodos
            Dim linha = New List(Of String)
            linha.Add(periodo.ID)
            linha.Add(periodo.Hora_Inicial)
            linha.Add(periodo.Hora_Final)
            linha.Add(periodo.Total)
            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

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
