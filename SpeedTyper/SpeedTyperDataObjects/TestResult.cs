using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperDataObjects
{
    public class TestResult
    {
        public int TestResultID { get; set; }

        public string DisplayName { get; set; }
        public int UserID { get; set; }
        public decimal WPM { get; set; }
        public int SecondsElapsed { get; set; }
        public string Date { get; set; }
    }
}
