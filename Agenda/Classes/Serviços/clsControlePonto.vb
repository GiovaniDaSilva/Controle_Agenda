Public Class clsControlePonto
    Public Sub Gravar(pPonto As clsPonto)
        Dim controle As New clsControlePontoDAO

        subValidaPonto(pPonto)

        controle.Gravar(pPonto)
    End Sub


    Public Sub subValidaPonto(pPonto As clsPonto)

        If DateDiff("d", CDate("01/01/1900"), pPonto.dataPonto) < 0 Then
            Throw New Exception("Data Inválida.")
        End If

        If DateDiff("d", Now.Date, pPonto.dataPonto) > 0 Then
            Throw New Exception("Data informada não pode ser superior a data atual.")
        End If


    End Sub


    Public Function CarregaPonto(pPonto As clsPonto) As clsPonto
        Return New clsControlePontoDAO().CarregaPonto(pPonto)
    End Function

    Friend Function CalculaSaldoSemana(dataPonto As String) As String

        Dim inicio As Date = clsTools.RetornaPrimeiroDiaSemana(CDate(dataPonto))
        Dim final As Date = clsTools.RetornaUltimoDiaSemana(CDate(dataPonto))

        Return CalculaSaldoperiodo(inicio, final)

    End Function

    Friend Function CalculaSaldoMes(dataPonto As String, Optional ByVal ConsiderarDiaHoje As Boolean = False) As String
        Dim inicio As Date = clsTools.RetornaPrimeiroDiaMes(CDate(dataPonto).Month)
        Dim final As Date = clsTools.RetornaUltimoDiaMes(CDate(dataPonto).Month)

        Return CalculaSaldoperiodo(inicio, final, ConsiderarDiaHoje)

    End Function

    Public Function CalculaSaldoDia(data As Date) As String
        Dim total As TimeSpan
        Dim totalEsperado As TimeSpan
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho

        total = RetornaTotalPeriodo(data, data, True)

        If Not (data.DayOfWeek = DayOfWeek.Saturday Or data.DayOfWeek = DayOfWeek.Sunday) Then
            totalEsperado = totalEsperado.Add(TimeSpan.Parse(escala))
        End If

        Return RetornaSaldo(total, totalEsperado)

    End Function



    Private Function CalculaSaldoperiodo(Inicio As Date, final As Date, Optional ByVal ConsiderarDiaHoje As Boolean = False) As String
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho
        Dim total As TimeSpan
        Dim totalEsperado As TimeSpan
        Dim dataFim As Date

        total = RetornaTotalPeriodo(Inicio, final, ConsiderarDiaHoje)

        While (Inicio.Date <= final)

            'Se nao considerar a data de hoje, não soma as horas que faltam de hoje
            If Not ConsiderarDiaHoje Then
                If Inicio.Date = Now.Date Then
                    Inicio = Inicio.AddDays(1)
                End If
            End If

            'Apenas calcula o esperado do mesmo mes
            If Inicio.Date.Month < Now.Date.Month Then
                If Not (Inicio.DayOfWeek = DayOfWeek.Saturday Or Inicio.DayOfWeek = DayOfWeek.Sunday) Then
                    totalEsperado = totalEsperado.Add(TimeSpan.Parse(escala))
                End If
            End If

            Inicio = Inicio.AddDays(1)
        End While

        Return RetornaSaldo(total, totalEsperado)
    End Function

    Private Shared Function RetornaSaldo(total As TimeSpan, totalEsperado As TimeSpan) As String
        Dim diferencao As TimeSpan

        diferencao = totalEsperado.Subtract(total)


        Dim horas As String = (diferencao.Days * 24 + diferencao.Hours)
        If horas.ToString.Length < 2 Then
            horas = "0" & horas
        End If

        Dim aux = horas & ":" & diferencao.Minutes.ToString("00")
        Return If(totalEsperado.TotalMinutes > total.TotalMinutes, "- ", "") & aux.Replace("-", "")
    End Function

    Public Function ExisteSaidaParaAlmoco(id_Ponto As Integer, pComRetornoAlmoco As Boolean) As Boolean

        If id_Ponto = 0 Then Return False

        Dim ponto = New clsControlePontoDAO().CarregaPonto(id_Ponto)
        Dim saiuParaAlmoco As Boolean = False
        Dim retornouAlmoco As Boolean = False


        For Each periodo In ponto.Periodo
            If periodo.Almoco = "" Then Continue For

            If periodo.Almoco = "Saída" Then
                saiuParaAlmoco = True
            End If

            If periodo.Almoco = "Retorno" Then
                retornouAlmoco = True
            End If
        Next

        If pComRetornoAlmoco Then
            Return (saiuParaAlmoco And retornouAlmoco)
        Else
            Return saiuParaAlmoco
        End If

    End Function

    Private Function RetornaTotalPeriodo(ByVal dtInicio As Date, ByVal dtFinal As Date, Optional ByVal ConsiderarDiaHoje As Boolean = False)
        Dim listaTotais As List(Of String)
        Dim total As TimeSpan

        listaTotais = New clsControlePontoDAO().RetornaTotaisPeriodo(dtInicio, dtFinal, ConsiderarDiaHoje)

        For Each totalDia In listaTotais
            total = total.Add(TimeSpan.Parse(totalDia))
        Next

        Return total
    End Function
End Class
