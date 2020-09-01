Imports Microsoft.Win32

Public Class clsRegistro

    Const APLICACAO = "Controle Agenda"


    Public Shared Sub subRegistrarAplicacaoInicializacaoWindows()
        ' dim caminho As String = "C:\_vbn\Consulta_Cep\Consulta_Cep\bin\Debug\Consulta_Cep.exe"

        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue("Controle Agenda", """" + Application.ExecutablePath + """")
        End Using

    End Sub


    Public Shared Sub subDesregistrarAplicacaoInicializacaoWindows()
       ' dim caminho As String = "C:\_vbn\Consulta_Cep\Consulta_Cep\bin\Debug\Consulta_Cep.exe"

       Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
	        key.DeleteValue(Application.ExecutablePath, False)
       End Using

    End Sub

    Public Shared Function subExisteRegistroAplicacao() As Boolean
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            Dim registro = key.GetValue("Controle Agenda")
            Return not registro Is Nothing 
       End Using

        Return false
    End Function

    'Abrir a pasta de inicializar automaticamente windows shell:startup


    Public Shared Sub GravaDataBackup(pData As Date)
        SaveSetting(APLICACAO, "Config", "DataBackup", pData)
    End Sub

    Public Shared Function RetornaDatabackup() As Date
        Dim registro = GetSetting(APLICACAO, "Config", "DataBackup")
        Dim data As Date = Now

        If registro IsNot Nothing AndAlso registro <> String.Empty Then
            data = CDate(registro)
        End If

        Return data
    End Function

End Class
