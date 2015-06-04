using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Phone.Speech.Synthesis;
using Windows.UI.Popups; 

namespace Pronounce_3._0
{
    class SpeakUp
    {
        private string language;
        private SpeechSynthesizer synth = new SpeechSynthesizer();
        public SpeakUp(string lang)
        {
            this.language = lang;
        }

        public SpeakUp()
        {

        }

        public async void speak(string text, string lang)
        {
            this.language = lang;
            IEnumerable<VoiceInformation> voices = from voice in InstalledVoices.All
                             where voice.Language == "en-US"
                             select voice;
            switch (language)
            {
                case "france":
                    if (isLanguageInstalled("fr-FR")) {
                    // Query for a voice that speaks French.
                    voices = from voice in InstalledVoices.All
                             where voice.Language == "fr-FR"
                             select voice;
                    }
                    else
                    {
                        voiceNotFoundMessage();
                    }
                    break;

                case "us":
                    if (isLanguageInstalled("en-US"))
                    {
                        // Query for a voice that speaks US English.
                        voices = from voice in InstalledVoices.All
                                 where voice.Language == "en-US"
                                 select voice;
                    }
                    else
                    {
                        voiceNotFoundMessage();
                    }
                    break;

                case "uk":
                    if (isLanguageInstalled("en-GB"))
                    {
                        // Query for a voice that speaks British English.
                        voices = from voice in InstalledVoices.All
                                 where voice.Language == "en-GB"
                                 select voice;
                    }
                    else
                    {
                        voiceNotFoundMessage();
                    }
                    break;

                case "india":
                    if (isLanguageInstalled("en-IN"))
                    {
                        // Query for a voice that speaks Indian.
                        voices = from voice in InstalledVoices.All
                                 where voice.Language == "en-IN"
                                 select voice;
                    }
                    else
                    {
                        voiceNotFoundMessage();
                    }
                    break;
            }
           
            // Set the voice as identified by the query.
            synth.SetVoice(voices.ElementAt(1));
            try { await synth.SpeakTextAsync(text); }
            catch(Exception e){
               // Debug.WriteLine("Hey");
            }
            
        }

        private Boolean isLanguageInstalled(String lang_code)
        {
            foreach (var voice in InstalledVoices.All)
            {
                if (voice.Language == lang_code)
                {
                    return true;
                }
            }
            return false;
        }

        private void  voiceNotFoundMessage()
        {
            MessageBoxResult result =
      MessageBox.Show("The selected language is not installed on your phone.\nPlease install this language from \"Settings>language\" on your phone.\nNow speaking in US accent!",
      "Language not installed!", MessageBoxButton.OK);

            if (result == MessageBoxResult.OK)
            {
                //do something, may be launch settings page
            }

           
        }

        public void cleanAll()
        {
            if (synth != null) { 
                synth.CancelAll(); 
            }
           
        }
    }
}
