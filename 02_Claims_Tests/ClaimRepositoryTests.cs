using System;
using System.Collections.Generic;
using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddClaimToQueue_ShouldReturnCorrectBool()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            InsuranceClaim claim = new InsuranceClaim(24, ClaimType.Theft, "stole my bike", 2000.00M, new DateTime(2018, 12, 23), new DateTime(2019, 12, 20));
           
            //ACT
            bool wasAdded = claimRepo.AddClaimToQueue(claim);

            //Assert
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetQueueOfClaims_ShouldReturnCorrectCollection()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            InsuranceClaim claim = new InsuranceClaim(24, ClaimType.Theft, "stole my bike", 2000.00M, new DateTime(2018, 12, 23), new DateTime(2019, 12, 20));
            claimRepo.AddClaimToQueue(claim);

            //ACT
            Queue<InsuranceClaim> claims = claimRepo.GetAllInsuranceClaims();
            var queueHasClaim = claims.Count;

            //Assert
            Assert.AreEqual(1, queueHasClaim);

        }
    }
}
