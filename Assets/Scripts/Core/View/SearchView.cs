using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    public class SearchView : MonoBehaviour, IView, ICleanable
    {
        [SerializeField]
        private InputField _addressInputField;
        public InputField AddressInputField { get => _addressInputField; }

        [SerializeField]
        private SmoothToolbar _addressTypeToolbar;
        public SmoothToolbar AddressTypeToolbar { get => _addressTypeToolbar; }

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

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Clean ()
        {
            _addressInputField.SetTextWithoutNotify("");
            _addressTypeToolbar.SetToggle(0, true);
        }
    }
}
