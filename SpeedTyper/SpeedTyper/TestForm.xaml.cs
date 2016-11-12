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
using System.Windows.Threading;

namespace SpeedTyper
{
    /// <summary>
    /// Interaction logic for TestForm.xaml
    /// </summary>
    public partial class TestForm : Window
    {
        private DispatcherTimer startTestTimer;
        private const int TimerCountdown = 5; // No magic numbers!
        private int timeLeft; 
        private bool testInProgress = false;
        User _user;
        public TestForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if(testInProgress == false)
            {
                timeLeft = TimerCountdown; // Start a new timer based off constant
                startTestTimer = new DispatcherTimer();
                startTestTimer.Tick += new EventHandler(startTestTimer_Tick);
                startTestTimer.Interval = new TimeSpan(0,0,1); // Ticks every 1 second.
                startTestTimer.Start();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void startTestTimer_Tick(object sender, EventArgs e)
        {
            if(timeLeft == 0)
            {
                txtTextEntryBox.Clear();
                txtTextEntryBox.IsEnabled = true;
                btnStart.IsEnabled = false;
                startTestTimer.Stop();
                
            }
            else
            {
                txtTextEntryBox.Text = "Test Starting In..." + timeLeft;
            }
            timeLeft--;
        }
    }
}
