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

    Public Shared Sub subTrataExcessao(e As Exception)
        MsgBox("Ocorreu o seguinte erro: " & e.Message)
    End Sub

End Class
