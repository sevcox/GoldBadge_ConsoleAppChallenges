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
    public class Menu
    {
        //Properties
        //Item Name -- string
        public string Name { get; set; } 
        //Item Price -- double
        public double Price { get; set; }
        //Item Description -- string
        public string Description { get; set; }
        //List of Ingredients -- list of type Ingredient
        public List<Ingredient> Ingredients { get; set; }
        public FoodType Type { get; set; }
        public string ImagePath {get; set;}

        //Constructors -- always want to define meal and category when creating menu
        public Menu()
        {

        }
        public Menu(FoodType type)
        {
            Type = type;
        }
        public Menu(FoodType type, string imagePath)
        {
            Type = type;
            ImagePath = imagePath;
        }
        public Menu (FoodType type, double price)
        {
            Type = type;
            Price = price;
        }
        public Menu(FoodType type,string name, double price)
        {
            Type = type;
            Name = name;
            Price = price;
        }
    }
}
