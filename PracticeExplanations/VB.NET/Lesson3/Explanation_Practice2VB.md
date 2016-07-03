# Explanation: #

This exercise follows on the example in Part II-B. Regardless of the type of data you want to add (shapefile, geodatabase, coverage, etc.), you will follow the same basic steps:

- Create a new WorkspaceFactory. This is where you specify the kind of data you want to bring in.
- Use the WorkspaceFactory to open the appropriate Workspace. The Workspace is nothing more than the path to your data.
- Use the Workspace to open the desired FeatureClass.
- Associate the FeatureClass with a new FeatureLayer and set any other appropriate properties.  (see comment in code above)
- Add the new layer.

Note:  The ESRI.ArcGIS.Display assembly is required as a reference for this code. Reason: interfaces that are implemented by FeatureLayerClass use the Display assembly. Look at the FeatureLayerClass coclass help page, look at the interface list on the table; if an interface needs a different assembly, the name assembly is shown in parentheses next to the interface name. You will find Geodatabase and Display assemblies needed to be referenced in order to use this class.

In this case we want to open shapefiles, so we create a new ShapefileWorkspaceFactory object.   (This requires a reference to the ESRI.ArcGIS.DataSourcesFile assembly).  We then use its OpenFromFile method to connect to the folder (Workspace) that stores the shapefiles.  Because we know that the folder stores shapefiles, we know that we can use a QI statement to work with the FeatureWorkspace interface. This interface enables us to obtain the desired FeatureClass objects using OpenFeatureClass.

Because we're adding two new layers, it makes sense to declare two separate FeatureLayer objects. The two critical properties to set for FeatureLayers are the FeatureClass and Name.

After adding the layers to the map using AddLayer, the Refresh method is called to update the map display and UpdateContents is called to show new entries for the layers in the Table of Contents.

Note that it's not technically necessary to use two sets of variables for each of the shapefiles. It is possible to re-use a single set, though the key is to set the IFeatureLayer pointer equal to a New FeatureLayer after adding the first layer:

```
#!vbnet
	Dim pFClass As IFeatureClass
	pFClass = pFWorkspace.OpenFeatureClass("us_boundaries")

	Dim pFLayer As IFeatureLayer
	pFLayer = New FeatureLayer
	pFLayer.FeatureClass = pFClass
	pFLayer.Name = "U.S. States"

	pMap.AddLayer(pFLayer)

	pFClass = pFWorkspace.OpenFeatureClass("us_cities")

	pFLayer = New FeatureLayer
	pFLayer.FeatureClass = pFClass
	pFLayer.Name = "U.S. Cities"

	pMap.AddLayer(pFLayer)
```		


