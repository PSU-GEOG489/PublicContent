Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile

Public Class NewShapefile
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub NewShapefile()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pWSFactory As IWorkspaceFactory
        pWSFactory = New ShapefileWorkspaceFactory

        Dim pFWorkspace As IFeatureWorkspace
        pFWorkspace = pWSFactory.OpenFromFile("c:/temp", My.ArcMap.Application.hWnd)

        Dim pFieldsEdit As IFieldsEdit
        pFieldsEdit = New Fields

        Dim pIDField As IFieldEdit
        pIDField = New Field

        With pIDField
            .Name_2 = "FID"
            .Type_2 = esriFieldType.esriFieldTypeOID
            .Length_2 = 8
        End With

        Dim pStatesLayer As IFeatureLayer
        pStatesLayer = pMap.Layer(0)

        Dim pStatesFields As IFields
        pStatesFields = pStatesLayer.FeatureClass.Fields

        Dim pStatesShapeField As IField
        pStatesShapeField = pStatesFields.Field(pStatesFields.FindField("Shape"))

        Dim pStatesGeomDef As IGeometryDef
        pStatesGeomDef = pStatesShapeField.GeometryDef

        Dim pShapeField As IFieldEdit
        pShapeField = New Field

        With pShapeField
            .Name_2 = "Shape"
            .Type_2 = esriFieldType.esriFieldTypeGeometry
            .GeometryDef_2 = pStatesGeomDef
        End With

        Dim pNameField As IFieldEdit
        pNameField = New Field

        With pNameField
            .Name_2 = "Site_Name"
            .Type_2 = esriFieldType.esriFieldTypeString
            .Length_2 = 20
        End With

        Dim pReadingField As IFieldEdit
        pReadingField = New Field

        With pReadingField
            .Name_2 = "Reading"
            .Type_2 = esriFieldType.esriFieldTypeInteger
            .Length_2 = 8
        End With

        Dim pDateField As IFieldEdit
        pDateField = New Field

        With pDateField
            .Name_2 = "Visit_Date"
            .Type_2 = esriFieldType.esriFieldTypeDate
        End With

        With pFieldsEdit
            .AddField(pIDField)
            .AddField(pShapeField)
            .AddField(pNameField)
            .AddField(pReadingField)
            .AddField(pDateField)
        End With

        Dim pFClass As IFeatureClass
        pFClass = pFWorkspace.CreateFeatureClass("measurements.shp", pFieldsEdit, Nothing, Nothing, esriFeatureType.esriFTSimple, "Shape", "")

        Dim pFLayer As IFeatureLayer
        pFLayer = New FeatureLayerClass

        pFLayer.FeatureClass = pFClass
        pFLayer.Name = "Field Measurements"

        pMap.AddLayer(pFLayer)
        pMxDoc.UpdateContents()

        Dim pActiveView As IActiveView
        pActiveView = pMap
        pActiveView.Refresh()
    End Sub

    Protected Overrides Sub OnClick()
        Call NewShapefile()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
