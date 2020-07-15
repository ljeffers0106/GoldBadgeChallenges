using _02_Claims;
using System;
using System.Collections;
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
        //Queue<int> idNumber = new Queue<int>();
        Queue<Claim> claimsQueue = new Queue<Claim>();

        //CRUD
        public bool AddClaim(Claim content)
        {
            int startingCount = _contentClaims.Count;
            _contentClaims.Add(content);
            bool wasAdded = (_contentClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }
        // GetContents was replaced with read of Queue claims - left it in case needed later
        public Queue<Claim> GetContents()
        {
            return claimsQueue;
        }
        public Claim GetContentByClaimId(int numberId)
        {
            foreach (Claim content in claimsQueue)
            {
                if (content.ClaimId == numberId)
                {
                    return content;
                }

            }
            return null;
        }
        public void AddClaimQueue(Claim information)
        {
            claimsQueue.Enqueue(information);
        }
        public void RemoveClaimQueue()
        {
            claimsQueue.Dequeue();
        }
    }
}
