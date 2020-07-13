using _01_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    public class ProgramUI
    {
        protected readonly MealRepository _mealRepo = new MealRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Dr.Seuss, Dr. Seuss you are! Please choose an option below.\n" +
                    "1. Add a Menu Item. \n" +
                    "2. Delete a Menu Item. \n" +
                    "3. See all Menu Items. \n" +
                    "4. Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMeals();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press any key to continue...");
                        break;

                }
            }

        }
        private void AddMenuItem()
        {
            Console.Clear();
            Meal newMeal = new Meal();
            //Food Type
            Console.WriteLine("Select a type of meal: \n" +
                "1) Breakfast \n" +
                "2) Lunch \n" +
                "3) Dinner");
            string foodTypeString = Console.ReadLine();
            switch (foodTypeString.ToLower())
            {
                case "1":
                case "breakfast":
                    newMeal.Type = FoodType.Breakfast;
                    break;
                case "2":
                case "lunch":
                    newMeal.Type = FoodType.Lunch;
                    break;
                case "3":
                case "dinner":
                    newMeal.Type = FoodType.Dinner;
                    break;
                default:
                    Console.WriteLine("Sorry you entered an invalid response. Your response was not recorded.");
                    break;
            }
            //Name
            Console.WriteLine("Enter in the name of the meal: ");
            newMeal.Name = Console.ReadLine();
            //Number
            Console.WriteLine("Enter in the number of the meal: ");
            newMeal.Number = Convert.ToInt32(Console.ReadLine());
            //Description
            Console.WriteLine("Enter in a description of the meal: ");
            newMeal.Description = Console.ReadLine();
            //List of Ingredients
            Console.WriteLine("Enter in the ingredients of the meal(separate ingredients with a comma): ");
            string ingredients = Console.ReadLine();
            List<string> newMealIng = ingredients.Split(',').ToList<string>();
            newMeal.Ingredients = newMealIng;
            //Price
            Console.WriteLine("Enter in the cost of the meal: ");
            decimal mealPrice = decimal.Parse(Console.ReadLine(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
            newMeal.Price = mealPrice;
            _mealRepo.AddMealsToMenu(newMeal);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void DeleteMenuItem()
        {
            Console.WriteLine("Which meal number would you like to remove from the menu?");
            List<Meal> mealList = _mealRepo.GetItemsFromMenu();
            int count = 0;
            foreach (Meal meal in mealList)
            {
                count++;
                Console.WriteLine($"{count}. {meal.Name}");
            }

            int targetMealId = Convert.ToInt32(Console.ReadLine());
            int targetIndex = targetMealId - 1;
            if (targetIndex >= 0 && targetIndex < mealList.Count)
            {
                Meal desiredMeal = mealList[targetIndex];
                if (_mealRepo.DeleteExistingMenuItem(desiredMeal))
                {
                    Console.WriteLine($"{desiredMeal.Name} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("Sorry Dr.Suess. Meal was not removed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid response. Meal could not be removed");
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllMeals()
        {
            Console.Clear();
            List<Meal> listOfMeals = _mealRepo.GetItemsFromMenu();
            foreach (Meal meal in listOfMeals)
            {
                DisplayMeal(meal);
                Console.WriteLine("__________________________________________________________________________________________________________");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayMeal(Meal meal)
        {
            Console.WriteLine($" Meal Type: {meal.Type} \n" +
                $" Name: {meal.Name} \n" +
                $" Number: {meal.Number} \n" +
                $" Description: {meal.Description} \n" +
                $" Ingredients: { meal.DisplayIngredients(meal.Ingredients)} \n" +
                $" Price: ${meal.Price} \n" +
                $" On Special: {meal.IsOnSpecial}");
        }
        private void SeedMenu()
        {
            //Menu Item 1
            List<string> mealOneIng = new List<string>();
            mealOneIng.Add("Eggs");
            mealOneIng.Add("Ham");
            mealOneIng.Add("Green Dye");
            mealOneIng.Add("Butter");
            mealOneIng.Add("Ketchup");
            Meal greenEggsAndHam = new Meal(FoodType.Breakfast, "Green Eggs and Ham", 1, "Steaming plate of green eggs paired with a slice of our slow roasted green ham", mealOneIng, 25.00M);
            _mealRepo.AddMealsToMenu(greenEggsAndHam);
            //Menu Item 2
            List<string> mealTwoIng = new List<string>();
            mealTwoIng.Add("Truffula Tuft");
            mealTwoIng.Add("Butterfly Milk");
            mealTwoIng.Add("Lorax Protein Powder");
            Meal proteinShake = new Meal(FoodType.Lunch, "Truffula Protein Shake", 2, "Fresh tuft picked from the Truffula tree blended with the Lorax's signature protein powder.", mealTwoIng, 15.50M);
            _mealRepo.AddMealsToMenu(proteinShake);
            //Menu Item 3
            List<string> mealThreeIng = new List<string>();
            mealThreeIng.Add("Who-Roast Beast");
            mealThreeIng.Add("Who-Potatoes");
            mealThreeIng.Add("Who-Pepper and Onion Blend");
            mealThreeIng.Add("Love");
            Meal roastBeastAndHash = new Meal(FoodType.Dinner, "Who-Roast Beast and Who-Hash", 3, "A feast set by the grinch himself. Carved Roast-Beast with a side of Who-Hash.", mealThreeIng, 30.99M);
            _mealRepo.AddMealsToMenu(roastBeastAndHash);
        }
    }
}
