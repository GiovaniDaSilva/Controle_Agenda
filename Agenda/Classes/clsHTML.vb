Imports HtmlAgilityPack


Public Class clsHTML
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
        Dim camposHTML As New CamposHTML
        For Each row As HtmlNode In table.SelectNodes("tr")
            iLinha += 1

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

    Public Class CamposHTML
        Public Property UF As Integer
        Public Property Codigo As Integer
        Public Property Resumo As Integer
        Public Property Objeto As Integer
        Public Property SubTipo As Integer
        Public Property Situacao As Integer
    End Class
End Class

Public Class clsHTMLTools
    Public Shared Function funLinhaTabela(ByVal pColunas As List(Of String), optional byval classe As String = vbNullString , Optional byval estilo As string = vbNullString) As String
        Dim retorno As String = vbNullString


        retorno = "<tr>"
        For Each col In pColunas
            retorno &= "<td "

            If classe <> vbNullString 
                retorno &= classe
            End If
            
            If estilo  <> vbNullString 
                retorno &= estilo 
            End If

            retorno &= " >" & col.ToString & "</td>"
        Next
        retorno &= "</tr>"

        Return retorno
    End Function

End Class


