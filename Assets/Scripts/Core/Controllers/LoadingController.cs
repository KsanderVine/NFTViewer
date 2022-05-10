using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Applicaton = NFTViewer.Application;

namespace NFTViewer
{
    public class LoadingController : MonoBehaviour, IController
    {
        private LoadingView _loadingView;

        public void Awake()
        {
            _loadingView = FindObjectOfType<LoadingView>(true);
            Application.OnStateChanged += OnStateChanged;
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Loading)
            {
                _loadingView.Hide();
                return;
            }
            _loadingView.Show();
        }
    }
}
