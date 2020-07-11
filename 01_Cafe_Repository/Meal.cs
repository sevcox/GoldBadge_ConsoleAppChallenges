using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    // This is similar to the streaming content example in class... meal is a portion of menu like movie was a portion of streamingcontent. I could have several other classes ranging from appetizer or sides. I choose inheritance because I want to share the properties from the Menu class as well.
    public class Meal : Menu
    {
        //Properties

        //Meal Number -- int
        public int Number { get; set; }
        public bool ComesWithBread { get; set; }
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
        //Constructors
        public Meal()
        {

        }
        public Meal(string name,bool comesWithBread)
        {
            Name = name;
            ComesWithBread = comesWithBread;
        }
        public Meal (string name, int number)
        {
            Name = name;
            Number = number;
        }
        public Meal (string name, int number, double price)
        {
            Name = name;
            Number = number;
            Price = price;
        }
        public Meal(string name, int number, double price, string description, List<Ingredient> ingredients)
        {
            Name = name;
            Number = number;
            Price = price;
            Description = description;
            Ingredients = ingredients;
        }

    }
}
