using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class CubeSide : MonoBehaviour, ISide
    {
        private MeshRenderer _meshRenderer;

        public void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetTexture(Texture texture)
        {
            _meshRenderer.material.SetTexture("_MainTex", texture);
        }
    }
}
