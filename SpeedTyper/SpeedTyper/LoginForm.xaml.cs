using SpeedTyperDataObjects;
using SpeedTyperLogicLayer;
using System;
using System.Windows;

namespace SpeedTyper
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        UserManager usrMgr = new UserManager();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;

            User user;

            if (username.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a username!");
                txtUsername.Focus();
                return;
            }
            if (password.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a password!");
                txtPassword.Focus();
                return;
            }

            try
            {
                user = usrMgr.AuthenticateUser(username, password);
                if (chkSaveLogin.IsChecked == true)
                {
                    Properties.Settings.Default.Username = username;
                }
                else
                {
                    Properties.Settings.Default.Username = "";
                }
                Properties.Settings.Default.Save();
                OpenMainForm(user);
            }
            catch (Exception ex)
            {
                MessageWindow.Show(this, "Error:", ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Properties.Settings.Default.Username.Equals(""))
            {
                this.txtUsername.Text = Properties.Settings.Default.Username;
                this.chkSaveLogin.IsChecked = true;
                this.txtPassword.Focus();
            }
            else
            {
                this.txtUsername.Focus();
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountCreateForm accountCreateForm = new AccountCreateForm();
            accountCreateForm.Owner = this;
            accountCreateForm.ShowDialog();
            if (accountCreateForm.DialogResult == true)
            {
                OpenMainForm(accountCreateForm.ReturnUser);
            }
        }

        private void btnContinueAsGuest_Click(object sender, RoutedEventArgs e)
        {
            OpenMainForm(usrMgr.CreateGuestUser());
        }

        private void OpenMainForm(User user)
        {
            var mainForm = new MainForm(user);
            mainForm.Top = this.Top;
            mainForm.Left = this.Left;
            mainForm.Show();
            this.Close();
        }
    }
}
