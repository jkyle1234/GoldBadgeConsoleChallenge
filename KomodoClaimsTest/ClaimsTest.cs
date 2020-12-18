using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodClaimsLib;
using System.Collections;
using System.Collections.Generic;

namespace KomodoClaimsTest
{
    [TestClass]
    public class ClaimsTest
    {
        private KomodClaimsLib.ClaimsRepo claimsRepo = new ClaimsRepo();

        [TestInitialize]
        public void TestInit()
        {
            Claim a = new Claim(1, ClaimType.Car, "A very good car", 325.23, DateTime.Now, DateTime.Now, true);
            claimsRepo.AddClaimToQueue(a);
        }

        [TestMethod]
        public void TestGetQueue()
        {
            Queue<Claim> test = claimsRepo.GetClaimQueue();
            Assert.IsNotNull(test);

        }

        [TestMethod]
        public void TestAddClaim()
        {
            Claim b = new Claim(2, ClaimType.Home, "A very good car", 325.23, DateTime.Now, DateTime.Now, true);
            claimsRepo.AddClaimToQueue(b);
            Assert.AreEqual(2, claimsRepo.GetQueueCount());
        }

        [TestMethod]
        public void TestProcessClaim()
        {
            claimsRepo.ProcessClaim();
            Assert.AreEqual(0, claimsRepo.GetQueueCount());
        }
    }

}
