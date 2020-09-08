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
            Dim path = pReqWeb.Context.Request.Url.AbsolutePath.Replace("/", "")
            Select Case path
                Case clsPaginasWeb.Home
                    locPagRetorno = funRetornaPaginaHome(pReqWeb)
                Case clsPaginasWeb.Home & "_get_detalhes"
                    locPagRetorno = funRetornaDetalhesAtividade(pReqWeb)
                Case clsPaginasWeb.CadastroAtividade
                    locPagRetorno = funRetornaCadastroAtividade(pReqWeb)
                Case clsPaginasWeb.CadastroAtividade & "_get_descricao"
                    locPagRetorno = funRetornaDescricaoAtividade(pReqWeb)
                Case clsPaginasWeb.CadastroAtividade & "_salvar"
                    locPagRetorno = funRetornaCadastroAtividade_Salvar(pReqWeb)
                Case clsPaginasWeb.CadastroAtividade & "_excluir"
                    locPagRetorno = funRetornaCadastroAtividade_Excluir(pReqWeb)
                Case clsPaginasWeb.CadastroAtividade & "_get_periodos_dia"
                    locPagRetorno = funRetornaCadastroAtividadePeriodosDia(pReqWeb)
                Case clsPaginasWeb.ControlePonto
                    locPagRetorno = funRetornaControlePonto(pReqWeb)
                Case clsPaginasWeb.ControlePonto & "_salvar"
                    locPagRetorno = funRetornaControlePonto_Salvar(pReqWeb)
                Case clsPaginasWeb.ControlePonto & "_excluir"
                    locPagRetorno = funRetornaControlePonto_Excluir(pReqWeb)
                Case clsPaginasWeb.Grafico
                    locPagRetorno = funRetornaPaginaGrafico(pReqWeb)
                Case clsPaginasWeb.ImpressaoAtividade
                    locPagRetorno = funRetornaPaginaImpressao(pReqWeb)
                Case clsPaginasWeb.ImpressaoPonto
                    locPagRetorno = funRetornaPaginaImpressaoPonto(pReqWeb)
                Case clsPaginasWeb.Versoes
                    locPagRetorno = My.Resources.Versoes
                Case clsPaginasWeb.Configuracao
                    locPagRetorno = funRetornaPaginaConfiguracao(pReqWeb)
                Case clsPaginasWeb.Configuracao & "_Salvar"
                    locPagRetorno = funRetornaPaginaConfiguracao_Salvar(pReqWeb)
                Case clsPaginasWeb.Configuracao & "_backup"
                    locPagRetorno = funRetornaPaginaConfiguracao_BackupBase(pReqWeb)
                Case clsPaginasWeb.CadastroTipo
                    locPagRetorno = funRetornaPaginaCadastroTipo(pReqWeb)
                Case clsPaginasWeb.CadastroTipo & "_ValidaCodigo"
                    locPagRetorno = funRetornaPaginaCadastroTipo_ValidaCodigo(pReqWeb)
                Case "favicon.ico"
                    pReqWeb.RetornaIcone = True
                    Exit Sub
                Case "Engrenagem.gif"
                    pReqWeb.RetornaEngrenagem = True
                    Exit Sub
            End Select

            clsHTMLComum.TrataParametrosComuns(locPagRetorno)

            pReqWeb.HTML = locPagRetorno
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.OK

        Catch ex As Exception
            pReqWeb.HTML = clsHTMLTools.RetornaPaginaErro("Ops.. Ocorreu o seguinte erro", ex.Message)
        End Try

    End Sub

    Private Function funRetornaPaginaCadastroTipo_ValidaCodigo(pReqWeb As clsReqWeb) As String
        Throw New NotImplementedException()
    End Function

    Private Function funRetornaPaginaCadastroTipo(pReqWeb As clsReqWeb) As String

        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

            End If

            Return New clsCadastroTipoWeb().RetornaPagina()
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Configurações.")
        End Try

    End Function

    Private Function funRetornaPaginaConfiguracao_BackupBase(pReqWeb As clsReqWeb) As String
        Dim json As String = vbNullString
        Dim retorno As New clsRetornoAjax
        Dim enviarEmail As Boolean = False
        Try
            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)
                enviarEmail = CBool(arr(0))
            End If

            Try
                retorno.codigo = clsRetornoAjax.enuCodigosRet.SUCESSO
                retorno.descricao = New clsConfiguracaoWeb().RetornaConfiguracaoBackupBase(enviarEmail)
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

    Private Function funRetornaPaginaConfiguracao(pReqWeb As clsReqWeb) As String
        Try

            If pReqWeb.Context.Request.HttpMethod = "POST" Then
                Dim arr = clsHTMLTools.RetornaPostEmArray(pReqWeb.Context)

            End If

            Return New clsConfiguracaoWeb().RetornaPagina()
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Configurações.")
        End Try
    End Function

    Private Function funRetornaPaginaConfiguracao_Salvar(pReqWeb As clsReqWeb) As String
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
                retorno.descricao = New clsConfiguracaoWeb().RetornaConfiguracaoSalvar(json)
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

        Dim filtro As New clsFiltroAtividades
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

            Dim dataAte = clsHTMLTools.RetornaValorPostGet(post(1))
            If dataAte <> vbNullString Then
                If Not IsDate(dataAte) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Data do POST inválida.")
                End If
                filtro.DataFinal = CDate(dataAte)
            End If

            Dim tipo = clsHTMLTools.RetornaValorPostGet(post(2))
            If tipo < 0 Then
                pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                Throw New Exception("Tipo de Atividade do POST inválido.")
            End If
            filtro.ID_TIPO_ATIVIDADE = tipo


            Dim ordenacao = clsHTMLTools.RetornaValorPostGet(post(3))
            If ordenacao = "C" Then
                filtro.Ordenacao = clsFiltroAtividades.enuOrdenacao.Crescente
            Else
                filtro.Ordenacao = clsFiltroAtividades.enuOrdenacao.Decrescente
            End If
        End If

        Try
            Return New clsImpressaoAtividadeWeb().RetornaPagina(filtro)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Impressão de Atividades.")
        End Try



    End Function

    Private Function funRetornaPaginaImpressaoPonto(pReqWeb As clsReqWeb) As String

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
            Return New clsImpressaoPontoWeb().RetornaPagina(locDataInicial, locDataFinal)
        Catch ex As Exception
            pReqWeb.Context.Response.StatusCode = HttpStatusCode.InternalServerError
            Throw New Exception("Erro ao carregar a página Impressão de Ponto.")
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
        Dim locDuplicarAtividade As Boolean = False

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

            If arr.Count = 3 Then
                locDuplicarAtividade = CBool(clsHTMLTools.RetornaValorPostGet(arr(2)))
            End If

        End If

        Try
            Return New clsCadastroAtividadeWeb().RetornaPaginaCadastroAtividade(locAtividade, locDuplicarAtividade)
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

            Dim dataAte = clsHTMLTools.RetornaValorPostGet(post(1))
            If dataAte <> vbNullString Then
                If Not IsDate(dataAte) Then
                    pReqWeb.Context.Response.StatusCode = HttpStatusCode.BadRequest
                    Throw New Exception("Data do POST inválida.")
                End If
                locParametros.DataAte = CDate(dataAte)
            End If

            Dim tipo = clsHTMLTools.RetornaValorPostGet(post(2))
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

    Public Shared Sub ChamaPagina(pagina As String)
        Process.Start(clsServidorHTTP.local & pagina)
    End Sub

    Public Shared Sub ChamaPaginaExterna(pagina As String)
        Process.Start(pagina)
    End Sub

End Class

Public Class clsPaginasWeb
    Public Shared ReadOnly Property Home = "Home"
    Public Shared ReadOnly Property CadastroAtividade = "CadastroAtividade"
    Public Shared ReadOnly Property ControlePonto = "ControlePonto"
    Public Shared ReadOnly Property Grafico = "Grafico"
    Public Shared ReadOnly Property ImpressaoAtividade = "ImpressaoAtividade"
    Public Shared ReadOnly Property ImpressaoPonto = "ImpressaoPonto"
    Public Shared ReadOnly Property Versoes = "Versoes"
    Public Shared ReadOnly Property Configuracao = "Configuracao"
    Public Shared ReadOnly Property CadastroTipo = "CadastroTipo"
End Class
