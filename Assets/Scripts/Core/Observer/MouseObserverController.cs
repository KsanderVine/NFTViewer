using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class MouseObserverController : MonoBehaviour, IObserver
    {
        [SerializeField]
        [Range(1, 30)]
        private float _rotationSpeed = 5f;
        private IShape _shape;

        private bool _isPressed;
        private Vector3 _lastPosition;

        private void Awake()
        {
            _shape = GetComponentInChildren<IShape>();
        }

        private void Update()
        {
            // todo: проверка на пересечение с UI

            if (Input.GetMouseButtonUp(0))
                _isPressed = false;

            if (Input.GetMouseButtonDown(0))
            {
                _lastPosition = Input.mousePosition;
                _isPressed = true;
            }

            if (_isPressed)
            {
                Vector3 axis = _lastPosition - Input.mousePosition;
                axis.y *= -1f;
                _lastPosition = Input.mousePosition;

                _shape.Rotate(axis * _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
