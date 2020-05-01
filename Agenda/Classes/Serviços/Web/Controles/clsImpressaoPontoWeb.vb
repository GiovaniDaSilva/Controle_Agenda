Imports System.Text

Public Class clsImpressaoPontoWeb

    Public Enum enuEstiloImpressao
        Data = 1
        Titulo = 2
        Titulo_Destaque = 3
        Informacao = 4
        Informacao_Destaque = 5
    End Enum

    Private Property html As New StringBuilder

    Public Function RetornaPagina(pDataInicial As Date, pDataFinal As Date) As String
        Return RetornaHTML(pDataInicial, pDataFinal)
    End Function

    Private Function RetornaHTML(pDataInicial As Date, pDataFinal As Date) As String

        Dim html As String
        html = My.Resources.ImpressaoPonto
        html = html.Replace("{p_meses_combo}", clsHTMLComum.RetornaMesesCombo(Month(pDataInicial)))
        html = html.Replace("{p_data_inicio}", clsTools.funFormataData(pDataInicial))
        html = html.Replace("{p_data_final}", clsTools.funFormataData(pDataFinal))
        html = html.Replace("{p_dados_impresso}", funRetornaDadosImpresso(pDataInicial, pDataFinal))
        html = html.Replace("[p_inicializa_campos]", funRetornaInicializaCampos(pDataInicial, pDataFinal))

        Return html
    End Function

    Private Function funRetornaInicializaCampos(pDataInicial As Date, pDataFinal As Date) As String
        Dim controle As New clsControlePonto
        Dim texto As New StringBuilder(String.Empty)
        Dim saldoGeral As String

        saldoGeral = controle.CalculaSaldoMes(pDataInicial, True)

        texto.AppendFormat("                    
            document.getElementById('SaldoGeral').innerHTML = ""{0}""
        ", saldoGeral)

        Return texto.ToString
    End Function

    Private Function funRetornaDadosImpresso(pDataInicial As Date, pDataFinal As Date) As String
        Dim listaPonto As New List(Of clsPonto)

        listaPonto = New clsControlePontoDAO().RetornaPontoPeriodo(pDataInicial, pDataFinal)

        subListaPontos(listaPonto)

        Return html.ToString
    End Function

    Private Sub subListaPontos(listaPonto As List(Of clsPonto))

        Dim dados As String = ""


        For Each ponto In listaPonto
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(funRetornaData(ponto)))
            linha.Add(New clsColunasTabela(funRetornaHoraTotal(ponto)))
            linha.Add(New clsColunasTabela(funRetornaPeriodo(ponto.Periodo)))
            linha.Add(New clsColunasTabela(funRetornaSaldoDia(ponto), "class='text-right'"))


            linha.Add(New clsColunasTabela(funRetornaBotao(ponto.dataPonto), "class='text-right'"))

            dados &= clsHTMLTools.funLinhaTabela(linha)
        Next


        html.Append(dados)

    End Sub

    Private Function funRetornaBotao(data As String) As String
        Dim icone_edit = "<i class=""material-icons"">edit</i>"
        Dim botao = "<a target=""_blank"" href=""ControlePonto?dataponto=" + data + """>" + icone_edit + "</a>"

        Return botao
    End Function

    Private Function funRetornaHoraTotal(ponto As clsPonto) As String
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho
        Dim total As String

        If ehHoraTotalNegativa(ponto, escala) Then
            total = clsHTMLTools.pintaDadoColunaTable(ponto.horaTotal, Color.Red)
        Else
            total = clsHTMLTools.pintaDadoColunaTable(ponto.horaTotal, Color.Green)
        End If

        Return total
    End Function

    Private Shared Function ehHoraTotalNegativa(ponto As clsPonto, escala As String) As Boolean


        If (CDate(ponto.dataPonto).DayOfWeek = DayOfWeek.Saturday Or CDate(ponto.dataPonto).DayOfWeek = DayOfWeek.Sunday) Then
            Return False
        End If

        If (TimeSpan.Parse(escala).TotalMinutes > TimeSpan.Parse(ponto.horaTotal).TotalMinutes) Then
            Return True
        End If

        Return False
    End Function

    Private Function funRetornaSaldoDia(ponto As clsPonto) As String
        Dim controle As New clsControlePonto

        Dim saldo = controle.CalculaSaldoDia(ponto.dataPonto)
        Dim icone_OK = "<i class=""material-icons"">thumb_up_alt</i>"


        If (saldo = "00:00") Then
            saldo = icone_OK
        Else
            If Mid(saldo, 1, 1) = "-" Then
                saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Red)
            Else
                saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Green)
            End If
        End If

        Return saldo
    End Function



    Private Function funRetornaPeriodo(periodo As List(Of clsPeriodoPonto)) As String
        Dim retorno As String = vbNullString

        For Each ponto In periodo
            retorno &= "[" & ponto.Entrada & "-" & ponto.Saida & "]  "
        Next

        Return retorno
    End Function

    Private Shared Function funRetornaData(ponto As clsPonto) As String
        Return clsTools.funFormataData(ponto.dataPonto) & "   " & clsTools.funRetornaDiaSemana(ponto.dataPonto, True)
    End Function

End Class
