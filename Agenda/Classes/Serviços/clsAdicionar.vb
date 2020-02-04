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
        Dim locResultado As New StringBuilder()
        Dim locAtividade As String
        Dim linha As String
        locResultado.Append("Sem período cadastrado!")

        listaAtividadesPeriodos = DAO.retornaPeriodoAtividades(pData)


        If Not listaAtividadesPeriodos Is Nothing AndAlso listaAtividadesPeriodos.Count > 0 Then
            locResultado.Clear()
            locAtividade = vbNullString

            For Each atividade In listaAtividadesPeriodos
                linha = Space(26)

                If locAtividade <> (atividade.descricao_tipo & " " & atividade.codigo_atividade) Then
                    locAtividade = (atividade.descricao_tipo & " " & atividade.codigo_atividade)

                    linha = locAtividade & Space(Mid(linha, locAtividade.Length, linha.Length).Length)

                    If atividade.descricao_tipo = "Outros" Then
                        linha &= Space(7)
                    ElseIf atividade.descricao_tipo = "PBI" Then
                        linha &= Space(4)
                    ElseIf atividade.codigo_atividade = vbNullString Then
                        linha &= Space(6)
                    End If


                    linha = linha & atividade.hora_inicial & " - " & atividade.hora_final
                Else
                    linha = Space(locAtividade.Length + 13) & Space(Mid(linha, locAtividade.Length, linha.Length).Length)
                    linha = linha & atividade.hora_inicial & " - " & atividade.hora_final
                End If

                locResultado.AppendLine(linha)
            Next
        End If

        Return locResultado.ToString
    End Function

End Class
