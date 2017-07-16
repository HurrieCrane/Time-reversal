# Time-reversal
A Unity scene in which one can reverse time

# How it works
Each x amount of seconds the position of the scripted object is pushed to a stack, when the player wished to reverse time a co-routine is run that pops from the stack and sets the objects position to this.

In the file *tracker.cs* there are two co-routines; reverse and recordPer. recordPer is used to record the position per x seconds and reverse is used to itterate through. In the update function of *tracker.cs* in a region called "Draw UI lines" UI lines are drawn, if you don't want this then delete or comment it out. Enter is, by default, the trigger used to start time reversal, this can easily be changed as desribed below.

# How to use
If you want to use this in your own game you need to take the file *tracker.cs* and attack it to an object in your scene, after you do this when the object is instantiated the positions will start to be recorded. You might decide that you want to change the trigger to reverse time, to do this you just have to start the **reverse** co-routine some other way weather that be a collider trigger or a different button.

# Notes
Currently there's no logic associated with the frequency, by this I mean it will record at the same frequency regardless, this is unfortunate as when the character stands still the positions are still recorded however this can be easily fixed and will hopefully be added later.

Feel free to contact me over this github account or on [Twitter](https://twitter.com/HurrieCrane) if you have any questions.
