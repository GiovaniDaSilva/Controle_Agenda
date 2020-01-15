Imports System.Text

Public Class clsAdicionarDAO
    Public Function GravarAtividade(parAtivdade As clsAtividade) As Boolean

        Dim Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Projeto\Controle_Agenda\BancoAgenda.db;")
        Conn.Open()

        Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
            Dim lista = New List(Of clsAtividade)
            lista.Add(parAtivdade)

            Comm.CommandText = funRetornaSQLInsert(lista)
            Comm.ExecuteNonQuery()
        End Using

        Return True

    End Function


    Private Function funRetornaSQLInsert(parListaAtividade As List(Of clsAtividade)) As String
        Dim locSQL As New StringBuilder(String.Empty)
        locSQL.Append("INSERT INTO ATIVIDADES (DATA, TIPO, CODIGO, HORA, DESCRICAO) VALUES ")

        For Each atividade In parListaAtividade
            locSQL.AppendFormat("('{0}','{1}',{2},'{3}','{4}'),", atividade.Data, atividade.Tipo, atividade.Codigo, atividade.Horas, atividade.Descricao)
        Next

        Return locSQL.ToString().Substring(0, locSQL.ToString.Length - 1)
    End Function
End Class
