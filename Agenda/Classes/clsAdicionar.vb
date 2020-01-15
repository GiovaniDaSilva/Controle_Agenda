Public Class clsAdicionar
    Public Function Gravar(parAtividade As clsAtividade) As Boolean
        Dim DAO As New clsAdicionarDAO

        Return DAO.GravarAtividade(parAtividade)

    End Function
End Class
