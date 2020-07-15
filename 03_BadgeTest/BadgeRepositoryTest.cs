using System;
using _03_Badges;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeTest
{
    [TestClass]
    public class BadgeRepositoryTest
    {
       
        [TestMethod]
        public void AddBadge_ShouldGetCorrectBoolean()
        {
            //Arrange 
            int badgeNumber = 55;
            string doorString = "a1, b1";
            // create an instance of your repo so you can use it.
            BadgeRepository _repo = new BadgeRepository();
            //Act
            bool addResult = _repo.AddBadge(badgeNumber,doorString);
            // Assert
            Assert.IsTrue(addResult);
        }
        private BadgeRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            int badge = 35;
            string doors = "a1, c1";
            _repo.AddBadge(badge, doors);
            badge = 65;
            doors = "a1, b1, c1";
            _repo.AddBadge(badge, doors);
        }
        [TestMethod]
        public void GetDoor_ShouldReturnCorrectCollection()
        {
            _repo = new BadgeRepository();  // arrange
            int badgenum = 35;
            string doorlist = _repo.GetBadgeRooms(badgenum); // act
            Assert.AreEqual("a1, c1", doorlist);  // assert
        }
        [TestMethod]
        public void GetBadgeCount_ShouldReturnCorrectCount()
        {
            //Arrange
            _repo = new BadgeRepository();  // arrange
            int badges = 2;
            //ACT
            int badgeCount = _repo.GetBadgeCount();
            //Assert!
            Assert.AreEqual(badges, badgeCount);  // assert
        }
        [TestMethod]
        public void RemoveBadge_ShouldGetCorrectBoolean()
        {
            //Arrange 
            int badgeNumber = 55;
            string doorString = "a1, b1";
            // create an instance of your repo so you can use it.
            _repo = new BadgeRepository();
            //Act
            bool addResult = _repo.AddBadge(badgeNumber, doorString);
            bool removeIt = _repo.RemoveBadge(badgeNumber);
            // Assert
            Assert.IsTrue(removeIt);
        }
        [TestMethod]
        public void GetBadge_ShouldGetCorrectBadge()
        {
            //Arrange 
            int index = 1;
            int badge = 65;
            // create an instance of your repo so you can use it.
            _repo = new BadgeRepository();
            //Act
            int badgeReturn = _repo.GetBadge(index);
           
            // Assert
            Assert.AreEqual(badge, badgeReturn);
        }
    }
}
