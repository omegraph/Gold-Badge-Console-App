using ClaimsApp.POCOs.ClaimType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsApp.POCOs
{
    public class Claims
    {
        public string ClaimID { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        //enum to represent Claim Type
        public Claim_Type ClaimType { get; set; }


        //Empty Constructor
        public Claims()
        {

        }

        //Constructor with properties
        public Claims(Claim_Type claimType, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }
    }



}
