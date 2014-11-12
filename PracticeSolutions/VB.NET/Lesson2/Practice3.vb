Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class Practice3
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice3()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim strName As String
        Dim lngNumLayers As Long

        strName = pMap.Name
        lngNumLayers = pMap.LayerCount

        MsgBox("The name of the active data frame is " & strName & vbCr & _
            "It has " & lngNumLayers & " layers")

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice3()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
