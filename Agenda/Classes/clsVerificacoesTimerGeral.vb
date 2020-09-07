
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
            nomeBackup = clsConexao.ExecutaBackupBase(ini.CaminhoBase, False, True)

            If nomeBackup <> vbNullString Then
                clsRegistro.GravaDataBackup(Now)
            End If
        End If

    End Sub

End Class
