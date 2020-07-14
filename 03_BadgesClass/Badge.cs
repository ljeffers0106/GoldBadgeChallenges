using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges

{
    public class Badge
    {
        public int BadgeNumber { get; set; }
        public string RoomList { get; set; }

        public Badge() { }

        public Badge(int badgeNumber, string roomList)
        {
            BadgeNumber = badgeNumber;
            RoomList = roomList;
        }
    }
}
