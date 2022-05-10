using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    public class MenuView : MonoBehaviour, IView
    {
        [SerializeField]
        private SmoothToolbar _languageToolbar;
        public SmoothToolbar LanguageToolbar { get => _languageToolbar; }

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
