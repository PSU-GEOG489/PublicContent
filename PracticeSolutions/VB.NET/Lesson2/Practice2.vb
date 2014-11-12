Imports ESRI.ArcGIS.Carto

Public Class Practice2
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice2()
        Dim pDocumentInfo As IDocumentInfo
        pDocumentInfo = My.ArcMap.Application.Document
        pDocumentInfo.Author = "Andrew Murdoch"
    End Sub

    Protected Overrides Sub OnClick()
        Call Practice2()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
