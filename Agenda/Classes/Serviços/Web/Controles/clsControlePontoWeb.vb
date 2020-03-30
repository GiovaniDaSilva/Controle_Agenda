Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsControlePontoWeb
    Public Function RetornaPagina(ByVal pPonto As clsPonto) As String
        Return RetornaHTML(pPonto)
    End Function


    Private Function RetornaHTML(ByVal pPonto As clsPonto) As String
        Dim html As String
        html = My.Resources.ControlePonto

        html = html.Replace("[p_id_ponto]", pPonto.id_Ponto)
        html = html.Replace("[p_inicializa_campos_ponto]", RetornaLinhasInicializacaoCampos(pPonto))
        html = html.Replace("{p_retorna_botao_excluir_atividade}", RetornaBotaoExcluir(pPonto))
        html = html.Replace("{p_linhas_tabela_periodo}", RetornaLinhasTabelaPeriodo(pPonto))
        html = html.Replace("{p_dia_semana}", funRetornaDiaSemana(pPonto.dataPonto))
        html = html.Replace("{p_escala_dia}", """08:30""")



        Return html
    End Function

    Private Function funRetornaDiaSemana(dataPonto As String) As String
        Dim data As String
        data = Strings.StrConv(String.Format("{0:dddd}", CDate(dataPonto)), VbStrConv.ProperCase)

        Return data
    End Function

    Private Function RetornaLinhasTabelaPeriodo(pPonto As clsPonto) As String
        Dim locRetorno As String = vbNullString

        If pPonto.id_Ponto = 0 Then Return ""
        If pPonto.Periodo.Count = 0 Then Return ""

        For Each periodo In pPonto.Periodo
            Dim linha = New List(Of String)
            linha.Add(periodo.ID)
            linha.Add(periodo.Entrada)
            linha.Add(periodo.Saida)
            linha.Add(periodo.Total)
            linha.Add("<button type='button' class='btn btn-outline-danger' id='btnExcluirPeriodo' onclick='excluiPeriodo()' >Excluir</button>")

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


        Dim locHora As String = vbNullString
        If Not Trim(pPonto.horaTotal).Replace(":", "") = vbNullString Then
            locHora = pPonto.horaTotal
        End If

        Dim data = clsTools.funAjustaDataSQL(Now)
        If pPonto.dataPonto IsNot Nothing Then
            data = clsTools.funAjustaDataSQL(pPonto.dataPonto)
        End If

        texto.AppendFormat("            
            document.getElementById('horaTotal').value = ""{0}"";  
            document.getElementById('dataPonto').value = ""{1}"";              
        ", locHora, data)

        Return texto.ToString
    End Function

    Friend Function RetornaControlePonto_Salvar(json As String) As String
        RetornaControlePonto_Salvar = "Erro"

        Dim controle As New clsControlePonto
        Dim pontoJson = DeserializarNewtonsoft(json)

        controle.Gravar(pontoJson)

        Return "Sucesso"

    End Function



    Private Function DeserializarNewtonsoft(json As String) As clsPonto
        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsPonto)(json)
    End Function

    Friend Function funRetornaControlePonto_Excluir(id As Long) As String
        Return New clsControlePontoDAO().Excluir(id)
    End Function
End Class


