Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class SelectFeatures
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub SelectFeatures()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pFLayer As IFeatureLayer
        pFLayer = pMap.Layer(0)   '** Assuming STATES is the first layer

        Dim pQueryFilter As IQueryFilter
        pQueryFilter = New QueryFilter

        Dim strState As String
        strState = "Alaska"
        pQueryFilter.WhereClause = "NAME = '" & strState & "'"

        Dim pFSel As IFeatureSelection
        pFSel = pFLayer   '** QI
        pFSel.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, False)

        Dim pActiveView As IActiveView
        pActiveView = pMxDoc.FocusMap
        pActiveView.Refresh()

    End Sub

    Protected Overrides Sub OnClick()
        Call SelectFeatures()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
