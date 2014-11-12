Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Display

Public Class Practice13
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub SetColor(ByVal pLayer As ILayer, ByVal strColor As String)

        Dim pRGBColor As IRgbColor

        pRGBColor = New RgbColor

        If strColor = "red" Then

            pRGBColor.Red = 255

            pRGBColor.Green = 0

            pRGBColor.Blue = 0

        ElseIf strColor = "green" Then

            pRGBColor.Red = 0

            pRGBColor.Green = 255

            pRGBColor.Blue = 0

        ElseIf strColor = "blue" Then

            pRGBColor.Red = 0

            pRGBColor.Green = 0

            pRGBColor.Blue = 255

        End If

        Dim pFLayer As IFeatureLayer2

        pFLayer = pLayer

        Dim pGeoFLayer As IGeoFeatureLayer

        pGeoFLayer = pFLayer

        Dim pRenderer As ISimpleRenderer

        pRenderer = pGeoFLayer.Renderer

        If pFLayer.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Then

            Dim pMarkerSym As ISimpleMarkerSymbol

            pMarkerSym = New SimpleMarkerSymbol

            pMarkerSym.Color = pRGBColor

            pRenderer.Symbol = pMarkerSym

        ElseIf pFLayer.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline Then

            Dim pLineSym As ISimpleLineSymbol

            pLineSym = New SimpleLineSymbol

            pLineSym.Color = pRGBColor

            pRenderer.Symbol = pLineSym

        ElseIf pFLayer.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon Then

            Dim pFillSym As ISimpleFillSymbol

            pFillSym = New SimpleFillSymbol

            pFillSym.Color = pRGBColor

            pRenderer.Symbol = pFillSym

        End If

        Dim pMxDoc As IMxDocument

        pMxDoc = My.ArcMap.Application.Document

        pMxDoc.UpdateContents()

        pMxDoc.ActiveView.Refresh()

    End Sub

    Public Sub Practice13()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pLayers As IEnumLayer
        pLayers = pMap.Layers

        Dim pLayer As ILayer
        pLayer = pLayers.Next

        Do Until pLayer Is Nothing
            If pLayer.Name = "us_cities" Then
                Call SetColor(pLayer, "red")
            ElseIf pLayer.Name = "us_roads" Then
                Call SetColor(pLayer, "green")
            ElseIf pLayer.Name = "us_boundaries" Then
                Call SetColor(pLayer, "blue")
            End If

            pLayer = pLayers.Next

        Loop

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice13()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
