using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceLib
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }

        public Badge(int num,List<string> doors)
        {
            this.BadgeID = num;
            this.DoorNames = doors;
        }

        public string GetDoors()
        {
            if (this.DoorNames.Count < 1)
                return "";
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in this.DoorNames)
                {
                    sb.Append(item).Append(",");
                }
                sb.Remove(sb.Length-1, 1);//remove trailing comma
                return sb.ToString();
            }
        }

        public void RemoveDoor(string name)
        {
            this.DoorNames.Remove(name);
        }

        public void AddDoor(string name)
        {
            this.DoorNames.Add(name);
        }
    }
}
