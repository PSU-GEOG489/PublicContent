Imports ESRI.ArcGIS.DataSourcesRaster
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile


Public Class AddData
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub


    Public Sub Add_AccessData()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pWSFactory As IWorkspaceFactory
        pWSFactory = New AccessWorkspaceFactory

        Dim pWorkspace As IWorkspace
        pWorkspace = pWSFactory.OpenFromFile("C:/wcgis/geog484/Lesson1/data/Lesson1.mdb", _
            My.ArcMap.Application.hWnd)

        Dim pFWorkspace As IFeatureWorkspace
        pFWorkspace = pWorkspace

        Dim pFClass As IFeatureClass
        pFClass = pFWorkspace.OpenFeatureClass("Roads")

        Dim pFLayer As IFeatureLayer
        pFLayer = New FeatureLayer
        pFLayer.FeatureClass = pFClass
        pMap.AddLayer(pFLayer)

        With pFLayer
            .Name = "Roads"
            .ShowTips = True
        End With

        pMxDoc.UpdateContents()

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()

    End Sub


    Public Sub Add_CoverageData()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pWSFactory As IWorkspaceFactory
        pWSFactory = New ArcInfoWorkspaceFactory

        Dim pWorkspace As IWorkspace
        pWorkspace = pWSFactory.OpenFromFile("C:/wcgis/geog483/Lesson5/data/", _
            My.ArcMap.Application.hWnd)

        Dim pFWorkspace As IFeatureWorkspace
        pFWorkspace = pWorkspace

        Dim pFClass As IFeatureClass
        pFClass = pFWorkspace.OpenFeatureClass("wdzoning:polygon")

        Dim pFLayer As IFeatureLayer
        pFLayer = New FeatureLayer
        pFLayer.FeatureClass = pFClass
        pMap.AddLayer(pFLayer)

        With pFLayer
            .Name = "Zoning"
            .ShowTips = True
        End With

        pMxDoc.UpdateContents()

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()

    End Sub


    Public Sub Add_Raster()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pRLayer As IRasterLayer
        pRLayer = New RasterLayer

        ' ** Can also go through a process similar to that of a feature layer,
        ' ** but this is a nice shortcut!
        pRLayer.CreateFromFilePath("C:/wcgis/geog484/Lesson1/data/cobhamclip.tif")
        pRLayer.Name = "Cobham DRG"
        pMap.AddLayer(pRLayer)

        pMxDoc.UpdateContents()

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()

    End Sub

    Protected Overrides Sub OnClick()
        Call Add_AccessData()
        Call Add_CoverageData()
        Call Add_Raster()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
