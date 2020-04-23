Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class clsRequisicoesWeb

    ''' <summary>
    ''' Trata as requisições web
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    Public Sub trataRequisicoesWeb(pReqWeb As clsReqWeb)
        Dim locPagRetorno As String = clsHTMLTools.RetornaPaginaErro("Página não encontrada", "A página solicitada não foi encontrada.")
        Try
            Select Case pReqWeb.Context.Request.Url.AbsolutePath
                Case "/Home"
                    locPagRetorno = funRetornaPaginaHome(pReqWeb)
                Case "/home_get_detalhes"
                    locPagRetorno = funRetornaDetalhesAtividade(pReqWeb)
                Case "/CadastroAtividade"
                    locPagRetorno = funRetornaCadastroAtividade(pReqWeb)
                Case "/CadastroAtividade_get_descricao"
                    locPagRetorno = funRetornaDescricaoAtividade(pReqWeb)
                Case "/CadastroAtividade_salvar"
                    locPagRetorno = funRetornaCadastroAtividade_Salvar(pReqWeb)
                Case "/CadastroAtividade_excluir"
                    locPagRetorno = funRetornaCadastroAtividade_Excluir(pReqWeb)
                Case "/CadastroAtividade_get_periodos_dia"
                    locPagRetorno = funRetornaCadastroAtividadePeriodosDia(pReqWeb)
                Case "/ControlePonto"
                    locPagRetorno = funRetornaControlePonto(pReqWeb)
                Case "/ControlePonto_salvar"
                    locPagRetorno = funRetornaControlePonto_Salvar(pReqWeb)
                Case "/ControlePonto_excluir"
                    locPagRetorno = funRetornaControlePonto_Excluir(pReqWeb)
                Case "/Grafico"
                    locPagRetorno = funRetornaPaginaGrafico(pReqWeb)
                Case "/Impressao"
                    locPagRetorno = funRetornaPaginaImpressao(pReqWeb)
                Case "/Versoes"
                    locPagRetorno = My.Resources.Versoes
                Case "/favicon.ico"
                    pReqWeb.RetornaIcone = True
                    Exit Sub
            End Select

            clsHTMLComum.TrataParametrosComuns(locPagRetorno)

            pReqWeb.HTML = locPagRetorno
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.OK

        Catch ex As Exception
            pReqWeb.HTML = clsHTMLTools.RetornaPaginaErro("Ops.. Ocorreu o seguinte erro", ex.Message)
        End Try

    End Sub

    Private Function funRetornaControlePonto_Excluir(pReqWeb As clsReqWeb) As String
        Dim id As Long = 0
        Dim retorno As New clsRetornoAjax
        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

                If arr.Count = 0 Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If

                If Not IsNumeric(arr(0)) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("ID inválido.")
                End If

                id = arr(0)
            End If

            If id <= 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("ID inválido.")
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = New clsControlePontoWeb().funRetornaControlePonto_Excluir(id)
            Catch ex As Exception
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                Throw
            End Try


        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)
    End Function

    Private Function funRetornaControlePonto_Salvar(pReqWeb As clsReqWeb) As String
        Dim json As String = vbNullString
        Dim retorno As New clsRetornoAjax

        Try

            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                json = New StreamReader(pReqWeb.Context.Request.InputStream).ReadToEnd()

                If json = vbNullString Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = New clsControlePontoWeb().RetornaControlePonto_Salvar(json)
            Catch ex As Exception
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                Throw
            End Try


        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)
    End Function

    Private Function funRetornaControlePonto(pReqWeb As clsReqWeb) As String
        Dim locAtividade As New clsAtividade
        Dim locPonto As New clsPonto
        Dim dataGet As Date

        dataGet = Now

        If pReqWeb.Context.Request.Url.Query <> vbNullString AndAlso pReqWeb.Context.Request.HttpMethod = "GET" Then

            Dim arr = clsHTMLTools.RetornaGetEmArray(pReqWeb.Context)
            If arr.Count = 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Parâmetros da Pagina estão inválidos.")
            End If


            Dim data = clsHTMLTools.RetornaValorPostGet(arr(1))
            If data <> vbNullString Then
                If Not IsDate(data) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Data do POST inválida.")
                End If
                dataGet = CDate(data)

            End If
        End If
        locPonto.dataPonto = dataGet
        locPonto = New clsControlePonto().CarregaPonto(locPonto)

        If locPonto.id_Ponto = 0 Then
            locPonto.dataPonto = dataGet
        End If
        Try
            Return New clsControlePontoWeb().RetornaPagina(locPonto)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Controle de Ponto.")
        End Try
    End Function

    Private Function funRetornaPaginaImpressao(pReqWeb As clsReqWeb) As String

        Dim filtro As New clsAtividade
        Dim post() As String
        Dim ParametrosIni = New clsIni().funCarregaIni()

        'Por default pega do ini
        If ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Atual Then
            filtro.Data = Now
        ElseIf ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Dias7 Then
            filtro.Data = Now.AddDays(-7)
        End If

        If pReqWeb.Context.Request.HttpMethod = "POST" Then

            post = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)
            If post.Count = 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Parâmetros do POST não foram informados.")
            End If

            Dim data = clsHTMLTools.RetornaValorPostGet(post(0))
            If data <> vbNullString Then
                If Not IsDate(data) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Data do POST inválida.")
                End If
                filtro.Data = CDate(data)
            End If

            Dim tipo = clsHTMLTools.RetornaValorPostGet(post(1))
            If tipo < 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Tipo de Atividade do POST inválido.")
            End If
            filtro.ID_TIPO_ATIVIDADE = tipo
        End If

        Try
            Return New clsImpressaoWeb().RetornaPagina(filtro)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Impressão.")
        End Try



    End Function

    Private Function funRetornaDetalhesAtividade(pReqWeb As clsReqWeb) As String
        Dim locDetalhes As New clsParametrosDetalhesAtividadeWeb
        If pReqWeb.Context.Request.HttpMethod = "POST" Then
            Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

            If Not IsNumeric(clsHTMLTools.RetornaValorPostGet(arr(0))) Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("ID inválido.")
            End If

            If Not IsDate(clsHTMLTools.RetornaValorPostGet(arr(1))) Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Data inválido.")
            End If


            locDetalhes.id = Val(clsHTMLTools.RetornaValorPostGet(arr(0)))
            locDetalhes.data = CDate(clsHTMLTools.RetornaValorPostGet(arr(1)))
            locDetalhes.codigo = clsHTMLTools.RetornaValorPostGet(arr(2))
        End If

        Return New clsCadastroAtividadeWeb().funRetornaCadastroAtividade_Detalhes(locDetalhes)
    End Function

    Private Function funRetornaCadastroAtividade_Excluir(pReqWeb As clsReqWeb) As String
        Dim id As Long = 0
        Dim retorno As New clsRetornoAjax
        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

                If arr.Count = 0 Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If

                If Not IsNumeric(arr(0)) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("ID inválido.")
                End If

                id = arr(0)
            End If

            If id <= 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("ID inválido.")
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = New clsCadastroAtividadeWeb().funRetornaCadastroAtividade_Excluir(id)
            Catch ex As Exception
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                Throw
            End Try


        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)
    End Function

    Private Function funRetornaCadastroAtividadePeriodosDia(pReqWeb As clsReqWeb) As String
        Dim data As Date
        Dim retorno As New clsRetornoAjax

        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

                If arr.Count = 0 Then
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If

                If Not IsDate(arr(0)) Then
                    Throw New Exception("Data inválida.")
                End If

                data = CDate(arr(0))
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = clsHTMLComum.RetornaTabelaPeriodosDia(data)
            Catch ex As Exception
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                Throw New Exception("Erro ao carregar os períodos do dia.")
            End Try

        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)

    End Function

    Private Function funRetornaCadastroAtividade_Salvar(pReqWeb As clsReqWeb) As String

        Dim json As String = vbNullString
        Dim retorno As New clsRetornoAjax

        Try

            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                json = New StreamReader(pReqWeb.Context.Request.InputStream).ReadToEnd()

                If json = vbNullString Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = New clsCadastroAtividadeWeb().RetornaCadastroAtividade_Salvar(json)
            Catch ex As Exception
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                Throw
            End Try


        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)
    End Function

    ''' <summary>
    ''' Retorna a Pagina de Cadastro de Atividade
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    ''' <returns></returns>
    Private Function funRetornaCadastroAtividade(pReqWeb As clsReqWeb) As String
        Dim locAtividade As New clsAtividade


        If pReqWeb.Context.Request.Url.Query <> vbNullString AndAlso pReqWeb.Context.Request.HttpMethod = "GET" Then

            Dim arr = clsHTMLTools.RetornaGetEmArray(pReqWeb.Context)
            If arr.Count = 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Parâmetros da Pagina estão inválidos.")
            End If


            Dim id = Val(clsHTMLTools.RetornaValorPostGet(arr(1)))
            If id <= 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("ID da atividade inválido.")
            End If

            locAtividade = New clsAtividade(id)
        End If

        Try
            Return New clsCadastroAtividadeWeb().RetornaPaginaCadastroAtividade(locAtividade)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Cadastro de Atividade.")
        End Try

    End Function

    ''' <summary>
    ''' Retorna a descrição da atividade da pagina hora atraves de ajax
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    ''' <returns></returns>
    Private Function funRetornaDescricaoAtividade(pReqWeb As clsReqWeb) As String
        Dim DAO As New clsAdicionarDAO
        Dim retorno As New clsRetornoAjax

        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

                If arr.Count = 0 Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Parâmetros da Pagina estão inválidos.")
                End If

                Dim id = arr(0)
                If Val(id) <= 0 Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("ID da atividade inválido.")
                End If

                Try
                    retorno.descricao = clsTools.RetornaCampoTabela("ATIVIDADES", "DESCRICAO", "ID = " & id)
                    retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                Catch ex As Exception
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
                    Throw New Exception("Erro ao carregar descrição da atividade.")
                End Try

            End If
        Catch ex As Exception
            retorno.codigo = clsRetornoAjax.enuCodigosRet.ERRO
            retorno.descricao = ex.Message
        End Try

        Return Newtonsoft.Json.JsonConvert.SerializeObject(retorno)
    End Function
    ''' <summary>
    ''' Chama a classe para tratar a pagina home
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    ''' <returns></returns>
    Private Function funRetornaPaginaHome(pReqWeb As clsReqWeb) As String

        Dim post() As String
        Dim locParametros As New clsParametrosFiltroWeb
        Dim ParametrosIni = New clsIni().funCarregaIni()
        Dim retorno As String = ""

        'Por default pega do ini
        If ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Atual Then
            locParametros.Data = Now
        ElseIf ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Dias7 Then
            locParametros.Data = Now.AddDays(-7)
        End If

        If pReqWeb.Context.Request.HttpMethod = "POST" Then

            post = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)
            If post.Count = 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Parâmetros do POST não foram informados.")
            End If

            Dim data = clsHTMLTools.RetornaValorPostGet(post(0))
            If data <> vbNullString Then
                If Not IsDate(data) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Data do POST inválida.")
                End If
                locParametros.Data = CDate(data)
            End If

            Dim tipo = clsHTMLTools.RetornaValorPostGet(post(1))
            If tipo < 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Tipo de Atividade do POST inválido.")
            End If
            locParametros.Tipo = tipo
        End If

        Try
            Return New clsHomeWeb().RetornaPaginaHome(locParametros)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Home.")
        End Try

    End Function

    ''' <summary>
    ''' Chama a classe para tratar a pagina de grafico
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    ''' <returns></returns>
    Private Function funRetornaPaginaGrafico(pReqWeb As clsReqWeb) As String
        Dim locDataInicial = clsTools.RetornaPrimeiroDiaMes()
        Dim locDataFinal = clsTools.RetornaUltimoDiaMes()


        If pReqWeb.Context.Request.Url.Query <> vbNullString Then
            Dim arr = clsHTMLTools.RetornaGetEmArray(pReqWeb.Context)
            If arr.Count = 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Parâmetros da Pagina estão inválidos.")
            End If

            Dim mesGeracao = clsHTMLTools.RetornaValorPostGet(arr(1))
            If mesGeracao = vbNullString Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Mês informado não é válido.")
            End If

            locDataInicial = clsTools.RetornaPrimeiroDiaMes(mesGeracao)
            locDataFinal = clsTools.RetornaUltimoDiaMes(mesGeracao)
        End If

        Try
            Return New clsGraficoWeb().RetornaPaginaGrafico(locDataInicial, locDataFinal)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página de gráfico.")
        End Try

    End Function
End Class


