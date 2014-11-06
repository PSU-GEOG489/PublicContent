Public Class Practice3
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Public Sub Practice3()
        Dim x As String
        x = InputBox("Please enter your name")

        MsgBox("Hi " & x & "!", vbOKOnly, "Practice 3")

    End Sub

    Protected Overrides Sub OnClick()

        Call Practice3()

    End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
