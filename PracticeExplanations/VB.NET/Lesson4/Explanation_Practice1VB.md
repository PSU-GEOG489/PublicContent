# Explanation: #

Because you're asked to create a dbf (dBase) table, you must use a ShapefileWorkspaceFactory (as opposed to an AccessWorkspaceFactory or an ArcInfoWorkspaceFactory, see Part I). Calling the WorkspaceFactory's  OpenFromFile method and providing a folder path returns a Workspace object (an object that implements IWorkspace).

Note that the Help says that OpenFromFile returns an "object that implements IWorkspace" (a Workspace object). The desired interface here is IFeatureWorkspace, since it provides access to the CreateTable method. One way to write the code would be to store the Workspace object in a pointer to IWorkspace, then QI to IFeatureWorkspace:
 
```
#!vbnet
	Dim pWorkspace As IWorkspace
	pWorkspace = pWFactory.OpenFromFile("c:/temp", My.ArcMap.Application.hWnd)

	Dim pFWorkspace As IFeatureWorkspace
	pFWorkspace = pWorkspace 'QI
``` 

However, in cases like this you can choose to store the return object in a pointer to any of the interfaces that it supports. This eliminates the need for the separate QI statement.

As mentioned above, IFeatureWorkspace provides access to the CreateTable method. However, before calling that method, you first need to create its collection of fields. The first step in creating this collection is to create a number of Field objects and use their IFieldEdit interface to set their properties. Once all of the desired Field objects are set up, a new Fields object is created. The individual Field objects are added to the Fields object using the AddField method accessed through IFieldsEdit. Note the use of With/End With blocks in setting the field properties.  Note the use of the “_2” suffix for properties that can write values as opposed to the other read-only properties.

In calling CreateTable, the two important arguments to specify are the first two, the name of the table and its collection of fields. The last three arguments are optional and can be ignored using the Nothing keyword for the first two (because they're object arguments) and "" for the third (because it's a string argument). The return object is stored in a pointer to ITable.

Finally, in order to add the table to the active Map, its ITableCollection interface must be used. At the beginning of the procedure a pointer to the Map was obtained (stored in a pointer to IMap). So a QI is used to set up a pointer to ITableCollection. The AddTable method is then called and the Table of Contents is updated.

