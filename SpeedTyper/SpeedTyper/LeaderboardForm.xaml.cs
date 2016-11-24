using SpeedTyperLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
