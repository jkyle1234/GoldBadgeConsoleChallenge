using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoLib
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }
       


        public Menu() { }
        public Menu(int mealnum,string mealname,string desc,List<string> items,double p)
        {
            this.MealNumber = mealnum;
            this.MealName = mealname;
            this.Description = desc;
            this.Ingredients = items;
            this.Price = p;
        }

        public string GetListOfIngredients()
        {
            string menu = "";
            foreach(String s in this.Ingredients)
            {
                menu += s + ",";
            }
            menu.Remove(menu.Length, 1);
            return menu;
        }


    }
}
