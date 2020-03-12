
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text

Public Class clsEmail

    Const EMAIL = "controle.agenda.mail@gmail.com"
    Const SENHA = "ControleAgenda2020"

    Public Property EmailDestino As String = "giovani.senior@gmail.com" 'vbNullString

    Public Property CaminhoAnexo As String = "C:\Projeto\Controle_Agenda\Agenda\bin\Debug\backups\BancoAgenda_11-03-2020-21-45-09.db" 'vbNullString

    Public Property Assunto As String = "Backup Agenda"

    Public Function EnviaEmail() As Boolean
        Dim mail As New MailMessage

        If Trim(EmailDestino) = vbNullString Then
            Throw New Exception("E-mail de destino não foi informado.")
        End If

        mail.Subject = Assunto
        mail.To.Add(EmailDestino)
        mail.From = New MailAddress(EMAIL)
        mail.Body = funRetornaBodyEmail()

        'Adicionado anexo no email
        If CaminhoAnexo <> vbNullString Then
            mail.Attachments.Add(funRetornaAnexo)
        End If

        Dim smtp As New SmtpClient("smtp.gmail.com")
        smtp.EnableSsl = True
        smtp.Credentials = New System.Net.NetworkCredential(EMAIL, SENHA)
        smtp.Port = 587

        smtp.Send(mail)

        Return True
    End Function

    Private Function funRetornaAnexo() As Attachment
        Dim arquivo As String = CaminhoAnexo

        'Cria o arquivo que vai em anexo no email
        Dim anexo As Attachment = New Attachment(arquivo, MediaTypeNames.Application.Octet)

        'Adiciona informações no anexo
        Dim disposition As ContentDisposition = anexo.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(arquivo)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(arquivo)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(arquivo)

        Return anexo
    End Function

    Private Function funRetornaBodyEmail() As String
        Dim texto As New StringBuilder

        texto.AppendFormat("Em anexo esta o backup da Agenda realizado em {0}", clsTools.funFormataData(Now))

        Return texto.ToString
    End Function
End Class
