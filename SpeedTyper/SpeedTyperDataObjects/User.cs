using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperDataObjects
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public int RankID { get; set; }
        public int Level { get; set; }
        public int CurrentXP { get; set; }
        public int XPToLevel { get; set; }
        public bool IsGuest { get; set; }
    }
}
