Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class Practice4
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()

    End Sub

    Protected Overrides Sub OnUpdate()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Enabled = False

        If pMap.LayerCount > 0 Then
            Dim pLayers As IEnumLayer
            pLayers = pMap.Layers

            Dim pLayer As ILayer
            pLayer = pLayers.Next

            Do Until pLayer Is Nothing
                If TypeOf pLayer Is IFeatureLayer Then
                    Enabled = True
                    Exit Do
                End If

                pLayer = pLayers.Next
            Loop
        End If
    End Sub

End Class
