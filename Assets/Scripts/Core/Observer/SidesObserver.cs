using UnityEngine;

namespace NFTViewer
{
    public class SidesObserver : MonoBehaviour, IObserver
    {
        [SerializeField]
        private RectTransform _grid;

        [SerializeField]
        private Texture _defaultTexture;

        private ISide[] _sides;

        public void Awake()
        {
            _sides = GetComponentsInChildren<ISide>();
        }

        public void Hide()
        {
            if (_sides != null)
            {
                foreach (ISide side in _sides)
                {
                    side.SetTexture(_defaultTexture);
                }
            }

            gameObject.SetActive(false);
        }

        public void Show()
        {
            // todo: load shape textures

            gameObject.SetActive(true);
        }
    }
}
