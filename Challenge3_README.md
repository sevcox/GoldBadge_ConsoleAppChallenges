# Console App Challenge 3- Badges
The purpose of this project was to create a console app for a security admin that contains a dictionary of employee badge information.
## Description
During the course of this project you will see the use of the repository design pattern along with the use of the single responsibilty principle.
When the console application is ran, the security admin will be prompted with a menu to select a number indicating what method needs to be called.
The first option, Add a Badge, will allow a user to create their own Badge that will then be stored in the dictionary of badges.
The second option, Edit a Badge, will prompt a user through a loop function that will prompt them with rather they would like to remove a door or add a door.
Whichever route they decided on will then decide which method requires to be ran. The loop will continue until the user tells the prompt that it would like to return to the main menu.
The third option, List All Badges, will display the Badges with their ID and corresponding door access values. The display utilizes String.Format.
The last option, Exit, will close the console application.
## Methods
The Badges project is based upon five methods in the repository.
The first method returns a bool and is used to add a badge to the dictionary of badges.
The second method returns a dictionary and is used to return the dictionary of all badges.
The third method returns a Badges and is used to retreive a badge by it's number from the dictionary and then able to correspond with the edit badge function.
The fourth method returns a bool and is used to add a door to a badge by first utilizing the method above to retreive the badge from the dictionary.
The fifth method return a bool and is used to remove a door from a badge by first utilizing the method above to retreive the badge from the dictionary.
All methods were tested in the unit test class and came back with a beautiful green check.
## Challenging Moments
The most challenging part of this project was learning how to strucutre and write out the logic for the editing a badge method.
I quickly learned that I had to reformat my Dictionary in order to complete the methods for editing.
Also remembering to format my methods to where they only did one thing became a bit more challenging during this project. 
It very easy to just continue to code out logic in the same method in order to get the job done, but remembering that organizationally it just doesn't make sense to do it that way.
It is also harder to test methods that do multiple things.
## Resources
[C# Dictionary](https://www.tutorialsteacher.com/csharp/csharp-dictionary/)
