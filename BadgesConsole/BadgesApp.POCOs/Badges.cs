
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesApp.POCOs
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorName{ get; set; }

        public Badges()
        {

        }

        public Badges(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

    }
}
