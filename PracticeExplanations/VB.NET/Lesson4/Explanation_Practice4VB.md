# Explanation: #

Again, the code in this procedure that obtains pointers to the necessary layers should look familiar by now. From there, selecting roads in New York requires obtaining that state's geometry. There are multiple ways to approach this part of the problem; the approach used in this solution is as follows:

- Set up a QueryFilter that identifies New York (and only New York).
- Get the States FeatureClass.
- Use the QueryFilter to create a FeatureCursor. (There should be only one Feature in it.)
- Get the New York Feature.
- Get its Geometry.

With the Geometry in hand, you're ready to set up a SpatialFilter to select roads that are within New York. The Geometry should be used to set the Geometry property of the SpatialFilter. The GeometryField property should be set to "SHAPE", the name of the field that stores the geometry. A number of SpatialRel constants will work (just as a number of choices in the Select By Location dialog box would work in performing the selection manually).

Keep in mind that setting up a SpatialFilter (or QueryFilter) is analogous to writing and saving a query. The next step is to decide whether to use that SpatialFilter to create a FeatureCursor (a collection of the individual matching Feature objects that you can work with) or to simply highlight the matching Features both on the map and in the attribute table. In this case, you're told to highlight the features, so the SpatialFilter should be used in a SelectFeatures statement. SelectFeatures is a method of the FeatureLayer class, but is accessed through IFeatureSelection, not IFeatureLayer. Therefore, a QI is necessary to call that method. After calling SelectFeatures, remember to refresh the map using IActiveView::Refresh.