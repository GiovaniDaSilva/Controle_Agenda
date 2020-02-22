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
                    locPagRetorno = funRetornaCadastroAtividade(pReqWeb.Context)
                Case "/CadastroAtividade_get_descricao"
                    locPagRetorno = funRetornaDescricaoAtividade(pReqWeb.Context)
                Case "/CadastroAtividade_salvar"
                    locPagRetorno = funRetornaCadastroAtividade_Salvar(pReqWeb.Context)
                Case "/CadastroAtividade_excluir"
                    locPagRetorno = funRetornaCadastroAtividade_Excluir(pReqWeb.Context)
                Case "/CadastroAtividade_get_periodos_dia"
                    locPagRetorno = funRetornaCadastroAtividadePeriodosDia(pReqWeb.Context)
                Case "/Grafico"
                    locPagRetorno = funRetornaPaginaGrafico(pReqWeb.Context)
                Case "/Versoes"
                    locPagRetorno = My.Resources.Versoes
            End Select

            clsHTMLComum.TrataParametrosComuns(locPagRetorno)

            pReqWeb.HTML = locPagRetorno
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.OK

        Catch ex As Exception
            pReqWeb.HTML = clsHTMLTools.RetornaPaginaErro("Ops.. Ocorreu o seguinte erro", ex.Message)
        End Try

    End Sub

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

    Private Function funRetornaCadastroAtividade_Excluir(pContext As HttpListenerContext) As String
        Dim id As Long = 0

        If pContext.Request.HttpMethod = "POST" Then
            Dim arr = clsHTMLTools.RetornaPostEmArray(pContext)

            If Not IsNumeric(arr(0)) Then
                Throw New Exception("ID inválido.")
            End If
            id = arr(0)
        End If

        Return New clsCadastroAtividadeWeb().funRetornaCadastroAtividade_Excluir(id)

    End Function

    Private Function funRetornaCadastroAtividadePeriodosDia(pContext As HttpListenerContext) As String
        Dim data As Date

        If pContext.Request.HttpMethod = "POST" Then
            Dim arr = clsHTMLTools.RetornaPostEmArray(pContext)

            If Not IsDate(arr(0)) Then
                Throw New Exception("Data inválida.")
            End If

            data = CDate(arr(0))
        End If

        Return New clsCadastroAtividadeWeb().RetornaTabelaPeriodosDia(data)
    End Function

    Private Function funRetornaCadastroAtividade_Salvar(pContext As HttpListenerContext) As String

        Dim json As String = vbNullString

        If pContext.Request.HttpMethod = "POST" Then
            json = New StreamReader(pContext.Request.InputStream).ReadToEnd()
        End If

        Return New clsCadastroAtividadeWeb().RetornaCadastroAtividade_Salvar(json)
    End Function

    ''' <summary>
    ''' Retorna a Pagina de Cadastro de Atividade
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Private Function funRetornaCadastroAtividade(pContext As HttpListenerContext) As String
        Dim locAtividade As New clsAtividade


        If pContext.Request.Url.Query <> vbNullString AndAlso pContext.Request.HttpMethod = "GET" Then

            Dim arr = clsHTMLTools.RetornaGetEmArray(pContext)
            Dim id = Val(clsHTMLTools.RetornaValorPostGet(arr(1)))

            If id <= 0 Then
                Throw New Exception("ID da ativiadde zerado.")
            End If

            locAtividade = New clsAtividade(id)
        End If

        Return New clsCadastroAtividadeWeb().RetornaPaginaCadastroAtividade(locAtividade)
    End Function

    ''' <summary>
    ''' Retorna a descrição da atividade da pagina hora atraves de ajax
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Private Function funRetornaDescricaoAtividade(pContext As HttpListenerContext) As String
        Dim DAO As New clsAdicionarDAO
        Dim locDescricao As String = vbNullString

        If pContext.Request.HttpMethod = "POST" Then
            Dim ID = clsHTMLTools.RetornaPostEmArray(pContext)

            locDescricao = clsTools.RetornaCampoTabela("ATIVIDADES", "DESCRICAO", "ID = " & ID(0))
        End If
        Return locDescricao
    End Function
    ''' <summary>
    ''' Chama a classe para tratar a pagina home
    ''' </summary>
    ''' <param name="pReqWeb"></param>
    ''' <returns></returns>
    Private Function funRetornaPaginaHome(pReqWeb As clsReqWeb) As String

        Dim post() As String
        Dim locParametros As New clsHomeParametros
        Dim ParametrosIni = New clsIni().funCarregaIni()
        Dim retorno As String = ""

        Try

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
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Chama a classe para tratar a pagina de grafico
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Private Function funRetornaPaginaGrafico(pContext As HttpListenerContext) As String
        Dim locDataInicial = clsTools.RetornaPrimeiroDiaMes()
        Dim locDataFinal = clsTools.RetornaUltimoDiaMes()


        If pContext.Request.Url.Query <> vbNullString Then
            Dim mesGeracao = String.Join(String.Empty, pContext.Request.Url.ToString.Split("?").Skip(1)).Replace("meseslista=", "")

            If mesGeracao = vbNullString Then
                Throw New Exception("Parâmetros da Pagina estão inválidos.")
            End If

            locDataInicial = clsTools.RetornaPrimeiroDiaMes(mesGeracao)
            locDataFinal = clsTools.RetornaUltimoDiaMes(mesGeracao)
        End If

        Return New clsGraficoWeb().RetornaPaginaGrafico(locDataInicial, locDataFinal)
    End Function
End Class


