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
    }
}