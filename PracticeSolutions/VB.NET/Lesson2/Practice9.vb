Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class Practice9
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice9()


        Dim pMxDoc As IMxDocument

        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap

        pMap = pMxDoc.FocusMap

        Dim pLayer As ILayer

        pLayer = pMap.Layer(0)

        Dim pLayerEffects As ILayerEffects

        pLayerEffects = pLayer

        pLayerEffects.Transparency = 50

        Dim pActiveView As IActiveView

        pActiveView = pMap

        pActiveView.Refresh()


    End Sub

    Protected Overrides Sub OnClick()
        Call Practice9()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
