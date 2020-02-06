﻿Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class clsServidorHTTP

    ' Configura o mumero maximo de requisições que 
    ' podem ser tratadas concorrentemente
    Private maxRequestHandlers As Integer = 5
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
        listener.Prefixes.Add("http://*:8484/Grafico/")
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
        
        Try
            ' Obtem o HttpListenerContext para a nova requisição
            Dim context As HttpListenerContext = listener.EndGetContext(result)
        
            ' Cria uma resposta usando um StreamWriter 
            Dim sw As New StreamWriter(context.Response.OutputStream, Encoding.UTF8)

            Dim url = context.Request.Url
            If url = New Uri("http://localhost:19080/giovani") Then
                If 1 = 1 Then

                End If
            End If

            ' Configura a resposta
            context.Response.ContentType = "text/html"
            context.Response.ContentEncoding = Encoding.UTF8
            context.Response.StatusCode = HttpStatusCode.OK

            'sw.WriteLine("<!DOCTYPE html>")
            'sw.WriteLine("<html>")
            'sw.WriteLine("<head>")
            'sw.WriteLine("<meta charset=""utf-8""> ")
            'sw.WriteLine("<title>Macoratti .Net - Quase tudo para VB .NET</title>")
            'sw.WriteLine("</head>")
            'sw.WriteLine("<body>")
            'sw.WriteLine("VB .NET 2017 : " & result.AsyncState)
            'sw.WriteLine("</body>")
            'sw.WriteLine("</html>")

            sw.WriteLine(My.Resources.GraficoAtividades  )

            sw.Flush()            
            ' Fecha a resposta para enviá-la ao cliente
            context.Response.Close()            
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
