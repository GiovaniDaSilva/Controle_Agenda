﻿Imports System.Text

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

        locSQL.Append("INSERT INTO PERIODO_PONTO (ENTRADA, SAIDA, TOTAL, ALMOCO,  ID_PONTO) VALUES ")

        For Each periodo In pPonto.Periodo
            locSQL.AppendFormat("( '{0}', '{1}', '{2}','{3}', {4}),", periodo.Entrada, periodo.Saida, periodo.Total, periodo.Almoco, locIdPonto)
        Next

        Return locSQL.ToString.Substring(0, locSQL.Length - 1)
    End Function

    Friend Function RetornaTotaisPeriodo(dtInicio As Date, dtFinal As Date, Optional ByVal ConsiderarDiaHoje As Boolean = False) As List(Of String)
        Dim locSQL As New StringBuilder(String.Empty)
        Dim lista As New List(Of String)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL.AppendFormat(" SELECT TOTAL FROM PONTO WHERE DATA >= '{0}' AND DATA <= '{1}'", clsTools.funAjustaDataSQL(dtInicio), clsTools.funAjustaDataSQL(dtFinal))

            If Not ConsiderarDiaHoje Then
                locSQL.AppendFormat(" AND DATA <> '{0}'", clsTools.funAjustaDataSQL(Now))
            End If

            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    lista.Add(Reader("TOTAL"))
                End While
            End Using

        End Using

        Return lista

    End Function

    Private Function funRetornaSQLInsertUpdatePonto(pPonto As clsPonto) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If pPonto.id_Ponto > 0 Then
            locSQL.AppendFormat("UPDATE PONTO SET DATA = '{0}', TOTAL = '{1}', OBSERVACAO = '{2}'
                                    WHERE ID = {3}",
                                clsTools.funAjustaDataSQL(pPonto.dataPonto), pPonto.horaTotal, pPonto.observacao, pPonto.id_Ponto)

        Else
            locSQL.Append("INSERT INTO PONTO (DATA, TOTAL, OBSERVACAO) VALUES ")
            locSQL.AppendFormat("('{0}','{1}', '{2}')", clsTools.funAjustaDataSQL(pPonto.dataPonto), pPonto.horaTotal, pPonto.observacao)
        End If

        Return locSQL.ToString()
    End Function



    Public Function RetornaPontoPeriodo(pdataInicio As Date, pdataFinal As Date) As List(Of clsPonto)
        Dim lista As New List(Of clsPonto)
        Dim locSQL As New StringBuilder(String.Empty)


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL.Append(" SELECT * FROM PONTO  WHERE (1 = 1)")
            locSQL.AppendFormat(" AND DATA >= '{0}'", clsTools.funAjustaDataSQL(pdataInicio))
            locSQL.AppendFormat(" AND DATA <= '{0}'", clsTools.funAjustaDataSQL(pdataFinal))
            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim ponto As New clsPonto
                    ponto.id_Ponto = Reader("ID")
                    ponto.dataPonto = Reader("DATA")
                    ponto.horaTotal = Reader("TOTAL")
                    ponto.observacao = Reader("OBSERVACAO")
                    ponto.Periodo = funRetornaPeriodoPonto(ponto.id_Ponto)

                    lista.Add(ponto)
                End While
            End Using
        End Using

        Return lista

    End Function

    Public Function CarregaPonto(ByVal id As Integer) As clsPonto
        Dim ponto As New clsPonto

        ponto.id_Ponto = id
        Return CarregaPonto(ponto)
    End Function

    Public Function CarregaPonto(ByVal parPonto As clsPonto) As clsPonto
        Dim ponto As New clsPonto
        Dim locSQL As New StringBuilder(String.Empty)


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL.Append(" SELECT * FROM PONTO  WHERE (1 = 1)")
            If Not parPonto.dataPonto = Nothing Then
                locSQL.AppendFormat(" AND DATA = '{0}'", clsTools.funAjustaDataSQL(parPonto.dataPonto))
            End If

            If parPonto.id_Ponto > 0 Then
                locSQL.AppendFormat(" AND ID = '{0}'", parPonto.id_Ponto)
            End If

            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    ponto.id_Ponto = Reader("ID")
                    ponto.dataPonto = Reader("DATA")
                    ponto.horaTotal = Reader("TOTAL")
                    ponto.observacao = Reader("OBSERVACAO")

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
                    periodo.Almoco = Reader("ALMOCO")

                    lista.Add(periodo)
                End While
            End Using
        End Using

        Return lista
    End Function


    Public Function Excluir(id As Integer) As Boolean
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())

            Comm.CommandText = "DELETE FROM PERIODO_PONTO WHERE ID_PONTO = " & id
            Comm.ExecuteNonQuery()


            Comm.CommandText = "DELETE FROM PONTO WHERE ID = " & id
            Comm.ExecuteNonQuery()
        End Using

        Return True

    End Function
End Class
