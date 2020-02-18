Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class clsRequisicoesWeb

    ''' <summary>
    ''' Trata as requisições do servidor
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Public Function trataRequisicoesWeb(pContext As HttpListenerContext) As String
        Dim locPagRetorno As String = My.Resources.Pagina_Não_Encontrada
        Try
            Select Case pContext.Request.Url.AbsolutePath
                Case "/Home"
                    locPagRetorno = funRetornaPaginaHome(pContext)
                Case "/home_get_descricao"
                    locPagRetorno = funRetornaDescricaoAtividade(pContext)
                Case "/CadastroAtividade"
                    locPagRetorno = funRetornaCadastroAtividade(pContext)
                Case "/CadastroAtividade_salvar"
                    locPagRetorno = funRetornaCadastroAtividade_Salvar(pContext)
                Case "/CadastroAtividade_excluir"
                    locPagRetorno = funRetornaCadastroAtividade_Excluir(pContext)
                Case "/CadastroAtividade_get_periodos_dia"
                    locPagRetorno = funRetornaCadastroAtividadePeriodosDia(pContext)
                Case "/Grafico"
                    locPagRetorno = funRetornaPaginaGrafico(pContext)
                Case "/Versoes"
                    locPagRetorno = My.Resources.Versoes
            End Select
        Catch ex As Exception
            Return ex.Message
        End Try

        clsHTMLComum.TrataParametrosComuns(locPagRetorno)

        Return locPagRetorno
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

            Data = CDate(arr(0))
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
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Private Function funRetornaPaginaHome(pContext As HttpListenerContext) As String

        Dim post() As String
        Dim locParametros As New clsHomeParametros
        Dim ParametrosIni = New clsIni().funCarregaIni()

        'Por default pega do ini
        If ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Atual Then
            locParametros.Data = Now
        ElseIf ParametrosIni.InicializarCampoApartirDe = enuApartirDe.Dias7 Then
            locParametros.Data = Now.AddDays(-7)
        End If

        If pContext.Request.HttpMethod = "POST" Then
            post = clsHTMLTools.RetornaPostEmArray(pContext)

            Dim data = clsHTMLTools.RetornaValorPostGet(post(0))
            If data <> vbNullString Then
                locParametros.Data = CDate(data)
            End If
            locParametros.Tipo = clsHTMLTools.RetornaValorPostGet(post(1))
        End If

        Return New clsHomeWeb().RetornaPaginaHome(locParametros)

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


