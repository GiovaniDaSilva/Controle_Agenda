Imports System.Text
Imports Agenda

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

    Friend Function CarregaTipos() As List(Of clsTipo)
        Dim lista As New List(Of clsTipo )

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

    Private Function funRetornaSQLInsert(parListaAtividade As List(Of clsAtividade)) As String
        Dim locSQL As New StringBuilder(String.Empty)
        locSQL.Append("INSERT INTO ATIVIDADES (DATA, CODIGO, HORA, DESCRICAO, ID_TIPO_ATIVIDADE) VALUES ")

        For Each atividade In parListaAtividade
            locSQL.AppendFormat("('{0}',{1},'{2}','{3}',{4}),", atividade.Data, atividade.Codigo, atividade.Horas, atividade.Descricao, atividade.ID_TIPO_ATIVIDADE )
        Next

        Return locSQL.ToString().Substring(0, locSQL.ToString.Length - 1)
    End Function

    Public Function carregarAtividades() As List(Of clsConsultaAtividades )
        Dim lista As New List(Of clsConsultaAtividades)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT A.ID, A.DATA, A.CODIGO, A.DESCRICAO, A.ID_TIPO_ATIVIDADE, T.DESCRICAO AS TIPO_DESCRICAO  
                                FROM ATIVIDADES A
                                INNER JOIN TIPO_ATIVIDADE T ON T.ID = A.ID_TIPO_ATIVIDADE "

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim atividade As New clsConsultaAtividades
                    atividade.ID = Reader("ID")
                    atividade.Data = Reader("DATA")
                    atividade.Codigo = Reader("CODIGO")
                    atividade.Descricao  = Reader("DESCRICAO")
                    atividade.ID_TIPO_ATIVIDADE = Reader("ID_TIPO_ATIVIDADE")
                    atividade.TIPO_DESCRICAO = Reader("TIPO_DESCRICAO")

                    lista.Add(atividade)
                End While
            End Using
        End Using

        Return lista
    End Function


End Class

