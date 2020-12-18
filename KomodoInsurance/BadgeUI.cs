using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using KomodoInsuranceLib;

namespace KomodoInsurance
{
    public class BadgeUI
    {
        private bool keepRunning = true;
        private BadgeRepo badgeRepo = new BadgeRepo();

        public void Run()
        {
            CreateInitialBadegData();
            Menu();
        }

        private void Menu()
        {
            while (keepRunning)
            {
                DisplayOptions();

                ListAllBadges();

                Console.WriteLine("Please enter an option:");

                string input = GetMenuOption();

                EvaluateInput(input);

            }
        }

        private void EvaluateInput(string input)
        {
            switch (input)
            {
                case "1":
                    Console.Clear();
                    AddNewBadge();
                    break;
                case "2":
                    Console.Clear();
                    EditBadge();
                    break;
                case "3":
                    ListAllBadges();
                    break;
                case "4":
                    RemoveAllDoors();
                    break;
                case "5":
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


        private void RemoveAllDoors()
        {
            Console.WriteLine("Please eneter the badge number you would like to remove all doors");
            string badNum = Console.ReadLine();
            Badge b = badgeRepo.GetBadge(badNum);
            badgeRepo.DeleteAllDoorsFromBagde(b);
        }

        private void ListAllBadges()
        {
           
            Dictionary<int, Badge> badges = badgeRepo.GetAllBadges();
            Console.WriteLine($"Badge #\t\t Door Access");
            foreach(var item in badges)
            {
                Console.WriteLine($"{item.Key}\t\t{((Badge)item.Value).GetDoors()}");
            }
        }

        private void EditBadge()
        {
            Console.WriteLine("What is the badge number to update?");
            string badgeNum = Console.ReadLine();
            Badge b = badgeRepo.GetBadge(badgeNum);
            DisplayBadgeDetail(b);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a door");
            Console.WriteLine("2. Remove a door");
            string input = Console.ReadLine();
            ProcessDoors(b,input);

        }

        public void ProcessDoors(Badge badge,string input)
        {
            if (input == "1")
            {
                Console.WriteLine("Which door would you like to add: ");
                string doorName = Console.ReadLine();
                badgeRepo.UpdateBadge(badge, input, doorName);
                Console.WriteLine("Door " + doorName + " added");
                DisplayBadgeDetail(badge);
            }
            else if (input == "2")
            {
                Console.WriteLine("Please enter the name of the door you would like to remove: ");
                string doorName = Console.ReadLine();
                badgeRepo.UpdateBadge(badge, input, doorName);
                Console.WriteLine("Door " + doorName + " removed");
                DisplayBadgeDetail(badge);
            }
            else
            {
                Console.WriteLine("Invalid choice can only enter 1 or 2");
            }

        }

        private void DisplayBadgeDetail(Badge badge)
        {
            Console.WriteLine($"{badge.BadgeID} has access to doors: {badge.GetDoors()}");
        }

     

        private void AddNewBadge()
        {
            Console.WriteLine("What is the number on the badge: ");
            int badNum = int.Parse(Console.ReadLine());
            List<string> doors = GetBadgeDoors();
            Badge b = new Badge(badNum, doors);
            Console.WriteLine("New badge created");
            badgeRepo.AddNewBadge(b);
        }

        private List<string> GetBadgeDoors()
        {
            bool notDone = true;
            List<string> doors = new List<string>();
            while (notDone)
            {
                Console.WriteLine("List a door that it needs access to: ");
                string door = Console.ReadLine();
                doors.Add(door);
                Console.WriteLine("Any other doors (y/n)?");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    notDone = true;
                }
                else
                {
                    notDone = false;
                }
            }

            return doors;
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

        private void DisplayOptions()
        {
            Console.WriteLine("Hello Security Admin, What would you like to do?");
            Console.WriteLine("1. Add a badge");
            Console.WriteLine("2. Edit a badge");
            Console.WriteLine("3. List all badges");
            Console.WriteLine("4. Remove all doors from badge");
            Console.WriteLine("5. Exit menu");
        }

        private void CreateInitialBadegData()
        {
            List<string> doora = new List<string>() { "A1","A2","A3"};
            List<string> doorB = new List<string>() { "B1", "B2", "B3" };
            Badge a = new Badge(1, doora);
            Badge b = new Badge(2, doorB);
            badgeRepo.AddNewBadge(a);
            badgeRepo.AddNewBadge(b);

        }

       
    }
}
