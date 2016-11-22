using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SpeedTyperDataObjects
{
    public class LeaderboardItem
    {
        public ImageSource RankIcon { get; set; }
        public string RankName { get; set; }
        public string DisplayName { get; set;}
        public decimal WPM { get; set; }
        public string Date { get; set; }
    }
}
