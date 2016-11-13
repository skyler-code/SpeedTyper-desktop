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
using System.Windows.Threading;

namespace SpeedTyper
{
    /// <summary>
    /// Interaction logic for TestForm.xaml
    /// </summary>
    public partial class TestForm : Window
    {
        private const int StartTimerCountdown = 5; // Test will start after 5 seconds
        private const int EndTimerCountdown = 120; // Test will end after 2 minutes.

        private DispatcherTimer beginTestTimer;
        private DispatcherTimer timeElapsedTimer; // This timer tracks how long the test has been.
        
        private int timeLeftUntilTestStart;
        private int secondsLeft; // int of seconds the user has left to complete test
        private int secondsElapsed; // int of seconds the user has been taking test
        private bool testInProgress = false;
        private TestData testData;

        User _user;
        TestManager testManager;
        public TestForm(User user)
        {
            _user = user;
            testManager = new TestManager();
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
                btnStart.IsEnabled = false;
                timeLeftUntilTestStart = StartTimerCountdown; // Start a new timer based off constant
                beginTestTimer = new DispatcherTimer();
                beginTestTimer.Tick += new EventHandler(beginTestTimer_Tick);
                beginTestTimer.Interval = new TimeSpan(0, 0, 1); // Ticks every 1 second.
                beginTestTimer.Start();
        }



        private void beginTestTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeftUntilTestStart == 0)
            {
                beginTestTimer.Stop();
                StartTest();
            }
            else
            {
                txtTextEntryBox.Text = "Test Starting In..." + timeLeftUntilTestStart;
            }
            timeLeftUntilTestStart--;
        }

        private void StartTest()
        {
            // Start the test
            testInProgress = true;
            txtTextEntryBox.Clear();
            txtTextEntryBox.IsEnabled = true;
            try
            {
                testData = testManager.RetrieveRandomTest();
            }
            catch (Exception ex)
            {
                MessageWindow.Show(this, "Error:", ex.Message);
            }
            
            txtTestData.Text = testData.TestDataText; // DEV TEST

            timeElapsedTimer = new DispatcherTimer();
            timeElapsedTimer.Tick += new EventHandler(timeElapsedTimer_Tick);
            timeElapsedTimer.Interval = new TimeSpan(0, 0, 1); // Ticks every 1 ms.
            timeElapsedTimer.Start();
            secondsLeft = EndTimerCountdown;
            secondsElapsed = 0;
            lblTimeLeft.Content = testManager.SecondsToTimeSpanFormatter(secondsLeft);
        }

        private void EndTest()
        {
            testInProgress = false;
            txtTextEntryBox.Clear();
            txtTextEntryBox.IsEnabled = false;
            btnStart.IsEnabled = true;
        }

        private void timeElapsedTimer_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            secondsElapsed++;
            lblTimeLeft.Content = testManager.SecondsToTimeSpanFormatter(secondsLeft);
            if(secondsLeft == 0)
            {
                timeElapsedTimer.Stop();
                EndTest();
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void txtTextEntryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (testInProgress)
            {
                txtTestData.Text = txtTextEntryBox.Text;
            }
        }
    }
}
