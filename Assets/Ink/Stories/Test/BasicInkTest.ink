// Global variables
VAR PlayerName = "John"
VAR ChoseRedPill = false
VAR HealthPoints = 50

-> start_knot

=== start_knot ===
Hello, {PlayerName}! This is the starting knot! // display variable value
Now, we'll go to knot 2!
-> knot_2

=== knot_2 ===
Hello from knot 2!
Time for a personality test. #thought
Red pill or blue pill?
*** Red pill
~ChoseRedPill = true // update variable value
-> red_pill
*** Blue pill
~HealthPoints -= 20 // update variable value
-> blue_pill

=== red_pill ===
My god, how brave!
-> continue_conversation

=== blue_pill
Bold move, my friend
-> continue_conversation

=== continue_conversation
{ HealthPoints < 50: You seem quite weak. I wonder why...}
Alright. You have answered my question.
{ ChoseRedPill:
You chose the red pill. But I'm still not sure I can trust you
}
{not red_pill: -> no_red_pill_comment}
->END

=== no_red_pill_comment ===
You didn't choose the red pill. I'm not sure I can trust you.
-> END