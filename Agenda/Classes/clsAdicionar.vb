Public Class clsAdicionar
    Private DAO As New clsAdicionarDAO
    Public Function Gravar(parAtividade As clsAtividade) As Boolean


        Return DAO.GravarAtividade(parAtividade)

    End Function

    public Sub CarregaComboTipo(pTipo As ComboBox)
        Dim locListaTipo As List(Of clsTipo)

        locListaTipo = DAO.CarregaTipos()
        
        pTipo.DataSource = locListaTipo 
        ptipo.DisplayMember = "DESCRICAO"
        ptipo.ValueMember = "ID"            
    End Sub

    Public Function excluir(iD As Long) As Boolean
        Return DAO.Excluir(iD)
    End Function
End Class
