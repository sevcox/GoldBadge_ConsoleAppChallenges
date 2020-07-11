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
            _mealRepo = new MealRepository();
            _meal = new Meal("Chicken Soup", 5, 10.99);
            _mealRepo.AddItemsToMenu(_meal);
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
        public void MyTestMethod()
        {
            //Arrange
            //That was already done in the Test Initialize.

            //ACT
            List<Meal> meals = _mealRepo.GetAllMeals();
            bool mealRepoHasMeal = meals.Contains(_meal);

            //Assert
            Assert.IsTrue(mealRepoHasMeal);


        }

    }
}
