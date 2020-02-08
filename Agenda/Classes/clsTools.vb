Public Class clsTools
    Public Shared function funRetornaData(byval pCampo as MaskedTextBox ) as date
        Dim locData As date

        If pCampo.Text = vbNullString Then
            return New Date(1900,12,31)
        End If
        
        Dim ano = mid(pCampo.Text,5,9)
        Dim mes = mid(pCampo.Text,3,2)
        Dim dia = mid(pCampo.Text,1,2)

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

    Public Shared Function Tab() As String
        Return "       "
    End Function

    Public Shared Function funLimpaHTMLTableSolicitacoes(html As String) As String
        Return html.Replace("<tbody>", "").Replace("</tbody>", "").Replace("<font color=""#ffffff"" style=""font: 11px Calibri"">", "").Replace("</font>", "").Replace("border=""0"" cellspacing=""1"" cellpadding=""2""", "").Replace(" align=""CENTER"" bgcolor=""#688fb0""", "").Replace(" valign=""top"" align=""left"" bgcolor=""#e0e0e0""", "").Replace("<font style=""font: 11px Calibri"">", "")
    End Function

    public Shared Function funRetornaUltimoIDBanco() As Integer
               
        Dim locID As Integer = 0
        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
                Comm.CommandText = "select last_insert_rowid() as ID"

                Using Reader = Comm.ExecuteReader()
                    if Reader.Read() then
                        locID = Reader("ID")                        
                    End if
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
    Public Shared Function funValidaHora(ByVal parHoras As String, optional byval parPermiteEmBranco As Boolean = false) As Boolean

        Dim locHora = Trim(parHoras.Replace(":", ""))

        'TimeSpan.Parse("12:10")
        If Not parPermiteEmBranco then
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
        Return Trim(pHora.text.Replace(":", "")) = vbNullString
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


End Class
