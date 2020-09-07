Public Class clsConexao
    Public Shared glfConexao As System.Data.SQLite.SQLiteConnection
    Public Shared Property CaminhoBase As String

    Private Sub New()
    End Sub

    Public Shared Function RetornaConexao() As System.Data.SQLite.SQLiteConnection

        'Dim locCaminho As String = "C:\Projeto\Controle_Agenda\BancoAgenda.db"
        'Dim locCaminho As String = "Data Source=C:\Giovani\Diversos\Giovani\Agenda\BancoAgenda.db;"

        If glfConexao Is Nothing Then

            If Not IO.File.Exists(CaminhoBase) Then
                Throw New Exception("Arquivo de banco não localizado.")
            End If

            glfConexao = New System.Data.SQLite.SQLiteConnection("Data Source=" & CaminhoBase & ";")
            glfConexao.Open()
        End If


        Return glfConexao
    End Function

    Public Shared Function ExisteBase() As Boolean
        Dim locRetorno As Boolean

        If CaminhoBase = vbNullString Then
            Throw New Exception("Caminho da base não informado.")
        End If

        locRetorno = IO.File.Exists(CaminhoBase)

        If Not locRetorno Then
            If IO.File.Exists(Application.StartupPath & "\BancoZerada.db") Then
                IO.File.Copy(Application.StartupPath & "\BancoZerada.db", CaminhoBase)
            End If
            locRetorno = IO.File.Exists(CaminhoBase)
        End If

        Return locRetorno
    End Function

    ''' <summary>
    ''' Executa o backup da base e retorna o caminho do backup
    ''' </summary>
    ''' <param name="pCaminhoBase"></param>
    ''' <returns></returns>
    Public Shared Function ExecutaBackupBase(ByVal pCaminhoBase As String, Optional pExibeMensagem As Boolean = True, Optional pEnviarPorEmail As Boolean = False) As String
        Dim nomeBackup As String
        Dim caminhoBackup As String

        If Trim(pCaminhoBase) = vbNullString Then
            Throw New Exception("Caminho da base de dados não foi informado.")
        End If

        'Cria o diretorio dos backups
        caminhoBackup = Application.StartupPath & "\backups"

        'Trata o nome o backup
        nomeBackup = caminhoBackup & "\BancoAgenda_" & Now.ToString.Replace("/", "-").Replace(":", "-").Replace(" ", "-") & ".db"

        CaminhoBase = pCaminhoBase
        If ExisteBase() Then
            If Not IO.Directory.Exists(caminhoBackup) Then
                IO.Directory.CreateDirectory(caminhoBackup)
            End If

            'Cria uma nova conexão para backup
            Dim locNovo = New System.Data.SQLite.SQLiteConnection("Data Source=" & nomeBackup & ";")
            locNovo.Open()
            Try
                glfConexao.BackupDatabase(locNovo, "main", "main", -1, Nothing, 0)
            Finally
                locNovo.Close()
            End Try

            If IO.File.Exists(nomeBackup) Then

                If pEnviarPorEmail Then
                    EnviarBackupEmail(nomeBackup)
                End If

                If pExibeMensagem Then
                    MsgBox("Backup realizado com sucesso. Disponivel em: " & nomeBackup)
                End If

                Return nomeBackup
            End If
        End If

        Return vbNullString
    End Function

    Public Shared Sub EnviarBackupEmail(caminhoBackup As String)
        Dim email As New clsEmail
        Dim ini = New clsIni().funCarregaIni()

        email.EmailDestino = ini.Email
        email.Assunto = "Agenda Backup da base"

        If caminhoBackup = vbNullString Then
            Throw New Exception("Caminho do backup não foi informado.")
        End If
        email.CaminhoAnexo = caminhoBackup

        If email.EnviaEmail() Then
            'MsgBox("E- mail com o backup foi enviado com sucesso.", vbInformation)
        End If
    End Sub

    Friend Shared Sub recriaConexao()
        glfConexao = Nothing
    End Sub
End Class


