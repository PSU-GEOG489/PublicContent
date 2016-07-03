# Explanation: #

This exercise brings together three different concepts covered in the lesson: If-Then blocks, Do loops, and making a call to another procedure.

In order to use the provided SetColor procedure, you first must have a pointer to a layer. I also stipulated that you cannot assume the position of the layers in the data frame. This requires you to obtain the map's Layers enumeration and loop through it one Layer at a time looking for the desired layer by name. The loop is set up to continue until pLayer becomes Nothing (when the enum's internal pointer moves beyond the last layer).

Inside the loop an If-Then block is used to check the layer name and make a call to SetColor passing in the name of the desired color. Note the syntax of the call to SetColor. The pointer toILayer is specified as the first parameter and a string representing the name of a color is specified as the second parameter.

An alternate way of coding this loop:

```
#!vbnet
	Dim strColor As String

	Do Until pLayer Is Nothing
		If pLayer.Name = "us_cities" Then
			strColor = "red"
		ElseIf pLayer.Name = "us_roads" Then
			strColor = "green"
		ElseIf pLayer.Name = "us_boundaries" Then
			strColor = "blue"
		Else
			strColor = "no change"
		End If

		If strColor <> "no change" Then
			Call SetColor(pLayer, strColor)
		End If

		pLayer = pLayers.Next

	Loop
``` 

In this version, a String variable is declared to hold the name of the color. The original If-Then block is altered so that the String variable is set to the appropriate value instead of calling SetColor (which now comes later). Another difference is that a catch-all Else clause is added to allow for layers other than the three we're looking for. A new If-Then block is used to make sure the current layer is not a layer whose color shouldn't be changed before calling SetColor. The call to SetColor uses the new String variable instead of one of the literal values as done in the original version.