using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class KeyboardObserverController : MonoBehaviour, IObserver
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
            Vector3 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.LeftArrow))
                direction.x = 1f;
            if (Input.GetKey(KeyCode.RightArrow))
                direction.x = -1f;

            if (Input.GetKey(KeyCode.UpArrow))
                direction.y = -1f;
            if (Input.GetKey(KeyCode.DownArrow))
                direction.y = 1f;

            if (direction != Vector3.zero)
                _shape.Rotate(direction * _rotationSpeed * Time.deltaTime);
        }
    }
}
