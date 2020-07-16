# Console App Challenge 2- Claims
The purpose of this project was to create a console application for an insurance agent to see a list of all claims, take care of a new claim, and enter in a new claim.
## Description
During the course of this project you will see the use of the repository design pattern along with the use of the single responsibilty principle.
When the console application is ran, the insurance agent will be prompted with a menu to select a number indicating to the code what method to be ran.
The first option, See All Claims, will display a table view of the data utilizing the String.Format method. 
The second option, Take Care of Next Claim, will remove the first claim off the queue when the user responds with a "y." If the user responds with a "n" simple nothing will be complete and the user will be prompted to return to the main menu.
The third option, Enter in a New Claim, will prompt the user to type in details of a claim which will then be saved in the queue under the details provided.
The last option, Exit, will close the console application.
## Methods
The Claims project is based upon two methods in the repository.
The first method returns a bool and is used to add a claim to the queue.
The second method returns a queue and is used to return the queue of all the insurance claims.
All methods were tested in the unit test class and came back with a beautiful green check.
## Challenging Moments
The most challenging part of this project was figuring out what to research in order to display the claims in a data table display.
I actually got to a point in the project where I created a whole data table for the claims and when I would breakpoint the method that created the table, I could not get it to display to the console.
When I researched String.Format I saw that I could display data to look like it was in a table format.
## Resources
[Microsoft Docs-String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1/)
