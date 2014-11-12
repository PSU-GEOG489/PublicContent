Public Class ReportTemperature
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Report_Temp()

        Dim dblInput As Double
        Dim dblOutput As Double

        Dim strChoice As String

        Do
            strChoice = InputBox("1 = Fahrenheit to Celsius" & vbCr & _
                "2 = Celsius to Fahrenheit" & vbCr & _
                "Any other key to quit", "Temp Converter")

            If strChoice = "1" Then
                dblInput = InputBox("What's the temp in Fahrenheit?", "Temp in F?")
                dblOutput = Temp_Convert(dblInput, "F")
            ElseIf strChoice = "2" Then
                dblInput = InputBox("What's the temp in Celsius?", "Temp in C?")
                dblOutput = Temp_Convert(dblInput, "C")
            Else
                Exit Sub
            End If

            MsgBox("The converted temp is " & dblOutput, vbOKOnly, "Converted Temp")
        Loop

    End Sub

    Public Function Temp_Convert(ByVal dblInTemp As Double, ByVal strInScale As String) As Double

        If strInScale = "F" Then
            Temp_Convert = (dblInTemp - 32) * 5 / 9
        ElseIf strInScale = "C" Then
            Temp_Convert = (dblInTemp * 9 / 5) + 32
        Else
            MsgBox("Input temp must be in F or C", vbCritical)
            Temp_Convert = -9999
        End If

    End Function

  Protected Overrides Sub OnClick()
        Call Report_Temp()
  End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
