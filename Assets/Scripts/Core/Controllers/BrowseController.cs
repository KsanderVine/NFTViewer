using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Applicaton = NFTViewer.Applicaton;

namespace NFTViewer
{
    public class BrowseController : MonoBehaviour, IController
    {
        private BrowseView _browseView;

        public void Awake()
        {
            _browseView = FindObjectOfType<BrowseView>(true);
            Applicaton.OnStateChanged += OnStateChanged;
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Browse)
            {
                _browseView.Hide();
                return;
            }
            _browseView.Show();
        }
    }
}
