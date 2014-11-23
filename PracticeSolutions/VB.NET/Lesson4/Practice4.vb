Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

Public Class Practice4
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice4()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pLayer As ILayer
        Dim pLayers As IEnumLayer
        Dim pStateLayer As IFeatureLayer = Nothing
        Dim pRoadLayer As IFeatureLayer = Nothing

        pLayers = pMap.Layers
        pLayer = pLayers.Next

        Do Until pLayer Is Nothing
            If pLayer.Name = "us_boundaries" Then
                pStateLayer = pLayer
            ElseIf pLayer.Name = "us_roads" Then
                pRoadLayer = pLayer
            End If

            pLayer = pLayers.Next
        Loop

        Dim pQueryFilter As IQueryFilter
        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = "NAME = 'New York'"

        Dim pStateFClass As IFeatureClass
        pStateFClass = pStateLayer.FeatureClass

        Dim pStateFCursor As IFeatureCursor
        pStateFCursor = pStateFClass.Search(pQueryFilter, True)

        Dim pStateFeature As IFeature
        pStateFeature = pStateFCursor.NextFeature  '** Moving to the NY feature

        Dim pGeom As IGeometry
        pGeom = pStateFeature.Shape   '** Getting the NY polygon geometry

        Dim pSpatialFilter As ISpatialFilter
        pSpatialFilter = New SpatialFilter

        With pSpatialFilter
            .Geometry = pGeom       '** Setting equal to NY shape
            .GeometryField = "SHAPE"
            .SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects  '** Getting roads that intersect NY
        End With

        Dim pFSel As IFeatureSelection
        pFSel = pRoadLayer   '** QI
        pFSel.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, False)

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice4()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
