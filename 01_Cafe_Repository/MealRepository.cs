using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MealRepository : MenuRepository
    {
        //CRUD
        private string _errorMessage = "Sorry, your attempt was not successful.";

        //Get meal by name
        public Meal GetMealByName(string name)
        {
            foreach (Menu item in _itemDirectory)
            {
                if (item.Name.ToLower() == name.ToLower() && item is Meal)
                {
                    return (Meal)item;
                }
                else
                {
                    Console.WriteLine(_errorMessage);
                }
            }
            return null;
        }

        //Get list of all meals
        public List<Meal> GetAllMeals()
        {
            List<Meal> allMeals = new List<Meal>();
            foreach (Menu item in _itemDirectory)
            {
                if (item is Meal)
                {
                    allMeals.Add((Meal)item);
                }
            }
            return allMeals;
        }

    }
}
