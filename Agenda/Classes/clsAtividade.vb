﻿Public Class clsAtividade

    Public Sub New(iD As Long, data As Date, codigo As Integer, horas As String, descricao As String, id_tipo_atividade As Integer, Optional periodo As List(Of clsPeriodo) = Nothing)
        Me.ID = iD
        Me.Data = data
        Me.Codigo = codigo
        Me.Horas = horas
        Me.Descricao = descricao
        Me.ID_TIPO_ATIVIDADE = id_tipo_atividade
        Me.Periodos = periodo
    End Sub
    Public Sub New()
    End Sub

    Public Property ID As Long
    Public Property Data As Date
    Public Property Codigo As String
    Public Property Horas As String
    Public Property Descricao As String
    Public Property ID_TIPO_ATIVIDADE As Integer
    Public Property Periodos As List(Of clsPeriodo)

    Public Function funRetornaDescricaoTratada() As String
        Return Descricao.ToString().Replace(ControlChars.Lf, " ").Replace("<", "&lt;").Replace(">", "&gt;")
    End Function

End Class


Public Class clsConsultaAtividades
    Inherits clsAtividade

    Public Property TIPO_DESCRICAO As String
End Class