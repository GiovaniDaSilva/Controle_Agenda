Imports System.Text
Imports Agenda

Public Class clsSolicitacaoDAO

    Public Function gravarSolicitacao(parSolicitacao As clsSolicitacao) As Boolean

        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
                Comm.CommandText = funRetornaSQLInsertUpdate(parSolicitacao)
                Comm.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return True

    End Function

    Private Function funRetornaSQLInsertUpdate(parSolicitacao As clsSolicitacao) As String

        Dim locSQL As New StringBuilder(String.Empty)

        If parSolicitacao.ID > 0 Then
            locSQL.AppendFormat("UPDATE SOLICITACOES SET SUBTIPO = '{0}', SITUACAO = '{1}'
                                    WHERE ID = {2}",
                                parSolicitacao.SubTipo, parSolicitacao.Situacao, parSolicitacao.ID_ATIVIDADE)

        Else
            locSQL.Append("INSERT INTO SOLICITACOES (CODIGO, UF, RESUMO, SUBTIPO, SITUACAO, OBJETO, ID_ATIVIDADE) VALUES  ")
            locSQL.AppendFormat("({0},'{1}','{2}','{3}','{4}','{5}',{6})",
                                parSolicitacao.Codigo, parSolicitacao.UF, parSolicitacao.Resumo, parSolicitacao.SubTipo, parSolicitacao.Situacao, parSolicitacao.Objeto, parSolicitacao.ID_ATIVIDADE)
        End If

        Return locSQL.ToString
    End Function


    Public Function consultaSolicitacao(iD As Long) As clsSolicitacao

        Dim solicitacao As clsSolicitacao = Nothing
        Dim locSQL As String

        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
                locSQL = "SELECT  * FROM SOLICITACOES WHERE ID_ATIVIDADE = " & iD
                locSQL &= " ORDER BY ID DESC"
                Comm.CommandText = locSQL

                Using Reader = Comm.ExecuteReader()
                    If Reader.Read() Then
                        solicitacao = New clsSolicitacao
                        solicitacao.ID = Reader("ID")
                        solicitacao.Codigo = Reader("CODIGO")
                        solicitacao.UF = Reader("UF")
                        solicitacao.Resumo = Reader("RESUMO")
                        solicitacao.Objeto = Reader("OBJETO")
                        solicitacao.Situacao = Reader("SITUACAO")
                        solicitacao.SubTipo = Reader("SUBTIPO")
                        solicitacao.ID_ATIVIDADE = Reader("ID_ATIVIDADE")
                    End If
                End Using
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return solicitacao
    End Function


End Class
