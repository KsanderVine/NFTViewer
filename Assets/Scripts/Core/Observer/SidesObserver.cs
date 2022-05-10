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

        public void Hide()
        {
            _grid.gameObject.SetActive(false);
        }

        public void SetTextures(Texture[] textures)
        {
            if(_sides == null)
                _sides = _grid.GetComponentsInChildren<ISide>(true);

            if (textures == null)
                return;

            foreach (ISide side in _sides)
                side.SetTexture(_defaultTexture);

            Debug.Log("L: " + textures.Length);

            for (int i = 0; i < _sides.Length; i++)
            {
                int repeatId = Mathf.FloorToInt(Mathf.Repeat(i, textures.Length));
                Debug.Log("R: " + repeatId);
                _sides[i].SetTexture(textures[repeatId]);
            }
        }

        public void Show()
        {
            _grid.gameObject.SetActive(true);
        }
    }
}
