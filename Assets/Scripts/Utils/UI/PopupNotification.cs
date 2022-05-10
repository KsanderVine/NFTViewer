using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;

namespace NFTViewer
{
    public class PopupNotification : MonoBehaviour
    {
        [SerializeField]
        private Text _description;
        private Tween _animation;

        public void PlayNotification(string description)
        {
            if (_animation != null)
                _animation.Kill();

            _description.text = description;

            transform.position = new Vector2(Screen.width * 2f, transform.position.y);
            Vector2 targetPosition = new Vector2(Screen.width / 2f, transform.position.y);

            _animation = transform.DOMove(targetPosition, 0.5f, false)
                .SetEase(Ease.InOutElastic);
        }
    }
}
