using SpeedTyperDataObjects;
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
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private User _user = null;
        public MainForm(User user)
        {
            this._user = user;
            InitializeComponent();
            setLabels();
            if (_user.IsGuest)
            {
                DisableFunctionsForGuest();
            }
        }

        private void setLabels()
        {
            lblCurrentUserName.Content += _user.UserName;
            lblCurrentDisplayName.Content += _user.DisplayName;
            lblUserLevel.Content += _user.Level.ToString();
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
            testForm.Owner = this;
            testForm.Show();
            this.Hide();
        }
    }
}
