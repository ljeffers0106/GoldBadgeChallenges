using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepository
    {
        //Define dictionary
        public Dictionary<int, string> _badgeLookup = new Dictionary<int, string>()
        {
        };
        // add a new badge and room list
        public bool AddBadge(int badgeNumber, string roomString)
        {
            int startingCount = _badgeLookup.Count;
            _badgeLookup.Add(badgeNumber, roomString);
            bool wasAdded = (_badgeLookup.Count > startingCount);
            return wasAdded;
        }
        // remove a badge from the dictionary
        public bool RemoveBadge(int badgeNumber)
        {
            int startingCount = _badgeLookup.Count;
            _badgeLookup.Remove(badgeNumber);
            bool wasRemoved = (_badgeLookup.Count > startingCount) ? true : false;
            return wasRemoved;
        }
        // get badge doors aka rooms
        public string GetBadgeRooms(int numberOfBadge)
        {
            string roomStringValue;
            _badgeLookup.TryGetValue(numberOfBadge, out roomStringValue);
            return roomStringValue;
        }
        public int GetBadgeCount()
        {
            int badgeCount = _badgeLookup.Count;
            return badgeCount;
        }
        public int GetBadge(int index)
        {
            int actualBadge = _badgeLookup.ElementAt(index).Key;
            return actualBadge;
        }
    }
}
