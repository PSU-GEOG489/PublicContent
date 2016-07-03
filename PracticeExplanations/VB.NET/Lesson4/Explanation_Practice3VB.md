# Explanation: #

This exercise requires you to query a layer's attribute table as laid out in Part III. The first step is to obtain the correct layer, which should be familiar to you by now. The next step is to set up a QueryFilter with a WhereClause that identifies the desired features. If the goal of the procedure was to show graphically which cities meet the criterion, you would use the layer's SelectFeatures method accessed through its IFeatureSelection interface. However, the goal is actually to provide the user with a list of city names. This requires the use of a FeatureCursor.

The FeatureCursor is created by obtaining the layer's FeatureClass and calling its Search method. Much like an enumeration, you can loop through the FeatureCursor using a Do loop and the NextFeature method.

In order to get the name of each city in the FeatureCursor, you need to read the Value property of the Feature, specifying the position of the CITY_NAME field in the attribute table. (IFeature inherits the Value property from IRow.) FindField is used to get the position of that field.

The list of cities is created one city at a time using the loop. The line:

```
#!vbnet
	strList = strList & pFeature.Value(lngNameField) & vbCr
``` 

may seem confusing. An important point to remember about assignment statements like this is that they are really an instruction to the computer to evaluate the expression on the right side of the equals sign and store the result in the variable on the left side of the equals sign. In this case, the computer looks in the box called strList and pulls out its value (an empty string the first time through the loop). It then concatenates that value with the value stored in the CITY_NAME field for the current Feature. The result of that concatenation is then concatenated with a carriage return and the whole string is stored in that same box strList (wiping out what had been stored there before).

After the loop terminates the list is complete and can be displayed to the user in a MsgBox.