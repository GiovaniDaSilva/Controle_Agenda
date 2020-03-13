Public Class clsImpressaoWeb

    Public Function RetornaPagina(pAtividade As clsAtividade) As String
            Return RetornaHTML(pAtividade)
        End Function

        Private Function RetornaHTML(pAtividade As clsAtividade) As String

            Dim html As String
            html = My.Resources.Impressao
            'html = html.Replace("[p_inicializa_campos_atividade]", RetornaLinhasInicializacaoCampos(pAtividade))


            Dim x As String

            Dim ini = New clsIni().funCarregaIni
            Dim atividades = New clsAdicionarDAO().carregarAtividades(pAtividade, ini)


            For Each item In atividades
                x &= "&nbsp <b>codigo:</b> " & item.Codigo
                x &= "</br> &nbsp <b>tipo:</b> " & item.TIPO_DESCRICAO
                x &= "</br> &nbsp <b>hora: </b>" & item.Horas
                x &= "</br> &nbsp <b>descricao: </b>" & item.Descricao
                x &= "</br> </br>"
            Next


            html = html.Replace("{p_dados_impresso}", x)
            Return html
        End Function


    End Class
