using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodClaimsLib
{
   public enum ClaimType { Car,Home,Theft}

    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType Claimtype { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int id,ClaimType type, string descr,double amount,DateTime incident,DateTime claim,bool isvalid)
        {
            this.ClaimID = id;
            this.Claimtype = type;
            this.Description = descr;
            this.ClaimAmount = amount;
            this.DateOfIncident = incident;
            this.DateOfClaim = claim;
            this.IsValid = isvalid;
        }


    }
}
