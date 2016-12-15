using SpeedTyperLogicLayer;
using System.Windows;

namespace SpeedTyper
{
    /// <summary>
    /// Interaction logic for LeaderboardForm.xaml
    /// </summary>
    public partial class LeaderboardForm : Window
    {
        LeaderboardManager boardManager = null;
        public LeaderboardForm(RankManager rankManager)
        {
            boardManager = new LeaderboardManager(rankManager);
            InitializeComponent();
        }


        private void LoadLeaderboards()
        {
            try
            {
                var topResults = boardManager.RetrieveAllResultsLeaderboard();
                lvwAllResults.ItemsSource = topResults;

                var last90DaysResults = boardManager.RetrieveLast90DaysResultsLeaderboard();
                lvwLast90Days.ItemsSource = last90DaysResults;

                var last30DaysResults = boardManager.RetrieveLast30DaysResultsLeaderboard();
                lvwLast30Days.ItemsSource = last30DaysResults;

                var todaysResults = boardManager.RetrieveTodaysResultsLeaderboard();
                lvwToday.ItemsSource = todaysResults;

                var highestRankingMembers = boardManager.RetrieveHighestRankingMembers();
                lvwHighestRankingMembers.ItemsSource = highestRankingMembers;
            }
            catch
            {
                MessageWindow.Show(this, "Error:", "Unable to Load Leaderboards");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLeaderboards();
        }
    }
}
