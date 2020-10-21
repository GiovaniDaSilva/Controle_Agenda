Imports System.Data.SQLite
Imports System.Text

Public Class clsVersaoSistema
    Public Shared Property Versao As String = "2.5"

    Public Shared Function RetornaVersaoBase() As String
        Return New clsVersaoSistemaDAO().RetornaVersao()
    End Function

    Public Shared Function VersaoSistema() As Integer
        Return CInt(Versao.Replace(".", ""))
    End Function


    Public Shared Sub AtualizaSistema()

        Dim versaoBase As Integer = RetornaVersaoBase()

        If versaoBase < VersaoSistema() Then

            If versaoBase < 20 Then atualizaVersao20(versaoBase)

            If versaoBase < 21 Then funMudaVersaoSistema(21, versaoBase)
            If versaoBase < 22 Then funMudaVersaoSistema(22, versaoBase)
            If versaoBase < 23 Then funMudaVersaoSistema(23, versaoBase)
            If versaoBase < 24 Then funMudaVersaoSistema(24, versaoBase)
            If versaoBase < 25 Then funMudaVersaoSistema(25, versaoBase)
        End If

    End Sub


    Private Shared Sub funMudaVersaoSistema(pVersao As Integer, Optional ByRef versaoBase As Integer = 0)
        clsSQL.ExecutaSQL(String.Format("INSERT INTO VERSAO_SISTEMA  (NUMERO_VERSAO, DATA_ATUALIZACAO) VALUES ({0},'{1}')", pVersao, clsTools.funAjustaDataSQL(Now)))
        versaoBase = pVersao
    End Sub


    Private Shared Sub atualizaVersao20(ByRef versaoBase As Integer)
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

        funMudaVersaoSistema(20, versaoBase)
    End Sub

    Friend Shared Sub ExisteVersaoSuperiorDisponivel()

        Dim locDiretorioExe As String = "\\GOVBR8484\Publico\Agenda"

        If Not IO.Directory.Exists(locDiretorioExe) Then
            Throw New Exception("Diretorio não existe ou sem permissão de acesso")
        End If

        For Each foundFile As String In IO.Directory.GetFiles(locDiretorioExe)

            If IO.File.GetLastWriteTime(foundFile) > IO.File.GetLastWriteTime(Application.StartupPath) Then

                Dim locMsg As String
                locMsg = "Existe uma nova versão da Agenda disponivel no diretorio: " & vbNewLine & foundFile & vbNewLine
                locMsg &= "Deseja atualizar?"

                If MsgBox(locMsg, vbYesNo + vbExclamation + vbDefaultButton2, "Nova Versão") = Windows.Forms.DialogResult.Yes Then
                    ExecutaBackupBase()
                    Process.Start(foundFile)
                    End
                End If

                Return
            End If

        Next

    End Sub

    Private Shared Sub ExecutaBackupBase()
        Dim ini = New clsIni().funCarregaIni()
        clsConexao.ExecutaBackupBase(ini.CaminhoBase, True, False)
    End Sub
End Class
