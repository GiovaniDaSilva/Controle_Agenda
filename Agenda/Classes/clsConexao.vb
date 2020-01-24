Public Class clsConexao
    Public Shared glfConexao As System.Data.SQLite.SQLiteConnection
    Public Shared Property CaminhoBase As String

    Private Sub New()
    End Sub

    Public Shared Function RetornaConexao() As System.Data.SQLite.SQLiteConnection

        'Dim locCaminho As String = "C:\Projeto\Controle_Agenda\BancoAgenda.db"
        'Dim locCaminho As String = "Data Source=C:\Giovani\Diversos\Giovani\Agenda\BancoAgenda.db;"

        If glfConexao Is Nothing Then

            If Not IO.File.Exists(CaminhoBase) Then
                Throw New Exception("Arquivo de banco não localizado.")
            End If

            glfConexao = New System.Data.SQLite.SQLiteConnection("Data Source=" & CaminhoBase & ";")
            glfConexao.Open()
        End If


        Return glfConexao
    End Function

    Public Shared Function ExisteBase() As Boolean
        Return IO.File.Exists(CaminhoBase)
    End Function

End Class


