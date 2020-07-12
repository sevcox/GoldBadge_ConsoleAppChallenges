using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimRepository
    {
        protected readonly Queue<InsuranceClaim> _claimdirectory = new Queue<InsuranceClaim>();
        //CRUD
        // See all claims
        public Queue<InsuranceClaim> GetAllInsuranceClaims()
        {
            return _claimdirectory;
        }
        //Take care of next claim
        //Enter a new claim
    }
}
