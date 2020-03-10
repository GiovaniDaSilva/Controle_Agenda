Imports System.Text

Public Class clsCadastroTipoAtividadeDAO
    Public Function gravarTipo(parTipos As List(Of clsTipo), parTiposRemovidos As List(Of clsTipo)) As Boolean

        gravarTipo = False

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())

            'Excluir os removidos
            For Each tipo In parTiposRemovidos
                If tipo.ID > 0 Then
                    Comm.CommandText = "DELETE FROM TIPO_ATIVIDADE WHERE ID = " & tipo.ID
                    Comm.ExecuteNonQuery()
                End If
            Next

            'Atualiza os demais
            For Each tipo In parTipos
                'Grava Atividade
                Comm.CommandText = funRetornaSQLInsertUpdateAtividade(tipo)
                Comm.ExecuteNonQuery()
            Next

        End Using
        Return True

    End Function

    Private Function funRetornaSQLInsertUpdateAtividade(tipo As clsTipo) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If tipo.ID > 0 Then
            locSQL.AppendFormat("UPDATE TIPO_ATIVIDADE SET CODIGO = '{0}', DESCRICAO = '{1}'
                                    WHERE ID = {2}",
                                tipo.CODIGO, tipo.DESCRICAO, tipo.ID)

        Else
            locSQL.Append("INSERT INTO TIPO_ATIVIDADE (CODIGO, DESCRICAO) VALUES ")
            locSQL.AppendFormat("('{0}','{1}')", tipo.CODIGO, tipo.DESCRICAO)
        End If

        Return locSQL.ToString()
    End Function

    Public Function TipoSendoUsado(pTipo As clsTipo) As Boolean

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT ID FROM ATIVIDADES WHERE ID_TIPO_ATIVIDADE = " & pTipo.ID

            Using Reader = Comm.ExecuteReader()
                If Reader.Read() Then
                    Return True
                End If
            End Using
        End Using

        Return False
    End Function
End Class
