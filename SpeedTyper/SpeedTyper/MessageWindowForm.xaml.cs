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
    /// Interaction logic for MessageBoxForm.xaml
    /// </summary>
    /// 
    public enum MessageBoxType { OK, OKCANCEL, YESNO };

    internal partial class MessageWindowForm : Window
    {
        internal MessageWindowForm(string title, string message, MessageBoxType messageType)
        {
            InitializeComponent();
            this.Title = title;
            this.txtMessage.Text = message;
            switch (messageType)
            {
                case MessageBoxType.OK:
                    btnAccept.Visibility = Visibility.Visible;
                    btnAccept.Content = "OK";
                    break;
                case MessageBoxType.OKCANCEL:
                    btnAccept.Visibility = Visibility.Visible;
                    btnAccept.Content = "OK";
                    btnCancel.Visibility = Visibility.Visible;
                    btnCancel.Content = "Cancel";
                    break;
                case MessageBoxType.YESNO:
                    btnAccept.Visibility = Visibility.Visible;
                    btnAccept.Content = "Yes";
                    btnCancel.Visibility = Visibility.Visible;
                    btnCancel.Content = "No";
                    break;
                default:
                    break;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If the user closes the window with the X button, the window will return a false DialogResult
            // Since a true DialogResult will also trigger this event, we have make sure it's not already set to true
            if (this.DialogResult != true)
            {
                this.DialogResult = false;
            }
        }
    }
    public static class MessageWindow
    {
        
        public static bool Show (Window owner, string title, string message, MessageBoxType messageType = MessageBoxType.OK)
        {
            MessageWindowForm messageBoxForm = new MessageWindowForm(title, message, messageType);
            messageBoxForm.Owner = owner;
            messageBoxForm.ShowDialog();
            return (bool)messageBoxForm.DialogResult;
        }


    }
}
