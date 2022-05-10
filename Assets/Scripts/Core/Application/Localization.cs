using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityApp = UnityEngine.Application;

namespace NFTViewer.UI
{
    public class Localization : MonoBehaviour
    {
        void Awake()
        {
            foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
            {
                if (locale.name.Contains(UnityApp.systemLanguage.ToString()))
                {
                    LocalizationSettings.SelectedLocale = locale;
                    break;
                }
            }
        }
        
        public void SetLocaleByIndex(int localeIndex)
        {
            if (localeIndex >= 0 && localeIndex < LocalizationSettings.AvailableLocales.Locales.Count)
            {
                Locale locale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
                LocalizationSettings.SelectedLocale = locale;
            }
        }

        public int GetCurrentLocaleIndex ()
        {
            int localeIndex = 0;
            foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
            {
                if (locale != LocalizationSettings.SelectedLocale)
                {
                    localeIndex++;
                }
                else
                {
                    break;
                }
            }

            return localeIndex;
        }
    }
}
