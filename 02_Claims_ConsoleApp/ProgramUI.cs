using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_ConsoleApp
{
    public class ProgramUI
    {
        protected readonly ClaimRepository _claimsRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimsQueue();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item. \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press any key to continue...");
                        break;
                }

            }

        }
        private void ShowAllClaims()
        {
            Console.Clear();
            var header = String.Format("{0,-8}{1,8}{2,30}{3,15}{4,20}{5,20}{6,12}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid?");
            Console.WriteLine(header);
            Queue<InsuranceClaim> queueOfClaims = _claimsRepo.GetAllInsuranceClaims();
            foreach (InsuranceClaim claim in queueOfClaims)
            {
                DisplayAllClaims(claim);
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowNextClaim()
        {
            Console.Clear();
            Queue<InsuranceClaim> queueOfClaims = _claimsRepo.GetAllInsuranceClaims();
            var claim1 = queueOfClaims.Peek();
            DisplayOneClaim(claim1);
            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            string userYOrN = Console.ReadLine();
            switch (userYOrN.ToLower())
            {
                case "y":
                    queueOfClaims.Dequeue();
                    break;
                case "n":
                    Console.WriteLine("Okay, please return to main menu.");
                    break;
                default:
                    Console.WriteLine("You did not enter a valid response.");
                    break;
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
        private void CreateNewClaim()
        {
            Console.Clear();
            InsuranceClaim newClaim = new InsuranceClaim();
            //Claim ID
            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimId = Convert.ToInt32(Console.ReadLine());
            //Claim Type
            Console.WriteLine("Enter the Claim Type:");
            string claimTypeString = Console.ReadLine();
            switch (claimTypeString.ToLower())
            {
                case "car":
                case "auto":
                case "vehicle":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "home":
                case "house":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("You did not enter a valid type. Your response was not recorded.");
                    break;
            }
            //Description
            Console.WriteLine("Enter a Claim Description:");
            newClaim.Description = Console.ReadLine();
            //Amount
            Console.WriteLine("Amount of Damage:");
            decimal claimAmount = decimal.Parse(Console.ReadLine(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
            newClaim.ClaimAmount = claimAmount;
            //Date Of Accident
            Console.WriteLine("Date of Accident:");
            DateTime claimAccidentDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = claimAccidentDate;
            //Date of Claim
            Console.WriteLine("Date of Claim:");
            DateTime claimDate = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = claimDate;
            //The claim is valid
            if (newClaim.IsValid == true)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("This claim is not valid");
            }
            _claimsRepo.AddClaimToQueue(newClaim);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayOneClaim(InsuranceClaim claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimId} \n" +
                $"Type: {claim.ClaimType} \n" +
                $"Description: {claim.Description} \n" +
                $"Amount: ${claim.ClaimAmount} \n" +
                $"DateOfAccident: {claim.DateOfIncident:d} \n" +
                $"DateOfClaim: {claim.DateOfClaim:d} \n" +
                $"IsValid: {claim.IsValid}");
        }
        private void DisplayAllClaims(InsuranceClaim claim)
        {
            var output = String.Format("{0,-8}{1,8}{2,30}{3,15:C2}{4,20:d}{5,20:d}{6,12}", claim.ClaimId, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
            Console.WriteLine(output);
        }
        private void SeedClaimsQueue()
        {
            //Claim 1
            InsuranceClaim claim1 = new InsuranceClaim(1, ClaimType.Car, "Car accident on 465.", 400.00M, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            //Put 1 in Queue
            _claimsRepo.AddClaimToQueue(claim1);
            //Claim 2
            InsuranceClaim claim2 = new InsuranceClaim(2, ClaimType.Home, "House fire in kitchen.", 4000.00M, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            //Put 2 in Queue
            _claimsRepo.AddClaimToQueue(claim2);
            //Claim 3
            InsuranceClaim claim3 = new InsuranceClaim(3, ClaimType.Theft, "Stolen pancakes.", 4.00M, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));
            //Put 3 in Queue
            _claimsRepo.AddClaimToQueue(claim3);
        }
    }
}
