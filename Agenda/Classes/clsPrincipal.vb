﻿Imports Agenda

Public Class clsPrincipal
    Public Sub Adicionar()
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ShowDialog()
    End Sub

    Public Function funCarregarAtividades() As List(Of clsConsultaAtividades )
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades()
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsConsultaAtividades))
        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case 1

                Case 2

            End Select
        Next
    End Sub
End Class
