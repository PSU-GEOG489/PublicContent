Public Class Practice12
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Public Function Square(ByVal intNum As Integer) As Integer

        Square = intNum * intNum

    End Function

    Public Sub Practice12()

        Dim intUserNum As Integer
        intUserNum = InputBox("Enter a number:")
        Dim intUserNumSquared As Integer
        intUserNumSquared = Square(intUserNum)

        MsgBox("That number squared is " & intUserNumSquared)

    End Sub

  Protected Overrides Sub OnClick()
        Call Practice12()
  End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
