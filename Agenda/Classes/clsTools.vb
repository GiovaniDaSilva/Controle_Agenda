﻿Imports System.IO
Imports System.Net
Imports System.Text

Public Class clsTools
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

    Public Shared Function funAjustaDataSQL(ByVal parData As Date) As String
        Return Format(parData, "yyyy-MM-dd")
    End Function

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

        Return True
    End Function

    Public Shared Function HoraVazia(pHora As MaskedTextBox) As Boolean
        Return Trim(pHora.Text.Replace(":", "")) = vbNullString
    End Function

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

    Public Shared Function RetornaUltimoDiaMes(Optional ByVal mes As Integer = 0) As Date
        Dim data As Date

        If mes = 0 Then
            data = DateAdd("m", 1, DateSerial(Year(Now), Month(Now), 1))
            data = DateAdd("d", -1, data)
            Return data
        Else
            data = DateAdd("m", 1, DateSerial(Year(Now), mes, 1))
            data = DateAdd("d", -1, data)
            Return data
        End If

    End Function

    Public Shared Function RetornaPrimeiroDiaMes(Optional ByVal mes As Integer = 0) As Date

        If mes = 0 Then
            Return CDate("01/" & Month(Now) & "/" & Year(Now))
        Else
            Return CDate("01/" & mes.ToString("00") & "/" & Year(Now))
        End If

    End Function

    Public Shared Function RetornaValorPost(ByVal campo As String) As String
        Return campo.ToString.Replace(campo.ToString.Substring(0, campo.IndexOf("=") + 1), "")
    End Function
    Public Shared Function RetornaPostEmArray(pContext As HttpListenerContext) As String()
        Return New StreamReader(pContext.Request.InputStream).ReadToEnd().Split(New Char() {"?", "&"})
    End Function

    Public shared Function RetornaCampoTabela(ByVal parTabela As String, ByVal parCampo As String, ByVal parWhere As String) As String
        Dim locSQL As New StringBuilder(String.Empty)
        Dim locResultado As String = vbNullString 

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)

            locSQL.AppendFormat("SELECT {0} AS VALOR FROM {1} WHERE {2}",parCampo, parTabela , parWhere  )
            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                if Reader.Read() then
                    locResultado = Reader("VALOR")
                End if
            End Using
        End Using

        Return locResultado 
    End Function
End Class
