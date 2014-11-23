Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

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

        Dim pCityLayer As IFeatureLayer = Nothing

        Do Until pLayer Is Nothing
            If pLayer.Name = "us_cities" Then
                pCityLayer = pLayer
                Exit Do
            End If
            pLayer = pLayers.Next
        Loop

        Dim pQueryFilter As IQueryFilter
        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = "POPCLASS >= 4"

        Dim pCityFClass As IFeatureClass
        pCityFClass = pCityLayer.FeatureClass

        Dim lngNameField As Long
        lngNameField = pCityFClass.FindField("NAME")

        Dim pFCursor As IFeatureCursor
        pFCursor = pCityFClass.Search(pQueryFilter, True)

        Dim pFeature As IFeature
        pFeature = pFCursor.NextFeature

        Dim strList As String
        strList = ""

        Do Until pFeature Is Nothing
            strList = strList & pFeature.Value(lngNameField) & vbCr
            pFeature = pFCursor.NextFeature
        Loop

        MsgBox("The following cities are in population class 4 or 5:" & vbCr & strList)

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice3()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
