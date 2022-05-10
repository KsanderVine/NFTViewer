using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer
{
    [RequireComponent(typeof(RawImage))]
    public class SpriteSide : MonoBehaviour, ISide
    {
        private RawImage _rawImage;

        public void SetTexture(Texture texture)
        {
            if(_rawImage == null)
                _rawImage = GetComponent<RawImage>();
            _rawImage.texture = texture;
        }
    } 
}
