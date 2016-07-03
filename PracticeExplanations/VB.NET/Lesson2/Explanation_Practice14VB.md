# Explanation: #

The first step in completing this exercise is to create a new function. The next step is to specify in parentheses what information will be passed in by the calling procedure; i.e., declare a variable that will hold the value entered by the user).  Note the use of the ByVal keyword instead of the ByRef keyword.  Next, add an As ____ clause at the end of the procedure declaration line to specify what kind of data should be returned (in this case the blank should be filled in with Double).

You should recall that the ultimate goal of writing code within a function is to set the name of the function equal to the value you want to return to the calling procedure. In this case, the return value can be calculated using a single statement, so the finished function looks like this:

```
#!vbnet
    Public Function CToF(ByVal dblCel As Double) As Double
		CtoF = (9 / 5 * dblCel) + 32
    End Function 
```

With the function set up, the original procedure should be changed so that each temperature calculation now makes a call to the new function. This is done simply by writing the function name and the temperature you want to convert in parentheses.