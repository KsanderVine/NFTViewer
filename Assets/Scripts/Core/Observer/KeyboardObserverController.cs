using UnityEngine;

namespace NFTViewer
{
    public class KeyboardObserverController : MonoBehaviour, IObserverController
    {
        [SerializeField]
        [Range(1, 30)]
        private float _rotationSpeed = 5f;
        private IShape _shape;

        private void Awake()
        {
            _shape = GetComponentInChildren<IShape>(true);
        }

        public void Activate() =>
            enabled = true;

        public void Deactivate() =>
            enabled = false;

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
