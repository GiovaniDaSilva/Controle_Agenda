Public Class clsAtividadesGrafico
    Public Property TotalHorasAtividades As Double
    Public Property TotalHorasSolicitacoes As Double
    Public Property TotalHorasPBI As Double
    Public Property TotalHorasReuniao As Double
    Public Property TotalHorasAusente As Double
    Public Property TotalHorasOutros As Double


    Public ReadOnly Property PercentualSolicitacoes() As Double
        Get
            Return calculaPercentual(TotalHorasSolicitacoes)
        End Get
    End Property

    Public ReadOnly Property PercentualPBI() As Double
        Get
            Return calculaPercentual(TotalHorasPBI)
        End Get
    End Property
    Public ReadOnly Property PercentualReuniao() As Double
        Get
            Return calculaPercentual(TotalHorasReuniao)
        End Get
    End Property
    Public ReadOnly Property PercentualAusente() As Double
        Get
            Return calculaPercentual(TotalHorasAusente)
        End Get
    End Property
    Public ReadOnly Property PercentualOutros() As Double
        Get
            Return calculaPercentual(TotalHorasOutros)
        End Get
    End Property

    Private Function calculaPercentual(pvalor As Double) As Double
        Return Math.Round(((pvalor / TotalHorasAtividades) * 100), 2)
    End Function

End Class
