# Explanation: #
Building on Practice Exercise 1, this exercise asks you to store integer values in two variables, then use a third variable to store the sum of those two numbers. This time the keyword *int* is used to specify a different type of variable. The line:

```
#!c#
z = x + y;
```

is an instruction to the computer to perform the following steps:

1. find the box called x
2. look inside to see what number x holds
3. find the box called y
4. look inside to see what number y holds
5. add the two numbers together
6. store the result in the box called z

**Two other items of note in this procedure:**

	(1) *MessageBox.Show* requires a string as its first argument.
C# requires you to convert numbers to strings before they can be used in string parameters (like the MessageBox prompt message string), so we used the built-in function *ToString()* to convert the number to its string representation.  VB.NET does not always require the same conversion and can automatically treat numbers as strings in certain instances.

	(2) There is some flexibility in the ordering of the statements in this procedure. The way the procedure is set up now, one variable is declared, that variable is assigned a value, another variable is declared, that variable is assigned a different value, etc. Another way to order the statements would be to first declare all of the variables, then assign values to the variables:

```
#!c#
        private void PracticeExercise2()
        {
            int x;
            int y;
            int z;
            x = 9;
            y = 7;
            z = x + y;

            MessageBox.Show(z.ToString(), "Practice 2", MessageBoxButtons.OK);
        }
```