Imports System.Text

Public Class clsControlePontoDAO
    Public Sub Gravar(parPonto As clsPonto)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())

            If parPonto.id_Ponto > 0 Then
                Comm.CommandText = "DELETE FROM PERIODO_PONTO WHERE ID_PONTO = " & parPonto.id_Ponto
                Comm.ExecuteNonQuery()
            End If

            'Grava Atividade
            Comm.CommandText = funRetornaSQLInsertUpdatePonto(parPonto)
            Comm.ExecuteNonQuery()

            'Grava Atividade
            If Not parPonto.Periodo Is Nothing AndAlso parPonto.Periodo.Count > 0 Then
                Comm.CommandText = funRetornaSQLInsertUpdatePeriodos(parPonto)
                Comm.ExecuteNonQuery()
            End If

        End Using


    End Sub

    Private Function funRetornaSQLInsertUpdatePeriodos(pPonto As clsPonto) As String
        Dim locSQL As New StringBuilder(String.Empty)
        Dim locIdPonto As Integer = clsTools.funRetornaUltimoIDBanco()

        If pPonto.id_Ponto > 0 Then
            locIdPonto = pPonto.id_Ponto
        End If

        locSQL.Append("INSERT INTO PERIODO_PONTO (ENTRADA, SAIDA, TOTAL, ID_PONTO) VALUES ")

        For Each periodo In pPonto.Periodo
            locSQL.AppendFormat("( '{0}', '{1}', '{2}', {3}),", periodo.Entrada, periodo.Saida, periodo.Total, locIdPonto)
        Next

        Return locSQL.ToString.Substring(0, locSQL.Length - 1)
    End Function

    Private Function funRetornaSQLInsertUpdatePonto(pPonto As clsPonto) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If pPonto.id_Ponto > 0 Then
            locSQL.AppendFormat("UPDATE PONTO SET DATA = '{0}', TOTAL = '{1}'
                                    WHERE ID = {2}",
                                clsTools.funAjustaDataSQL(pPonto.dataPonto), pPonto.horaTotal, pPonto.id_Ponto)

        Else
            locSQL.Append("INSERT INTO PONTO (DATA, TOTAL) VALUES ")
            locSQL.AppendFormat("('{0}','{1}')", clsTools.funAjustaDataSQL(pPonto.dataPonto), pPonto.horaTotal)
        End If

        Return locSQL.ToString()
    End Function


    Public Function CarregaPonto(ByVal parPonto As clsPonto) As clsPonto
        Dim ponto As New clsPonto
        Dim locSQL As New StringBuilder(String.Empty)


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL.Append(" SELECT * FROM PONTO ")


            If Not parPonto.dataPonto = Nothing Then
                locSQL.Append(" AND DATA = '{0}'", clsTools.funAjustaDataSQL(parPonto.dataPonto))
            End If

            If parPonto.id_Ponto > 0 Then
                locSQL.Append(" AND ID = '{0}'", parPonto.id_Ponto)
            End If

            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    ponto.id_Ponto = Reader("ID")
                    ponto.dataPonto = Reader("DATA")
                    ponto.horaTotal = Reader("TOTAL")

                    ponto.Periodo = funRetornaPeriodoPonto(ponto.id_Ponto)

                End While
            End Using


        End Using

        Return ponto
    End Function

    Private Function funRetornaPeriodoPonto(iD As Long) As List(Of clsPeriodoPonto)
        Dim lista As New List(Of clsPeriodoPonto)
        Dim locSQL As String


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL = "SELECT * FROM PERIODO_PONTO  WHERE ID_PONTO = " & iD
            Comm.CommandText = locSQL

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim periodo As New clsPeriodoPonto
                    periodo.ID = Reader("ID")
                    periodo.Entrada = Reader("ENTRADA")
                    periodo.Saida = Reader("SAIDA")
                    periodo.Total = Reader("TOTAL")

                    lista.Add(periodo)
                End While
            End Using
        End Using

        Return lista
    End Function

End Class
