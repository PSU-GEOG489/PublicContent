Public Class Practice1
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Public Sub Practice1()
        Dim x As String
        x = "Hello"
        MsgBox(x, vbOKOnly, "Practice 1")
    End Sub


    Protected Overrides Sub OnClick()

        Call Practice1()

    End Sub

  Protected Overrides Sub OnUpdate()
    Enabled = My.ArcMap.Application IsNot Nothing
  End Sub
End Class
