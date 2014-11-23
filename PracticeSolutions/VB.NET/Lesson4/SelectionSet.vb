Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class SelectionSet
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub SelectionSet()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pFLayer As IFeatureLayer
        pFLayer = pMap.Layer(0)

        Dim pFSel As IFeatureSelection
        pFSel = pFLayer

        Dim pSelSet As ISelectionSet
        pSelSet = pFSel.SelectionSet

        Dim pFCursor As IFeatureCursor = Nothing
        pSelSet.Search(Nothing, True, pFCursor)

        Dim pFeature As IFeature
        pFeature = pFCursor.NextFeature

        Dim i As Integer
        Dim lngTotalArea As Long
        i = 0
        lngTotalArea = 0

        Dim pFClass As IFeatureClass
        pFClass = pFLayer.FeatureClass

        Dim lngAreaIndex As Long
        lngAreaIndex = pFClass.Fields.FindField("Shape_Area")

        Do Until pFeature Is Nothing
            i = i + 1
            lngTotalArea = lngTotalArea + pFeature.Value(lngAreaIndex)
            pFeature = pFCursor.NextFeature
        Loop

        MsgBox("There are " & i & " selected states." & vbCr &
            "The total area (decimal degrees) of the states is " & lngTotalArea & vbCr &
            "and the average area per state is " & lngTotalArea / i)

    End Sub

    Protected Overrides Sub OnClick()
        Call SelectionSet()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
