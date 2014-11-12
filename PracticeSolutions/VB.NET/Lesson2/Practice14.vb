Public Class Practice14
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

    End Sub

    Public Function CToF(ByVal dblCel As Double) As Double

        CtoF = (9 / 5 * dblCel) + 32

    End Function

    Public Sub Practice14()

        Dim dblC1 As Double
        dblC1 = InputBox("Please enter the 3AM temp in Celsius.")

        Dim dblF1 As Double
        dblF1 = CToF(dblC1)

        Dim dblC2 As Double
        dblC2 = InputBox("Please enter the 9AM temp in Celsius.")

        Dim dblF2 As Double
        dblF2 = CToF(dblC2)

        Dim dblC3 As Double
        dblC3 = InputBox("Please enter the 3PM temp in Celsius.")

        Dim dblF3 As Double
        dblF3 = CToF(dblC3)

        Dim dblC4 As Double
        dblC4 = InputBox("Please enter the 9PM temp in Celsius.")

        Dim dblF4 As Double
        dblF4 = CToF(dblC4)

        Dim dblAvg As Double
        dblAvg = (dblF1 + dblF2 + dblF3 + dblF4) / 4

        MsgBox(dblAvg)

    End Sub
  Protected Overrides Sub OnClick()
        Call Practice14()
  End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
