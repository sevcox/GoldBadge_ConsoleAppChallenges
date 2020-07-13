using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimRepository
    {
        protected readonly Queue<InsuranceClaim> _claims = new Queue<InsuranceClaim>();
        //CRUD
        //Add claim to queue
        public bool AddClaimToQueue(InsuranceClaim claim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(claim);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }
        // See all claims
        public Queue<InsuranceClaim> GetAllInsuranceClaims()
        {
            return _claims;
        }
    }
}
