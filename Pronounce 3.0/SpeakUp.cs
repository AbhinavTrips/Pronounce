using System;
using System.Collections.Generic;
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
        private SpeechSynthesizer synth;
        public SpeakUp(String lang)
        {
            this.language = lang;
        }

        public async void speak(string text)
        {
            // Initialize the SpeechSynthesizer object.
            synth = new SpeechSynthesizer();
            IEnumerable<VoiceInformation> voices = from voice in InstalledVoices.All
                             where voice.Language == "en-US"
                             select voice;
            switch (language)
            {
                case "french":
                    if (isLanguageInstalled("fr-FR")) {
                    // Query for a voice that speaks French.
                    voices = from voice in InstalledVoices.All
                             where voice.Language == "fr-FR"
                             select voice;
                    }
                    else
                    {
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
                    }
                    break;
            }
           
            // Set the voice as identified by the query.
            synth.SetVoice(voices.ElementAt(0));

            await synth.SpeakTextAsync(text);
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
      MessageBox.Show("The selected language is not installed on your phone. Would you like to install it?",
      "Language not installed!", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("No caption, one button.");
            }

           
        }
    }
}

