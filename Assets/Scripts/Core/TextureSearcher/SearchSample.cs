using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class SearchSample
    {
        public struct TextureReference
        {
            public string Url;
            public Texture Texture;
        }

        public List<TextureReference> References { get; private set; }

        public bool IsSampleEmpty() =>
            References.Count == 0;

        public SearchSample ()
        {
            References = new List<TextureReference>();
        }

        public void AddReferenceUrl(string url)
        {
            References.Add(new TextureReference { Url = url });
        }

        public void SetReferenceTexturebyIndex(int index, Texture texture)
        {
            TextureReference reference = References[index];
            reference.Texture = texture;
            References[index] = reference;
        }

        public Texture[] GetAllTextures()
        {
            List<Texture> textures = new List<Texture>();

            for (int i = 0; i < References.Count; i++)
            {
                if (References[i].Texture != null)
                    textures.Add(References[i].Texture);
            }

            return textures.ToArray();
        }
    }
}
