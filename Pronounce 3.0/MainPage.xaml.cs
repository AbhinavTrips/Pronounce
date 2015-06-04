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
        int[] langBool;
        SpeakUp speaker;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            langBool = new int[4];
            speaker = new SpeakUp();
           
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void button_in_Click(object sender, RoutedEventArgs e)
        {

            // speaker = new SpeakUp();
            string toSpeak = pronounce_box.Text;
            speaker.cleanAll();
            speaker.speak(toSpeak, "india");
        }

        private void button_fr_Click(object sender, RoutedEventArgs e)
        {
            string toSpeak = pronounce_box.Text;
            speaker.cleanAll();
            speaker.speak(toSpeak, "france");
        }

        private void button_uk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_usa_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}