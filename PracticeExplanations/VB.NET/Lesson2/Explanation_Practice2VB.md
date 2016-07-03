# Explanation: #

This exercise requires you to set the map document's author. The object that represents the map document is MxDocument. Anytime you need to write code that deals with an object in ArcMap, you must start with one of the two preset global variables, My.ArcMap.Application or My.ArcMap.Application.Document. You should have memorized the fact that My.ArcMap.Application.Document points to the MxDocument through the IDocumentinterface.

So your first step should be to see if the IDocument interface has a property or method that deals with the map document's author. After not finding anything appropriate under IDocument, you should check the other interfaces on MxDocument. This can be done either by looking at the ArcMap OMD or by going to the MxDocument page in the Developer Help and checking the list of properties and methods on each of the interface pages (you can start with the interfaces whose names sound promising). It turns out that the IDocumentInfo interface has an Author property that is read-write.

After finding out that IDocumentInfo has the property you need, you should declare a variable that points to that interface. In the program above, this is accomplished with the Dim line. Remember that the second word of the statement is a name that is up to you the developer. It could be pDocInfo, pDI, x, whatever. Using the box analogy from Lesson 1, this line is creating a new empty box called pDocumentInfo that's allowed to store any object that implements the IDocumentInfo interface (another way of saying any object that has IDocumentInfo as one of its interfaces).

If the Dim statement created a new empty box, you need another statement that puts an object in that box. In other words, you need to get the variable to point to the object whose Author property you want to change. This takes us back to the My.ArcMap.Application.Document variable. It points to the currently opened MxDocument. This is a case where you want to perform a Query Interface (QI) operation so that you can use another one of the MxDocument's interfaces. By entering the line:
 
```
#!vbnet
	pDocumentInfo = My.ArcMap.Application.Document  
``` 

you're telling the computer you want the pDocumentInfo variable to point to the same object that My.ArcMap.Application.Document  points to.

At this point, you can use the pDocumentInfo variable to set properties that are accessed through the IDocumentInfo interface or the My.ArcMap.Application.Document  interface to set properties that are accessed through the IDocument. To set the Author property, use the basic object.property = newvalue syntax.
