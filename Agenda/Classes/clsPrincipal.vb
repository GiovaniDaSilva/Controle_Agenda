Imports Agenda

Public Class clsPrincipal
    Public Sub Adicionar(Optional parAtividade As clsAtividade = Nothing)
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ChamaFormulario(parAtividade)
    End Sub

    Public Function funCarregarAtividades(ByVal parFiltro As clsAtividade) As List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades(parFiltro)
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsConsultaAtividades))
        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case 1

                Case 2

            End Select
        Next
    End Sub

    Public Sub GravaDescricao(pAtividade As clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        DAO.gravarAtividade(pAtividade)
    End Sub

    Public Sub CarregaComboTipo(pTipo As ComboBox)
        Dim locAdicionar As New clsAdicionar
        locAdicionar.CarregaComboTipo(pTipo)
    End Sub

End Class
