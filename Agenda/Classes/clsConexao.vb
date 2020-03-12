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

        locRetorno = IO.File.Exists(CaminhoBase)

        If Not locRetorno then
            If IO.File.Exists(Application.StartupPath & "\BancoZerada.db" )        
                IO.File.Copy(Application.StartupPath & "\BancoZerada.db",CaminhoBase)
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
    Public Shared Function ExecutaBackupBase(ByVal pCaminhoBase As String) As String
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
                MsgBox("Backup realizado com sucesso. Disponivel em: " & nomeBackup)
                Return nomeBackup
            End If
        End If

        Return vbNullString
    End Function
End Class


