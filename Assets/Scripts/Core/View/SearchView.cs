using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    public abstract class SearchView : MonoBehaviour, IView
    {
        [SerializeField]
        private Button _submitButton;
        public Button SubmitButton { get => _submitButton; }

        [SerializeField]
        private Button _backButton;
        public Button BackButton { get => _backButton; }

        [SerializeField]
        private Button _menuButton;
        public Button MenuButton { get => _menuButton; }

        public bool IsVisible() => gameObject.activeInHierarchy;

        public abstract void Hide();
        public abstract void Show();

        public abstract void Notify(NotificationType notificationType);

        public abstract void Clean();
        public abstract ISearchRequest GetSearchRequest();
    }
}
