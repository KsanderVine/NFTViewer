using DG.Tweening;
using UnityEngine;

namespace NFTViewer
{
    public class EndlessRotation : MonoBehaviour
    {
        void Start()
        {
            transform.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }
    }
}
