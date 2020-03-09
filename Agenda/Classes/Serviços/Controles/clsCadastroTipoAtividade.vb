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


        If codigo <= 0 Then
            Throw New Exception("Informe o código para o tipo de atividade.")
        End If


        Dim i = lista.FindIndex(Function(x) x.CODIGO = codigo)
        If i > -1 Then
            If index = -1 Or index > -1 AndAlso lista(i).ID <> lista(index).ID Then
                Throw New Exception("Este código já esta sendo utilizado por outro tipo de atividade.")
            End If
        End If

        Return True
    End Function

    Friend Function GravaTipos(parTipos As List(Of clsTipo), parTiposRemovidos As List(Of clsTipo)) As Boolean

        If Not funValidaCampos(parTipos) Then Return False

        Return New clsCadastroTipoAtividadeDAO().gravarTipo(parTipos, parTiposRemovidos)
    End Function

    Private Function funValidaCampos(parTipos As List(Of clsTipo)) As Boolean

        For i = 0 To parTipos.Count - 1
            If Not ValidaCampoCodigo(parTipos(i).CODIGO, i, parTipos) Then
                Return False
            End If

            If Not ValidaCampoDescricao(parTipos(i).DESCRICAO, i) Then
                Return False
            End If
        Next

        Return True
    End Function

    Friend Function ValidaExclusao(clsTipo As clsTipo) As Boolean

    End Function
End Class
