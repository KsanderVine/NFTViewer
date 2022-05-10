using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NFTViewer.UI
{
    [ExecuteAlways]
    public class QuadRawImage : RawImage
    {
        public void Update()
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.sizeDelta.y);
        }
    }
}
