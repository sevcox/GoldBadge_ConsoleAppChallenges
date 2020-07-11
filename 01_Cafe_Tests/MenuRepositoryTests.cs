using System;
using System.Collections.Generic;
using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {

        [TestMethod]
        public void AddItemToMenu_ShouldGetCorrectBool()
        {
            //Arrange
            Menu item = new Menu();
            MenuRepository menuRepository = new MenuRepository();

            //ACT
            bool wasItemAdded = menuRepository.AddItemsToMenu(item);

            //Assert
            Assert.IsTrue(wasItemAdded);
        }

        private MenuRepository _menuRepo;
        private Menu _menuItem;

        [TestInitialize]
            public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _menuItem = new Menu(FoodType.Breakfast, "Ham and Eggs", 11.50);
            _menuRepo.AddItemsToMenu(_menuItem);
        }

        [TestMethod]
        public void DeleteExistingMenuItem_ShouldGetCorrectBool()
        {
            //Arrange
            Menu item = _menuRepo.GetMenuItemsByName("Ham and Eggs");

            //ACT
            bool wasItemRemoved = _menuRepo.DeleteExistingMenuItem(item);

            //Assert
            Assert.IsTrue(wasItemRemoved);
        }

        [TestMethod]
        public void GetMenuItemByName_ShouldReturnCorrectMenuItem()
        {
            //Arrange
            //This part was already complete by the Test Initialize above

            //ACT
            Menu menuItemSearchResult = _menuRepo.GetMenuItemsByName("Ham and Eggs");

            //Assert
            Assert.AreEqual(_menuItem, menuItemSearchResult);
        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnCorrectBool()
        {
            //Arrange
            _menuRepo.AddItemsToMenu(_menuItem);

            //ACT
            List<Menu> menuItems = _menuRepo.GetItemsFromMenu();
            bool collectionHasMenuItem = menuItems.Contains(_menuItem);

            //Assert
            Assert.IsTrue(collectionHasMenuItem);
        }
    }
}
