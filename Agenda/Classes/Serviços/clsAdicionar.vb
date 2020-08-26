Imports System.Text

Public Class clsAdicionar
    Private DAO As New clsAdicionarDAO
    Public Function Gravar(parAtividade As clsAtividade) As Boolean

        subValidaAtividade(parAtividade)

        Return DAO.gravarAtividade(parAtividade)

    End Function

    Private Sub subValidaAtividade(parAtividade As clsAtividade)
        Dim ini = New clsIni().funCarregaIni()

        If Val(parAtividade.Codigo) > 9999999 Then
            Throw New Exception("Código da atividade não deve ser superior a 999999.")
        End If

        If DateDiff("d", CDate("01/01/1900"), parAtividade.Data) < 0 Then
            Throw New Exception("Data Inválida.")
        End If

        If ini.Horastrabalhadas = enuHorasTrabalhadas.Periodo Then
            If Trim(parAtividade.Horas) <> ":" And
               Trim(parAtividade.Horas) <> "00:00" And
                parAtividade.Periodos.Count = 0 Then
                Throw New Exception("Não é permitido horas trabalhadas sem período informado.")
            End If

            If Trim(parAtividade.Horas) = ":" And parAtividade.Periodos.Count > 0 Then
                Throw New Exception("Horas totais não informado.")
            End If
        End If
    End Sub

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
                'linha = Space(26)
                linha = StrDup(26, ".")
                If locAtividade <> (atividade.descricao_tipo & " " & atividade.codigo_atividade) Then
                    locAtividade = (atividade.descricao_tipo & " " & atividade.codigo_atividade)

                    linha = locAtividade & StrDup(Mid(linha, locAtividade.Length, linha.Length).Length, ".")


                    linha = linha & atividade.hora_inicial & " - " & atividade.hora_final
                Else
                    linha = Space(locAtividade.Length) & StrDup(Mid(linha, locAtividade.Length, linha.Length).Length, ".")
                    linha = linha & atividade.hora_inicial & " - " & atividade.hora_final
                End If

                locResultado.AppendLine(linha)
            Next
        End If

        Return locResultado.ToString
    End Function

End Class
