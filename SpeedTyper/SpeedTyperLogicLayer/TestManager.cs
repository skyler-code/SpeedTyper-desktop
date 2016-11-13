using SpeedTyperDataAccess;
using SpeedTyperDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperLogicLayer
{
    public class TestManager
    {

        public string SecondsToTimeSpanFormatter(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);

            return string.Format("{0:D2}:{1:D2}",
                            t.Minutes,
                            t.Seconds);
        }

        public string TicksToTimeSpanFormatter(Int64 ticks)
        {
            TimeSpan t = TimeSpan.FromTicks(ticks);

            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
        }

        public TestData RetrieveRandomTest()
        {
            TestData testData = null;

            try
            {
                testData = TestAccessor.RetrieveRandomTest();
            }
            catch (Exception)
            {
                throw;
            }

            return testData;
        }
    }
}
