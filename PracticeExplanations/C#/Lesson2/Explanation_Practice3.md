# Explanation: #

The first steps in this procedure are to get a pointer to the active data frame (Map). One part of ArcObjects you may want to just memorize is that the FocusMap property is used to obtain the active data frame. FocusMap is accessed through the IMxDocument interface, which is in turn an interface on the MxDocument object. Remembering that ArcMap.Application.Document references the MxDocument through the IDocument interface, this is another situation that calls for a QI operation.

You begin by declaring a variable that points to the desired IMxDocument interface. You then set that variable equal to the ArcMap.Application.Document variable so that it too points to the current MxDocument. You'll now be able to access the FocusMap property through the pMxDoc variable.

Before reading the FocusMap property, you'll need to declare a variable to store the return object (the object that represents the active data frame). To figure out what type of variable you need to declare, go to the OMD or Developer Help. On the OMD, this information is listed next to the property name after the colon. In the Developer Help, it's listed under the Syntax section next to variable. Both resources tell you to declare a pointer to IMap.

After declaring a pointer to IMap, the next step is to read the FocusMap property and store a reference to the returned Map object in the new pointer.

Now that you have a pointer to the active data frame through its IMap interface, you're ready to get its name and number of layers. Scanning through the OMD or Developer Help, you should find that this information can be obtained through the Name and LayerCount properties, respectively. The return values of these properties should be stored in the strName and LayerCount variables.

The MessageBox statement uses concatenation, the line continuation character, and a carriage return constant. Refer back to the instructions for explanation of this statement.