using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class TouchObserverController : MonoBehaviour, IObserver
    {
        [SerializeField]
        [Range(1, 30)]
        private float _rotationSpeed = 5f;
        private IShape _shape;

        private void Awake()
        {
            _shape = GetComponentInChildren<IShape>();
        }

        private void Update()
        {
            // todo: не было проверено на устройстве

            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Moved)
                {
                    _shape.Rotate(t.deltaPosition * _rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}
