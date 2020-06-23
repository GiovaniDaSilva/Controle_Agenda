Imports System.Data.SQLite
Imports System.Text

Public Class clsVersaoSistema
    Public Shared Property Versao As String = "2.2"

    Public Shared Function VerificaVersao() As String
        Return New clsVersaoSistemaDAO().RetornaVersao()
    End Function

    Public Shared Function RetornaVersao() As Integer
        Return CInt(Versao.Replace(".", ""))
    End Function


    Public Shared Sub AtualizaSistema()

        Dim versao As Integer = VerificaVersao()

        Do While versao < RetornaVersao()

            If versao < 20 Then
                atualizaVersao20()
            End If

            If versao < 21 Then
                funMudaVersaoSistema(21)
            End If

            If versao < 22 Then
                funMudaVersaoSistema(22)
            End If

            versao = VerificaVersao()
        Loop

    End Sub



    Private Shared Sub funMudaVersaoSistema(pVersao As Integer)
        clsSQL.ExecutaSQL(String.Format("INSERT INTO VERSAO_SISTEMA  (NUMERO_VERSAO, DATA_ATUALIZACAO) VALUES ({0},'{1}')", pVersao, clsTools.funAjustaDataSQL(Now)))
    End Sub


    Private Shared Sub atualizaVersao20()
        Dim locSQL As New StringBuilder(String.Empty)


        locSQL.Append(" CREATE TABLE VERSAO_SISTEMA (
	                    ID	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        NUMERO_VERSAO	INTEGER NOT NULL,
	                    DATA_ATUALIZACAO	TEXT NOT NULL)")
        clsSQL.ExecutaSQL(locSQL.ToString)


        locSQL.Clear()
        locSQL.Append("CREATE TABLE PONTO (
	                   ID	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       Data	TEXT NOT NULL,
	                   TOTAL TEXT,
                       OBSERVACAO TEXT)")
        clsSQL.ExecutaSQL(locSQL.ToString)

        locSQL.Clear()
        locSQL.Append("CREATE TABLE PERIODO_PONTO (
	                   ID	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       ENTRADA	TEXT,
	                   SAIDA	TEXT,
                       TOTAL	TEXT,
                       ALMOCO	TEXT,
	                   ID_PONTO	Integer Not NULL,
                       FOREIGN KEY(""ID_PONTO"") REFERENCES PONTO(""ID""))")
        clsSQL.ExecutaSQL(locSQL.ToString)

        clsSQL.ExecutaSQL(String.Format("INSERT INTO VERSAO_SISTEMA  (NUMERO_VERSAO, DATA_ATUALIZACAO) VALUES ({0},'{1}')", 20, clsTools.funAjustaDataSQL(Now)))

    End Sub
End Class
