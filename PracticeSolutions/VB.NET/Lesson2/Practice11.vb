Imports ESRI.ArcGIS.ArcMapUI

Public Class Practice11
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public Sub Practice11()
        Dim pPrinterNames As IEnumPrinterNames
        pPrinterNames = My.ArcMap.Application

        Dim strName As String
        strName = pPrinterNames.Next

        Do Until strName = ""
            MsgBox(strName)
            strName = pPrinterNames.Next
        Loop

    End Sub

    Protected Overrides Sub OnClick()
        Call Practice11()
    End Sub

    Protected Overrides Sub OnUpdate()

    End Sub
End Class
