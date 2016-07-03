# Explanation: #

This exercise is meant to give you practice looping through an enumeration. The list of printers is accessed through the Application object's IEnumPrinterNames interface. Since the preset variable ArcMap.Application provides a pointer to the Application object (but through the wrong interface), this is a situation that requires a QI statement. You start by declaring a pointer to the desired interface, then set that pointer equal to the Application variable. Again, this tells the computer that you want your new variable to point to the same object that the preset variable does. In my solution, this new variable is called pPrinterNames.

If pPrinterNames gives me access to the collection of available printers names, I need another variable to store individual names. That's where the strName variable comes in. One thing you may find confusing about this procedure is the use of the line:

```
#!c#
	strName = pPrinterNames.Next()
```
	
both before the loop and within it. The reason the code is set up this way has to do with the condition you need to test for to see if it's time to stop looping. To understand how an enumeration works, it helps to think of it as a list of values or objects with an arrow pointing at one of the items in that list. When you first get an enumeration, the arrow is pointing just above the first item in the list. When you call the Next method, the arrow is moved down to the first item and that item is returned. Another call to Next moves the arrow down to the second item and that item is returned. And so it goes until you reach the end of the list. If the Next method is called when the arrow is pointing at the last item in the list, the arrow will move past the last item. If you're dealing with a list of strings, the return value will be an empty string (""). If it's a list of objects, the return object will be null. That's why enumeration loops are usually set up to continue until the variable that holds the individual items becomes "" or null.

The reason there is a call to Next before the loop is to initialize the strName variable. Until it is initialized, it stores an empty string. (Until object variables are initialized, they store null.) So, if the call to Next before the loop were removed, the loop would end before it really began because strName would be "". While there are other ways to set up a loop through an enumeration, this is the most efficient way.

 If you try running this procedure a second time, seemingly nothing happens. The reason is that after the procedure was executed the first time, the enumeration arrow was left pointing beyond the last item in the list. The solution to this problem is to call the enumeration's Reset method immediately after obtaining it. Reset moves the arrow back above the first item in the list. No harm will be done if the arrow was already in that position.

So the best solution to this exercise is:

```
#!c#
		public void PracticeExercise11()
        {
            IEnumPrinterNames pPrinterNames;
            pPrinterNames = (IEnumPrinterNames)ArcMap.Application;
			pPrinterNames.Reset();
			
            string strName;
            strName = pPrinterNames.Next();

            while (!(string.IsNullOrEmpty(strName)))
            {
                MessageBox.Show(strName);
                strName = pPrinterNames.Next();
            }

        }
```