using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Application = NFTViewer.Application;

namespace NFTViewer
{
    public class SearchController : MonoBehaviour, IController
    {
        private TextureLoader _textureLoader;
        private SearchView _searchView;
        private SearchSample _lastSearchSample;

        public void Awake()
        {
            _textureLoader = FindObjectOfType<TextureLoader>(true);
            _searchView = FindObjectOfType<SearchView>(true);

            _searchView.BackButton.onClick.AddListener(MoveToBrowse);
            _searchView.MenuButton.onClick.AddListener(MoveToMenu);
            _searchView.SubmitButton.onClick.AddListener(SubmitSearch);

            Application.OnStateChanged += OnStateChanged;
        }

        private void MoveToBrowse ()
        {
            if (_lastSearchSample == null)
            {
                _searchView.Notify(NotificationType.EmptySearchSample);
                return;
            }
            Application.ChangeState(ApplicationState.Browse);
        }

        private void MoveToMenu ()
        {
            Application.ChangeState(ApplicationState.Menu);
        }

        private void SubmitSearch ()
        {
            ISearchRequest searchRequest = _searchView.GetSearchRequest();

            if (searchRequest.IsAnyEmpty())
            {
                _searchView.Notify(NotificationType.EmptySearch);
                return;
            }

            _textureLoader.GetTextures(searchRequest, RequestCallback);
            Application.ChangeState(ApplicationState.Loading);
        }

        private void RequestCallback (SearchSample searchSample)
        {
            if (searchSample == null)
            {
                Application.ChangeState(ApplicationState.Search);
                _searchView.Notify(NotificationType.EmptySearchResult);
                _searchView.Clean();
                return;
            }

            _lastSearchSample = searchSample;
            Application.ChangeState(ApplicationState.Browse);

            BrowseController browseController = FindObjectOfType<BrowseController>();
            browseController.UpdateTextures(searchSample.GetAllTextures());
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
