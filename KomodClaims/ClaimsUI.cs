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
            Claim a = new Claim(1, ClaimType.Car, "A very good car", 325.23, DateTime.Now, DateTime.Now, true);
            Claim b = new Claim(2, ClaimType.Home, "home insurance", 1325.23, DateTime.Now, DateTime.Now, true);
            Claim c = new Claim(3, ClaimType.Theft, "theft insurace is good", 11325.23, DateTime.Now, DateTime.Now, false);
            claimsRepo.AddClaimToQueue(a);
            claimsRepo.AddClaimToQueue(b);
            claimsRepo.AddClaimToQueue(c);

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

            Console.WriteLine("Please enter the date of accident as month day, year ex: Jan 1, 2009 ");
            var incident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of claim as month day, year ex: Jan 1, 2009 ");
            var claimdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter if the claim is valid true or false");
            bool valid = bool.Parse(Console.ReadLine());

            Claim claim = new Claim(id, theType, desc, amount, incident,claimdate, valid);
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
            Queue<Claim> claims = claimsRepo.GetClaimQueue();
            bool processClaim = true;
            if(claims.Count>0)
            {
                while(processClaim)
                {
                    Claim c = claims.Peek();
                    DisplayClaim(c);
                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    string input = Console.ReadLine();
                    if(input == "y")
                    {
                        Claim temp = claimsRepo.ProcessClaim();
                        Console.WriteLine($"Claim {temp.ClaimID} has been processed and removed.");
                        Console.WriteLine("Please press any key to continue...");
                        Console.ReadKey();

                    }
                    if(input == "n")
                    {
                        processClaim = false;
                    }
                }
                
            }
           
        }

        private void DisplayClaim(Claim c)
        {
            Console.Clear();
            Console.WriteLine($"ClaimID: {c.ClaimID}");
            Console.WriteLine($"Type: {c.Claimtype}");
            Console.WriteLine($"Description: {c.Description}");
            Console.WriteLine($"Amount: {c.ClaimAmount}");
            Console.WriteLine($"DateOfAccident: {c.DateOfIncident.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"DateOfClaim: {c.DateOfClaim.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"IsValid: {c.IsValid}");
        }

        private void SeeAllClaims()
        {
            Queue<Claim> claims = claimsRepo.GetClaimQueue();
            IEnumerator<Claim> enumerator = claims.GetEnumerator();

            Console.WriteLine("ClaimID\tType\t\tDescription\tAmount\t\tDateOfAccident\tDateOfClaim\tIsValid");
            while(enumerator.MoveNext())
            {
                Claim c = enumerator.Current;
                Console.WriteLine($"{c.ClaimID}\t{c.Claimtype}\t\t{c.Description}\t{c.ClaimAmount}\t\t{c.DateOfIncident.ToString("MM/dd/yyyy")}\t{c.DateOfClaim.ToString("MM/dd/yyyy")}\t{c.IsValid}".PadLeft(5));
            }


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
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("1. See all claims");
            Console.WriteLine("2. Take care of next claim");
            Console.WriteLine("3. Enter a new claim");
            Console.WriteLine("4. Exit");

        }


    }
}
