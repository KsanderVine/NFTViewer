using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFTViewer.UI;
using Applicaton = NFTViewer.Application;

namespace NFTViewer
{
    public class BrowseController : MonoBehaviour, IController
    {
        private BrowseView _browseView;

        private IObserver _sidesObserver;
        private IObserver _shapeObserver;

        private ViewMode _viewMode;
        private ViewMode[] _viewModes;

        public void Awake()
        {
            _viewMode = ViewMode.View2D;
            _viewModes = System.Enum.GetValues(typeof(ViewMode)) as ViewMode[];

            _browseView = FindObjectOfType<BrowseView>(true);
            _shapeObserver = FindObjectOfType<ShapeObserver>(true);
            _sidesObserver = FindObjectOfType<SidesObserver>(true);

            _browseView.BackButton.onClick.AddListener(MoveToSearch);
            _browseView.ViewModeToolbar.OnToggled += ViewModeToggled;

            Application.OnStateChanged += OnStateChanged;
        }

        private void MoveToSearch ()
        {
            Application.ChangeState(ApplicationState.Search);
        }

        private void ViewModeToggled(int viewModeID)
        {
            if (viewModeID >= 0 && viewModeID < _viewModes.Length)
            {
                _viewMode = (ViewMode)viewModeID;
                ValidateViewMode();
            }
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Browse)
            {
                _sidesObserver.Hide();
                _shapeObserver.Hide();
                _browseView.Hide();
                return;
            }
            _browseView.Show();
            ValidateViewMode();
        }

        private void ValidateViewMode ()
        {
            if(_viewMode == ViewMode.View2D)
            {
                _shapeObserver.Hide();
                _sidesObserver.Show();
            }
            else
            {
                _sidesObserver.Hide();
                _shapeObserver.Show();
            }
        }
    }
}
