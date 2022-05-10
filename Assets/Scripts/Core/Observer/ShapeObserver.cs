using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class ShapeObserver : MonoBehaviour, IObserver
    {
        private IShape _shape;
        private IObserverController[] _observerControllers;

        public void Awake()
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

        public void Show()
        {
            // todo: load shape textures

            _shape.Show();
            foreach (IObserverController controller in _observerControllers)
                controller.Activate();
        }
    }
}
