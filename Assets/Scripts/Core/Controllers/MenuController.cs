using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Applicaton = NFTViewer.Applicaton;

namespace NFTViewer
{
    public class MenuController : MonoBehaviour, IController
    {
        private MenuView _menuView;

        public void Awake()
        {
            _menuView = FindObjectOfType<MenuView>(true);
            Applicaton.OnStateChanged += OnStateChanged;
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
