Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.CartoUI
Imports ESRI.ArcGIS.Display

Public Class Render
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Render_Layers()
        Dim pMxDoc As IMxDocument
        pMxDoc = My.ArcMap.Application.Document
        Dim pMap As IMap
        pMap = pMxDoc.FocusMap
        Dim strChoice As String
        '** Giving the user a choice of 3 predefined maps
        strChoice = InputBox("1 - U.S. States, " & vbCrLf & _
            "2 - Major Cities, " & vbCrLf & _
            "3 - State Polygon Area Rank" _
            , "Please choose a map.")
        If strChoice = "" Then
            Exit Sub
        End If
        Dim pWFactory As IWorkspaceFactory
        pWFactory = New ShapefileWorkspaceFactory
        Dim pWorkspace As IWorkspace
        pWorkspace = pWFactory.OpenFromFile("C:\GEOG489\Lesson1-2", 0)
        Dim pFeatureWorkspace As IFeatureWorkspace
        pFeatureWorkspace = pWorkspace
        Dim pFLayer As IFeatureLayer
        pFLayer = New FeatureLayer
        Dim pGeoFLayer As IGeoFeatureLayer
        pGeoFLayer = pFLayer
        Dim pFClass As IFeatureClass
        Dim pTable As ITable
        Dim pClasses As IClassify
        Dim pTableHist As ITableHistogram
        Dim pHist As IHistogram
        Dim pCBR As IClassBreaksRenderer
        Dim pUIProperties As IClassBreaksUIProperties
        Dim pLegendInfo As ILegendInfo
        Dim Frequencies As Object
        Dim Values As Object
        If strChoice = "1" Then
            '** User gets a Unique Value rendering of U.S. States by sub-region
            pFClass = pFeatureWorkspace.OpenFeatureClass("us_boundaries.shp")
            pFLayer.FeatureClass = pFClass
            pFLayer.Name = "U.S. States"
            pMap.AddLayer(pFLayer)
            Dim pUVRender As IUniqueValueRenderer
            pUVRender = New UniqueValueRenderer
            '** Setting default symbol for features that don't have a value in
            '** the classification field
            Dim pSymDefault As ISimpleFillSymbol
            pSymDefault = New SimpleFillSymbol
            pSymDefault.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSSolid
            pSymDefault.Outline.Width = 0.4
            '** These properties should be set prior to adding values
            pUVRender.FieldCount = 1    '** Can classify based on up to 3 fields
            pUVRender.Field(0) = "NAME"   '** Name of the 1st (only) field
            pUVRender.DefaultSymbol = pSymDefault
            pUVRender.UseDefaultSymbol = True
            Dim pQFilter As IQueryFilter
            pQFilter = New QueryFilter '** empty QueryFilter same as selecting all recs
            Dim pFCursor As IFeatureCursor
            pFCursor = pFClass.Search(pQFilter, False) '** getting all features
            '** Make the color ramp we will use for the symbols in the renderer.
            '** Colors should be random for Unique Value, as opposed to light-to-dark.
            '** Make settings for hue, saturation, value, and seed to have random
            '** colors generated within certain limits.
            Dim pRamp As IRandomColorRamp
            pRamp = New RandomColorRamp
            pRamp.MinSaturation = 25
            pRamp.MaxSaturation = 45
            pRamp.MinValue = 85
            pRamp.MaxValue = 100
            pRamp.StartHue = 205
            pRamp.EndHue = 320
            pRamp.UseSeed = True
            pRamp.Seed = 25
            Dim pFeature As IFeature
            Dim n As Integer
            Dim i As Integer
            n = pFClass.FeatureCount(pQFilter) '** Getting total count of state features
            '** Loop through the features
            Do Until i = n
                Dim pSymX As ISimpleFillSymbol
                pSymX = New SimpleFillSymbol
                '** Move to the next feature and assign the value in the Sub_region field to a var
                pFeature = pFCursor.NextFeature
                Dim strVal As String
                strVal = pFeature.Value(2) '** NAME Field is at this index in fields collection
                '** Test to see if we've already added this value
                '** to the renderer, if not, then add it.
                Dim blnAdded As Boolean
                blnAdded = False
                Dim x As Integer
                For x = 0 To (pUVRender.ValueCount - 1) '** First time through, ValueCount = 0
                    If pUVRender.Value(x) = strVal Then
                        blnAdded = True
                        Exit For
                    End If
                Next x
                If blnAdded = False Then    '** Value not yet encountered, must add it
                    pUVRender.AddValue(strVal, "Predominant Term", pSymDefault)
                    pUVRender.Label(strVal) = strVal
                    pUVRender.Symbol(strVal) = pSymX '** All values get same symbol at first,
                    '** colors assigned later
                End If
                i = i + 1
            Loop
            '** Can size the color ramp and assign the colors, now that the
            '** number of unique values is known.
            pRamp.Size = pUVRender.ValueCount
            pRamp.CreateRamp(True)
            '** Create an enum of colors from the color ramp and initialize it
            Dim pColors As IEnumColors
            pColors = pRamp.Colors
            pColors.Reset()
            Dim y As Long
            '** Loop through each unique value, setting its symbol's color
            For y = 0 To (pUVRender.ValueCount - 1)
                Dim strRendVal As String
                strRendVal = pUVRender.Value(y)
                If strRendVal <> "" Then
                    Dim pSym As ISimpleFillSymbol
                    pSym = pUVRender.Symbol(strRendVal)
                    pSym.Color = pColors.Next
                    pUVRender.Symbol(strRendVal) = pSym
                End If
            Next y
            '** If you didn't use a color ramp that was predefined
            '** in a style, use "Custom" here, otherwise
            '** use the name of the color ramp you chose.
            pUVRender.ColorScheme = "Custom"
            pUVRender.FieldType(0) = True   '** Set to True since Sub_region is a string
            pGeoFLayer.Renderer = pUVRender
            '** Make sure the symbology tab shows the correct info.
            Dim pRendPropPage As IRendererPropertyPage
            pRendPropPage = New UniqueValuePropertyPage
            pGeoFLayer.RendererPropertyPageClassID = pRendPropPage.ClassID
        ElseIf strChoice = "2" Then
            '** User gets a graduated symbol map of U.S. Cities
            pFClass = pFeatureWorkspace.OpenFeatureClass("us_cities.shp")
            pFLayer.FeatureClass = pFClass
            pFLayer.Name = "Major U.S. Cities"
            pGeoFLayer = pFLayer
            pMap.AddLayer(pFLayer)
            '** Switching to the ITable interface; FeatureClass is a type of Table
            pTable = pFClass
            '** Creating a new quantile classification
            pClasses = New Quantile
            '** Must create a TableHistogram to generate classes
            '** Need both ITableHistogram and IHistogram interfaces
            pTableHist = New TableHistogram
            pHist = pTableHist
            '** Set the table and field for the histogram, then use GetHistogram to
            '** get arrays of values and corresponding frequencies
            pTableHist.Field = "POPCLASS"
            pTableHist.Table = pTable
            pHist.GetHistogram(Values, Frequencies)
            '** Assign the arrays of values and frequencies to the quantile classification
            '** then break the data into 5 classes
            pClasses.SetHistogramData(Values, Frequencies)
            pClasses.Classify(4)
            '** Ready to render the data
            pCBR = New ClassBreaksRenderer
            pCBR.BreakCount = 4
            pCBR.Field = "POPCLASS"
            pCBR.MinimumBreak = pClasses.ClassBreaks(0) '** ClassBreak(0) is min value of 1st class
            Dim j As Long
            '** Loop thru each class, setting the renderers breaks
            '** The renderer's breaks are 0-based, quantile's breaks are 1-based
            For j = 0 To (pCBR.BreakCount - 1)
                pCBR.Break(j) = pClasses.ClassBreaks(j + 1)
                pCBR.Label(j) = pClasses.ClassBreaks(j) & " - " & pClasses.ClassBreaks(j + 1)
            Next j
            '** Ready for symbols
            Dim pCitySym As ISimpleMarkerSymbol
            '** Setting the smallest symbol size
            Dim dblFromSize As Double
            dblFromSize = 4
            '** Setting the largest symbol size
            Dim dblToSize As Double
            dblToSize = 16
            '** Calculating the change in size between classes based on the min size,
            '** max size, and # of classes
            Dim dblStep As Double
            dblStep = (dblToSize - dblFromSize) / (pCBR.BreakCount - 1)
            '** Setting the foreground color of the symbols
            Dim pColor As IRgbColor
            pColor = New RgbColor
            With pColor
                .Red = 179
                .Green = 235
                .Blue = 255
            End With
            '** Setting the outline color of the symbols
            '** No color settings means black outline (r=0, g=0, b=0)
            Dim pOlColor As IRgbColor
            pOlColor = New RgbColor
            Dim k As Integer
            '** Setting symbol for each class
            For k = 0 To pCBR.BreakCount - 1
                pCitySym = New SimpleMarkerSymbol
                pCitySym.Color = pColor
                pCitySym.Outline = True
                pCitySym.OutlineColor = pOlColor
                pCitySym.OutlineSize = 1
                pCitySym.Size = dblFromSize + (dblStep * CDbl(k))
                pCBR.Symbol(k) = pCitySym
            Next k
            '** Assigning the ClassBreaksRenderer to the layer
            pGeoFLayer.Renderer = pCBR
            pUIProperties = pCBR
            pUIProperties.LowBreak(0) = pCBR.MinimumBreak
            Dim m As Long
            For m = 1 To pCBR.BreakCount - 1
                pUIProperties.LowBreak(m) = pClasses.ClassBreaks(m)
            Next m
            '** Creating a heading for the legend in the Table of Contents
            pLegendInfo = pCBR 'qi
            pLegendInfo.LegendGroup(0).Heading = "Population Class"
            pLegendInfo.SymbolsAreGraduated = False
        ElseIf strChoice = "3" Then
            '** User gets a graduated color map of state population normalized by area
            pFClass = pFeatureWorkspace.OpenFeatureClass("us_boundaries.shp")
            pFLayer.FeatureClass = pFClass
            pFLayer.Name = "State Polygon Area Rank"
            pGeoFLayer = pFLayer
            pMap.AddLayer(pFLayer)
            '** Very similar to previous example
            pTable = pFClass
            pClasses = New Quantile
            pTableHist = New TableHistogram
            pHist = pTableHist
            pTableHist.Field = "Shape_Area"
            pTableHist.Table = pTable
            'pTableHist.NormField = "Rank" '** Setting the normalization field before getting histogram
            pHist.GetHistogram(Values, Frequencies)
            pClasses.SetHistogramData(Values, Frequencies)
            pClasses.Classify(5)
            pCBR = New ClassBreaksRenderer
            '** Making normalization settings for the renderer
            'Dim pNorm As IDataNormalization
            'pNorm = pCBR
            'pNorm.NormalizationField = "Rank"
            'pNorm.NormalizationType = esriDataNormalization.esriNormalizeByField
            pCBR.BreakCount = 5
            pCBR.Field = "Shape_Area"
            pCBR.MinimumBreak = pClasses.ClassBreaks(0)
            Dim t As Long
            pUIProperties = pCBR
            pUIProperties.LowBreak(0) = pCBR.MinimumBreak
            For t = 0 To UBound(pClasses.ClassBreaks) - 1
                pCBR.Break(t) = pClasses.ClassBreaks(t + 1)
                '** Want to round the class break values in the class labels
                '** Use the NumericFormat class to set up a 1-decimal format
                Dim pNumericFormat As INumericFormat
                pNumericFormat = New NumericFormat
                pNumericFormat.RoundingOption = ESRI.ArcGIS.esriSystem.esriRoundingOptionEnum.esriRoundNumberOfDecimals
                pNumericFormat.RoundingValue = 1
                Dim pNumberFormat As INumberFormat
                pNumberFormat = pNumericFormat
                Dim strRndVal1 As String
                Dim strRndVal2 As String
                '** Using ValueToString method to convert the numbers into the desired format
                strRndVal1 = pNumberFormat.ValueToString(pClasses.ClassBreaks(t))
                strRndVal2 = pNumberFormat.ValueToString(pClasses.ClassBreaks(t + 1))
                pCBR.Label(t) = strRndVal1 & " - " & strRndVal2
            Next t
            pGeoFLayer.Renderer = pCBR
            For t = 1 To 4
                pUIProperties.LowBreak(t) = pClasses.ClassBreaks(t)
            Next t
            '** Ready to set colors
            '** Want to use AlgorithmicColorRamp to ramp from one color to another
            Dim pColorEnum As IEnumColors
            Dim pAColorRamp As IAlgorithmicColorRamp
            Dim pFromColor As IRgbColor
            Dim pToColor As IRgbColor
            '** Setting up the algorithmic color ramp
            pFromColor = New RgbColor
            pFromColor.RGB = RGB(242, 233, 250)     ' lavender
            pToColor = New RgbColor
            pToColor.RGB = RGB(56, 45, 121)       ' deep purple
            pAColorRamp = New AlgorithmicColorRamp
            With pAColorRamp
                .Algorithm = ESRI.ArcGIS.Display.esriColorRampAlgorithm.esriHSVAlgorithm
                .Size = 5                       '** # of classes
                .FromColor = pFromColor
                .ToColor = pToColor
                .CreateRamp(True)
                pColorEnum = .Colors
            End With
            pColorEnum.Reset()
            Dim s As Integer
            '** Loop thru the classes, creating a new symbol, assigning the next color
            '** created by the ramp, and assigning the symbol to the renderer.
            For s = 0 To 4
                Dim pSFSym As ISimpleFillSymbol
                pSFSym = New SimpleFillSymbol
                pSFSym.Color = pColorEnum.Next
                pCBR.Symbol(s) = pSFSym
            Next s
            '** Creating a heading for the legend in the Table of Contents
            pLegendInfo = pCBR 'qi
            pLegendInfo.LegendGroup(0).Heading = "Area (Degrees)"
            pLegendInfo.SymbolsAreGraduated = False
        End If
        '** Refreshing the Table of Contents
        pMxDoc.ActiveView.ContentsChanged()
        pMxDoc.UpdateContents()
        '** Re-drawing the map
        pMxDoc.ActiveView.Refresh()
    End Sub

    Protected Overrides Sub OnClick()      
        Call Render_Layers()
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
