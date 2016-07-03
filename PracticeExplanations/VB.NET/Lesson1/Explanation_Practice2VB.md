# Explanation: #
Building on Practice Exercise 1, this exercise asks you to store integer values in two variables, then use a third variable to store the sum of those two numbers. Again, Dim is used to set aside space in memory. This time the keyword Integer is used to specify a different type of variable. The line:

```
#!vbnet
z = x + y
```

is an instruction to the computer to perform the following steps:

find the box called x
look inside to see what number x holds
find the box called y
look inside to see what number y holds
add the two numbers together
store the result in the box called z
Two other items of note in this procedure:

MsgBox requires a string as its first argument, while here I've specified an integer instead. This is allowed because VB can automatically treat numbers as strings in certain instances. It's not always necessary to convert numbers to strings as it is in some other languages. There are VB functions for doing this, when they're needed. A good analogy is entering data into Word vs. Calculator. In Word you can enter numbers and they will be interpreted as text. In Calculator, you can't enter text, only numbers.

There is some flexibility in the ordering of the statements in this procedure. The way the procedure is set up now, one variable is declared, that variable is assigned a value, another variable is declared, that variable is assigned a different value, etc. Another way to order the statements would be to first declare all of the variables, then assign values to the variables:

```
#!vbnet
	Public Sub Practice2()

		Dim x As Integer
		Dim y As Integer
		Dim z As Integer
		x = 9
		y = 7
		z = x + y

		MsgBox (z, vbOKOnly, "Practice 2")

	End Sub
```