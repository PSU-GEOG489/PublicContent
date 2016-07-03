# Explanation: #

Line 1: The first line is the procedure declaration statement. The keyword Public specifies that this procedure is visible to all other procedures in the project. (Using Private would specify that it would only be visible to other procedures within the same module.) The keyword Sub indicates that this is a procedure that is meant to execute without returning a value (as opposed to a function which can be used to return a value to another procedure that calls it). The word Practice1 is a name that is up to you the coder. All procedures must end with a set of parentheses. In Lesson 3 we'll see that within the parentheses you can specify input parameters that must be supplied for the procedure to do its job. If no input parameters are required, you can simply have empty parentheses, as is the case here.

Line 2: Declaring a variable requires the Dim keyword. The word after Dim is the name you want to give your variable, in this case x. The keyword As tells the computer that the type of variable you want to create will be coming next. The keyword String tells the computer to create a variable that is allowed to store strings.

Line 3: This is an example of an assignment statement. The statement tells the computer to find the place in memory labeled x and store the value "Hello" there. Using the box analogy, Line 2 created an empty box called x that is allowed to store string values. Line 3 puts a string value into the box. Note that storing a value in a string variable requires you to surround the value by quotes. You do not do this for other data types like numbers.

Line 4: MsgBox is a VB function that allows you to display a message in a dialog box. The first argument in the statement is the text of the message. This can be a literal string or a variable that stores a string. In the instructions I asked you to use a variable. Another way to write this procedure would be:
```
#!vbnet
	Public Sub Practice1()
		MsgBox ("Hello", vbOKOnly, "Practice 1")
	End Sub
```

The second argument specifies the buttons that will be found on the dialog box. The VB Help Reference can be used to see all of the valid choices for this argument. (More on the VB Help Reference in Lesson 2.) The third argument specifies the text to be displayed in the title bar of the dialog box. The second and third arguments are actually optional. (In fact, there are two more optional arguments as well.) The only required argument is the message. So, this procedure could be shortened even further:

```
#!vbnet
	Public Sub Practice1()
		MsgBox ("Hello")
	End Sub
```

Line 5: End Sub tells the computer that this is the end of the procedure. When you choose to run the Practice1 procedure, the computer will execute all of the lines of code found between the procedure declaration statement and the End Sub line (these two lines also being known as stub, or wrapper code). Note that you can add stub code automatically by selecting Insert > Procedure in the VB Editor.

Line 6, 7 and 8 are the OnClick procedure stub code for an Add-In Button.  Lines 6 and 8 should already be created for by the ESRI Add-In wizard.  Line 7 is used to call the external subprocedure named Practice1.  The very simplest way to get the same result would have been to put our Practice1 code into the OnClick procedure like this:

```
#!vbnet
	Protected Overrides Sub OnClick()
		MsgBox(“Hello”)
	End Sub
```