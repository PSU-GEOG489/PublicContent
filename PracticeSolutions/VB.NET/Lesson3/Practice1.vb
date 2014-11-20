Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto

Public Class Practice1
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice1()

        Dim strUserInput As String
        strUserInput = InputBox("Enter the data frame to activate")

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMaps As IMaps
        pMaps = pMxDoc.Maps

        Dim pMap As IMap
        Dim i As Integer

        For i = 0 To pMaps.Count - 1
            pMap = pMaps.Item(i)
            If pMap.Name = strUserInput Then
                pMxDoc.ActiveView = pMap
                Exit For
            End If
        Next i

        pMxDoc.UpdateContents()

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice1()

    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
