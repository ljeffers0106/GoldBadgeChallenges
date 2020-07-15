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
        private ClaimsRepository _repo;
        private Claim _content;
        [TestInitialize]
        public void Arrange()
        {
            DateTime inDateTime = new DateTime(2020, 07, 10);
            DateTime claimDateTime = new DateTime(2020, 07, 15);
            _repo = new ClaimsRepository();
            _content = new Claim(10, ClaimType.Car, "Fender Bender", 500.00, inDateTime, claimDateTime);
            _repo.AddClaim(_content);
            _content = new Claim(20, ClaimType.Car, "Accident", 1500.00, inDateTime, claimDateTime);
            _repo.AddClaim(_content);
        }
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
        [TestMethod]
        public void GetContents_ShouldReturnCorrectCollection()
        {
            //Arrange
            Claim content = new Claim();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddClaim(content);
            //Act
            Queue<Claim> contents = _repo.GetContents();
            bool queueHasContent = contents.Contains(content);
            //Assert
            Assert.IsTrue(queueHasContent);
        }
        [TestMethod]
        public void AddClaimQueue_ShouldAddIt()
        {
            //Arrange
            Queue<Claim> localclaimsQueue = _repo.GetContents();
            //List<Claim> _contentClaims = new List<Claim>();
            DateTime inDateTime = new DateTime(2020, 07, 01);
            DateTime claimDateTime = new DateTime(2020, 07, 04);
            Claim _content1 = new Claim(10, ClaimType.Car, "Hit Bicycler", 30000.00, inDateTime, claimDateTime);
            //ACT
            int startingCount = localclaimsQueue.Count;
            _repo.AddClaimQueue(_content1);
            int count = localclaimsQueue.Count;
            bool wasAdded = (localclaimsQueue.Count > startingCount) ? true : false;
            // Assert
            Assert.IsTrue(wasAdded);
            //Assert!

        }
        [TestMethod]
        public void RemoveClaimQueue_RemoveIt()
        {
            Queue<Claim> localclaimsQueue = _repo.GetContents();
            //List<Claim> _contentClaims = new List<Claim>();
            DateTime inDateTime = new DateTime(2020, 07, 01);
            DateTime claimDateTime = new DateTime(2020, 07, 04);
            Claim _content1 = new Claim(10, ClaimType.Car, "Hit Bicycler", 30000.00, inDateTime, claimDateTime);
            //ACT
            int startingCount = localclaimsQueue.Count;
            _repo.AddClaimQueue(_content1);
            // must add a claim before removing it
            _repo.RemoveClaimQueue();
            int count = localclaimsQueue.Count;
            bool wasRemoved = (localclaimsQueue.Count == startingCount) ? true : false;
            // Assert
            Assert.IsTrue(wasRemoved);
            //Assert!
        }
    }
}

    

