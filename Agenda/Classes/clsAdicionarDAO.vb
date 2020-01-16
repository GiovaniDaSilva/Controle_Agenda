Imports System.Text

Public Class clsAdicionarDAO
    Public Function gravarAtividade(parAtivdade As clsAtividade) As Boolean

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
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

    Public Function carregarAtividades() As List(Of clsAtividade)
        Dim lista As New List(Of clsAtividade)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT * FROM ATIVIDADES"

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    lista.Add(New clsAtividade(Reader("ID"),
                                               Reader("DATA"),
                                               Reader("TIPO"),
                                               Reader("CODIGO"),
                                               Reader("HORA"),
                                               Reader("DESCRICAO")))
                End While
            End Using
        End Using

        Return lista
    End Function

End Class
