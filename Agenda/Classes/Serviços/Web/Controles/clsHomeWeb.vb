Imports System.Text
Imports Agenda

Public Class clsHomeWeb

    Public Function RetornaPaginaHome(parametros As clsParametrosFiltroWeb) As String
        Return GeraPagina(parametros)

    End Function

    Private Function GeraPagina(parametros As clsParametrosFiltroWeb) As String

        Dim locAtividades As New List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Dim Filtro As New clsFiltroAtividades

        Filtro.Data = parametros.Data
        Filtro.DataFinal = parametros.DataAte
        Filtro.ID_TIPO_ATIVIDADE = parametros.Tipo

        locAtividades = DAO.carregarAtividades(Filtro)

        Return RetornaHTML(locAtividades, parametros)

    End Function

    Private Function RetornaHTML(listaAtividades As List(Of clsConsultaAtividades), parametros As clsParametrosFiltroWeb) As String
        Dim html As String
        html = My.Resources.Home

        html = html.Replace("{p_linhas_tabela}", RetornaLinhasTabela(listaAtividades))
        html = html.Replace("[p_inicializa_campos_filtro]", RetornaInicializaCamposFiltro(parametros))
        html = html.Replace("{p_tipos_atividades_filtro}", clsHTMLComum.RetornaTiposAtividadesFiltro(parametros.Tipo))
        html = html.Replace("[p_pagina]", clsPaginasWeb.Home)
        html = html.Replace("{p_linhas_tabela_periodo_dia}", clsHTMLComum.RetornaTabelaPeriodosDia(Now))
        html = html.Replace("{data_atual}", clsTools.funFormataData(Now))
        html = html.Replace("[p_funcoes_atalho_filtros]", clsHTMLComum.RetornaFuncoesAtalhoFiltros)

        Return html
    End Function

    Private Function RetornaInicializaCamposFiltro(parametros As clsParametrosFiltroWeb) As String
        Dim texto As New StringBuilder(vbNullString)
        texto.AppendFormat("
            document.getElementById('data_ini').value = ""{0}"";                  
            document.getElementById('data_ate').value = ""{1}"";  
        ", If(parametros.Data = CDate("01/01/0001"), "", clsTools.funAjustaDataSQL(parametros.Data)), If(parametros.DataAte = CDate("01/01/0001"), "", clsTools.funAjustaDataSQL(parametros.DataAte)))
        Return texto.ToString

    End Function

    Private Function RetornaLinhasTabela(listaAtividades As List(Of clsConsultaAtividades)) As String
        Dim locRetorno As String = vbNullString

        For Each atividade In listaAtividades
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(atividade.ID))
            linha.Add(New clsColunasTabela(atividade.Data))
            linha.Add(New clsColunasTabela(clsHTMLTools.pintaDadoColunaTable(clsTools.funRetornaDiaSemana(atividade.Data, True), Color.DarkGreen)))
            linha.Add(New clsColunasTabela(atividade.TIPO_DESCRICAO))
            linha.Add(New clsColunasTabela(atividade.funRetornaCodigoTratado, ))
            linha.Add(New clsColunasTabela(atividade.Horas))
            linha.Add(New clsColunasTabela(atividade.funRetornaDescricaoTratada, "class=""descricao"""))
            linha.Add(New clsColunasTabela(""))
            linha.Add(New clsColunasTabela(""))

            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function


End Class
