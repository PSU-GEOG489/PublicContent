Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.GeoDatabaseUI

Module Utilities

    Public Sub Util_Extract(ByVal pInFLayer As IFeatureLayer, ByVal strValue As String, ByVal strField As String)

        '****** Author:  Jim Detwiler
        '******** Date:  11/17/2001
        '* Description:  Sub procedure that accepts a feature layer, attribute
        '*               value, and field name as parameters.  Using these
        '*               parameters, it will select out all features having
        '*               the attribute value in the specified field, the
        '*               write them to a new shapefile.
        '**** Calls to:
        '**** Calls by:  Rivers_Subset
        '***** Globals:
        '****** Locals:  pInFLayer, strValue, strField, pInFClass, pInDataset,
        '******          pFeatureWorkspace, pInFClassName, strShpName, pFields,
        '******          lngGeomIndex, pField, pGeomDef, pQFilter,
        '******          pWorkspaceFactory, pOutWorkspaceName, pOutFClassName,
        '******          pOutDatasetName, pSelSet, pExportOp
        '**** Location:
        '****** Source:
        '******* Notes:
        '****************************************
        '* Revision Author:  Andrew Murdoch
        '** Revision Date:  5/28/2011
        '** Revision Notes:  Updated for ArcGIS 10 and VB.NET

        ' Getting the input feature class info
        Dim pInFClass As IFeatureClass
        pInFClass = pInFLayer.FeatureClass

        Dim pInDataset As IDataset
        pInDataset = pInFLayer ' QI to get workspace

        Dim pFeatureWorkspace As IFeatureWorkspace
        pFeatureWorkspace = pInDataset.Workspace

        Dim pInFClassName As IFeatureClassName
        pInFClassName = pInDataset.FullName

        'Get geometry definition from input featureclass.
        Dim strShpName As String
        strShpName = pInFClass.ShapeFieldName
        Dim pFields As IFields
        pFields = pInFClass.Fields
        Dim lngGeomIndex As Long
        lngGeomIndex = pFields.FindField(strShpName)
        Dim pField As IField
        pField = pFields.Field(lngGeomIndex)
        Dim pGeomDef As IGeometryDef
        pGeomDef = pField.GeometryDef

        ' Setting up the query filter based on the supplied field and value
        Dim pQFilter As IQueryFilter
        pQFilter = New QueryFilter
        pQFilter.WhereClause = strField & " = '" & strValue & "'"

        Dim pWorkspaceFactory As IWorkspaceFactory
        pWorkspaceFactory = New ShapefileWorkspaceFactory

        'Set up outworkspacename for new shape file.
        Dim pOutWorkspaceName As IWorkspaceName
        pOutWorkspaceName = New WorkspaceName
        pOutWorkspaceName.WorkspaceFactoryProgID = "esricore.shapefileworkspacefactory.1"
        pOutWorkspaceName.PathName = "c:\temp"   'path to where I want the shapefile.
        Dim pOutFClassName As IFeatureClassName
        pOutFClassName = New FeatureClassName
        Dim pOutDatasetName As IDatasetName
        pOutDatasetName = pOutFClassName
        pOutDatasetName.Name = strValue 'Output shapefile name.
        pOutDatasetName.WorkspaceName = pOutWorkspaceName

        ' Performing the selection
        Dim pSelSet As ISelectionSet
        pSelSet = pInFClass.Select(pQFilter, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, pFeatureWorkspace)

        ' Exporting the selection
        Dim pExportOp As IExportOperation
        pExportOp = New ExportOperation
        pExportOp.ExportFeatureClass(pInFClassName, pQFilter, pSelSet, pGeomDef, pOutDatasetName, 0)

    End Sub

End Module