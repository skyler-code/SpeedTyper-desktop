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
            if (_user.XPToLevel != 0) // Can't divide by 0!
            {
                levelProgress = ((double)_user.CurrentXP / (double)_user.XPToLevel) * 100;
            }
            prgLevelProgress.Value = levelProgress;
            lblLevelProgress.Content = _user.CurrentXP.ToString() + " / " + _user.XPToLevel.ToString();
        }

        private void DisableFunctionsForGuest()
        {
            btnViewAchievements.IsEnabled = false;
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
            TestForm testForm = new TestForm(_user);
            testForm.Top = this.Top;
            testForm.Left = this.Left;
            testForm.Show();
            this.Close();
        }

        private void LoadTop10()
        {
            try
            {
                lvwTop10.ItemsSource = testManager.GetTop10TestResults();
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
            }
        }

        private void setRankImage()
        {
            var userRank = _user.RankID;
            string fileName;
            if (userRank < 10)
            {
                fileName = "Rank0" + userRank;
            }
            else
            {
                fileName = "Rank" + userRank;
            }
            imgRankIcon.BeginInit();
            imgRankIcon.Source = (ImageSource)FindResource(fileName);
            imgRankIcon.Stretch = Stretch.Fill;
            imgRankIcon.ToolTip = userManager.RetrieveUserRankName(userRank);
            imgRankIcon.EndInit();
        }
    }
}
