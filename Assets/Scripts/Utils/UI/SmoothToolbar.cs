using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NFTViewer
{
    public class SmoothToolbar : MonoBehaviour
    {
        public int CurrentToolID { get; private set; }
        public event Action<int> OnToggled;

        [SerializeField]
        private Color _normalColor;

        [SerializeField]
        private Color _selectedColor;

        [SerializeField]
        private RectTransform _cursor;

        [SerializeField]
        private Text[] _options;

        private int _defaultToolID;

        private void Awake()
        {
            if (_options == null || _options.Length == 0)
            {
                _options = GetComponentsInChildren<Text>();

                if (_options.Length == 0)
                    throw new System.NotImplementedException();
            }

            for (int i = 0; i < _options.Length; i++)
            {
                Text option = _options[i];

                EventTrigger eventTrigger = option.gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;

                int toolID = i;
                entry.callback.AddListener((data) => SetToggle(toolID));
                eventTrigger.triggers.Add(entry);
            }

            CurrentToolID = 0;
        }

        private void Start()
        {
            StartCoroutine(LateStart(0.1f));
        }

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SetToggle(_defaultToolID, true);
        }

        public void SetDefaultToggle (int toolID)
        {
            _defaultToolID = toolID;
        }

        public void SetToggle(int toolID, bool isSilent = false)
        {
            CurrentToolID = toolID;

            Vector2 position = _options[CurrentToolID].rectTransform.anchoredPosition;
            Vector2 size = _options[CurrentToolID].rectTransform.sizeDelta;

            _cursor.DOAnchorPos(position, 0.5f);
            _cursor.DOSizeDelta(size, 0.5f)
                .SetEase(Ease.InOutQuart);

            foreach (Text option in _options)
            {
                if (option == _options[CurrentToolID])
                    option.DOColor(_selectedColor, 0.5f);
                else
                    option.DOColor(_normalColor, 0.5f);
            }

            if (isSilent == false)
            {
                if (OnToggled != null)
                    OnToggled.Invoke(toolID);
            }
        }
    }
}
