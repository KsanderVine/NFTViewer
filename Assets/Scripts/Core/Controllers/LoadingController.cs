using NFTViewer.UI;
using UnityEngine;

namespace NFTViewer
{
    public class LoadingController : MonoBehaviour, IController
    {
        private LoadingView _loadingView;

        private void Awake()
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
