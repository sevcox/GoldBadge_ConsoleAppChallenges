using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace _01_Cafe_Tests
{
    [TestClass]
    public class MealRepositoryTests
    {
        private MealRepository _mealRepo;
        private Meal _meal;
       
        [TestInitialize]
        public void Arrange()
        {
             List<string> _ingredients = new List<string>();
            _ingredients.Add("chicken");
            _ingredients.Add("noodles");
            _ingredients.Add("veggies");
            _mealRepo = new MealRepository();
            _meal = new Meal(FoodType.Lunch, "Chicken Soup", 5, "Noodles, chicken, and veggies", _ingredients, 12.99M);
            _mealRepo.AddMealsToMenu(_meal);
        }
        [TestMethod]
        public void AddMealToMenu_ShouldReturnCorrectBool()
        {
            //Arrange
            //That was already done in the Test Initialize

            //ACT
            bool addResult = _mealRepo.AddMealsToMenu(_meal);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetByMealName_ShouldReturnCorrect()
        {
            //Arrange
            //That was already done in the Test Initialize.

            //ACT
            Meal mealSearchResult = _mealRepo.GetMealByName("Chicken Soup");

            //Assert
            Assert.AreEqual(_meal, mealSearchResult);
        }

        [TestMethod]
        public void RecieveListOfMeals_ShouldReturnCorrectBool()
        {
            //Arrange
            //That was already done in the Test Initialize.

            //ACT
            List<Meal> meals = _mealRepo.GetItemsFromMenu();
            bool mealRepoHasMeal = meals.Contains(_meal);

            //Assert
            Assert.IsTrue(mealRepoHasMeal);


        }

        [TestMethod]
        public void DeleteMealFromMenu_ShouldGetCorrectBool()
        {
            //Arrange
            Meal meal = _mealRepo.GetMealByName("Chicken Soup");

            //ACT
            bool wasRemoved = _mealRepo.DeleteExistingMenuItem(meal);

            //Assert
            Assert.IsTrue(wasRemoved);
        }


    }
}
