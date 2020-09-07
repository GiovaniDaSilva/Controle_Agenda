Public Class clsCadastroTipoWeb
    Public Function RetornaPagina() As String
        Return GeraPagina()
    End Function

    Private Function GeraPagina() As String

        Dim listaTipos As New List(Of clsTipo)

        listaTipos = New clsCadastroTipoAtividade().CarregarTiposAtividades()

        Return RetornaHTML(listaTipos)

    End Function

    Private Function RetornaHTML(tipos As List(Of clsTipo)) As String
        Dim html As String
        html = My.Resources.CadastroTipo

        html = html.Replace("[p_pagina]", clsPaginasWeb.CadastroTipo)
        html = html.Replace("{p_linhas_tabela_tipos}", RetornaLinhasTabelaTipo(tipos))

        Return html
    End Function

    Private Function RetornaLinhasTabelaTipo(tipos As List(Of clsTipo)) As String
        Dim locRetorno As String = vbNullString

        If tipos.Count = 0 Then Return ""

        For Each tipo In tipos
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(tipo.ID))
            linha.Add(New clsColunasTabela(tipo.CODIGO))
            linha.Add(New clsColunasTabela(tipo.DESCRICAO))
            linha.Add(New clsColunasTabela("<button type='button' class='btn btn-outline-danger' id='btnExcluirTipo' onclick='excluiTipo()' >Excluir</button>"))

            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function
End Class
