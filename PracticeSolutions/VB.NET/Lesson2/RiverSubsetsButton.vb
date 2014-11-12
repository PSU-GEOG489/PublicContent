Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class RiverSubsetsButton
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub River_Subsets()

        '****** Author:  Jim Detwiler, edited by Frank Hardisty
        '******** Date:  6/Nov/2009
        '* Description:  Searches the active data frame for a layer called
        '*               "U.S. Rivers" or "us_hydro".  When found, creates a new
        '*               collection of river names to pass to another sub
        '*               that creates a new shapefile for each individual
        '*               river.
        '**** Calls to:  Util_Extract
        '**** Calls by:
        '***** Globals:
        '****** Locals:  pMxDoc, pMap, pLayers, pLayer, colRivers,
        '******          strQueryField, i
        '**** Location:
        '****** Source:
        '******* Notes:
        '****************************************
        '* Revision Author:  Andrew Murdoch
        '*** Revision Date:  5/28/2011
        '** Revision Notes:  Updated for ArcGIS 10 and VB.NET

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document '* Getting the mxd

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap '* Getting the focus map from the mxd

        Dim pLayers As IEnumLayer
        pLayers = pMap.Layers '* Getting an enumeration of layers from the map

        Dim pLayer As ILayer
        pLayer = pLayers.Next '* Moving the pointer to the first layer

        Do Until pLayer Is Nothing '* Looping thru all layers
            If pLayer.Name = "U.S. Rivers" Or pLayer.Name = "us_hydro" Then
                Exit Do '* Found the layer we want
            End If
            pLayer = pLayers.Next '* If not correct layer, go to next layer
        Loop

        If pLayer Is Nothing Then
            '* Couldn't find the layer.  Tell user, then quit.
            MsgBox("Sorry, can't find U.S. Rivers layer", vbOKOnly)
            Exit Sub
        End If

        Dim colRivers As Collection
        colRivers = New Collection '* Creating a new rivers collection

        '* Adding items to the collection
        colRivers.Add("Colorado River")
        colRivers.Add("Columbia River")
        colRivers.Add("Mississippi River")
        colRivers.Add("Rio Grande")

        Dim strQueryField As String
        strQueryField = "NAMEEN" '* This is the field to query on

        Dim i As Integer
        For i = 1 To colRivers.Count '* For each item in the collection
            '* Make call to Util_Extract sub passing the layer, current item in
            '* collection, and the query field
            Call Utilities.Util_Extract(pLayer, colRivers.Item(i), strQueryField)
        Next i

        MsgBox("Finished creating river subsets.", vbOKOnly, "Done")
    End Sub

    


    Protected Overrides Sub OnClick()

        Call River_Subsets()

    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
