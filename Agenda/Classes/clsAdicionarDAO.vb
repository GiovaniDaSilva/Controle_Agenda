Imports System.Text
Imports Agenda

Public Class clsAdicionarDAO
    Public Function gravarAtividade(parAtivdade As clsAtividade) As Boolean

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
            Comm.CommandText = funRetornaSQLInsertUpdate(parAtivdade)
            Comm.ExecuteNonQuery()
        End Using
        Return True

    End Function

    Friend Function CarregaTipos() As List(Of clsTipo)
        Dim lista As New List(Of clsTipo)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT * FROM TIPO_ATIVIDADE"

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    lista.Add(New clsTipo(Reader("ID"),
                                               Reader("CODIGO"),
                                               Reader("DESCRICAO")))
                End While
            End Using
        End Using

        Return lista
    End Function

    Public Function Excluir(iD As Long) As Boolean
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
            Comm.CommandText = "DELETE FROM ATIVIDADES WHERE ID = " & iD
            Comm.ExecuteNonQuery()
        End Using
        Return True
    End Function

    Private Function funRetornaSQLInsertUpdate(Atividade As clsAtividade) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If Atividade.ID > 0 Then
            locSQL.AppendFormat("UPDATE ATIVIDADES SET DATA = '{0}', CODIGO = {1}, HORA = '{2}', DESCRICAO = '{3}', ID_TIPO_ATIVIDADE = {4}
                                    WHERE ID = {5}",
                                Atividade.Data, Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE, Atividade.ID)

        Else
            locSQL.Append("INSERT INTO ATIVIDADES (DATA, CODIGO, HORA, DESCRICAO, ID_TIPO_ATIVIDADE) VALUES ")
            locSQL.AppendFormat("('{0}',{1},'{2}','{3}',{4})", Atividade.Data, Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE)
        End If

        Return locSQL.ToString()
    End Function

    Public Function carregarAtividades() As List(Of clsConsultaAtividades)
        Dim lista As New List(Of clsConsultaAtividades)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT A.ID, A.DATA, A.CODIGO, A.HORA, A.DESCRICAO, A.ID_TIPO_ATIVIDADE, T.DESCRICAO AS TIPO_DESCRICAO  
                                FROM ATIVIDADES A
                                INNER JOIN TIPO_ATIVIDADE T ON T.ID = A.ID_TIPO_ATIVIDADE "

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim atividade As New clsConsultaAtividades
                    atividade.ID = Reader("ID")
                    atividade.Data = Reader("DATA")
                    atividade.Horas = Reader("HORA")
                    atividade.Codigo = Reader("CODIGO")
                    atividade.Descricao = Reader("DESCRICAO")
                    atividade.ID_TIPO_ATIVIDADE = Reader("ID_TIPO_ATIVIDADE")
                    atividade.TIPO_DESCRICAO = Reader("TIPO_DESCRICAO")

                    lista.Add(atividade)
                End While
            End Using
        End Using

        Return lista
    End Function


End Class

