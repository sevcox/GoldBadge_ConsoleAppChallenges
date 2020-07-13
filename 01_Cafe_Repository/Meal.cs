using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public enum FoodType
    {
        Breakfast = 1,
        Lunch,
        Dinner
    }
    public class Meal
    {
        //Properties
        public FoodType Type { get; set; }
        //Item Name -- string
        public string Name { get; set; }
        //Meal Number -- int
        public int Number { get; set; }
        //Item Description -- string
        public string Description { get; set; }
        //List of Ingredients -- list of type Ingredient
        public List<string> Ingredients { get; set; }
        //Item Price -- double
        public decimal Price { get; set; }
        public bool IsOnSpecial
        {
            get
            {
                if (Price >= 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //Method
        public string DisplayIngredients(List<string> listOfIngredients)
        {
            string ingredients = string.Join(", ", listOfIngredients);
            return ingredients;
        }
        //Constructors
        public Meal()
        {

        }
        public Meal(FoodType foodType, string name, int number, string description, List<string> ingredients, decimal price)
        {
            Type = foodType;
            Name = name;
            Number = number;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
