using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepository
    {
        // protected - can only access ?
        protected readonly List<Claim> _contentClaims = new List<Claim>();
        //CRUD
        public bool AddClaim(Claim content)
        {
            int startingCount = _contentClaims.Count;
            _contentClaims.Add(content);
            bool wasAdded = (_contentClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Claim> GetContents()
        {
            return _contentClaims;
        }
    }
}
