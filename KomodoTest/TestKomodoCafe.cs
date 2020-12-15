using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoLib;
using System.Collections.Generic;

namespace KomodoTest
{
    [TestClass]
    public class TestKomodoCafe
    {
        MenuRepository menuRepo = new MenuRepository();

        [TestInitialize]
        public void TestInit()
        {
           
            Menu m = new Menu();
            m.MealNumber = 1;
            m.MealName = "Test";
            menuRepo.AddMenuItem(m);

        }
        [TestMethod]
        public void Test_Get_Menu_Items()
        {
            int count = menuRepo.GetMenuItems().Count;
            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void Test_Add_Menu_Item()
        {
           
            List<Menu> menuItems = menuRepo.GetMenuItems();
            int count = menuItems.Count;//should be one

            Menu m = new Menu();
            m.MealNumber = 2;
            m.MealName = "Test";

            menuRepo.AddMenuItem(m);
            Assert.AreEqual(2, menuItems.Count);//should be two if true
        }


        [TestMethod]
        public void Test_Delete_Menu_Item()
        {
            Menu m = new Menu();
            m.MealName = "Test delete";
            m.MealNumber = 4;
            menuRepo.AddMenuItem(m);

            bool deleted = menuRepo.DeleteMenuItem(4);
            Assert.IsTrue(deleted);

        }

        
            
    }
}
