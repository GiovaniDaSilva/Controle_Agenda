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
            linha.Add(New clsColunasTabela("<button type='button' class='btn btn-outline-danger' id='btnExcluirTipo' onclick='excluiTipo(true)' >Excluir</button>"))

            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function


    Friend Function PermiteExcluir(idTipo As Integer) As String
        If idTipo <= 0 Then Return ""

        Dim tipo As New clsTipo
        tipo.InicializaPorID(idTipo)

        Dim tipoAtividade As New clsCadastroTipoAtividade
        tipoAtividade.ValidaExclusao(tipo)

    End Function

    Friend Function CodigoSendoUsado(codigoAtividade As Integer) As String
        Dim tipoAtividade As New clsTipo
        tipoAtividade.Inicializa(codigoAtividade)

        If tipoAtividade.ID > 0 Then
            Throw New Exception("Código do Tipo de Atividade está sendo utilizado.")
        End If

        Return ""
    End Function

    Friend Function Salvar(json As String) As String
        Salvar = "Erro"

        Dim controle As New clsCadastroTipoAtividade

        Dim listaTiposJson = DeserializarNewtonsoft(funTrataJson(json))
        Dim listaTiposExcluidos = RetornaListaTiposExcluidos(listaTiposJson)

        If controle.GravaTipos(listaTiposJson, listaTiposExcluidos) Then
            Return "Sucesso"
        End If

    End Function

    Private Function funTrataJson(json As String) As String
        Return json.Replace("""Descrição"":", """Descricao"":").Replace("""Código"":", """Codigo"":")
    End Function

    Private Function RetornaListaTiposExcluidos(listaTiposJson As List(Of clsTipo)) As Object


        Dim tiposAtuais = New clsCadastroTipoAtividade().CarregarTiposAtividades
        Dim listaRemovidos As New List(Of clsTipo)

        For Each tipo In tiposAtuais
            If Not listaTiposJson.Exists(Function(x) x.CODIGO = tipo.CODIGO Or x.ID = tipo.ID) Then
                listaRemovidos.Add(tipo)
            End If
        Next

        Return listaRemovidos
    End Function

    Private Function DeserializarNewtonsoft(json As String) As List(Of clsTipo)
        Dim listaWeb = Newtonsoft.Json.JsonConvert.DeserializeObject(Of tipoTeste)(json)
        Dim listaTipo As New List(Of clsTipo)
        For Each tipo In listaWeb.Tipos
            Dim aux As New clsTipo

            aux.Inicializa(tipo.Codigo)
            aux.CODIGO = tipo.Codigo
            aux.DESCRICAO = tipo.Descricao

            listaTipo.Add(aux)
        Next

        Return listaTipo
    End Function

    Public Class tipoTeste
        Public Property Tipos As List(Of clsTipoWeb)
    End Class

    Public Class clsTipoWeb
        Public Property Codigo As Integer
        Public Property Descricao As String
    End Class

End Class
