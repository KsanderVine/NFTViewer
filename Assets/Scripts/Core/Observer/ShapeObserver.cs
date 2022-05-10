using UnityEngine;

namespace NFTViewer
{
    public class ShapeObserver : MonoBehaviour, IObserver
    {
        private IShape _shape;
        private IObserverController[] _observerControllers;

        private void Awake()
        {
            _shape = GetComponentInChildren<IShape>(true);
            _observerControllers = GetComponents<IObserverController>();
        }

        public void Hide()
        {
            _shape.Hide();
            foreach (IObserverController controller in _observerControllers)
                controller.Deactivate();
        }

        public void SetTextures(Texture[] textures)
        {
            _shape.SetTextures(textures);
        }

        public void Show()
        {
            _shape.Show();
            foreach (IObserverController controller in _observerControllers)
                controller.Activate();
        }
    }
}
