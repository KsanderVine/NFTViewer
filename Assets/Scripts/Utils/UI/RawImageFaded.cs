using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer
{
    public class RawImageFaded : MonoBehaviour
    {
        private RawImage _rawImage;

        private void Awake()
        {
            _rawImage = GetComponent<RawImage>();
        }

        public void Update()
        {
            if (_rawImage.texture == null)
                return;

            if (_rawImage.color.a == 1)
                return;

            Color color = _rawImage.color;
            color.a += Time.deltaTime * 5f;
            color.a = Mathf.Clamp(color.a, 0, 1);
            _rawImage.color = color;
        }
    }
}
