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

    End Sub


    Public Function CarregaPonto(pPonto As clsPonto) As clsPonto
        Return New clsControlePontoDAO().CarregaPonto(pPonto)
    End Function

    Friend Function CalculaSaldoSemana(dataPonto As String) As String

        Dim inicio As Date = clsTools.RetornaPrimeiroDiaSemana(CDate(dataPonto))
        Dim final As Date = clsTools.RetornaUltimoDiaSemana(CDate(dataPonto))

        Return CalculaSaldoperiodo(inicio, final)

    End Function

    Friend Function CalculaSaldoMes(dataPonto As String) As String
        Dim inicio As Date = clsTools.RetornaPrimeiroDiaMes(CDate(dataPonto).Month)
        Dim final As Date = clsTools.RetornaUltimoDiaMes(CDate(dataPonto).Month)

        Return CalculaSaldoperiodo(inicio, final)

    End Function

    Private Function CalculaSaldoperiodo(Inicio As Date, final As Date) As String
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho
        Dim total As TimeSpan
        Dim totalEsperado As TimeSpan
        Dim diferencao As TimeSpan

        total = RetornaTotalPeriodo(Inicio, final)

        While (Inicio.Date < Now.Date)
            If Not (Inicio.DayOfWeek = DayOfWeek.Saturday Or Inicio.DayOfWeek = DayOfWeek.Sunday) Then
                totalEsperado = totalEsperado.Add(TimeSpan.Parse(escala))
            End If

            Inicio = Inicio.AddDays(1)
        End While

        diferencao = totalEsperado.Subtract(total)


        Dim horas As String = (diferencao.Days * 24 + diferencao.Hours)
        If horas.ToString.Length < 2 Then
            horas = "0" & horas
        End If

        Dim aux = horas & ":" & diferencao.Minutes.ToString("00")
        Return If(totalEsperado.TotalMinutes > total.TotalMinutes, "- ", "") & aux.Replace("-", "")

    End Function

    Private Function RetornaTotalPeriodo(ByVal dtInicio As Date, ByVal dtFinal As Date)
        Dim listaTotais As List(Of String)
        Dim total As TimeSpan

        listaTotais = New clsControlePontoDAO().RetornaTotaisPeriodo(dtInicio, dtFinal)

        For Each totalDia In listaTotais
            total = total.Add(TimeSpan.Parse(totalDia))
        Next

        Return total
    End Function
End Class
