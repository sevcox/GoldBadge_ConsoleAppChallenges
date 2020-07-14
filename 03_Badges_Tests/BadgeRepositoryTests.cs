using System;
using System.Collections.Generic;
using _03_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge;
        private Dictionary<int, Badge> _badgeIdAndDoors;

        [TestInitialize]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            doors.Add("A12");
            doors.Add("B7");
            _badgeRepo = new BadgeRepository();
            _badge = new Badge(35, doors);
            _badgeIdAndDoors = new Dictionary<int, Badge>();
            _badgeRepo.AddBadgeToDictionary(_badge);
        }
        [TestMethod]
        public void AddBadgeToDictionary_ShouldGetCorrectBool()
        {
            //Arrange
            //That was already done in the Test Initialize.

            //ACT
            bool wasAdded = _badgeRepo.AddBadgeToDictionary(_badge);

            //Assert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetDictionary_ShouldGetCorrectCollection()
        {
            //Arrange
            Badge newBadge = new Badge();
            _badgeRepo.AddBadgeToDictionary(newBadge);

            //ACT
            Dictionary<int, Badge> badges = _badgeRepo.ReturnBadgeDictionary();

            var dictionaryHasContents = badges.Count;

            //Assert
            Assert.AreEqual(2, dictionaryHasContents);
        }

        [TestMethod]
        public void GetBadgeByNumber_ShouldGetCorrectBadge()
        {
            //Arrange
            //That was already done in the Test Initialize.

            //ACT
            Badge searchResult = _badgeRepo.GetBadgeByNumber(35);

            //Assert
            Assert.AreEqual(_badge, searchResult);
        }

        [TestMethod]
        public void AddADoorToBadge_ShouldGetCorrectBool()
        {
            //Arrange
            //That was already done in the Test Initialize

            //ACT
            bool wasAdded = _badgeRepo.AddADoorToBadge(_badge, "B12");

            //Assert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DeleteDoorFromBadge_ShouldGetCorrectBool()
        {
            //Arrange
            //That was already done in the Test Initialize

            //ACT
            bool wasDeleted = _badgeRepo.RemoveADoorFromBadge(_badge, "B7");

            //Arrange
            Assert.IsTrue(wasDeleted);
        }
    }
}
