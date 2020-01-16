﻿Public Class clsConexao
    Public Shared glfConexao As System.Data.SQLite.SQLiteConnection

    Private Sub New()
    End Sub

    Public Shared Function RetornaConexao() As System.Data.SQLite.SQLiteConnection
        If glfConexao Is Nothing Then
            glfConexao = New System.Data.SQLite.SQLiteConnection("Data Source=C:\Giovani\Diversos\Giovani\Agenda\BancoAgenda.db;")
            glfConexao.Open()
        End If

        Return glfConexao
    End Function

    Public Shared Sub Close()
        glfConexao.Close()
    End Sub

End Class
