using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_ConsoleApp
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claimsRepo = new ClaimRepository();
        public void Run()
        { 
            var dataTable = SeedDataTable();
            foreach (DataColumn dataCol in dataTable.Columns)
            {
                Console.WriteLine("{0}\t", dataCol);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t ${3}\t {4}\t {5}\t {6}", dataRow[0], dataRow[1], dataRow[2], dataRow[3], dataRow[4], dataRow[5], dataRow[6]);
            }
            Console.ReadLine();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                //switch (userInput)
                //{
                //    case "1":
                //        Method1();
                //        break;
                //    case "2":
                //        Method2();
                //        break;
                //    case "3":
                //        Method3();
                //        break;
                //    case "4":
                //        continueToRun = false;
                //        break;
                //    default:
                //        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                //            "Press any key to continue");
                //        break;
                //}
            }

        }
        //private void DisplayClaims(DataTable claimsTable) 
        //{
        //    foreach(DataRow row in claimsTable.Rows)
        //    {
        //        string claimId = row["Claim ID"].ToString();
        //        string 

        //    }

        //}
        //private void ShowAllClaims()
        //{
        //    Console.Clear();
        //    Queue<InsuranceClaim> allInsuranceClaims = _claimsRepo.GetAllInsuranceClaims();

        //    foreach(InsuranceClaim claim in allInsuranceClaims)
        //    {
        //        DisplayClaims(claim);
        //    }
        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}
        public DataTable SeedDataTable()
        {
            //Create DataTable
            DataTable claimsTable = new DataTable("Insurance Claims");
            Queue<InsuranceClaim> claims = new Queue<InsuranceClaim>();

            //Create Columns
            claimsTable.Columns.Add("Claim ID", typeof(Int32));
            claimsTable.Columns.Add("Type", typeof(Enum));
            claimsTable.Columns.Add("Description", typeof(String));
            claimsTable.Columns.Add("Amount", typeof(Decimal));
            claimsTable.Columns.Add("Date Of Accident", typeof(DateTime));
            claimsTable.Columns.Add("Date Of Claim", typeof(DateTime));
            claimsTable.Columns.Add("Is Valid?", typeof(Boolean));
            //Create Rows
            //Claim 1
            InsuranceClaim claim1 = new InsuranceClaim();
            claimsTable.Rows.Add(claim1.ClaimId = 1, claim1.ClaimType = ClaimType.Car, claim1.Description = "Car accident on 465.", claim1.ClaimAmount = 400.00M, claim1.DateOfIncident = new DateTime(18, 4, 25), claim1.DateOfClaim = new DateTime(18, 4, 27), claim1.IsValid);
            //Put 1 in Queue
            claims.Enqueue(claim1);
            //Claim 2
            InsuranceClaim claim2 = new InsuranceClaim();
            claimsTable.Rows.Add(claim2.ClaimId = 2, claim2.ClaimType = ClaimType.Home, claim2.Description = "House fire in kitchen.", claim2.ClaimAmount = 4000.00M, claim2.DateOfIncident = new DateTime(18, 4, 11), claim2.DateOfClaim = new DateTime(18, 4, 12), claim2.IsValid);
            //Put 2 in Queue
            claims.Enqueue(claim2);
            //Claim 3
            InsuranceClaim claim3 = new InsuranceClaim();
            claimsTable.Rows.Add(claim3.ClaimId = 3, claim3.ClaimType = ClaimType.Theft, claim3.Description = "Stolen pancakes.", claim3.ClaimAmount = 4.00M, claim3.DateOfIncident = new DateTime(18, 4, 27), claim3.DateOfClaim = new DateTime(18, 6, 01), claim3.IsValid);
            //Put 3 in Queue
            claims.Enqueue(claim3);

            return claimsTable;
        }
    }
}
