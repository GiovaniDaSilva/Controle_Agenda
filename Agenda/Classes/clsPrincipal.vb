Imports Agenda

Public Class clsPrincipal

    Public Enum enuTipoAtividades
        SOLICITACAO = 1
        PBI = 2
        REUNIAO = 3
        AUSENTE = 4
        OUROS = 5
    End Enum


    Public Sub Adicionar(ByVal parIni As clsParametrosIni, Optional parAtividade As clsAtividade = Nothing)
        Dim locFormAdicionar As New frmAdicionar

        locFormAdicionar.ChamaFormulario(parIni, parAtividade)
    End Sub

    Public Function funCarregarAtividades(ByVal parFiltro As clsAtividade, parParametrosIni As clsParametrosIni) As List(Of clsConsultaAtividades)
        Dim DAO As New clsAdicionarDAO
        Return DAO.carregarAtividades(parFiltro, parParametrosIni)
    End Function

    Public Sub subListarAtivdades(ByRef txtTela As RichTextBox, ByRef lista As List(Of clsConsultaAtividades), Optional ByVal pHTML As String = vbNullString)
        Dim objeto As clsIListaAtividades
        Dim locExisteSolicitacao As Boolean
        Dim listaSolicitacao As New List(Of clsSolicitacao)

        Dim i = lista.FindIndex(Function(X) X.ID_TIPO_ATIVIDADE = enuTipoAtividades.SOLICITACAO)
        locExisteSolicitacao = (i >= 0)

        txtTela.Clear()
        If locExisteSolicitacao Then
            listaSolicitacao = clsSolicitacao.funCarregaDetalhesSolicitacoes(pHTML)
        End If


        For Each item In lista
            Select Case item.ID_TIPO_ATIVIDADE

                Case enuTipoAtividades.SOLICITACAO
                    objeto = New clsListaSolictacao(listaSolicitacao)
                Case enuTipoAtividades.PBI
                    objeto = New clsListaPBI
                Case enuTipoAtividades.REUNIAO
                    objeto = New clsListaReuniao
                Case enuTipoAtividades.AUSENTE
                    objeto = New clsListaAusente
                Case Else
                    objeto = New clsListaOutros
            End Select
            objeto.subListaAtividade(txtTela, item)
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

    Friend Sub Configurar(pParametros As clsParametrosIni)
        Dim locForm As New frmConfiguracoes
        Dim locParametros = pParametros

        pParametros = locForm.funChamaConfiguracao(pParametros)

        If pParametros Is Nothing Then
            pParametros = locParametros
        End If

    End Sub

    Friend Function funCarregaArquivoIni() As clsParametrosIni
        Dim locIni As New clsIni
        Return locIni.funCarregaIni
    End Function

End Class


Public Interface clsIListaAtividades
    Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades)
End Interface

Public Class clsListaSolictacao
    Implements clsIListaAtividades

    Public Sub New(listaSolicitacoes As List(Of clsSolicitacao))
        Me.ListaSolicitacoes = listaSolicitacoes
    End Sub

    Public Property ListaSolicitacoes As New List(Of clsSolicitacao)


    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'Solicitacao
        '       Código: xxxx           
        '       Titulo: xxxx           
        '       Horas: xx:xx
        '       SubTipo: xxxx
        '       Objeto: xxxx
        '       Situação: xxxx
        '       Descrição: xxxxxxxxxxxx      

        Dim locDetalhes As clsSolicitacao
        Dim locDetalhesBase As clsSolicitacao
        Dim locDAO As New clsSolicitacaoDAO

        locDetalhes = ListaSolicitacoes.Find(Function(X) X.Codigo = item.Codigo)
        locDetalhesBase = locDAO.consultaSolicitacao(item.ID)

        If Not locDetalhes Is Nothing Then
            locDetalhes.ID_ATIVIDADE = item.ID

            If Not locDetalhesBase Is Nothing Then
                locDetalhes.ID = locDetalhesBase.ID
            End If

            locDAO.gravarSolicitacao(locDetalhes)
        Else
            If Not locDetalhesBase Is Nothing Then
                locDetalhes = locDetalhesBase
            End If
        End If

        RichAddLineFmt(parCampo, "<fc:" & Color.Red.Name & "><b>Solicitação</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Código: " & item.Codigo)

        If Not locDetalhes Is Nothing Then
            RichAddLineFmt(parCampo, clsTools.Tab & "Titulo: " & locDetalhes.Resumo)
        End If

        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)


        If Not locDetalhes Is Nothing Then
            RichAddLineFmt(parCampo, clsTools.Tab & "SubTipo: " & locDetalhes.SubTipo)
            RichAddLineFmt(parCampo, clsTools.Tab & "Objeto: " & locDetalhes.Objeto)
            RichAddLineFmt(parCampo, clsTools.Tab & "Situação: " & locDetalhes.Situacao)
        End If

        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.funRetornaDescricaoTratada())
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
        RichAddLineFmt(parCampo, "<fc:" & Color.Blue.Name & "><b>PBI</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Código: " & item.Codigo)
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "IPP: -")
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class


Public Class clsListaReuniao
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'Reuniao       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, "<fc:" & Color.Green.Name & "><b>Reunião</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class

Public Class clsListaAusente
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'Ausente       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, "<fc:" & Color.Orange.Name & "><b>Ausente</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class

Public Class clsListaOutros
    Implements clsIListaAtividades

    Public Sub subListaAtividade(parCampo As RichTextBox, item As clsConsultaAtividades) Implements clsIListaAtividades.subListaAtividade
        'Outros       
        '       Horas: xx:xx        
        '       Descrição: xxxxxxxxxxxx      
        RichAddLineFmt(parCampo, "<fc:" & Color.Maroon.Name & "><b>Outros</b></fc>")
        RichAddLineFmt(parCampo, clsTools.Tab & "Horas: " & item.Horas)
        RichAddLineFmt(parCampo, clsTools.Tab & "Descrição: " & item.funRetornaDescricaoTratada())
        RichAddLineFmt(parCampo, "")
    End Sub
End Class
