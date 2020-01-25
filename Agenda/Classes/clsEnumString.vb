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