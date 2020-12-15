using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodClaimsLib
{
    public class ClaimsRepo
    {
        private Queue<Claim> claimRepo = new Queue<Claim>();

        public ClaimsRepo() { }




        //Create
        public void AddClaimToQueue(Claim c)
        {
            claimRepo.Enqueue(c);
        }

        



        //Read
        public Queue<Claim> GetClaimQueue()
        {
            return claimRepo;
        }

        



        //Update
        public Claim ProcessClaim(string input)
        {
            if (input.ToLower() == "y")
            {
                return claimRepo.Dequeue();
            }
            else
                return null;
        }



        //Delete
    }
}
