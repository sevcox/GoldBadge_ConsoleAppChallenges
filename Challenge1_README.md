# Console App Challenge 1- Cafe
The purpose of this project was to create a console app for a cafe manager to add new menu items, delete menu items, and recieve a list of all menu items.
## Description
During the course of this project you will see the use of the repository design pattern along with the use of the single responsibilty principle.
When the console application is ran, the cafe manager will be prompted with a menu to select a number indicating what method needs to be called.
The first option, Add a Menu Item, will prompt the user to type in details about a new menu item. The response will then be saved and added to the list of menu items.
The second option, Delete a Menu Item, will allow a user to type in a meal number to delete and then the method for deleting content will be ran and remove the item from the list.
The third option, Show All Meals, will retreive the list of meals that the user has either added to or deleted from and show them in a list format. 
The last option, Exit, will close the console application.
## Methods
The Cafe project is based upon three methods in the repository.
The first method returns a bool and is used to add a meal to a list of meals.
The second method returns a list and is used to return the list of all the meals.
The third method returns a bool and is used to delete a meal from the list of meals.
All methods were tested in the unit test class and came back with a beautiful green check.
## Challenging Moments
The most challenging part of this project was learning to plan and layout my code in the repository design pattern.
This was the first of the three projects so I really learned a lot about planning and how to structure code so that it make sense to other developers.
I researched a lot about repository patterns for this one so that I could then get better at structuring my code in the following projects.
## Resources
[Repository Pattern](https://codewithshadman.com/repository-pattern-csharp/#:~:text=A%20Repository%20in%20C%23%20mediates,layers%20(like%20Entity%20Framework).&text=Repository%20pattern%20C%23%20is%20a,view%20of%20the%20persistence%20layer./)
