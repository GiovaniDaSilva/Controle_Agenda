﻿Public Class clsConexao
    Public Shared glfConexao As System.Data.SQLite.SQLiteConnection

    Private Sub New()
    End Sub

    Public Shared Function RetornaConexao() As System.Data.SQLite.SQLiteConnection

        Dim locCaminho As String = "C:\Projeto\Controle_Agenda\BancoAgenda.db"
        'Dim locCaminho As String = "Data Source=C:\Giovani\Diversos\Giovani\Agenda\BancoAgenda.db;"


        Try
            If glfConexao Is Nothing Then

                If Not IO.File.Exists(locCaminho) Then
                    Throw New Exception("Arquivo de banco não localizado.")
                End If

                glfConexao = New System.Data.SQLite.SQLiteConnection("Data Source=" & locCaminho & ";")
                glfConexao.Open()
            End If

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return glfConexao
    End Function

End Class
