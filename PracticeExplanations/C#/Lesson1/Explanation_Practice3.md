# Explanation: #
This procedure is designed to give you more practice concatenating a value stored in a variable with literal text. Note that the *InputBox* line specifies only the message; other optional parameters are not included. The *MessageBox* line uses the concatenation character ("+") twice to create the message: once between the first part of the message and the input name, and again between the name and the last part of the message. A more step-by-step approach to displaying the message might look like this:
```
#!c#
private void PracticeExercise3()
    {
        string x;
        x = Interaction.InputBox("Please enter your name");
        string y;
        y = "Hi" + x + "!";
        MessageBox.Show(y, "Practice 3", MessageBoxButtons.OK);
    }
```

The use of *Interaction.InputBox* is frankly a holdover from the previous iterations of the course which used VB.NET instead of C#.  There is no built-in *InputBox* function in C# so we have added a reference (and using statement) to the **Microsoft.VisualBasic** assembly to reference the function there.  This [StackOverflow forum post][sopost] does a good job of explaining the problem and solutions:  

[sopost]: http://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputdialog
