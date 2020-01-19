﻿Imports HtmlAgilityPack


Public Class clsHTML
    Public Shared Function funCarregaSolicitacoes(ByVal pHTML As String) As List(Of clsSolicitacao)


        Dim locLista As New List(Of clsSolicitacao)
        Dim locSolicitaco As clsSolicitacao
        Dim iLinha As Integer = 0
        Dim iColuna As Integer = 0

        If pHTML = vbNullString Then Return locLista

        Dim locstring = clsTools.funLimpaHTMLTableSolicitacoes(pHTML)
        Dim doc As New HtmlDocument()

        Try
            If locstring = vbNullString Then
                Throw New Exception("HTML incorreto.")
            End If

            doc.LoadHtml(locstring)
            Dim nodes = doc.DocumentNode.SelectNodes("//table")
            Dim table = nodes(5)

            'For Each table As HtmlNode In nodes(5)

            For Each row As HtmlNode In table.SelectNodes("tr")
                iLinha += 1
                If iLinha = 1 Then Continue For

                locSolicitaco = New clsSolicitacao
                iColuna = 0
                For Each cell As HtmlNode In row.SelectNodes("th|td")
                    iColuna += 1

                    Select Case iColuna
                        Case 1 : locSolicitaco.UF = cell.InnerText
                        Case 2 : locSolicitaco.Codigo = Val(cell.InnerText)
                        Case 3 : locSolicitaco.Resumo = Trim(cell.InnerText)
                        Case 4 : locSolicitaco.Objeto = Trim(cell.InnerText)
                        Case 5 : locSolicitaco.SubTipo = Trim(cell.InnerText)
                        Case 6 : locSolicitaco.Situacao = Trim(cell.InnerText)
                    End Select

                Next cell
                locLista.Add(locSolicitaco)
            Next row
            'next table

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try



        Return locLista
    End Function
End Class


