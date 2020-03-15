Imports System.Text
Imports Agenda

Public Class clsHomeWeb

    Public Function RetornaPaginaHome(parametros As clsParametrosFiltroWeb) As String
        Return GeraPagina(parametros)

    End Function

    Private Function GeraPagina(parametros As clsParametrosFiltroWeb) As String

        Dim locAtividades As New List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Dim Filtro As New clsAtividade

        Filtro.Data = parametros.Data
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

        Return html
    End Function

    Private Function RetornaInicializaCamposFiltro(parametros As clsParametrosFiltroWeb) As String
        Dim texto As New StringBuilder(vbNullString)
        texto.AppendFormat("
            document.getElementById('data_ini').value = ""{0}"";                  
        ", clsTools.funAjustaDataSQL(parametros.Data))
        Return texto.ToString

    End Function

    Private Function RetornaLinhasTabela(listaAtividades As List(Of clsConsultaAtividades)) As String
        Dim locRetorno As String = vbNullString

        For Each atividade In listaAtividades
            Dim linha = New List(Of String)
            linha.Add(atividade.ID)
            linha.Add(atividade.Data)
            linha.Add(atividade.TIPO_DESCRICAO)
            linha.Add(atividade.funRetornaCodigoTratado)
            linha.Add(atividade.Horas)
            linha.Add(atividade.funRetornaDescricaoTratada)
            linha.Add("")
            locRetorno &= clsHTMLTools.funLinhaTabela(linha, "class=""descricao""")
        Next

        Return locRetorno

    End Function


End Class
