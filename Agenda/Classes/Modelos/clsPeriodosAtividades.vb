Public Class clsPeriodosAtividades
    Public Sub New(descricao_tipo As String, codigo_atividade As Integer, hora_inicial As String, hora_final As String, total As String)
        Me.descricao_tipo = descricao_tipo
        Me.codigo_atividade = codigo_atividade
        Me.hora_inicial = hora_inicial
        Me.hora_final = hora_final
        Me.total = total
    End Sub

    Public Property descricao_tipo As String
    Private _codigo_atividade As String

    Public Property codigo_atividade() As String
        Get
            Return iif(_codigo_atividade = "0", "",_codigo_atividade)
        End Get
        Set(ByVal value As String)
            _codigo_atividade = value
        End Set
    End Property

    Public Property hora_inicial As String
    Public Property hora_final As String
    Public Property total As string

End Class
