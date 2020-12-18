using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoInsuranceLib;
using System.Collections;
using System.Collections.Generic;

namespace KomodoInsuranceTest
{
    [TestClass]
    public class BadgeTest
    {
        private BadgeRepo badgeRepo = new BadgeRepo();

        [TestInitialize]
        public void TestInit()
        {
            List<string> doora = new List<string>() { "A1", "A2", "A3" };
            List<string> doorB = new List<string>() { "B1", "B2", "B3" };
            Badge a = new Badge(1, doora);
            Badge b = new Badge(2, doorB);
            badgeRepo.AddNewBadge(a);
            badgeRepo.AddNewBadge(b);

        }

        [TestMethod]
        public void TestAddNewBadge()
        {
            int intitailCount = badgeRepo.Count();//two
            List<string> doorc = new List<string>() { "C1", "C2", "C3" };
            Badge c = new Badge(3, doorc);
            badgeRepo.AddNewBadge(c);
            Assert.AreEqual(3, intitailCount+1);
            List<string> doord = new List<string>() { "D1", "D2", "D3" };
            Badge d = new Badge(4, doord);
            badgeRepo.AddNewBadge(d.BadgeID, d);
            Assert.AreEqual(4, intitailCount + 2);

        }

        [TestMethod]
        public void TestEditBadgeAddDoor()
        {
            List<string> doore = new List<string>() { "E1", "E2", "E3" };
            Badge e = new Badge(5, doore);
            badgeRepo.AddNewBadge(e);
            string doorName = "E4";
            string input = "1";//add door
            badgeRepo.UpdateBadge(e, input, doorName);
            Assert.AreEqual(e.GetDoors(), "E1,E2,E3,E4");
        }

        [TestMethod]
        public void TestEditBadgeRemoveDoor()
        {
            List<string> doorf = new List<string>() { "F1", "F2", "F3" };
            Badge f = new Badge(6, doorf);
            badgeRepo.AddNewBadge(f);
            string doorName = "F3";
            string input = "2";
            badgeRepo.UpdateBadge(f, input, doorName);
            Assert.AreEqual(f.GetDoors(), "F1,F2");
        }

        [TestMethod]
        public void TestGetBadges()
        {
            Dictionary<int, Badge> badges = badgeRepo.GetAllBadges();
            Assert.IsNotNull(badges);
        }

        [TestMethod]
        public void TestRemoveAllDoors()
        {
            Badge a = badgeRepo.GetBadge("1");
            string doors = a.GetDoors();
            badgeRepo.DeleteAllDoorsFromBagde(a);
            Assert.AreEqual("", a.GetDoors());

        }
    }
}
