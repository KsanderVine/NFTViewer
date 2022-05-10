using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class Cube : MonoBehaviour, IShape
    {
        public int SidesCount => _sides.Length;
        private ISide[] _sides;

        public void Awake()
        {
            _sides = GetComponentsInChildren<ISide>(true);
        }

        public void SetTextures(params Texture[] textures)
        {
            if (textures.Length == 0)
            {
                // todo: ILogger
                return;
            }

            int texturesCount = textures.Length;
            Texture[] sideTextures = new Texture[SidesCount];

            for (int i = 0; i < SidesCount; i++)
            {
                int repeatId = Mathf.FloorToInt(Mathf.Repeat(i, texturesCount));
                sideTextures[i] = textures[repeatId];
            }

            for (int i = 0; i < SidesCount; i++)
                _sides[i].SetTexture(sideTextures[i]);
        }

        public void Rotate(Vector3 axis)
        {
            float tmp = axis.x;
            axis.x = axis.y;
            axis.y = tmp;

            axis = transform.InverseTransformDirection(axis);
            transform.Rotate(axis, Space.Self);
        }

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);
    }
}
