# Explanation: #
This procedure is designed to give you more practice concatenating a value stored in a variable with literal text. Note that the InputBox line specifies only the message; other optional parameters are not included. The MsgBox line uses the concatenation character twice to create the message: once between the first part of the message and the input name, and again between the name and the last part of the message. A more step-by-step approach to displaying the message might look like this:
```
#!vbnet
	Public Sub Practice3()
		Dim x As String
		x = InputBox("Please enter your name")
		Dim y As String
		y = "Hi " & x & "!"
		
		MsgBox (y, vbOKOnly, "Practice 3")

	End Sub
```
