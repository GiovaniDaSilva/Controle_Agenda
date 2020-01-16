Imports Agenda

Public Class clsPrincipal
    Public Sub Adicionar()
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ShowDialog()
    End Sub

    Public Function funCarregarAtividades() As List(Of clsAtividade)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades()
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsAtividade))
        For Each item In lista
            Select Case item.Tipo

                Case "X"

                Case "Y"

            End Select
        Next
    End Sub
End Class
