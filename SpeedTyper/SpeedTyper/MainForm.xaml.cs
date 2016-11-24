using SpeedTyperDataObjects;
using SpeedTyperLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        User _user = null;
        TestManager testManager = new TestManager();
        UserManager userManager = new UserManager();
        RankManager rankManager = new RankManager();
        LevelManager levelManager = new LevelManager();

        public MainForm(User user)
        {
            this._user = user;
            InitializeComponent();
        }

        private void setLabels()
        {
            lblCurrentUserName.Content = "Current User: " + _user.UserName;
            lblCurrentDisplayName.Content = "Display Name: " + _user.DisplayName;
            lblUserLevel.Content = "Level: " + _user.Level.ToString();
            double levelProgress = 0;
            double currentXP = 0;
            double xpToLevel = 0;
            try
            {
                if (_user.IsGuest == false)
                {
                    var previousLevelXPToLevel = levelManager.RetrieveXPForLevel(_user.Level);
                    if (_user.Level > 0)
                    {
                        currentXP = _user.CurrentXP - previousLevelXPToLevel;
                        if (_user.Level == Constants.MAXLEVEL)
                        {
                            xpToLevel = 1;
                        }
                        else
                        {
                            xpToLevel = _user.XPToLevel - previousLevelXPToLevel;
                        }
                    }
                    else
                    {
                        currentXP = _user.CurrentXP;
                        xpToLevel = _user.XPToLevel;
                    }
                    levelProgress = (currentXP / xpToLevel) * 100;
                    prgLevelProgress.Value = levelProgress;
                }
                lblLevelProgress.Content = currentXP.ToString() + " / " + xpToLevel.ToString();
            }
            catch (Exception)
            {
                MessageWindow.Show(this, "Error:", "Unable to set progress bar.");
            }
        }

        private void DisableFunctionsForGuest()
        {
            btnAccountSettings.IsEnabled = false;
            tabLast10Scores.Visibility = Visibility.Collapsed;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Top = this.Top;
            loginForm.Left = this.Left;
            loginForm.Show();
            this.Close();
        }

        private void btnTakeSpeedTest_Click(object sender, RoutedEventArgs e)
        {
            TestForm testForm = new TestForm(_user, userManager, testManager, levelManager, rankManager);
            testForm.Top = this.Top;
            testForm.Left = this.Left;
            testForm.Show();
            this.Close();
        }

        private void LoadTop10()
        {
            LeaderboardManager boardManager = new LeaderboardManager(rankManager);
            try
            {
                var top10Results = boardManager.RetrieveTop10Leaderboard();
                lvwTop10.ItemsSource = top10Results;


            }
            catch
            {
                MessageWindow.Show(this, "Error:", "Unable to Load Top 10");
            }
        }

        private void LoadLast10TestResults()
        {
            try
            {
                lvwLast10Scores.ItemsSource = testManager.GetUserLast10TestResults(_user.UserID);
            }
            catch
            {
                MessageWindow.Show(this, "Error:", "Unable to Load Last 10");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTop10();
            setLabels();
            if (_user.IsGuest == false)
            {
                LoadLast10TestResults();
                if (_user.RankID > 0)
                {
                    setRankImage();
                }
            }
            else
            {
                DisableFunctionsForGuest();
            }
        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            AccountManagementForm accountManagementForm = new AccountManagementForm(_user);
            accountManagementForm.Owner = this;
            accountManagementForm.ShowDialog();
            if (accountManagementForm.DialogResult == true)
            {
                _user = accountManagementForm.ReturnUser;
                setLabels();
                LoadTop10();
            }
        }

        private void setRankImage()
        {
            var userRank = _user.RankID;
            try
            {
                imgRankIcon.Source = rankManager.RetrieveRankIcon(userRank);
                imgRankIcon.ToolTip = rankManager.RetrieveUserRankName(userRank);
            }
            catch (Exception)
            {
                MessageWindow.Show(this, "Error:", "Unable to load rank image.");
            }
        }

        private void btnViewLeaderboards_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardForm leaderboardForm = new LeaderboardForm(rankManager);
            leaderboardForm.Owner = this;
            leaderboardForm.ShowDialog();
        }
    }
}
