using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        private PopupNotification _popupNotification;

        public override void Hide() =>
            gameObject.SetActive(false);

        public override void Show() =>
            gameObject.SetActive(true);

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
                    _popupNotification.PlayNotification(NotificationType.EmptySearch.ToString());
                    break;
                case NotificationType.EmptySearchResult:
                    _popupNotification.PlayNotification(NotificationType.EmptySearchResult.ToString());
                    break;
                case NotificationType.EmptySearchSample:
                    _popupNotification.PlayNotification(NotificationType.EmptySearchSample.ToString());
                    break;
            }
        }
    }
}