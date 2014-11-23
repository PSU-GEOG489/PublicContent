Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

Public Class SpatialFilter
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub SpatialFilter()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pCityLayer As IFeatureLayer
        pCityLayer = pMap.Layer(0)  '** Assuming first layer is us_cities

        Dim pStateLayer As IFeatureLayer
        pStateLayer = pMap.Layer(1) '** Assuming second layer is STATES

        Dim pStateFClass As IFeatureClass
        pStateFClass = pStateLayer.FeatureClass

        Dim pQueryFilter As IQueryFilter
        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = "NAME = 'Pennsylvania'"

        Dim pStateFCursor As IFeatureCursor
        pStateFCursor = pStateFClass.Search(pQueryFilter, True)

        Dim pStateFeature As IFeature
        pStateFeature = pStateFCursor.NextFeature  '** Moving to the PA feature

        Dim pGeom As IGeometry
        pGeom = pStateFeature.Shape   '** Getting the PA polygon geometry

        Dim pSpatialFilter As ISpatialFilter
        pSpatialFilter = New SpatialFilterClass

        With pSpatialFilter
            .Geometry = pGeom       '** Setting equal to PA shape
            .GeometryField = "SHAPE"
            .SpatialRel = esriSpatialRelEnum.esriSpatialRelContains  '** Getting features contained by PA shape
        End With

        Dim pCityFClass As IFeatureClass
        pCityFClass = pCityLayer.FeatureClass

        Dim pCityFCursor As IFeatureCursor
        pCityFCursor = pCityFClass.Search(pSpatialFilter, True)

        Dim lngPopclassIndex As Long   '** Field index for population class
        Dim lngCityNameIndex As Long   '** Field index for the name of the city

        lngPopclassIndex = pCityFClass.Fields.FindField("POPCLASS")
        lngCityNameIndex = pCityFClass.Fields.FindField("NAME")

        Dim pCityFeature As IFeature
        pCityFeature = pCityFCursor.NextFeature

        Do Until pCityFeature Is Nothing
            If pCityFeature.Value(lngPopclassIndex) >= 3 Then
                '** If a city is big, report that
                MsgBox(pCityFeature.Value(lngCityNameIndex) & " is a big city.")
            End If
            pCityFeature = pCityFCursor.NextFeature
        Loop

    End Sub

    Protected Overrides Sub OnClick()
        Call SpatialFilter()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
