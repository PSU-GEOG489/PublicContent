Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Display

Public Class Practice3
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice3()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pLayers As IEnumLayer
        pLayers = pMap.Layers

        Dim pLayer As ILayer
        pLayer = pLayers.Next

        Do Until pLayer Is Nothing
            If pLayer.Name = "U.S. Cities" Then
                Exit Do
            End If

            pLayer = pLayers.Next
        Loop

        Dim pGeoFLayer As IGeoFeatureLayer
        pGeoFLayer = pLayer 'QI

        Dim pSym As ISimpleMarkerSymbol
        pSym = New SimpleMarkerSymbol
        pSym.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSX

        Dim pRenderer As ISimpleRenderer
        pRenderer = New SimpleRenderer
        pRenderer.Symbol = pSym
        pGeoFLayer.Renderer = pRenderer

        Dim pActiveView As IActiveView
        pActiveView = pMap

        pActiveView.Refresh()
        pMxDoc.UpdateContents()

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice3()

    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
