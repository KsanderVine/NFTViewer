using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class CubeSide : MonoBehaviour, ISide
    {
        private MeshRenderer _meshRenderer;

        public void SetTexture(Texture texture)
        {
            if(_meshRenderer == null)
                _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material.SetTexture("_MainTex", texture);
        }
    }
}
