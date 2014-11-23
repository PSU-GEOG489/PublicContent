Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile

Public Class Practice1
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice1()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pWFactory As IWorkspaceFactory
        pWFactory = New ShapefileWorkspaceFactory

        Dim pFWorkspace As IFeatureWorkspace
        pFWorkspace = pWFactory.OpenFromFile("c:/temp", My.ArcMap.Application.hWnd)

        Dim pFieldsEdit As IFieldsEdit
        pFieldsEdit = New Fields

        Dim pIDField As IFieldEdit
        pIDField = New Field

        With pIDField
            .Name_2 = "OID"
            .Type_2 = esriFieldType.esriFieldTypeOID
            .Length_2 = 3
        End With

        Dim pCodeField As IFieldEdit
        pCodeField = New Field

        With pCodeField
            .Name_2 = "LU_Code"
            .Type_2 = esriFieldType.esriFieldTypeString
            .Length_2 = 4
        End With

        Dim pDescField As IFieldEdit
        pDescField = New Field

        With pDescField
            .Name_2 = "LU_Desc"
            .Type_2 = esriFieldType.esriFieldTypeString
            .Length_2 = 25
        End With

        With pFieldsEdit
            .AddField(pIDField)
            .AddField(pCodeField)
            .AddField(pDescField)
        End With

        Dim pTable As ITable
        pTable = pFWorkspace.CreateTable("lu_codes.dbf", pFieldsEdit, Nothing, Nothing, "")

        Dim pTableCollection As ITableCollection
        pTableCollection = pMap 'QI

        pTableCollection.AddTable(pTable)
        pMxDoc.UpdateContents()
    End Sub

    Protected Overrides Sub OnClick()
        Call Practice1()
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
