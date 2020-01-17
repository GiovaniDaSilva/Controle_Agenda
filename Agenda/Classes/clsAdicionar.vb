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
        If MsgBox("Deseja Excluir a atividade?", MsgBoxStyle.YesNo, "Questão") = Windows.Forms.DialogResult.Yes  Then
           Return DAO.Excluir(iD)     
        End If
        Return false        
    End Function
End Class
