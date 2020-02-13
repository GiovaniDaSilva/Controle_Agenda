Public Class clsHomeWeb

    Public Function RetornaPaginaGrafico() As String

        Return GeraPagina()

    End Function

    Private Function GeraPagina() As String

        Dim locAtividades As New List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO

        locAtividades = DAO.carregarAtividades()

        Return RetornaHTML(locAtividades)

    End Function

    Private Function RetornaHTML(listaAtividades As List(Of clsConsultaAtividades)) As String
        Dim html As String
        html = My.Resources.Home

        html = html.Replace("{p_linhas_tabela}", RetornaLinhasTabela(listaAtividades))

        Return html
    End Function

    Private Function RetornaLinhasTabela(listaAtividades As List(Of clsConsultaAtividades)) As String
        Dim locRetorno As String = vbNullString

        For Each atividade In listaAtividades
            Dim linha = New List(Of String)
            linha.Add(atividade.ID)
            linha.Add(atividade.Data)
            linha.Add(atividade.TIPO_DESCRICAO)
            linha.Add(atividade.Codigo)
            linha.Add(atividade.Horas)
            linha.Add(atividade.Descricao)            
            locRetorno &= clsHTMLTools.funLinhaTabela(linha, "class=""descricao""")
        Next

        Return locRetorno

    End Function


End Class
