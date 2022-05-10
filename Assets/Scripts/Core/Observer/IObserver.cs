using UnityEngine;

namespace NFTViewer
{
    public interface IObserver
    {
        void Show();
        void Hide();
        void SetTextures(Texture[] textures);
    }
}
