﻿Imports System.IO
Imports System.Net
Imports System.Text

Public Class clsTools


    Public Shared Function ehSabadoDomingo(data As String) As Boolean
        Return (CDate(data).DayOfWeek = DayOfWeek.Saturday Or CDate(data).DayOfWeek = DayOfWeek.Sunday)
    End Function


    ''' <summary>
    ''' Converte o conteudo do campo texto em um date
    ''' </summary>
    ''' <param name="pCampo"></param>
    ''' <returns></returns>
    Public Shared Function funRetornaData(ByVal pCampo As MaskedTextBox) As Date
        Dim locData As Date

        If pCampo.Text = vbNullString Then
            Return New Date(1900, 12, 31)
        End If

        Dim ano = Mid(pCampo.Text, 5, 9)
        Dim mes = Mid(pCampo.Text, 3, 2)
        Dim dia = Mid(pCampo.Text, 1, 2)

        Try
            locData = New Date(ano, mes, dia)
        Catch ex As Exception
            Throw New Exception("Data inválida.")
        End Try

        Return locData
    End Function

    Friend Shared Function RetornaUltimoDiaSemana(data As Date) As Date
        Dim diaSemana As Short
        diaSemana = data.DayOfWeek
        Return data.AddDays(6 - diaSemana)
    End Function

    Friend Shared Function RetornaPrimeiroDiaSemana(data As Date) As Date
        Dim diaSemana As Short
        diaSemana = data.DayOfWeek
        Return data.AddDays(-diaSemana)
    End Function

    ''' <summary>
    ''' Retorna os minutos de um timespan
    ''' </summary>
    ''' <param name="timeAux"></param>
    ''' <returns></returns>
    Public Shared Function funRetornaMinutos(timeAux As TimeSpan) As Double
        Return (timeAux.TotalHours * 60) + timeAux.Minutes
    End Function

    ''' <summary>
    ''' Formata a data para o padrao de banco de dados
    ''' </summary>
    ''' <param name="parData"></param>
    ''' <returns></returns>
    Public Shared Function funAjustaDataSQL(ByVal parData As Date) As String
        Return Format(parData, "yyyy-MM-dd")
    End Function

    ''' <summary>
    ''' Formata a data para o padrao pt-br
    ''' </summary>
    ''' <param name="parData"></param>
    ''' <returns></returns>
    Public Shared Function funFormataData(ByVal parData As Date) As String
        Return Format(parData, "dd/MM/yyyy")
    End Function

    Public Shared Function Tab() As String
        Return Space(2)
    End Function

    Public Shared Function funLimpaHTMLTableSolicitacoes(html As String) As String
        Return html.Replace("<tbody>", "").Replace("</tbody>", "").Replace("<font color=""#ffffff"" style=""font: 11px Calibri"">", "").Replace("</font>", "").Replace("border=""0"" cellspacing=""1"" cellpadding=""2""", "").Replace(" align=""CENTER"" bgcolor=""#688fb0""", "").Replace(" valign=""top"" align=""left"" bgcolor=""#e0e0e0""", "").Replace("<font style=""font: 11px Calibri"">", "")
    End Function

    Public Shared Function funRetornaUltimoIDBanco() As Integer

        Dim locID As Integer = 0
        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
                Comm.CommandText = "select last_insert_rowid() as ID"

                Using Reader = Comm.ExecuteReader()
                    If Reader.Read() Then
                        locID = Reader("ID")
                    End If
                End Using
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return locID

    End Function

    Public Shared Sub subTrataExcessao(e As Exception)
        MsgBox("Ocorreu o seguinte erro: " & e.Message)
    End Sub

    ''' <summary>
    ''' Retorna o dia da semana por extenso
    ''' </summary>
    ''' <param name="pData"></param>
    ''' <returns></returns>
    Public Shared Function funRetornaDiaSemana(pData As String, Optional abreviado As Boolean = False) As String
        Dim data As String
        data = Strings.StrConv(String.Format("{0:dddd}", CDate(pData)), VbStrConv.ProperCase)

        Return If(abreviado, Mid(data, 1, 3), data)
    End Function

    ''' <summary>
    ''' Valida o campo hora
    ''' hora valida, minuto valido
    ''' </summary>
    ''' <param name="parHoras"></param>
    ''' <param name="parPermiteEmBranco"></param>
    ''' <returns></returns>
    Public Shared Function funValidaHora(ByVal parHoras As String, Optional ByVal parPermiteEmBranco As Boolean = False) As Boolean

        Dim locHora = Trim(parHoras.Replace(":", ""))

        'TimeSpan.Parse("12:10")
        If Not parPermiteEmBranco Then
            If locHora = vbNullString Then ' Then
                Throw New Exception("Hora não informada.")
            End If
        End If

        If locHora.Length < 4 Then
            Throw New Exception("Hora Inválida.")
        End If

        If Val(Mid(locHora, 1, 2)) > 23 Then
            Throw New Exception("Hora Inválida.")
        End If

        If Val(Mid(locHora, 3, 4)) > 59 Then
            Throw New Exception("Hora Inválida.")
        End If

        If Not IsNumeric(Mid(locHora, 1, 2)) Then
            Throw New Exception("Hora Inválida.")
        End If

        If Not IsNumeric(Mid(locHora, 3, 4)) Then
            Throw New Exception("Hora Inválida.")
        End If

        Return True
    End Function

    ''' <summary>
    ''' Converte os dados da lista em uma string     
    ''' </summary>
    ''' <param name="parLista"></param>
    ''' <param name="parEhString"></param>
    ''' <returns></returns>
    Public Shared Function RetornArrayLista(ByVal parLista As IEnumerable(Of String), Optional parEhString As Boolean = False) As String
        Dim retorno As String = vbNullString
        Dim aux As String

        For Each i In parLista
            aux = i.ToString.Replace(",", ".")

            If parEhString Then
                aux = "'" & aux & "'"
            End If

            retorno &= aux & ","
        Next
        Return retorno.Substring(0, retorno.Length - 1)

    End Function

    Public Shared Function RetornaUltimoDiaMes(Optional ByVal pMes As Integer = 0, Optional ByVal pAno As Integer = 0) As Date
        Dim data As Date

        Dim mes As Integer = Month(Now)
        Dim ano As Integer = Year(Now)

        If pMes > 0 Then mes = pMes
        If pAno > 0 Then ano = pAno

        data = DateAdd("m", 1, DateSerial(ano, mes, 1))
        data = DateAdd("d", -1, data)
        Return data

    End Function


    Public Shared Function RetornaPrimeiroDiaMes(Optional ByVal pMes As Integer = 0, Optional ByVal pAno As Integer = 0) As Date

        Dim mes As Integer = Month(Now)
        Dim ano As Integer = Year(Now)

        If pMes > 0 Then mes = pMes
        If pAno > 0 Then ano = pAno

        Return CDate("01/" & mes.ToString("00") & "/" & ano.ToString("0000"))
    End Function


    ''' <summary>
    ''' Retorna um determinado campo de uma determinada tabela
    ''' </summary>
    ''' <param name="parTabela"></param>
    ''' <param name="parCampo"></param>
    ''' <param name="parWhere"></param>
    ''' <returns></returns>
    Public Shared Function RetornaCampoTabela(ByVal parTabela As String, ByVal parCampo As String, ByVal parWhere As String) As String
        Dim locSQL As New StringBuilder(String.Empty)
        Dim locResultado As String = vbNullString

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)

            locSQL.AppendFormat("SELECT {0} AS VALOR FROM {1} WHERE {2}", parCampo, parTabela, parWhere)
            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                If Reader.Read() Then
                    locResultado = Reader("VALOR")
                End If
            End Using
        End Using

        Return locResultado
    End Function
End Class



''' <summary>
''' Classe para tratar funções que auxiliar o preenchimento do html
''' </summary>
Public Class clsHTMLTools


    Public Shared Function funLinhaTabela(ByVal pColunas As List(Of clsColunasTabela)) As String
        Dim retorno As String = vbNullString


        retorno = "<tr>"
        For Each col In pColunas
            retorno &= "<td "

            If col.classe <> vbNullString Then
                retorno &= col.classe
            End If

            If col.estilo <> vbNullString Then
                retorno &= col.estilo
            End If

            retorno &= " >" & col.dado & "</td>"
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

    Public Shared Function RetornaPaginaErro(pTitulo As String, pMensagem As String) As String
        Dim locPagRetorno As String
        locPagRetorno = My.Resources.Pagina_Não_Encontrada.Replace("{p_titulo}", pTitulo).Replace("{p_mensagem}", pMensagem)
        clsHTMLComum.TrataParametrosComuns(locPagRetorno)

        Return locPagRetorno
    End Function

    Public Shared Sub Imprime(html As StringBuilder, dado As String, Optional estilo As enuEstiloImpressao = enuEstiloImpressao.Informacao, Optional PulaLinha As Boolean = False, Optional Tab As Integer = 0)
        If PulaLinha Then html.Append("</br>")
        If Tab > 0 Then html.Append(clsHTMLTools.retornaTabWeb(Tab))
        html.Append(funRetornaEstilo(estilo, dado))
    End Sub

    Private Shared Function retornaTabWeb(tab As Integer) As String
        Dim x As String = ""
        For i = 0 To tab
            x &= "&nbsp "
        Next

        Return x
    End Function

    Public Shared Sub PulaLinha(html As StringBuilder, linhas As Integer)

        If linhas = 0 Then
            Throw New Exception("Numero de linhas deve ser superior a zero.")
        End If

        For i = 0 To linhas
            html.Append("</br>")
        Next
    End Sub

    Private Shared Function funRetornaEstilo(estilo As enuEstiloImpressao, dado As String) As String
        Select Case estilo
            Case enuEstiloImpressao.Data
                Return Paragrafo(dado, "estiloData")
            Case enuEstiloImpressao.Titulo
                Return Tab() & Paragrafo(dado, "estiloTitulo")
            Case enuEstiloImpressao.Titulo_Destaque
                Return Paragrafo(dado, "estiloTituloDestaque")
            Case enuEstiloImpressao.Informacao
                Return Paragrafo(dado, "estiloInformacao")
            Case enuEstiloImpressao.Informacao_Destaque
                Return Paragrafo(dado, "estiloInformacaoDestaque")
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function Paragrafo(campo As String, classe As String) As String
        Return String.Format("<label class = {0}> {1} </label>", classe, campo)
    End Function


    Public Shared Function Tab() As String
        Return "&nbsp &nbsp"
    End Function

    Public Enum enuEstiloImpressao
        Data = 1
        Titulo = 2
        Titulo_Destaque = 3
        Informacao = 4
        Informacao_Destaque = 5
    End Enum

    Public Shared Function pintaDadoColunaTable(dado As String, cor As Color, Optional tag As String = "span") As String
        Return "<" & tag & " style= color:" & cor.Name & ";>" & dado & "</" & tag & ">"

    End Function



End Class
