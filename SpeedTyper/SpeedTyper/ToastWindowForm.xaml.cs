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
    /// Interaction logic for ToastWindowForm.xaml
    /// </summary>
    internal partial class ToastWindowForm : Window
    {
        internal ToastWindowForm(string title, string message, int rankID, RankManager rankManager)
        {
            InitializeComponent();
            this.Title = title;
            txtMessage.Text = message;
            imgRankIcon.Source = rankManager.RetrieveRankIcon(rankID);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }

    public static class ToastWindow
    {
        public static bool Show(Window owner, string title, string message, int rankID, RankManager rankManager)
        {
            ToastWindowForm toastWindow = new ToastWindowForm(title, message, rankID, rankManager);
            toastWindow.Owner = owner;
            toastWindow.ShowDialog();
            return (bool)toastWindow.DialogResult;
        }
    }
}
