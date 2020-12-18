using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoLib;

namespace KomdoCaffe
{
    class ProgramUI
    {
        private bool keepRunning = true;
        private MenuRepository menuRep = new MenuRepository();
        
       

        public void Run()
        {
            CreateInitialMenu();
            Menu();
        }

        public void Menu()
        {

            while(keepRunning)
            {
                DisplayOptions();

                Console.WriteLine("Please enter an option:");

                string input = GetMenuOption();

                EvaluateInput(input);
            }
        }

        public void CreateInitialMenu()
        {
            List<string> items =  new List<string>() { "Burger", "medium fries", "large drink" };
            Menu m = new Menu(1, "Burger combo", "Classic burger", items, 5.50);
            menuRep.AddMenuItem(m);
            List<string> items2 = new List<string>() { "Chicken sandwich", "medium fries", "large drink" };
            Menu n = new Menu(2, "Chicken sandwich", "chicken offering", items2, 5.25);
            menuRep.AddMenuItem(n);
        }

        public void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("1. Create new menu item");
            Console.WriteLine("2. Delete menu item");
            Console.WriteLine("3. Display menu items");
            Console.WriteLine("4. Exit");

        }


        private string GetMenuOption()
        {
            string input = Console.ReadLine();
            while (input is null || input == "")
            {
                Console.WriteLine("Please enter a valid integer resposne:");
                input = Console.ReadLine();
            }

            return input;
        }


        private void EvaluateInput(string input)
        {

            switch(input)
            {
                case "1":
                    Console.Clear();
                    AddMenuItem();
                    break;
                case "2":
                    Console.Clear();
                    DeleteMenuItem();
                    break;
                case "3":
                    Console.Clear();
                    DisplayMenu();
                    break;
                case "4":
                    keepRunning = false;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Please choose a valid entry between 1-4.");
                    break;

            }

            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        private void AddMenuItem()
        {

            Console.WriteLine("Please enter the meal number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the meal name:");
            string mealName = Console.ReadLine();
            Console.WriteLine("Please enter a description of the meal:");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter the list of ingredients comma seperated:");
            string ingredints = Console.ReadLine();
            List<string> menuitems = ingredints.Split(',').ToList<string>();
            Console.WriteLine("Please enter the price:");
            double p = double.Parse(Console.ReadLine());
            Menu m = new Menu(num, mealName, description, menuitems, p);
            menuRep.AddMenuItem(m);
            DisplayMenu();

        }

        private void DeleteMenuItem()
        {
           
            DisplayMenu();
            Console.WriteLine("\nPlease enter the meal number to remove:");
            int num = int.Parse(Console.ReadLine());
            bool deleted = menuRep.DeleteMenuItem(num);
            if (deleted)
                Console.WriteLine("Menu item deleted");
        }

        private void DisplayMenu()
        {
            List<Menu> items = menuRep.GetMenuItems();
            foreach(Menu m in items)
            {
                Console.WriteLine($"Meal number:\t {m.MealNumber}");
                Console.WriteLine($"Meal name:\t {m.MealName}");
                Console.WriteLine($"Meal Description:\t {m.Description}");
                Console.WriteLine($"Meal ingredients:\t {m.GetListOfIngredients()}");
                Console.WriteLine($"Meal price:\t {m.Price}");
                Console.WriteLine();
            }
            
        }


    }
}
