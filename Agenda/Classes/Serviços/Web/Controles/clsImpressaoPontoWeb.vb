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
        Dim saldoGeralAcumulado As String

        saldoGeral = RetornaSaldoGeral(pDataInicial)

        saldoGeralAcumulado = RetornaSaldoAcumulado(pDataInicial)

        texto.AppendFormat("                    
            document.getElementById('SaldoGeral').innerHTML = ""{0};""
            document.getElementById('SaldoGeralAcumulado').innerHTML = ""{1};""
        ", saldoGeral, saldoGeralAcumulado)

        Return texto.ToString
    End Function

    Private Shared Function RetornaSaldoGeral(pDataInicial As Date) As String
        Dim controle As New clsControlePonto
        Dim saldo As String

        saldo = controle.CalculaSaldoMes(pDataInicial, False)
        Return funColoriSaldo(saldo)
    End Function

    Private Shared Function RetornaSaldoAcumulado(pDataInicial As Date) As String
        Dim controle As New clsControlePonto
        Dim saldo As String

        Dim inicial = clsTools.RetornaPrimeiroDiaMes(pDataInicial.Month - 1)
        Dim final = clsTools.RetornaUltimoDiaMes(pDataInicial.Month)

        saldo = controle.CalculaSaldoperiodo(inicial, final, False)
        Return funColoriSaldo(saldo)
    End Function

    Private Shared Function funColoriSaldo(saldo As String) As String
        If Mid(saldo, 1, 1) = "-" Then
            saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Red, "b")
        Else
            saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Green, "b")
        End If

        Return saldo
    End Function

    Private Function funRetornaDadosImpresso(pDataInicial As Date, pDataFinal As Date) As String
        Dim listaPonto As New List(Of clsPonto)

        listaPonto = New clsControlePontoDAO().RetornaPontoPeriodo(pDataInicial, pDataFinal)

        subAdicionaDiasSemApontamento(listaPonto, pDataInicial, pDataFinal)

        listaPonto = listaPonto.OrderBy(Function(x) CDate(x.dataPonto)).ToList()

        subListaPontos(listaPonto)

        Return html.ToString
    End Function

    ''' <summary>
    ''' Adiciona as datas que não foram gravado o ponto, para aparecer o mes completo na impressao
    ''' </summary>
    ''' <param name="listaPonto"></param>
    Private Sub subAdicionaDiasSemApontamento(ByRef listaPonto As List(Of clsPonto), ByVal pDataInicial As Date, ByVal pDataFinal As Date)


        While (pDataInicial <= pDataFinal)
            If listaPonto.Find(Function(x) CDate(x.dataPonto) = pDataInicial) Is Nothing Then
                Dim ponto As New clsPonto
                ponto.dataPonto = pDataInicial
                ponto.horaTotal = 0
                listaPonto.Add(ponto)
            End If

            pDataInicial = pDataInicial.AddDays(1)
        End While
    End Sub

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

            If CDate(ponto.dataPonto).DayOfWeek = DayOfWeek.Saturday Then
                subAdicionadoLinhaDivisao(dados, ponto)
            End If

        Next


        html.Append(dados)

    End Sub

    Private Sub subAdicionadoLinhaDivisao(ByRef dados As String, ponto As clsPonto)

        Dim controle As New clsControlePonto
        Dim saldoSemana As String

        saldoSemana = controle.CalculaSaldoSemana(CDate(ponto.dataPonto))

        If Mid(saldoSemana, 1, 1) = "-" Then
            saldoSemana = clsHTMLTools.pintaDadoColunaTable(saldoSemana, Color.Red)
        Else
            saldoSemana = clsHTMLTools.Tab & clsHTMLTools.pintaDadoColunaTable(saldoSemana, Color.Green)
        End If

        ''Para não começar a grid com a linha em branco
        If dados = "" Then Exit Sub
        Dim linha1 = New List(Of clsColunasTabela)

        linha1.Add(New clsColunasTabela("<b>Saldo da Semana:</b>"))
        linha1.Add(New clsColunasTabela(saldoSemana, "COLSPAN = ""4"""))

        dados &= clsHTMLTools.funLinhaTabela(linha1)

        Dim linha2 = New List(Of clsColunasTabela)

        linha2.Add(New clsColunasTabela("-", " COLSPAN = ""5"" class='text-right'"))
        dados &= clsHTMLTools.funLinhaTabela(linha2)


    End Sub

    Private Function funRetornaBotao(data As String) As String
        Dim icone_edit = "<i class=""material-icons"">edit</i>"
        Dim botao = "<a target=""_blank"" href=""ControlePonto?dataponto=" + data + """>" + icone_edit + "</a>"

        Return botao
    End Function

    Private Function funRetornaHoraTotal(ponto As clsPonto) As String
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho
        Dim total As String = vbNullString

        If ponto.horaTotal = "0" Then
            ponto.horaTotal = "00:00"
        End If

        'Adicionado um tab, para fazer o alinhamento com o saldo da semana
        If ehHoraTotalNegativa(ponto, escala) Then
            total = clsHTMLTools.pintaDadoColunaTable(clsHTMLTools.Tab() & ponto.horaTotal, Color.Red)
        Else
            total = clsHTMLTools.pintaDadoColunaTable(clsHTMLTools.Tab() & ponto.horaTotal, Color.Green)
        End If

        Return total
    End Function

    Private Shared Function ehHoraTotalNegativa(ponto As clsPonto, escala As String) As Boolean


        If clsTools.ehSabadoDomingo(ponto.dataPonto) Then
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
        Dim icone_futuro = "<i class=""material-icons"">remove</i>"

        If (ponto.dataPonto > Now) Then
            Return icone_futuro
        End If

        If (saldo = "00:00") Then
            Return icone_OK
        End If


        If Mid(saldo, 1, 1) = "-" Then
            saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Red)
        Else
            saldo = clsHTMLTools.pintaDadoColunaTable(saldo, Color.Green)
        End If


        Return saldo
    End Function



    Private Function funRetornaPeriodo(periodo As List(Of clsPeriodoPonto)) As String
        Dim retorno As String = vbNullString
        Dim entrada As String = vbNullString
        Dim saida As String = vbNullString

        If periodo Is Nothing Then
            Return "[" & entrada & "-" & saida & "]  "
        End If

        For Each ponto In periodo


            entrada = ponto.Entrada
            If ponto.Almoco = "Retorno" Then
                entrada = clsHTMLTools.pintaDadoColunaTable(entrada, Color.Brown)
            End If


            saida = ponto.Saida
            If ponto.Almoco = "Saída" Then
                saida = clsHTMLTools.pintaDadoColunaTable(saida, Color.Brown)
            End If


            retorno &= "[" & entrada & "-" & saida & "]  "
        Next

        Return retorno
    End Function

    Private Shared Function funRetornaData(ponto As clsPonto) As String

        Dim data As String

        data = clsTools.funFormataData(ponto.dataPonto)
        data &= "   "
        data &= clsHTMLTools.pintaDadoColunaTable(clsTools.funRetornaDiaSemana(ponto.dataPonto, True), Color.DarkBlue)

        Return data
    End Function

End Class
