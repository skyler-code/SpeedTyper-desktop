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

        public TestResult SaveTestResults(int userID, decimal WPM, int secondsElapsed)
        {
            TestResult testResult = null;
            try
            {
                var testID = TestAccessor.SaveTestResults(userID, WPM, secondsElapsed);
                testResult = TestAccessor.RetrieveTestResultsByID(testID);
            }
            catch (Exception)
            {
                throw;
            }
            return testResult;
        }

        public decimal CalculateWPM(List<String> correctWords, decimal secondsElapsed)
        {
            decimal wpm = 0;
            var typedEntries = string.Join("", correctWords.ToArray());
            var minutesElapsed = secondsElapsed * (1m / 60m);
            if (minutesElapsed > 0) // Can't divide by zero so we'll wait a second before we do anything.
            {
                wpm = Math.Round((typedEntries.Length / 5) / minutesElapsed, 2);
            }
            return wpm;
        }

        public List<TestResult> GetTop10TestResults()
        {
            List<TestResult> top10Tests = null;

            try
            {
                top10Tests = TestAccessor.RetrieveTop10TestResults();
            }
            catch (Exception)
            {
                throw;
            }

            return top10Tests;
        }
    }
}
