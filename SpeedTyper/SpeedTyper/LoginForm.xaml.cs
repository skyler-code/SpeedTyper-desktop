using SpeedTyperDataObjects;
using SpeedTyperLogicLayer;
using System;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeedTyper
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var usrMgr = new UserManager();
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
                var mainForm = new MainForm(user);
                mainForm.Show();
                this.Close();
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
                this.Close();
                accountCreateForm.Close();
            }
            else
            {
                accountCreateForm.Close();
            }
        }
        
    }
}
