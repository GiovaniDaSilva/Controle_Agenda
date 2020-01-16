Public Class clsPrincipal
    Public Sub Adicionar()
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ShowDialog()
    End Sub

    Public Function funCarregarAtividades() As List(Of clsAtividade)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades()
    End Function

End Class
