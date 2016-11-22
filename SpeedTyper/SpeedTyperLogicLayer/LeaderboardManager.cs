using SpeedTyperDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperLogicLayer
{
    public class LeaderboardManager
    {
        private TestManager _testManager = new TestManager();
        private RankManager _rankManager = new RankManager();

        public LeaderboardManager(TestManager testManager, RankManager rankManager)
        {
            _testManager = testManager;
            _rankManager = rankManager;
        }
        public List<LeaderboardItem> RetrieveTop10Leaderboard()
        {
            var _returnBoard = new List<LeaderboardItem>();

            var top10Results = _testManager.GetTop10TestResults();

            foreach(TestResult t in top10Results)
            {
                _returnBoard.Add(new LeaderboardItem()
                {
                    RankIcon = _rankManager.RetrieveRankIcon(t.RankID),
                    RankName = _rankManager.RetrieveUserRankName(t.RankID),
                    DisplayName = t.DisplayName,
                    WPM = t.WPM,
                    Date = t.Date
                });
            }
            return _returnBoard;
        }

    }
}
