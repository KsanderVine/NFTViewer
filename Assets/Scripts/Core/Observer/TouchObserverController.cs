using UnityEngine;

namespace NFTViewer
{
    public class TouchObserverController : MonoBehaviour, IObserverController
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
            // todo: �� ���� ��������� �� ����������

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
