Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json

Public Class clsServidorHTTP


    Public Shared ReadOnly Property local = "http://localhost:8484/"

    ' Configura o mumero maximo de requisições que 
    ' podem ser tratadas concorrentemente
    Private maxRequestHandlers As Integer = 50
    ' Um inteirousado para atribui cada requisição HTTP 
    ' um identificador unico
    Private requestHandlerID As Integer = 0
    ' O objeto HttpListener que fornece todos
    ' os recursos para receber e processar requisições HTTP
    Private listener As HttpListener


    Public Sub InicializaServidor()
        ' Se o recurso não for suportado encerra o programa
        If Not HttpListener.IsSupported Then
            Console.WriteLine("Você precisa estar executando no ambiente do Windows" &
                              " XP SP2, Windows Server 2003, ou superior para criar um HttpListener.")
            Exit Sub
        End If

        listener = New HttpListener

        ' Configura o prefixo URI que irá mapear para o HttpListener.

        'Para acesso apartir de qualquer estação
        'listener.Prefixes.Add("http://*:8484/")
        listener.Prefixes.Add(local)

        listener.Start()

        ' Cria um numero de tratadores de requisições assincronas
        ' ate a configuração maxima definida, cada um com identificador unico
        For count As Integer = 1 To maxRequestHandlers
            listener.BeginGetContext(AddressOf RequestHandler,
                                     "RequestHandler_" & Interlocked.Increment(requestHandlerID))
        Next

    End Sub

    Public Sub EncerraServidorHTTP()
        ' Para de aceitar novas requisições
        listener.Stop()

        ' Termina o HttpListener sem processar as requisições atuais
        listener.Abort()
    End Sub


    'Este método processa de forma assincrona requisições individuais
    Private Sub RequestHandler(ByVal result As IAsyncResult)
        Dim locRequisicoesWeb As New clsRequisicoesWeb
        Dim locReqWeb As New clsReqWeb
        Try
            ' Obtem o HttpListenerContext para a nova requisição
            Dim context As HttpListenerContext = listener.EndGetContext(result)

            locReqWeb.Context = context

            locRequisicoesWeb.trataRequisicoesWeb(locReqWeb)


            Dim webPage() As Byte = Encoding.UTF8.GetBytes("")

            If Not locReqWeb.RetornaIcone Then
                webPage = Encoding.UTF8.GetBytes(locReqWeb.HTML)

                ' Configura a resposta
                locReqWeb.Context.Response.ContentType = "text/html"
                locReqWeb.Context.Response.ContentEncoding = Encoding.UTF8
                locReqWeb.Context.Response.ContentLength64 = webPage.Length
            End If


            Dim outputStream = locReqWeb.Context.Response.OutputStream
            Dim canWrite As Boolean
            Dim count As Integer = 0

            canWrite = outputStream.CanWrite
            Do While Not canWrite
                System.Threading.Thread.Sleep(1000)
                canWrite = outputStream.CanWrite
                count += 1

                'Maximo de 10 tentativas
                If count = 10 Then Exit Do
            Loop

            If canWrite Then
                If Not locReqWeb.RetornaIcone Then
                    outputStream.Write(webPage, 0, webPage.Length)
                Else
                    My.Resources.Agenda.Save(outputStream)
                End If

                outputStream.Flush()
            End If

            ' Fecha a resposta para enviá-la ao cliente
            locReqWeb.Context.Response.Close()

        Catch ex As ObjectDisposedException
            Console.WriteLine("{0}: HttpListener disposed--shutting down.", result.AsyncState)
        Finally
            ' Inicia outro manipulador a menos que o HttpListener esteja fechado
            If listener.IsListening Then
                listener.BeginGetContext(AddressOf RequestHandler, "RequestHandler_" &
                    Interlocked.Increment(requestHandlerID))
            End If
        End Try
    End Sub


End Class
