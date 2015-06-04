using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Pronounce_3._0.Resources;
using Microsoft.Phone.Tasks;

namespace Pronounce_3._0
{
    public partial class MainPage : PhoneApplicationPage
    {
        string blankMessage;
        SpeakUp speaker;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            speaker = new SpeakUp();
            blankMessage = "Please put a word in the box to know its correct pronunciation";
           
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void button_in_Click(object sender, RoutedEventArgs e)
        {
            callSpeaker("india");
        }

        private void button_fr_Click(object sender, RoutedEventArgs e)
        {
            callSpeaker("france");
        }

        private void button_uk_Click(object sender, RoutedEventArgs e)
        {
            callSpeaker("uk");
        }

        private void button_usa_Click(object sender, RoutedEventArgs e)
        {
            callSpeaker("us");
        }
        
        private void callSpeaker(string country)
        {
            string toSpeak = pronounce_box.Text;
            if (toSpeak.ToUpper() == toSpeak)
            {
                speaker.cleanAll();
                speaker.speak(blankMessage, country);
            }
            else
            {
                speaker.cleanAll();
                speaker.speak(toSpeak, country);
            }
            
        }

        private void bar_rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();

        }

        private void bar_help_Click(object sender, EventArgs e)
        {
            String message = "Pronounce teaches you correct pronunciation of words in different accents.\nYou just need to type the word in the box and click the desired button with country name on it.\n\nPlease RATE the app if you liked it or give your suggestion by clicking feedback button at the bottom of the screen.";
            MessageBoxResult result =
      MessageBox.Show(message,
      "Help", MessageBoxButton.OK);
        }

        private void bar_feedback_Click(object sender, EventArgs e)
        {
            String sub = "Pronounce feedback/suggestions";
            String rec = "abhinavtripathi01@hotmail.com";
            String body = "Please enter your suggestions here.";
            String cc = "";
            String bcc = "";

            EMailLauncher.mailLaunch(sub, body, rec, cc, bcc);
        }
    }
}