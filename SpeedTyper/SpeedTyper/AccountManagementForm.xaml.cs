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
    /// Interaction logic for AccountManagementForm.xaml
    /// </summary>
    public partial class AccountManagementForm : Window
    {
        public User ReturnUser { get; private set; }

        private User _user;
        public AccountManagementForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void btnUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            var displayName = txtDisplayName.Text;
            var oldPassword = txtOldPassword.Password;
            var newPassword = txtNewPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;
            var usrMgr = new UserManager();


            if (displayName.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a display name!");
                return;
            }
            if (oldPassword.Equals(""))
            {
                MessageWindow.Show(this, "Error:", "You must enter a password!");
                return;
            }
            if (oldPassword.Equals(newPassword))
            {
                MessageWindow.Show(this, "Error:", "Your new password must be different from your old password!");
                return;
            }
            if (!newPassword.Equals(confirmPassword))
            {
                MessageWindow.Show(this, "Error:", "Your passwords must match!");
                return;
            }
            if (newPassword.Equals(""))
            {
                newPassword = txtOldPassword.Password;
            }

            try
            {
                _user = usrMgr.AuthenticateUser(_user.UserName, oldPassword);
                ReturnUser = usrMgr.UpdateUser(_user.UserID, _user.DisplayName, displayName, oldPassword, newPassword);
                MessageWindow.Show(this, "Success:", "Account successfully updated!");
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
            Title = "Account Management: " + _user.UserName;
            txtDisplayName.Text = _user.DisplayName;
        }
    }
}
