Imports System.IO
Imports System.Net
Imports HtmlAgilityPack


Public Class clsHTML

    ''' <summary>
    ''' Carrega as colunas necessárias da pagina HTML do sistema de consulta de solicitações
    ''' </summary>
    ''' <param name="pHTML"></param>
    ''' <returns></returns>
    Public Shared Function funCarregaSolicitacoes(ByVal pHTML As String) As List(Of clsSolicitacao)


        Dim locLista As New List(Of clsSolicitacao)
        Dim locSolicitaco As clsSolicitacao
        Dim iLinha As Integer = 0
        Dim iColuna As Integer = 0

        If pHTML = vbNullString Then Return locLista

        Dim locstring = clsTools.funLimpaHTMLTableSolicitacoes(pHTML)
        Dim doc As New HtmlDocument()


        If locstring = vbNullString Then
            Throw New Exception("HTML incorreto.")
        End If

        doc.LoadHtml(locstring)
        Dim nodes = doc.DocumentNode.SelectNodes("//table")
        Dim table = nodes(5)

        'For Each table As HtmlNode In nodes(5)
        Dim camposHTML As New CamposHTMLSolicitacaoImport
        For Each row As HtmlNode In table.SelectNodes("tr")
            iLinha += 1

            'Define a posição das colunas
            If iLinha = 1 Then
                iColuna = 0
                For Each cell As HtmlNode In row.SelectNodes("th|td")
                    iColuna += 1

                    Select Case Trim(cell.InnerText)
                        Case "UF" : camposHTML.UF = iColuna
                        Case "Código" : camposHTML.Codigo = iColuna
                        Case "Resumo" : camposHTML.Resumo = iColuna
                        Case "Objeto" : camposHTML.Objeto = iColuna
                        Case "Subtipo" : camposHTML.SubTipo = iColuna
                        Case "Situação" : camposHTML.Situacao = iColuna
                    End Select
                Next cell
                Continue For
            End If

            'Alimenta as colunas a serem importadas
            locSolicitaco = New clsSolicitacao
            iColuna = 0
            For Each cell As HtmlNode In row.SelectNodes("th|td")
                iColuna += 1

                Select Case iColuna
                    Case camposHTML.UF : locSolicitaco.UF = cell.InnerText
                    Case camposHTML.Codigo : locSolicitaco.Codigo = Val(cell.InnerText)
                    Case camposHTML.Resumo : locSolicitaco.Resumo = Trim(cell.InnerText)
                    Case camposHTML.Objeto : locSolicitaco.Objeto = Trim(cell.InnerText)
                    Case camposHTML.SubTipo : locSolicitaco.SubTipo = Trim(cell.InnerText)
                    Case camposHTML.Situacao : locSolicitaco.Situacao = Trim(cell.InnerText)
                End Select

            Next cell
            locLista.Add(locSolicitaco)
        Next row
        'next table


        Return locLista

    End Function

    ''' <summary>
    ''' Classe que define os campos a serem importados na impressao das atividades
    ''' </summary>
    Public Class CamposHTMLSolicitacaoImport
        Public Property UF As Integer
        Public Property Codigo As Integer
        Public Property Resumo As Integer
        Public Property Objeto As Integer
        Public Property SubTipo As Integer
        Public Property Situacao As Integer
    End Class
End Class

''' <summary>
''' Classe para tratar funções que auxiliar o preenchimento do html
''' </summary>
Public Class clsHTMLTools
    Public Shared Function funLinhaTabela(ByVal pColunas As List(Of String), Optional ByVal classe As String = vbNullString, Optional ByVal estilo As String = vbNullString) As String
        Dim retorno As String = vbNullString


        retorno = "<tr>"
        For Each col In pColunas
            retorno &= "<td "

            If classe <> vbNullString
                retorno &= classe
            End If

            If estilo <> vbNullString
                retorno &= estilo
            End If

            retorno &= " >" & col.ToString & "</td>"
        Next
        retorno &= "</tr>"

        Return retorno
    End Function

    ''' <summary>
    ''' Ajustar o campo dentro do array que venho do post, removendo o nome do campo e o sinal de igual
    ''' </summary>
    ''' <param name="campo"></param>
    ''' <returns></returns>
    Public Shared Function RetornaValorPostGet(ByVal campo As String) As String
        Return campo.ToString.Replace(campo.ToString.Substring(0, campo.IndexOf("=") + 1), "")
    End Function

    ''' <summary>
    ''' Converte o post dentro do request em array de string
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Public Shared Function RetornaPostEmArray(pContext As HttpListenerContext) As String()
        Return New StreamReader(pContext.Request.InputStream).ReadToEnd().Split(New Char() {"?", "&"})
    End Function

    ''' <summary>
    ''' Converte o get dentro da url em array de string
    ''' </summary>
    ''' <param name="pContext"></param>
    ''' <returns></returns>
    Public Shared Function RetornaGetEmArray(pContext As HttpListenerContext) As String()
        Return pContext.Request.Url.Query.ToString.Split(New Char() {"?", "&"})
    End Function

End Class


