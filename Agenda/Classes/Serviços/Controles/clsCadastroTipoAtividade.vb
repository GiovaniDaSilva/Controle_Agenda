Public Class clsCadastroTipoAtividade
    Public Function CarregarTiposAtividades() As List(Of clsTipo)
        Return New clsAdicionarDAO().CarregaTipos()
    End Function

    Public Function ValidaCampoDescricao(ByVal descricao As String, ByVal index As Integer) As Boolean

        If Trim(descricao) = vbNullString Then
            Throw New Exception("Informe uma descrição para o tipo de atividade.")
        End If

        If descricao.Length > 30 Then
            Throw New Exception("Descrição informada ultrapassa o tamanho maximo permitido.")
        End If

        Return True
    End Function

    Public Function ValidaCampoCodigo(ByVal codigo As Integer, ByVal index As Integer, lista As List(Of clsTipo)) As Boolean

        If index <= -1 Then Return False

        If codigo <= 0 Then
            Throw New Exception("Informe o código para o tipo de atividade.")
        End If

        Dim i = lista.FindIndex(Function(x) x.CODIGO = codigo)
        If i > -1 AndAlso lista(i).ID <> lista(index).ID Then
            Throw New Exception("Este código já esta sendo utilizado por outro tipo de atividade.")
        End If

        Return True
    End Function

    Friend Function GravaTipos(parTipos As List(Of clsTipo), parTiposRemovidos As List(Of clsTipo)) As Boolean
        Return New clsCadastroTipoAtividadeDAO().gravarTipo(parTipos, parTiposRemovidos)
    End Function
End Class
