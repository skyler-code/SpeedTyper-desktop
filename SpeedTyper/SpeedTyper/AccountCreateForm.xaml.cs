using SpeedTyperDataObjects;
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
    /// Interaction logic for AccountCreateForm.xaml
    /// </summary>
    public partial class AccountCreateForm : Window
    {
        public AccountCreateForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUserName.Text;
            var displayname = txtDisplayName.Text;
            var password = txtPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;
            var usrMgr = new UserManager();

            if(username.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a user name!");
                return;
            }
            if(displayname.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a display name!");
                return;
            }
            if(password.Equals("") || confirmPassword.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a password!");
                return;
            }
            if (!password.Equals(confirmPassword))
            {
                MessageWindow.Show(this, "Error:", "Your passwords must match!");
                return;
            }
            try
            {
                User user = usrMgr.CreateUser(username, displayname, password);
                MessageWindow.Show(this, "Success:", "Account successfully created!");
                MainForm mainForm = new MainForm(user);
                mainForm.Top = this.Top;
                mainForm.Left = this.Left;
                mainForm.Show();
                this.DialogResult = true;
                
            }
            catch (Exception ex)
            {
                MessageWindow.Show(this, "Account creation failed:", ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
