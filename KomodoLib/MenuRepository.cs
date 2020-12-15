using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoLib
{
    public class MenuRepository
    {
        public List<Menu> menuRepo = new List<Menu>();


        public MenuRepository() { }

        //create
        public void AddMenuItem(Menu item)
        {
            menuRepo.Add(item);
        }




        //read
        public List<Menu> GetMenuItems()
        {
            return menuRepo;
        }


        //update
        //TODO implement in future iteration


        //delete
        public bool DeleteMenuItem(int menuNum)
        {
            var menuItem = GetMenuItem(menuNum);
            return menuRepo.Remove(menuItem); 
        }



        //helper
        public Menu GetMenuItem(int id)
        {
            foreach(Menu m in menuRepo)
            {
                if (m.MealNumber == id)
                {
                    return m;
                }
            }
            return null;
        }


    }
}
