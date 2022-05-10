using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;

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
            // todo: ре-транслировать приложение
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Menu)
            {
                _menuView.Hide();
                return;
            }
            _menuView.Show();
        }
    }
}
