using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class Badge
    {
        public int Number { get; set; }
        public List<string> DoorAccess { get; set; }

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
