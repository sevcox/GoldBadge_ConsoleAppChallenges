using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeNumberAndDoorAccess = new Dictionary<int, List<string>>();
        private readonly List<string> _doorAccess = new List<string>();
        public bool AddBadgeToDictionary(Badge badge)
        {
            int startingCount = _badgeNumberAndDoorAccess.Count;
            _badgeNumberAndDoorAccess.Add(badge.Number, badge.DoorAccess);
            bool wasAdded = (_badgeNumberAndDoorAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int,List<string>> ReturnBadgeDictionary()
        {
            return _badgeNumberAndDoorAccess;
        }
        //public Badge GetBadgeByNumber (int number)
        //{
        //    foreach(Badge badge in _badgeNumberAndDoorAccess)
        //    {
               
        //    }
        //}

    }
}
