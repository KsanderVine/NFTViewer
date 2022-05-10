using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Application = NFTViewer.Application;

namespace NFTViewer
{
    public class SearchController : MonoBehaviour, IController
    {
        private SearchView _searchView;

        public void Awake()
        {
            _searchView = FindObjectOfType<SearchView>(true);
            _searchView.BackButton.onClick.AddListener(MoveToBrowse);
            _searchView.MenuButton.onClick.AddListener(MoveToMenu);
            _searchView.SubmitButton.onClick.AddListener(SubmitSearch);

            Application.OnStateChanged += OnStateChanged;
        }

        private void MoveToBrowse ()
        {
            // todo: если данных нет, то попап
            Application.ChangeState(ApplicationState.Browse);
        }

        private void MoveToMenu ()
        {
            Application.ChangeState(ApplicationState.Menu);
        }

        private void SubmitSearch ()
        {
            string address = _searchView.AddressInputField.text;

            if (string.IsNullOrEmpty(address))
            {
                // todo: если нет адреса, то попап
            }
            
            // todo: если нет данных на сервере, то _searchView.Clean();

            Application.ChangeState(ApplicationState.Loading);
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Search)
            {
                _searchView.Hide();
                return;
            }
            _searchView.Show();
        }
    }
}
