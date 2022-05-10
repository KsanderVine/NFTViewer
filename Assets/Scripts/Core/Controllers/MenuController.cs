using NFTViewer.UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace NFTViewer
{
    public class MenuController : MonoBehaviour, IController
    {
        private MenuView _menuView;

        public void Awake()
        {
            _menuView = FindObjectOfType<MenuView>(true);

            _menuView.LanguageToolbar.OnToggled += LanguageToggled;
            _menuView.BackButton.onClick.AddListener(MoveToSearch);

            Application.OnStateChanged += OnStateChanged;
        }

        private void MoveToSearch ()
        {
            Application.ChangeState(ApplicationState.Search);
        }

        private void LanguageToggled(int languageID)
        {
            Locale locale = LocalizationSettings.AvailableLocales.Locales[languageID];
            LocalizationSettings.SelectedLocale = locale;
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Menu)
            {
                _menuView.Hide();
                return;
            }

            int toolbarID = 0;
            foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
            {
                if (locale != LocalizationSettings.SelectedLocale)
                {
                    toolbarID++;
                }
                else
                {
                    break;
                }
            }

            _menuView.Show();
            _menuView.LanguageToolbar.SetDefaultToggle(toolbarID);
            _menuView.LanguageToolbar.SetToggle(toolbarID);
        }
    }
}
