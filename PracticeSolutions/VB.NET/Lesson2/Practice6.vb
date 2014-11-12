Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class Practice6
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice6()

        Dim pMxDoc As IMxDocument

        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap

        pMap = pMxDoc.FocusMap

        MsgBox(pMap.SelectionCount)

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice6()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
