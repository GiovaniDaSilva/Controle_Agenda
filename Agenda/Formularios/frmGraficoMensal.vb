Public Class frmGraficoMensal
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtDataFinal_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtDataFinal.MaskInputRejected

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim locGrafico As New clsGraficoMensal

        locGrafico.subGeraGrafico(clsTools.funRetornaData(txtDataInicial), clsTools.funRetornaData(txtDataFinal))
    End Sub
End Class