using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, Badge> _badgeNumberAndDoorAccess = new Dictionary<int, Badge>();
        private readonly List<string> _doorAccess = new List<string>();
        public bool AddBadgeToDictionary(Badge badge)
        {
            int startingCount = _badgeNumberAndDoorAccess.Count;
            _badgeNumberAndDoorAccess.Add(badge.Number, badge);
            bool wasAdded = (_badgeNumberAndDoorAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, Badge> ReturnBadgeDictionary()
        {
            return _badgeNumberAndDoorAccess;
        }
        public Badge GetBadgeByNumber(int badgeNumber)
        {
            Badge badge = _badgeNumberAndDoorAccess[badgeNumber];
            if (badge != null)
            {
                return badge;
            }
            return null;
        }
        public bool AddADoorToBadge(Badge badge, string doorNumber)
        {
            Badge oldBadge = GetBadgeByNumber(badge.Number);
           int startingCount = oldBadge.DoorAccess.Count();
            List<string> doors = oldBadge.DoorAccess;
            doors.Add(doorNumber);
            bool wasAdded = (oldBadge.DoorAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool RemoveADoorFromBadge (Badge badge, string doorNumber)
        {
            Badge oldBadge = GetBadgeByNumber(badge.Number);
            int startingCount = oldBadge.DoorAccess.Count();
            List<string> doors = oldBadge.DoorAccess;
            doors.Remove(doorNumber);
            bool wasRemoved = (oldBadge.DoorAccess.Count < startingCount) ? true : false;
            return wasRemoved;
        }
        public bool UpdateExistingBadge(int badgeNumber, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByNumber(badgeNumber);
            if(oldBadge != null)
            {
                oldBadge.Number = newBadge.Number;
                oldBadge.DoorAccess = newBadge.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
