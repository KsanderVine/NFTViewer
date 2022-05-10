using UnityEngine;

namespace NFTViewer
{
    public interface IShape
    {
        int SidesCount { get; }

        void Rotate(Vector3 axis);
        void SetTextures(params Texture[] textures);

        void Show();
        void Hide();
    }
}
