using NFTViewer.UI;
using UnityEngine;

namespace NFTViewer
{
    public class BrowseController : MonoBehaviour, IController
    {
        private BrowseView _browseView;

        private IObserver _sidesObserver;
        private IObserver _shapeObserver;

        private ViewMode _viewMode;
        private ViewMode[] _viewModes;

        private Texture[] _textures;

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

        public void UpdateTextures (Texture[] textures)
        {
            _textures = textures;
            _sidesObserver.SetTextures(textures);
            _shapeObserver.SetTextures(textures);
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
                _sidesObserver.SetTextures(_textures);
            }
            else
            {
                _sidesObserver.Hide();
                _shapeObserver.Show();
                _shapeObserver.SetTextures(_textures);
            }
        }
    }
}
