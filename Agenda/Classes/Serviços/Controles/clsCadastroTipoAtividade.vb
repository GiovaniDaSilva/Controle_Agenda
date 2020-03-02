Public Class clsCadastroTipoAtividade
    Public Function CarregarTiposAtividades() As List(Of clsTipo)
        Return New clsAdicionarDAO().CarregaTipos()
    End Function
End Class
