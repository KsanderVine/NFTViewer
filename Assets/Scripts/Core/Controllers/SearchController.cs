using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Applicaton = NFTViewer.Applicaton;

namespace NFTViewer
{
    public class SearchController : MonoBehaviour, IController
    {
        private SearchView _searchView;

        private string _address;
        private AddressType _addressType;

        private AddressType[] _addressTypes;

        public void Awake()
        {
            _addressType = AddressType.Owner;
            _addressTypes = System.Enum.GetValues(typeof(AddressType)) as AddressType[];

            _searchView = FindObjectOfType<SearchView>(true);

            _searchView.BackButton.onClick.AddListener(MoveToBrowse);
            _searchView.SubmitButton.onClick.AddListener(SubmitSearch);
            _searchView.AddressTypeToolbar.OnToggled += AddressTypeToggled;

            Applicaton.OnStateChanged += OnStateChanged;
        }

        private void AddressTypeToggled(int toggleID)
        {
            if (toggleID >= 0 && toggleID < _addressTypes.Length)
                _addressType = (AddressType)toggleID;
        }

        private void MoveToBrowse ()
        {
            // todo: если данных нет, то попап
            Applicaton.ChangeState(ApplicationState.Browse);
        }

        private void SubmitSearch ()
        {
            string address = _searchView.AddressInputField.text;

            if (string.IsNullOrEmpty(address))
            {
                // todo: если нет адреса, то попап
            }
            
            // todo: если нет данных на сервере, то _searchView.Clean();

            Applicaton.ChangeState(ApplicationState.Loading);
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
