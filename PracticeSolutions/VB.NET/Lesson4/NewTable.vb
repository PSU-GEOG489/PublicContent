Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile

Public Class NewTable
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub NewTable()

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
            .Name_2 = "OID"
            .Type_2 = esriFieldType.esriFieldTypeOID
            .Length_2 = 8
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
            .AddField(pNameField)
            .AddField(pReadingField)
            .AddField(pDateField)
        End With

        Dim pTable As ITable
        pTable = pFWorkspace.CreateTable("measurements.dbf", pFieldsEdit, Nothing, Nothing, "")

        Dim pTableCollection As ITableCollection
        pTableCollection = pMap
        pTableCollection.AddTable(pTable)

        pMxDoc.UpdateContents()
    End Sub

    Protected Overrides Sub OnClick()
        Call NewTable()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
