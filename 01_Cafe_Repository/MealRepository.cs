using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MealRepository
    {
        protected readonly List<Meal> _allMeals = new List<Meal>();
        //CRUD
        //Add Meals to Menu
        public bool AddMealsToMenu(Meal meal)
        {
            int startingCount = _allMeals.Count;
            _allMeals.Add(meal);
            bool wasAdded = (_allMeals.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Delete Menu Items
        public bool DeleteExistingMenuItem (Meal existingMeal)
        {
            bool wasDeleted = _allMeals.Remove(existingMeal);
            return wasDeleted;
        }

        //Receive a List of Menu Items
        public List<Meal> GetItemsFromMenu()
        {
            return _allMeals;
        }

        //Get meal by name
        public Meal GetMealByName(string name)
        {
            foreach (Meal meal in _allMeals)
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
                else
                {
                    Console.WriteLine("Sorry, your attempt was not successful.");
                }
            }
            return null;
        }

    }

}
