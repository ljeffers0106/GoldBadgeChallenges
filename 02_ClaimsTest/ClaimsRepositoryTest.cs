using System;
using System.Collections.Generic;
using _02_Claims;
using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsRepositoryTest
    {
        [TestMethod]
        public void AddClaim_ShouldGetCorrectBoolean()
        {
            //Arrange 
            Claim content = new Claim();
            ClaimsRepository _repo = new ClaimsRepository();

            //Act
            bool addResult = _repo.AddClaim(content);

            // Assert
            Assert.IsTrue(addResult);
        }

        private ClaimsRepository _repo;
        private Claim _content;
        [TestInitialize]
        public void Arrange()
        {
            DateTime inDateTime = new DateTime(2020, 07, 10);
            DateTime claimDateTime = new DateTime(2020, 07, 15);
            _repo = new ClaimsRepository();
            _content = new Claim(1, ClaimType.Car, "Fender Bender", 500.00, inDateTime, claimDateTime);
            _repo.AddClaim(_content);
        }

        [TestMethod]
        public void GetContents_ShouldReturnCorrectCollection()
        {
            //Arrange
            Claim content = new Claim();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddClaim(content);
            //Act
            List<Claim> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);
            //Assert
            Assert.IsTrue(directoryHasContent);
        }
        [TestMethod]
        public void GetByClaimID_ShouldReturnCorrectContent()
        {
            //Arrange
            //ACT
            Claim searchResult = _repo.GetContentByClaimId(1);
            //Assert!
            Assert.AreEqual(_content, searchResult);
        }

    }
}

    

