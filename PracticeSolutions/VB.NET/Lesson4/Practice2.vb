Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class Practice2
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice2()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pTableCollection As ITableCollection
        pTableCollection = pMap  '** QI

        Dim i As Integer
        Dim pTable As ITable = Nothing
        Dim pDataset As IDataset    '** IDataset needed for Name property

        Dim blnFoundTable As Boolean
        blnFoundTable = False

        For i = 0 To pTableCollection.TableCount - 1
            pTable = pTableCollection.Table(i)
            pDataset = pTable      '** QI

            If pDataset.Name = "lu_codes" Then
                blnFoundTable = True
                Exit For
            End If
        Next i

        If blnFoundTable = False Then
            MsgBox("Table not loaded in data frame")
            Exit Sub
        End If

        Dim lngCodeField As Long
        Dim lngDescField As Long

        lngCodeField = pTable.FindField("LU_Code")
        lngDescField = pTable.FindField("LU_Desc")

        Dim pRow As IRow
        pRow = pTable.CreateRow
        pRow.Value(lngCodeField) = "RES"
        pRow.Value(lngDescField) = "Residential"
        pRow.Store()

        pRow = pTable.CreateRow
        pRow.Value(lngCodeField) = "COM"
        pRow.Value(lngDescField) = "Commercial"
        pRow.Store()

        pRow = pTable.CreateRow
        pRow.Value(lngCodeField) = "IND"
        pRow.Value(lngDescField) = "Industrial"
        pRow.Store()

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice2()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
