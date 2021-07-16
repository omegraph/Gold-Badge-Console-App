using BadgesApp.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesApp.Repository
{
    public class BadgesRepository
    {
        private List<Badges> _listOfBadges = new List<Badges>();

        public Dictionary<int, List<string>> badgesDictionary = new Dictionary<int, List<string>>();


        //Create
        public void AddNewBadgeToList(Badges badges)
        {
            _listOfBadges.Add(badges);
            badgesDictionary.Add(badges.BadgeID, badges.DoorName);
        }

        //Read
        public Dictionary<int, List<string>> GetBadgesDictionary()
        {
            return badgesDictionary;
        }

        //Update
        public bool UpdateExistingBadge(int badgeID, Badges newBadgeData)
        {
            Badges oldBadgeData = GetBadgesByID(badgeID);
            if (oldBadgeData is null)
            {
                return false;
            }
            oldBadgeData.BadgeID = newBadgeData.BadgeID;
            oldBadgeData.DoorName = newBadgeData.DoorName;
            badgesDictionary.Add(newBadgeData.BadgeID, newBadgeData.DoorName);
            return true;
        }

        //Delete
        public bool DeleteExistingBadge(int badgeID)
        {
            Badges deleteBadge = GetBadgesByID(badgeID);
            if (deleteBadge is null)
            {
                return false;
            }
            int initialCount = badgesDictionary.Count;
            _listOfBadges.Remove(deleteBadge);
            badgesDictionary.Remove(deleteBadge.BadgeID);
            if (initialCount > badgesDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //get badge by id (Helper method)
        public Badges GetBadgesByID(int badgeNumber)
        {
            foreach (Badges badges in _listOfBadges)
            {
                if (badges.BadgeID == badgeNumber)
                {
                    return badges;
                }
            }
            return null;
        }

    }
}
