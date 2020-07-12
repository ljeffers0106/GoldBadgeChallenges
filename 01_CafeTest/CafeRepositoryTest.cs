using System;
using _01_Cafe;
using static _01_Cafe.CafeClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _01_CafeTest
{
    [TestClass]
    public class CafeRepositoryTest
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            //Arrange 
            MenuItem content = new MenuItem();
            CafeRepository repo = new CafeRepository();

            //Act
            bool addResult = repo.AddMealToMenu(content);

            // Assert
            Assert.IsTrue(addResult);
        }

        private CafeRepository _repo;
        private MenuItem _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepository();
            _content = new MenuItem(1, "Meatloaf", "Savory meatloaf and mashed potatoes", "Ground sirloin, eggs, ketchup, potatoes, milk, butter", 5.99);
            _repo.AddMealToMenu(_content);
        }

        [TestMethod]
        public void GetContents_ShouldReturnCorrectCollection()
        {
            //Arrange
            MenuItem content = new MenuItem();
            CafeRepository repo = new CafeRepository();
            repo.AddMealToMenu(content);
            //Act
            List<MenuItem> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            //Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            MenuItem content = _repo.GetContentByNumber(1);
            //Act
            bool removeResult = _repo.DeleteExistingContent(content);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
