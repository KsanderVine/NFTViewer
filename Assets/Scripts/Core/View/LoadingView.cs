using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    public class LoadingView : MonoBehaviour, IView
    {
        public bool IsVisible() => gameObject.activeInHierarchy;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
