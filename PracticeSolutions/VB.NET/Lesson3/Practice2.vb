Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile

Public Class Practice2
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice2()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pWSFactory As IWorkspaceFactory
        pWSFactory = New ShapefileWorkspaceFactory

        Dim pWorkspace As IWorkspace
        pWorkspace = pWSFactory.OpenFromFile("c:\WCGIS\G5224P\Lesson1_2_3", _
            My.ArcMap.Application.hWnd)

        Dim pFWorkspace As IFeatureWorkspace
        pFWorkspace = pWorkspace 'QI

        Dim pStatesFClass As IFeatureClass
        pStatesFClass = pFWorkspace.OpenFeatureClass("us_boundaries")

        Dim pStatesLayer As IFeatureLayer
        pStatesLayer = New FeatureLayer
        pStatesLayer.FeatureClass = pStatesFClass
        pStatesLayer.Name = "U.S. States"

        pMap.AddLayer(pStatesLayer)

        Dim pCitiesFClass As IFeatureClass
        pCitiesFClass = pFWorkspace.OpenFeatureClass("us_cities")

        Dim pCitiesLayer As IFeatureLayer

        pCitiesLayer = New FeatureLayer
        pCitiesLayer.FeatureClass = pCitiesFClass
        pCitiesLayer.Name = "U.S. Cities"

        pMap.AddLayer(pCitiesLayer)

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()

        pMxDoc.UpdateContents()

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice2()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
