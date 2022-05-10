using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace NFTViewer.UI
{
    public class RaribleSearchView : SearchView, IView
    {
        [SerializeField]
        private InputField _addressInputField;
        public InputField AddressInputField { get => _addressInputField; }

        [SerializeField]
        private SmoothToolbar _addressTypeToolbar;
        public SmoothToolbar AddressTypeToolbar { get => _addressTypeToolbar; }

        [SerializeField]
        private PopupNotification _popupNotification_EmptySearch;

        [SerializeField]
        private PopupNotification _popupNotification_EmptySearchResult;

        [SerializeField]
        private PopupNotification _popupNotification_EmptySearchSample;

        public override void Hide()
        {
            _popupNotification_EmptySearch.Hide();
            _popupNotification_EmptySearchResult.Hide();
            _popupNotification_EmptySearchSample.Hide();
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            _popupNotification_EmptySearch.Hide();
            _popupNotification_EmptySearchResult.Hide();
            _popupNotification_EmptySearchSample.Hide();
            gameObject.SetActive(true);
            ((RectTransform)transform).anchoredPosition += (Vector2.right * Screen.width);
            ((RectTransform)transform).DOAnchorPosX(0, 0.5f, false).SetEase(Ease.OutExpo);
        }

        public override void Clean ()
        {
            _addressInputField.SetTextWithoutNotify("");
        }

        public override ISearchRequest GetSearchRequest ()
        {
            AddressType requestAddressType = (AddressType)_addressTypeToolbar.CurrentToolID;
            string address = _addressInputField.text;

            // todo: not perfect
            int size = FindObjectOfType<ShapeObserver>(true).GetComponentInChildren<IShape>(true).SidesCount;

            return new RaribleSearchRequest(requestAddressType, address, size);
        }

        public override void Notify(NotificationType notificationType)
        {
            switch(notificationType)
            {
                case NotificationType.EmptySearch:
                    _popupNotification_EmptySearch.PlayNotification();
                    break;
                case NotificationType.EmptySearchResult:
                    _popupNotification_EmptySearchResult.PlayNotification();
                    break;
                case NotificationType.EmptySearchSample:
                    _popupNotification_EmptySearchSample.PlayNotification();
                    break;
            }
        }
    }
}
