using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class Badge
    {
        //Properties
        public int Number { get; set; }
        public List<string> DoorAccess { get; set; }
        //Method
        public string DisplayDoors(List<string> listOfDoors)
        {
            string doors = string.Join(" & ", listOfDoors);
            return doors;
        }
        public string DisplayDoorsWithComma(List<string> listOfDoors)
        {
            string doors = string.Join(" , ", listOfDoors);
            return doors;
        }
        //Constructors
        public Badge()
        {
        }
        public Badge(int number)
        {
            Number = number;
        }

        public Badge(int number, List<string> doorAccess)
        {
            Number = number;
            DoorAccess = doorAccess;
        }
    }
}
