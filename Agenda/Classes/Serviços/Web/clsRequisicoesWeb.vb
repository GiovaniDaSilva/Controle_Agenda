Imports System.IO
Imports System.Net
Imports System.Web

Public Class clsRequisicoesWeb

    Public Function trataRequisicoesWeb(pContext As HttpListenerContext) As String
        Dim locPagRetorno As String = My.Resources.Pagina_Não_Encontrada
        Try
            Select Case pContext.Request.Url.AbsolutePath
                Case "/Home"
                    locPagRetorno = funRetornaPaginaHome(pContext)
                Case "/Grafico"
                    locPagRetorno = funRetornaPaginaGrafico(pContext)
                Case "/Versoes"
                    locPagRetorno = My.Resources.Versoes
            End Select
        Catch ex As Exception
            Return locPagRetorno
        End Try


        clsHTMLComum.TrataParametrosComuns(locPagRetorno)

        Return locPagRetorno
    End Function

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
            post = clsTools.RetornaPostEmArray(pContext)

            Dim data = clsTools.RetornaValorPost(post(0))
            If data <> vbNullString Then
                locParametros.Data = CDate(data)
            End If
            locParametros.Tipo = clsTools.RetornaValorPost(post(1))
        End If

        Return New clsHomeWeb().RetornaPaginaHome(locParametros)

    End Function


    Private Function funRetornaPaginaGrafico(pContext As HttpListenerContext) As String
        Dim locDataInicial = clsTools.RetornaPrimeiroDiaMes()
        Dim locDataFinal = clsTools.RetornaUltimoDiaMes()

        'Pode ser feito com array
        'Dim parts() As String
        'parts = pUri.ToString.Split(New Char() {"?", "&"})

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


