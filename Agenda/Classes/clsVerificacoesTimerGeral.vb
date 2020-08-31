
Public Class clsVerificacoesTimerGeral


    Public Sub ExecutaValidacoes()
        ExecutaBackupBase()
    End Sub



    ''' <summary>
    ''' Executa o backup da base de dados, quando a data do backup for anterir a data atual
    ''' </summary>
    Private Sub ExecutaBackupBase()
        Dim dataUltbackup As Date
        Dim ini As New clsParametrosIni
        Dim nomeBackup As String

        ini = New clsIni().funCarregaIni()

        If ini.Email = vbNullString Then Exit Sub

        dataUltbackup = clsRegistro.RetornaDatabackup()

        If DateTime.Compare(clsTools.funFormataData(dataUltbackup), clsTools.funFormataData(Now)) = -1 Then
            clsRegistro.GravaDataBackup(Now)
            nomeBackup = clsConexao.ExecutaBackupBase(ini.CaminhoBase, False)

            subEnviaEmailBackup(nomeBackup, ini.Email)
        End If

    End Sub

    Private Sub subEnviaEmailBackup(pNomeBackup As String, pEmail As String)

        Dim email As New clsEmail
        email.EmailDestino = pEmail
        email.Assunto = "Agenda Backup Automatico da base"

        If pNomeBackup = vbNullString Then
            Throw New Exception("Caminho do backup não foi informado.")
        End If

        email.CaminhoAnexo = pNomeBackup
        email.EnviaEmail()
    End Sub
End Class
