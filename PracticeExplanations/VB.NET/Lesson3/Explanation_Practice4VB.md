# Explanation: #

An OnUpdate procedure is a procedure that is called by ArcMap's underlying code when a change is made in the state of the application.  Your job in this exercise is to enable the button only if a FeatureLayer is present in the active data frame.  For this exercise, you will have to replace the existing OnUpdate procedure for the Add-In Button you are working with.

After writing the now familiar code for getting the MxDocument and Map, you need to loop through the layers, checking to see if any of the layers is a FeatureLayer. Before beginning the loop, a smart approach is to set the Enabled value to False. If you later manage to find a FeatureLayer, you can then set the Enabled value to True.

Also before beginning the loop, you should first be sure that you're not dealing with an empty data frame. This is done by using an If expression that checks whether the Map's LayerCount property is greater than zero.

Within the If block is the code that gets the Layers enumeration and loops through it one layer at a time. Checking to see if the layer is a FeatureLayer involves a TypeOf expression. An interface that is unique to the FeatureLayer class is IFeatureLayer. Therefore, the expression

```
#!vbnet
	TypeOf pLayer Is IFeatureLayer
```

is a good way to test for a FeatureLayer. Remember what this expression translates to in plain English: Does the layer referenced by pLayer have IFeatureLayer as one of its interfaces? If yes, the return value is set to True and the loop terminates. Notice that there is no need for an Else clause that sets the return value to False because it was set to False prior to beginning the loop.
