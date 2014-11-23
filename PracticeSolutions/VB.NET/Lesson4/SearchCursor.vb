Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class SearchCursor
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub SearchCursor()

        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document

        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pFLayer As IFeatureLayer
        pFLayer = pMap.Layer(0)  '** Assuming that us_hydro is the first layer

        Dim pFClass As IFeatureClass
        pFClass = pFLayer.FeatureClass

        Dim pQueryFilter As IQueryFilter    '** Creating a new QueryFilter
        pQueryFilter = New QueryFilter

        Dim strBasin As String
        strBasin = "Mississippi River"

        '** Defining the WhereClause
        pQueryFilter.WhereClause = "NAMEEN = '" & strBasin & "'"

        Dim pFCursor As IFeatureCursor
        pFCursor = pFClass.Search(pQueryFilter, True)

        Dim pFeature As IFeature
        pFeature = pFCursor.NextFeature   '** Getting the first Feature

        Dim i As Integer      '** will use to count number of line segments in the cursor
        Dim lngTotalLength As Long   '** will use to sum the state pops in the cursor
        i = 0
        lngTotalLength = 0

        '** Getting the index pos of the Shape_Leng field
        Dim lngLengthIndex As Long
        lngLengthIndex = pFClass.Fields.FindField("Shape_Leng")

        Do Until pFeature Is Nothing
            i = i + 1               '** Incrementing the line segment counter by 1
            '** Getting the river length and adding to total
            lngTotalLength = lngTotalLength + pFeature.Value(lngLengthIndex)
            pFeature = pFCursor.NextFeature
        Loop

        MsgBox("There are " & i & " line segments in the " & strBasin & " river." & vbCr & _
            "The total length of the river is " & lngTotalLength & " meters." & vbCr & _
            "and the average length per segment is " & lngTotalLength / i & " meters.")

    End Sub

    Protected Overrides Sub OnClick()
        Call SearchCursor()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
