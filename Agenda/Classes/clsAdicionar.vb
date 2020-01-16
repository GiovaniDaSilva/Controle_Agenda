Public Class clsAdicionar
    Private DAO As New clsAdicionarDAO
    Public Function Gravar(parAtividade As clsAtividade) As Boolean


        Return DAO.GravarAtividade(parAtividade)

    End Function


End Class
