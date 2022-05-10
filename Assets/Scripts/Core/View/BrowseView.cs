using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    public class BrowseView : MonoBehaviour, IView
    {
        [SerializeField]
        private SmoothToolbar _viewModeToolbar;
        public SmoothToolbar ViewModeToolbar { get => _viewModeToolbar; }

        [SerializeField]
        private Button _backButton;
        public Button BackButton { get => _backButton; }

        public bool IsVisible() => gameObject.activeInHierarchy;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
