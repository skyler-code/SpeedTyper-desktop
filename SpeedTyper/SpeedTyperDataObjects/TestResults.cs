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
        public TimeSpan Time { get; set; }
        public DateTime DateTimeTaken { get; set; }
    }
}
