Imports System.Data.SQLite
Imports System.Text

Public Class clsSQL

    Public Shared Sub ExecutaSQL(pSQL As String)
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
            Comm.CommandText = pSQL
            Comm.ExecuteNonQuery()
        End Using

    End Sub


    Public Shared Function ExisteTabela(pTabela As String) As Boolean
        Dim locSQL As New StringBuilder(String.Empty)
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)

            locSQL.AppendFormat("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}' COLLATE NOCASE", pTabela)
            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                Return Reader.Read()
            End Using
        End Using

    End Function
End Class
