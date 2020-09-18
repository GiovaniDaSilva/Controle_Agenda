Imports System.Data.SQLite

Public Class clsTipo
    Public Property ID As Integer
    Public Property CODIGO As Integer
    Public Property DESCRICAO As String

    Public Sub New()
    End Sub

    Public Sub InicializaPorID(id)
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT * FROM TIPO_ATIVIDADE WHERE ID = " & id

            CarregaTipo(Comm)
        End Using
    End Sub

    Public Sub Inicializa(codigo)
        Using Comm As New System.Data.SQLite.SQLiteCommand(clsConexao.RetornaConexao)
            Comm.CommandText = "SELECT * FROM TIPO_ATIVIDADE WHERE CODIGO = " & codigo

            CarregaTipo(Comm)
        End Using
    End Sub

    Private Sub CarregaTipo(Comm As SQLiteCommand)
        Using Reader = Comm.ExecuteReader()
            If Reader.Read() Then
                Me.ID = Reader("ID")
                Me.CODIGO = Reader("CODIGO")
                Me.DESCRICAO = Reader("DESCRICAO")
            End If
        End Using
    End Sub

    Public Sub New(iD As Integer, cODIGO As Integer, dESCRICAO As String)
        Me.ID = iD
        Me.CODIGO = cODIGO
        Me.DESCRICAO = dESCRICAO
    End Sub
End Class
