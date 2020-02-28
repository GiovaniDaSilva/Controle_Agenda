Public Class clsEnumString
End Class

Public MustInherit Class enuApartirDe
    Public Shared Property Branco As String = "Branco"
    Public Shared Property Dias7 As String = "7Dias"
    Public Shared Property Atual As String = "Atual"
End Class

Public MustInherit Class enuHorasTrabalhadas
    Public Shared Property Periodo As String = "Periodo"
    Public Shared Total As String = "Total"
End Class

Public MustInherit Class enuOrdenacaoDasAtividades
    Public Shared Property Dec As String = "Dec"
    Public Shared Property Cre As String = "Cre"
End Class


Public MustInherit Class enuParametrosIni
    Public Shared Property CampoAPartirDe As String = "CampoAPartirDe"
    Public Shared Property HorasTrabalhadas As String = "HorasTrabalhadas"
    Public Shared Property Ordenacao As String = "Ordenacao"
    Public Shared Property SolicitarHTML As String = "SolicitarHTML"
    Public Shared Property CaminhoBase As String = "CaminhoBase"
    Public Shared Property TempoNotificacao As String = "TempoNotificacao"
End Class

Public MustInherit Class enuTempoNotificacao
    Public Shared Property Hora1 As String = "Hora1"
    Public Shared Property Hora2 As String = "Hora2"
    Public Shared Property Hora3 As String = "Hora3"
    Public Shared Property Hora4 As String = "Hora4"
    Public Shared Property NaoUsar As String = "NaoUsa"
End Class

Public MustInherit Class enuGrupoIni
    Public Shared Property Geral As String = "Geral"
    Public Shared Property Dados As String = "Dados"
End Class

Public MustInherit Class enuCamposImpressao
    Public Shared Property Codigo As String = "<b>Código: </b>"
    Public Shared Property Titulo As String = "<b>Titulo: </b>"
    Public Shared Property Horas As String = "<b>Horas: </b>"
    Public Shared Property Periodo As String = "<b>Período: </b>"
    Public Shared Property Subtipo As String = "<b>SubTipo: </b>"
    Public Shared Property Objeto As String = "<b>Objeto: </b>"
    Public Shared Property Situacao As String = "<b>Situação: </b>"
    Public Shared Property Descricao As String = "<b>Descrição: </b>"

    Public Shared Property Solicitacoes As String = "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>Solicitação</u></b></fc></fs>"
    Public Shared Property PBI As String = "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>PBI</u></b></fc></fs>"
    Public Shared Property Ausente As String = "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>Ausente</u></b></fc></fs>"
    Public Shared Property Reuniao As String = "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>Reunião</u></b></fc></fs>"
    'Public Shared Property Outros As String = "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>Outros</u></b></fc></fs>"

    Public Shared Function Outros(descricao As String) As String
        Return "<fs:10><fc:" & Color.DarkBlue.Name & "><b><u>" & descricao & "</u></b></fc></fs>"
    End Function
End Class


Public MustInherit Class enuTipoAtividade
    Public Shared Property Solicitacao As String = "Solicitações"
    Public Shared Property PBI As String = "PBI"
    Public Shared Property Reuniao As String = "Reunião"
    Public Shared Property Ausente As String = "Ausente"
    Public Shared Property Outros As String = "Outros"
End Class
