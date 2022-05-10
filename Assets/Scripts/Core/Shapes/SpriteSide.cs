using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer
{
    [RequireComponent(typeof(RawImage))]
    public class SpriteSide : MonoBehaviour, ISide
    {
        private RawImage _rawImage;

        private void Awake()
        {
            _rawImage = GetComponent<RawImage>();
        }

        public void SetTexture(Texture texture)
        {
            _rawImage.texture = texture;
        }
    } 
}
