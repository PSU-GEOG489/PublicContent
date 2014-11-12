Public Class Practice10
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Public Sub Practice10()

        Dim intScore As Integer
        intScore = InputBox("Please enter the student's score out of 100")

        Dim strGrade As String

        If intScore > 89 Then
            strGrade = "A"
        ElseIf intScore > 79 Then
            strGrade = "B"
        ElseIf intScore > 69 Then
            strGrade = "C"
        ElseIf intScore > 59 Then
            strGrade = "D"
        Else
            strGrade = "F"
        End If

        MsgBox("The student's letter grade is " & strGrade)

    End Sub

  Protected Overrides Sub OnClick()
        Call Practice10()
  End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
