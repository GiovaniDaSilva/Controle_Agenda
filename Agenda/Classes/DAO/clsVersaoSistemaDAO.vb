Imports System.Text

Public Class clsVersaoSistemaDAO


    Public Function RetornaVersao() As Integer
        Dim locSQL As New StringBuilder(String.Empty)
        Dim versao As Integer = 0

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)

            If clsSQL.ExisteTabela("VERSAO_SISTEMA") Then
                locSQL.AppendFormat("SELECT NUMERO_VERSAO FROM VERSAO_SISTEMA   ORDER BY NUMERO_VERSAO DESC LIMIT 1 ")
                Comm.CommandText = locSQL.ToString

                Using Reader = Comm.ExecuteReader()
                    If Reader.Read() Then
                        versao = Reader("NUMERO_VERSAO")
                    End If
                End Using
            End If
        End Using

        Return versao

    End Function
End Class
