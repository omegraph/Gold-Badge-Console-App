using ClaimApp.Repository;
using ClaimsApp.POCOs;
using ClaimsApp.POCOs.ClaimType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimRepositoryTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void Add_ClaimIsNull_ReturnFalse()
        {

            //Arrange
            Claims claims = null;
            ClaimRepository repo = new ClaimRepository();

            //Act
            bool result = repo.AddClaim(claims);

            //Assert
            Assert.IsFalse(result);

        }   

        [TestMethod]
        public void Add_ClaimIsNotNull_ReturnTrue()
        {
            //Arrange
            Claims claim = new Claims(Claim_Type.Car,"Hail Damage", "3300", new DateTime (2021,6,15), new DateTime (2021, 7, 3), true);
            ClaimRepository repo = new ClaimRepository();

            //Act
            bool result = repo.AddClaim(claim);

            //Assert
            Assert.IsTrue(result);
        }
        
    }
}
