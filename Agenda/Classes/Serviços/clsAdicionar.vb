Imports System.Text

Public Class clsAdicionar
    Private DAO As New clsAdicionarDAO
    Public Function Gravar(parAtividade As clsAtividade) As Boolean


        Return DAO.gravarAtividade(parAtividade)

    End Function

    Public Sub CarregaComboTipo(pTipo As ComboBox)
        Dim locListaTipo As List(Of clsTipo)

        locListaTipo = DAO.CarregaTipos()

        pTipo.DataSource = locListaTipo
        pTipo.DisplayMember = "DESCRICAO"
        pTipo.ValueMember = "ID"
    End Sub

    Public Function excluir(iD As Long) As Boolean
        If MsgBox("Deseja Excluir a atividade?", MsgBoxStyle.YesNo, "Questão") = Windows.Forms.DialogResult.Yes Then
            Return DAO.Excluir(iD)
        End If
        Return False
    End Function

    Friend Function RetornaTotalHoras(pInicial As String, pFinal As String) As String
        Dim Inicial As TimeSpan
        Dim Final As TimeSpan

        Inicial = TimeSpan.Parse(pInicial)
        Final = TimeSpan.Parse(pFinal)

        Return Mid(Final.Subtract(Inicial).ToString(), 1, 5)
    End Function

    Public Function RetornaToolTipPeriodosDia(ByVal pData As Date) As String
        Dim listaAtividadesPeriodos As List(Of clsPeriodosAtividades)
        Dim locResultado As new StringBuilder()
        Dim locAtividade As String

        locResultado.Append("Sem período cadastrado!")
        
        listaAtividadesPeriodos = DAO.retornaPeriodoAtividades(pData)


        If Not listaAtividadesPeriodos Is Nothing AndAlso listaAtividadesPeriodos.Count > 0
            locResultado.Clear()        
            locAtividade = vbNullString
            For Each atividade In listaAtividadesPeriodos
                If locAtividade <> (atividade.descricao_tipo & atividade.codigo_atividade)
                    locAtividade = (atividade.descricao_tipo & atividade.codigo_atividade)
                Else
                    locAtividade = StrDup(locAtividade.Length," ") 
                End If
                
                locResultado.Append(locAtividade & clsTools.Tab & atividade.hora_inicial & " - " & atividade.hora_final)            
            Next
        End If

        Return locResultado.ToString 
    End Function

End Class
