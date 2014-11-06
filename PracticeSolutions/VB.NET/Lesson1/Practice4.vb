Imports ESRI.ArcGIS.ArcMapUI

Public Class Practice4
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice4()
        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document
        Dim lngSearchTol As Long
        lngSearchTol = pMxDoc.SearchTolerancePixels

        MsgBox(lngSearchTol)
    End Sub

    Protected Overrides Sub OnClick()
        Call Practice4()

    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
