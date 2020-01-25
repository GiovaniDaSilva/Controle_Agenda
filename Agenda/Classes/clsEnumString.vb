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
End Class

Public MustInherit Class enuGrupoIni
    Public Shared Property Geral As String = "Geral"
    Public Shared Property Dados As String = "Dados"
End Class

Public MustInherit Class enuCamposImpressao
    Public Shared Property Solicitacoes As String = "<fc:" & Color.Red.Name & "><b>Solicitação</b></fc>"
    Public Shared Property Codigo As String = "<b>Código: </b>"
    Public Shared Property Titulo As String = "<b>Titulo: </b>"
    Public Shared Property Horas As String = "<b>Horas: </b>"
    Public Shared Property Subtipo As String = "<b>SubTipo: </b>"
    Public Shared Property Objeto As String = "<b>Objeto: </b>"
    Public Shared Property Situacao As String = "<b>Situação: </b>"
    Public Shared Property Descricao As String = "<b>Descrição: </b>"

    Public Shared Property PBI As String = "<fc:" & Color.Blue.Name & "><b>PBI</b></fc>"
    Public Shared Property Outros As String = "<fc:" & Color.Maroon.Name & "><b>Outros</b></fc>"
    Public Shared Property Ausente As String = "<fc:" & Color.Orange.Name & "><b>Ausente</b></fc>"
    Public Shared Property Reuniao As String = "<fc:" & Color.Green.Name & "><b>Reunião</b></fc>"
End Class
