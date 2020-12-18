using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceLib
{
    public class BadgeRepo
    {
        public Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();



        //create a new badge
        public void AddNewBadge(int id,Badge badge)
        {
            badgeRepo.Add(id, badge);
        }

        //create a new badge
        public void AddNewBadge(Badge badge)
        {
            badgeRepo.Add(badge.BadgeID, badge);
        }



        //update doors on existing badge
        public bool UpdateDoor(string door,Badge bad)
        {
            List<string> doors = bad.DoorNames;
            foreach(string name in doors)
            {
                if (name == door)
                {
                    doors.Remove(name);
                    return true;
                }
            }
            return false;
        }

        public void UpdateBadge(Badge b,string input,string doorName)
        {
            if (input == "1")
            {
                b.AddDoor(doorName);
            }
            else if (input == "2")
            {
                b.RemoveDoor(doorName);
            }
        }



        //delete all doors from existing badge
        public bool DeleteAllDoorsFromBagde(Badge bad)
        {
            bad.DoorNames.Clear();
            return true;
        }



        //show a list with all badge numbers and door access
        public Dictionary<int,Badge> GetAllBadges()
        {
            return badgeRepo;
        }


        public Badge GetBadge(string badgeNum)
        {
            try
            {
                int bnum = int.Parse(badgeNum);
                Badge b = badgeRepo[bnum];
                return b;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public int Count()
        {
            return badgeRepo.Count;
        }


        
    }
}
