using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperDataObjects
{
    class TestResults
    {
        public int TestResultID { get; set; }
        public int UserID { get; set; }
        public int WPM { get; set; }
        public int Errors { get; set; }
        public Int64 TimeSpanTicks { get; set; }
        public DateTime Date { get; set; }
    }
}
