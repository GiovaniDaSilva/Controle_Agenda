Imports System.Text
Imports Agenda

Public Class clsAdicionarDAO
    Public Function gravarAtividade(parAtivdade As clsAtividade) As Boolean

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao())

            If parAtivdade.ID > 0 Then
                Comm.CommandText = "DELETE FROM PERIODO WHERE ID_ATIVIDADE = " & parAtivdade.ID
                Comm.ExecuteNonQuery()
            End If

            'Grava Atividade
            Comm.CommandText = funRetornaSQLInsertUpdateAtividade(parAtivdade)
            Comm.ExecuteNonQuery()

            'Grava Atividade
            If Not parAtivdade.Periodos Is Nothing AndAlso parAtivdade.Periodos.Count > 0 Then
                Comm.CommandText = funRetornaSQLInsertUpdatePeriodos(parAtivdade)
                Comm.ExecuteNonQuery()
            End If

        End Using
        Return True

    End Function

    Private Function funRetornaSQLInsertUpdatePeriodos(parAtivdade As clsAtividade) As String
        Dim locSQL As New StringBuilder(String.Empty)
        Dim locIdAtividade As Integer = clsTools.funRetornaUltimoIDBanco()

        If parAtivdade.ID > 0 Then
            locIdAtividade = parAtivdade.ID
        End If

        locSQL.Append("INSERT INTO PERIODO (ID_ATIVIDADE, HORA_INICIAL, HORA_FINAL, TOTAL) VALUES ")

        For Each periodo In parAtivdade.Periodos
            locSQL.AppendFormat("( {0}, '{1}', '{2}', '{3}'),", locIdAtividade, periodo.Hora_Inicial, periodo.Hora_Final, periodo.Total)
        Next

        Return locSQL.ToString.Substring(0, locSQL.Length - 1)
    End Function

    Public Function retornaPeriodoAtividades(pData As Date) As List(Of clsPeriodosAtividades)
        Dim lista As New List(Of clsPeriodosAtividades)
        Dim locSQL As New StringBuilder(String.Empty)

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)

            locSQL.AppendFormat("SELECT T.DESCRICAO, A.CODIGO, P.HORA_INICIAL, P.HORA_FINAL, P.TOTAL FROM ATIVIDADES A
                            INNER JOIN PERIODO P ON P.ID_ATIVIDADE = A.ID
                            INNER JOIN TIPO_ATIVIDADE T ON T.ID = A.ID_TIPO_ATIVIDADE
                            WHERE A.DATA = '{0}'
                            ORDER BY HORA_INICIAL, HORA_FINAL", clsTools.funAjustaDataSQL(pData))
            Comm.CommandText = locSQL.ToString

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    lista.Add(New clsPeriodosAtividades(Reader("DESCRICAO"),
                                                        Val(Reader("CODIGO")),
                                                        Reader("HORA_INICIAL"),
                                                        Reader("HORA_FINAL"),
                                                        Reader("TOTAL")))
                End While
            End Using
        End Using

        Return lista
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

    Private Function funRetornaSQLInsertUpdateAtividade(Atividade As clsAtividade) As String
        Dim locSQL As New StringBuilder(String.Empty)

        If Atividade.ID > 0 Then
            locSQL.AppendFormat("UPDATE ATIVIDADES SET DATA = '{0}', CODIGO = {1}, HORA = '{2}', DESCRICAO = '{3}', ID_TIPO_ATIVIDADE = {4}
                                    WHERE ID = {5}",
                                clsTools.funAjustaDataSQL(Atividade.Data), Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE, Atividade.ID)

        Else
            locSQL.Append("INSERT INTO ATIVIDADES (DATA, CODIGO, HORA, DESCRICAO, ID_TIPO_ATIVIDADE) VALUES ")
            locSQL.AppendFormat("('{0}',{1},'{2}','{3}',{4})", clsTools.funAjustaDataSQL(Atividade.Data), Atividade.Codigo, Atividade.Horas, Atividade.Descricao, Atividade.ID_TIPO_ATIVIDADE)
        End If

        Return locSQL.ToString()
    End Function

    Public Function carregarAtividades(codigo As String) As List(Of clsConsultaAtividades)
        Dim lista As New List(Of clsConsultaAtividades)
        Dim locSQL As String

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL = funRetornaSQLConsultaComum()


            If codigo <> vbNullString Then
                locSQL &= " AND A.CODIGO = " & codigo
            End If

            locSQL &= " ORDER BY A.DATA DESC, A.ID DESC"

            Comm.CommandText = locSQL
            subCarregaListaAtividades(lista, Comm)
        End Using

        Return lista
    End Function

    Public Function carregarAtividades() As List(Of clsConsultaAtividades)
        Return carregarAtividades(vbNullString)
    End Function

    Public Function carregarAtividades(pDataInicial As Date, pDataFinal As Date) As List(Of clsConsultaAtividades)
        Dim lista As New List(Of clsConsultaAtividades)
        Dim locSQL As String

        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL = funRetornaSQLConsultaComum()

            locSQL &= " AND (A.DATA >= '" & clsTools.funAjustaDataSQL(pDataInicial) & "'"
            locSQL &= "      AND A.DATA <= '" & clsTools.funAjustaDataSQL(pDataFinal) & "')"


            Comm.CommandText = locSQL
            subCarregaListaAtividades(lista, Comm)
        End Using

        Return lista
    End Function

    Public Function carregarAtividades(ByVal parFiltro As clsAtividade) As List(Of clsConsultaAtividades)
        Dim locIni As New clsParametrosIni
        locIni = New clsIni().funCarregaIni()
        Return carregarAtividades(parFiltro, locIni)
    End Function

    Public Function carregarAtividades(ByVal parFiltro As clsAtividade, parParametrosIni As clsParametrosIni) As List(Of clsConsultaAtividades)
        Dim lista As New List(Of clsConsultaAtividades)
        Dim locSQL As String


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL = funRetornaSQLConsultaComum()

            If Not parFiltro.Data = Nothing Then
                locSQL &= " AND A.DATA >= '" & clsTools.funAjustaDataSQL(parFiltro.Data) & "'"
            End If

            If parFiltro.Codigo > 0 Then
                locSQL &= " AND A.CODIGO = " & parFiltro.Codigo
            End If

            If parFiltro.ID_TIPO_ATIVIDADE > 0 Then
                locSQL &= " AND A.ID_TIPO_ATIVIDADE = " & parFiltro.ID_TIPO_ATIVIDADE
            End If

            If parParametrosIni.OrdenacaoDasAtividades = enuOrdenacaoDasAtividades.Dec Then
                locSQL &= " ORDER BY A.DATA DESC, A.ID DESC"
            Else
                locSQL &= " ORDER BY A.DATA ASC , A.ID ASC"
            End If

            Comm.CommandText = locSQL

            subCarregaListaAtividades(lista, Comm)

        End Using

        Return lista
    End Function

    Private Sub subCarregaListaAtividades(lista As List(Of clsConsultaAtividades), Comm As SQLite.SQLiteCommand)
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
    End Sub

    Private Shared Function funRetornaSQLConsultaComum() As String
        Return "SELECT A.ID, A.DATA, A.CODIGO, A.HORA, A.DESCRICAO, A.ID_TIPO_ATIVIDADE, T.DESCRICAO AS TIPO_DESCRICAO  
            
                                FROM ATIVIDADES A
                                INNER JOIN TIPO_ATIVIDADE T ON T.ID = A.ID_TIPO_ATIVIDADE 
                     WHERE (1=1)"
    End Function

    Private Function funRetornaPeriodoAtividade(iD As Long) As List(Of clsPeriodo)
        Dim lista As New List(Of clsPeriodo)
        Dim locSQL As String


        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            locSQL = "SELECT * FROM PERIODO  WHERE ID_ATIVIDADE = " & iD
            Comm.CommandText = locSQL

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim periodo As New clsPeriodo
                    periodo.ID = Reader("ID")
                    periodo.ID_Atividade = Reader("ID_ATIVIDADE")
                    periodo.Hora_Inicial = Reader("HORA_INICIAL")
                    periodo.Hora_Final = Reader("HORA_FINAL")
                    periodo.Total = Reader("TOTAL")

                    lista.Add(periodo)
                End While
            End Using
        End Using

        Return lista
    End Function
End Class

