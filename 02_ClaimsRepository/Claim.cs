using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claim
    {

        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan timespan = DateOfClaim - DateOfIncident;
                if (timespan.Days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }   
        public Claim() { }

        public Claim(int claimId, ClaimType claimType, string claimDescription, DateTime dateOfIncident, DateTime dateOfClaim)
            {
                ClaimId = claimId;
                ClaimType = claimType;
                ClaimDescription = claimDescription;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
            }

        

    }
}
