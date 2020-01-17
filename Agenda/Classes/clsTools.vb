﻿Public Class clsTools
    Public Shared function funRetornaData(byval pCampo as MaskedTextBox ) as date
        Dim locData As date

        If pCampo.Text = vbNullString Then
            return New Date(1900,12,31)
        End If
        
        Dim ano = mid(pCampo.Text,5,9)
        Dim mes = mid(pCampo.Text,3,2)
        Dim dia = mid(pCampo.Text,1,2)

        locData = New Date(ano, mes, dia)

        Return locData
    End function

    Public Shared function funAjustaDataSQL(byval parData As date) As string
        Return Format(parData, "yyyy-MM-dd")
    End function

End Class
