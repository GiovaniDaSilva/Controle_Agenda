﻿Imports System.Text
Imports Agenda

Public Class clsAdicionarDAO
    Public Function gravarAtividade(parAtivdade As clsAtividade) As Boolean

        Try
            
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())

                 If parAtivdade.ID > 0 Then
                    Comm.CommandText = "DELETE FROM PERIODO WHERE ID_ATIVIDADE = " & parAtivdade.ID
                    Comm.ExecuteNonQuery()
                End If

                'Grava Atividade
                Comm.CommandText = funRetornaSQLInsertUpdateAtividade(parAtivdade)
                Comm.ExecuteNonQuery()

                'Grava Atividade
                if Not parAtivdade.Periodos Is nothing AndAlso parAtivdade.Periodos.Count > 0 then
                    Comm.CommandText = funRetornaSQLInsertUpdatePeriodos(parAtivdade)
                    Comm.ExecuteNonQuery()
                End if

            End Using
            

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return True

    End Function

    Private Function funRetornaSQLInsertUpdatePeriodos(parAtivdade As clsAtividade) As String
        Dim locSQL As new StringBuilder(string.Empty) 
        Dim locIdAtividade As Integer = clsTools.funRetornaUltimoIDBanco()
        
        If parAtivdade.ID > 0 then
            locIdAtividade = parAtivdade.id
        End If

        locSQL.Append("INSERT INTO PERIODO (ID_ATIVIDADE, HORA_INICIAL, HORA_FINAL, TOTAL) VALUES ") 

        For Each periodo In parAtivdade.Periodos 
            locSQL.AppendFormat("( {0}, '{1}', '{2}', '{3}'),",locIdAtividade, periodo.Hora_Inicial, periodo.Hora_Final, periodo.Total)
        Next

        Return locSQL.ToString.Substring(0, locSQL.Length - 1)
    End Function

    Friend Function CarregaTipos() As List(Of clsTipo)
        Dim lista As New List(Of clsTipo)

        Try

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

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return lista
    End Function

    Public Function Excluir(iD As Long) As Boolean

        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())
                Comm.CommandText = "DELETE FROM ATIVIDADES WHERE ID = " & iD
                Comm.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return True
    End Function

    Private Function funRetornaSQLInsertUpdateAtividade(Atividade As clsAtividade) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If Atividade.ID > 0 Then
            locSQL.AppendFormat("UPDATE ATIVIDADES SET DATA = '{0}', CODIGO = {1}, HORA = '{2}', DESCRICAO = '{3}', ID_TIPO_ATIVIDADE = {4}
                                    WHERE ID = {5}",
                                clstools.funAjustaDataSQL(Atividade.Data), Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE, Atividade.ID)

        Else
            locSQL.Append("INSERT INTO ATIVIDADES (DATA, CODIGO, HORA, DESCRICAO, ID_TIPO_ATIVIDADE) VALUES ")
            locSQL.AppendFormat("('{0}',{1},'{2}','{3}',{4})", clstools.funAjustaDataSQL(Atividade.Data), Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE)
        End If

        Return locSQL.ToString()
    End Function

    Public Function carregarAtividades(ByVal parFiltro As clsAtividade, parParametrosIni As clsParametrosIni) As List(Of clsConsultaAtividades)
        Dim lista As New List(Of clsConsultaAtividades)
        Dim locSQL As String

        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
                locSQL = "SELECT A.ID, A.DATA, A.CODIGO, A.HORA, A.DESCRICAO, A.ID_TIPO_ATIVIDADE, T.DESCRICAO AS TIPO_DESCRICAO  
            
                                FROM ATIVIDADES A
                                INNER JOIN TIPO_ATIVIDADE T ON T.ID = A.ID_TIPO_ATIVIDADE 
                     WHERE (1=1)"

                If Not parFiltro.Data = Nothing Then
                    locSQL &= " AND A.DATA >= '" & clsTools.funAjustaDataSQL(parFiltro.Data) & "'"
                End If

                If parFiltro.Codigo > 0 Then
                    locSQL &= " AND A.CODIGO = " & parFiltro.Codigo
                End If

                If parFiltro.ID_TIPO_ATIVIDADE > 0 Then
                    locSQL &= " AND A.ID_TIPO_ATIVIDADE = " & parFiltro.ID_TIPO_ATIVIDADE
                End If

                If parParametrosIni.OrdenacaoDasAtividades = "Dec" Then
                    locSQL &= " ORDER BY A.DATA DESC, A.ID DESC"
                Else
                    locSQL &= " ORDER BY A.DATA ASC , A.ID ASC"
                End If
                
                Comm.CommandText = locSQL


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
                        atividade.Periodos = funRetornaPeriodoAtividade(atividade.ID)
                        
                        lista.Add(atividade)
                    End While
                End Using
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return lista
    End Function

    Private Function funRetornaPeriodoAtividade(iD As Long) As List(Of clsPeriodo)
        Dim lista As New List(Of clsPeriodo )
        Dim locSQL As String

        Try
            Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
                locSQL = "SELECT * FROM PERIODO  WHERE ID_ATIVIDADE = " & id                
                Comm.CommandText = locSQL
                
                Using Reader = Comm.ExecuteReader()
                    While Reader.Read()
                        Dim periodo As New clsPeriodo 
                        periodo.ID = Reader("ID")
                        periodo.ID_Atividade  = Reader("ID_ATIVIDADE")
                        periodo.Hora_Inicial  = Reader("HORA_INICIAL")
                        periodo.Hora_Final = Reader("HORA_FINAL")
                        periodo .Total = Reader("TOTAL")
                                                
                        lista.Add(periodo)
                    End While
                End Using
            End Using

        Catch ex As Exception
            clsTools.subTrataExcessao(ex)
        End Try

        Return lista
    End Function
End Class

