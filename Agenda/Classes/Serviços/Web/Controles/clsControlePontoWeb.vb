Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsControlePontoWeb
    Public Function RetornaPagina(ByVal pPonto As clsPonto) As String
        Return RetornaHTML(pPonto)
    End Function


    Private Function RetornaHTML(ByVal pPonto As clsPonto) As String
        Dim html As String
        Dim escala = New clsIni().funCarregaIni().EscalaTrabalho

        html = My.Resources.ControlePonto

        html = html.Replace("[p_id_ponto]", pPonto.id_Ponto)
        html = html.Replace("[p_inicializa_campos_ponto]", RetornaLinhasInicializacaoCampos(pPonto))
        html = html.Replace("{p_retorna_botao_excluir_atividade}", RetornaBotaoExcluir(pPonto))
        html = html.Replace("{p_linhas_tabela_periodo}", RetornaLinhasTabelaPeriodo(pPonto))
        html = html.Replace("{p_dia_semana}", clsTools.funRetornaDiaSemana(pPonto.dataPonto))
        html = html.Replace("[p_escala_dia]", """" & escala & """")
        html = html.Replace("[p_retorno_almoco]", funRetornaEhRetornoAlmoco(pPonto))
        html = html.Replace("[p_pagina]", clsPaginasWeb.ControlePonto)



        Return html
    End Function

    Private Function funRetornaEhRetornoAlmoco(pPonto As clsPonto) As String
        Dim controle As New clsControlePonto

        Return If(controle.ExisteSaidaParaAlmoco(pPonto.id_Ponto, False), "true", "false")
    End Function



    Private Function RetornaLinhasTabelaPeriodo(pPonto As clsPonto) As String
        Dim locRetorno As String = vbNullString

        If pPonto.id_Ponto = 0 Then Return ""
        If pPonto.Periodo.Count = 0 Then Return ""

        For Each periodo In pPonto.Periodo
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(periodo.ID))
            linha.Add(New clsColunasTabela(periodo.Entrada))
            linha.Add(New clsColunasTabela(periodo.Saida))
            linha.Add(New clsColunasTabela(periodo.Total))
            'linha.Add("<i class=""material-icons"">live_help</i>")
            linha.Add(New clsColunasTabela(periodo.Almoco))
            linha.Add(New clsColunasTabela("<button type='button' class='btn btn-outline-danger' id='btnExcluirPeriodo' onclick='excluiPeriodo()' >Excluir</button>"))

            locRetorno &= clsHTMLTools.funLinhaTabela(linha)
        Next

        Return locRetorno

    End Function

    Private Function RetornaBotaoExcluir(pPonto As clsPonto) As String
        Dim texto As New StringBuilder(vbNullString)

        If pPonto.id_Ponto = 0 Then Return ""

        texto.AppendFormat("
            <input id=""btnExcluir"" type=""button"" value=""Excluir"" form=""form_dados"" class="" btn btn-danger"" data-toggle=""modal"" data-target=""#confirmaExclusao"" />        
        ")
        Return texto.ToString
    End Function

    Private Function RetornaLinhasInicializacaoCampos(pPonto As clsPonto) As String
        Dim texto As New StringBuilder(vbNullString)
        Dim SaldoSemana As String = "00:00"
        Dim SaldoGeral As String = "00:00"

        Dim locHora As String = vbNullString
        If Not Trim(pPonto.horaTotal).Replace(":", "") = vbNullString Then
            locHora = pPonto.horaTotal
        End If

        Dim data = clsTools.funAjustaDataSQL(Now)
        If pPonto.dataPonto IsNot Nothing Then
            data = clsTools.funAjustaDataSQL(pPonto.dataPonto)
        End If


        subCalculaSaldos(SaldoSemana, SaldoGeral, pPonto)


        texto.AppendFormat("            
            document.getElementById('horaTotal').value = ""{0}"";  
            document.getElementById('dataPonto').value = ""{1}"";              
            document.getElementById('observacao').value = ""{2}"";        
            document.getElementById('SaldoSemana').innerHTML = ""{3}""
            document.getElementById('SaldoGeral').innerHTML = ""{4}""
        ", locHora, data, pPonto.observacao, SaldoSemana, SaldoGeral)

        Return texto.ToString
    End Function

    Private Sub subCalculaSaldos(ByRef saldoSemana As String, ByRef saldoGeral As String, pPonto As clsPonto)
        Dim controle As New clsControlePonto

        saldoSemana = controle.CalculaSaldoSemana(pPonto.dataPonto)
        saldoGeral = controle.CalculaSaldoMes(pPonto.dataPonto)
    End Sub

    Friend Function RetornaControlePonto_Salvar(json As String) As String
        RetornaControlePonto_Salvar = "Erro"

        Dim controle As New clsControlePonto
        Dim pontoJson = DeserializarNewtonsoft(funTrataJson(json))

        subValidaPeriodos(pontoJson)

        controle.Gravar(pontoJson)

        Return "Sucesso"

    End Function

    Private Function funTrataJson(json As String) As String
        Return json.Replace("""Almoço"":", """Almoco"":")
    End Function

    Private Sub subValidaPeriodos(pontoJson As clsPonto)
        Dim PeriodosValidos As New List(Of clsPeriodoPonto)

        For Each periodo In pontoJson.Periodo
            If (funValidaHoraPeriodo(periodo.Total) AndAlso
                funValidaHoraPeriodo(periodo.Entrada) AndAlso
                funValidaHoraPeriodo(periodo.Saida)) Then

                PeriodosValidos.Add(periodo)
            End If
        Next

        pontoJson.Periodo.Clear()
        pontoJson.Periodo = PeriodosValidos

    End Sub

    Private Function funValidaHoraPeriodo(hora As String) As Boolean
        Try
            Return clsTools.funValidaHora(hora)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DeserializarNewtonsoft(json As String) As clsPonto
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsPonto)(json)
    End Function

    Friend Function funRetornaControlePonto_Excluir(id As Long) As String
        Return New clsControlePontoDAO().Excluir(id)
    End Function
End Class


