using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_ConsoleApp
{
    public class ProgramUI
    {
        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
   
        }
        public void SeedDataTable()
        {
            DataTable claimsTable = new DataTable();
            InsuranceClaim claim = new InsuranceClaim();
            claimsTable.Clear();
            claimsTable.Columns.Add("Claim ID");
            claimsTable.Columns.Add("Type");
            claimsTable.Columns.Add("Description");
            claimsTable.Columns.Add("Amount");
            claimsTable.Columns.Add("Date Of Accident");
            claimsTable.Columns.Add("Date Of Claim");
            claimsTable.Columns.Add("Is Valid?");


        }
    }
}
