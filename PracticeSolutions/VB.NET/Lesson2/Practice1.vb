Public Class Practice1
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Public Sub Practice1()
        My.ArcMap.Application.Caption = "We Are Penn State!"
    End Sub

  Protected Overrides Sub OnClick()
        Call Practice1()
  End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
