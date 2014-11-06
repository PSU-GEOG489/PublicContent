Public Class Practice2
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice2()
        Dim x As Integer
        x = 9
        Dim y As Integer
        y = 7
        Dim z As Integer
        z = x + y

        MsgBox(z, vbOKOnly, "Practice 2")
    End Sub

    Protected Overrides Sub OnClick()

        Call Practice2()

    End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
