using ClaimsApp.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimApp.Repository
{
    public class ClaimRepository
    {
        //create fake database
        private readonly Queue<Claims> _claimsDatabase = new Queue<Claims>();

        public bool AddClaim(Claims claims)
        {
            if (claims is null)
            {
                return false;
            }

            
            _claimsDatabase.Enqueue(claims);
            return true;
        }

        public Queue<Claims> GetClaims()
        {
            return _claimsDatabase;
        }

        public Claims GetClaimByID(string id)
        {
            foreach (var claim in _claimsDatabase)
            {
                if (claim.ClaimID==id)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
