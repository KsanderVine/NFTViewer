using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace NFTViewer
{
    public class PopupNotification : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Tween _animation;

        private Coroutine _autoDisable;

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
        }

        public void PlayNotification()
        {
            gameObject.SetActive(true);

            if (_autoDisable != null)
            {
                StopCoroutine(_autoDisable);
                _autoDisable = null;
            }

            if (_animation != null)
            {
                _animation.Kill();
                _animation = null;
            }

            _rectTransform.anchoredPosition = new Vector2(Screen.width, _rectTransform.anchoredPosition.y);
            Vector2 targetPosition = new Vector2(0, _rectTransform.anchoredPosition.y);

            _animation = _rectTransform.DOAnchorPos(targetPosition, 0.5f, false)
                .SetEase(Ease.InOutElastic);

            _autoDisable = StartCoroutine(AutoDisable(2f));
        }

        private IEnumerator AutoDisable (float delay)
        {
            yield return new WaitForSeconds(delay);

            Vector2 targetPosition = new Vector2(-Screen.width, _rectTransform.anchoredPosition.y);
            _animation = _rectTransform.DOAnchorPos(targetPosition, 0.5f, false)
                .SetEase(Ease.InOutElastic);
        }

        public void Hide()
        {
            if (_animation != null)
            {
                _animation.Kill();
                _animation = null;
            }

            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if (_autoDisable != null)
            {
                StopCoroutine(_autoDisable);
                _autoDisable = null;
            }
        }
    }
}
