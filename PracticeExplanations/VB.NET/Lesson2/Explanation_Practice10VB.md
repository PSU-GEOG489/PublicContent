# Explanation: #

This procedure relies on an If-Then block to assign letter grades based on the score inputted by the user. By now you should be comfortable with prompting the user for an entry using the InputBox function. Within the If-Then block, you may be wondering why the conditional expressions don't specify ranges of scores. For example:

```
#!vbnet
	ElseIf intScore > 79 And intScore < 90 Then
``` 

Specifying ranges like this isn't necessary because of the way the block is evaluated from top to bottom. If the intScore > 79 line is being evaluated, then you know that the first expression (intScore > 89) has already evaluated to False (i.e., that the score can't be over 89). This eliminates the need to test for values over 89 in the second expression. Similar logic applies through the rest of the block. Note that the order of the expressions is important.