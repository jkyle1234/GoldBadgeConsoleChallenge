using KomodClaimsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodClaims
{
    public class ClaimsUI
    {
        private bool keepRunning = true;
        private ClaimsRepo claimsRepo = new ClaimsRepo();

        public void Run()
        {
            CreateInitialQueue();
            Menu();
        }


        private void CreateInitialQueue()
        {

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

        private void EvaluateInput(string input)
        {
            switch (input)
            {
                case "1":
                    Console.Clear();
                    SeeAllClaims();
                    break;
                case "2":
                    Console.Clear();
                    ProcessClaim();
                    break;
                case "3":
                    CreateNewClaim();
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

        private void CreateNewClaim()
        {
            Console.WriteLine("Please enter the claim id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the  claim type 1 for car 2 for home 3 for theft:");
            int claimtype = int.Parse(Console.ReadLine());
            ClaimType theType = GetClaimType(claimtype);

            Console.WriteLine("Please enter the description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Please enter the claim amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of incident as month day, year ex: Jan 1, 2009 ");
            var incident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter if the claim is valid true or false");
            bool valid = bool.Parse(Console.ReadLine());

            Claim claim = new Claim(id, theType, desc, amount, incident,DateTime.Now, valid);
            claimsRepo.AddClaimToQueue(claim);
        }

        ClaimType GetClaimType(int num)
        {
            switch(num)
            {
                case 1:
                    return ClaimType.Car;
                   
                case 2:
                    return ClaimType.Home;
                   
                case 3:
                    return ClaimType.Theft;
                default:
                    throw new Exception("Invalid entry need to enter 1,2, or 3");
            }
            
        }

        private void ProcessClaim()
        {
           
        }

        private void SeeAllClaims()
        {
            Queue<Claim> claims = claimsRepo.GetClaimQueue();
            Console.WriteLine("ClaimID\tType\tDescription\t\tAmount\tDateOfAccident\tDateOfClaim\tIsValid");
            while(claims.Count > 0)
            {
                Claim c = claims.Dequeue();
                Console.WriteLine($"{c.ClaimID}\t{c.Description}\t{c.ClaimAmount}\t{c.DateOfIncident}\t{c.DateOfClaim}\t{c.IsValid}");
            }


        }

        private string GetMenuOption()
        {
            throw new NotImplementedException();
        }

        private void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("1. See all claims");
            Console.WriteLine("2. Take care of next claim");
            Console.WriteLine("3. Enter a new claim");
            Console.WriteLine("4. Exit");

        }


    }
}
