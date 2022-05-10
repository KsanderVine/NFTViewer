using NFTViewer.UI;
using UnityEngine;

namespace NFTViewer
{
    public class MenuController : MonoBehaviour, IController
    {
        private MenuView _menuView;
        private Localization _localization;

        private void Awake()
        {
            _menuView = FindObjectOfType<MenuView>(true);
            _localization = FindObjectOfType<Localization>(true);

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
            _localization.SetLocaleByIndex(languageID);
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Menu)
            {
                _menuView.Hide();
                return;
            }

            int toolbarID = _localization.GetCurrentLocaleIndex();

            _menuView.Show();
            _menuView.LanguageToolbar.SetDefaultToggle(toolbarID);
            _menuView.LanguageToolbar.SetToggle(toolbarID);
        }
    }
}
