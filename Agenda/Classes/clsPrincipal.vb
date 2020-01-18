Imports Agenda

Public Class clsPrincipal

    Public Enum enuTipoAtividades
        SOLICITACAO = 1
        PBI = 2
        REUNIAO = 3
        AUSENTE = 4
        OUROS = 5
    End Enum


    Public Sub Adicionar(Optional parAtividade As clsAtividade = Nothing)
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ChamaFormulario(parAtividade)
    End Sub

    Public Function funCarregarAtividades(ByVal parFiltro As clsAtividade) As List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades(parFiltro)
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsConsultaAtividades))
        txtTela.Clear()

        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case enuTipoAtividades.SOLICITACAO
                    Dim x = New clsListaSolictacao
                    x.subListaAtividade(txtTela, item)
                Case enuTipoAtividades.PBI
                    Dim x = New clsListaPBI
                    x.subListaAtividade(txtTela, item)
                Case enuTipoAtividades.REUNIAO

                Case enuTipoAtividades.AUSENTE

                Case enuTipoAtividades.OUROS

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


Public Interface clsIListaAtividades
    Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades)
End Interface

Public Class clsListaSolictacao
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'Solicitacao
        '       Código: xxxx           
        '       Horas: xx:xx
        '       Tipo de conclusão: xxxx
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, "<fc:red><b>Solicitação</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Código: " & item.Codigo)
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "Tipo de Conclusão: -")
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.Descricao.ToString().Replace(ControlChars.Lf, " "))
        RichAddLineFmt(parCampo, "")
    End Sub
End Class


Public Class clsListaPBI
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'PBI
        '       Código: xxxx           
        '       Horas: xx:xx
        '       IPP: xxxx
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, "<fc:Blue><b>PBI</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Código: " & item.Codigo)
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "IPP: -")
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.Descricao.ToString().Replace(ControlChars.Lf, " "))
        RichAddLineFmt(parCampo, "")
    End Sub
End Class


