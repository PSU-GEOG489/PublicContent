# Explanation: #

This exercise is designed to give you practice setting up and making a call to a function. Recall that both functions and void procedures can be set up to accept input parameters, but only a function can return a value or object to the procedure that called it. In this exercise you're asked to set up a function that takes an integer as input and returns that value squared (also an integer).

The first step is to add a Function procedure, and give the function a name.

The next step is to decide what pieces of information will be passed in from the calling procedure and insert them inside the parentheses in the procedure declaration statement. In this case only one item will be passed in, an int. The code "int intNum;" serves two purposes. First, it specifies that the function requires an integer as input to do its job; i.e., any procedure that calls this function must provide an integer value in parentheses after the function name. Second, it declares a variable called intNum that can be used throughout the function just like any other variable. This variable will hold whatever value was passed in by the calling procedure.  

Next, you must decide what type of information the function is going to return to the calling procedure. This comes before the name of the function. In this case I told you that the function should return an integer, so the word int should be added.

You are now ready to write the code of the function. In general, the code you write in a function should be focused on computing the return value. In most cases a number of intermediate variables will be required to turn the function's input values into the desired output. In this exercise, the function is quite simple. All we need it to do is square the input value. Regardless of how much code is required to compute the return value, you specify the return value by setting the return keyword to some expression or value. I specify the return value using the line:

 
```
#!c#
            return intNum * intNum;
``` 

Note that another way to perform this calcuation is to use C#'s Math.Pow method.  The second numeric parameter argument acts as an exponent to the first numeric argument. For example:
 
```
#!c#
            return (int)Math.Pow(intNum, 2);
``` 

With the function written, the next step in the exercise is to write a void procedure that tests out this new function. In my solution, I use a variable called intUserNum to store the user's number. Note the syntax of the call to the function. Because the function will be returning a value, I first declare a variable that matches the data type of the function's return value. I then put that variable on the left side of an assignment statement and the call to the function on the right. The call to the function is simply the name of the function along with the values I want to pass to it in parentheses.

The void procedure ends by displaying the value that was returned by the function in a MessageBox.

Two important points to note:

The names of the variables being passed from the calling procedure need not match the names of the variables in the function.
You may also pass literal values instead of variables, just as you can use either literal values or variables for the parameters of a C# function like MessageBox.