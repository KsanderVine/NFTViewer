using UnityEngine;

namespace NFTViewer
{
    public class TextureLoader : MonoBehaviour
    {
        public RaribleTextureSearcher RaribleTextureSearcher { get; private set; }

        public void Awake()
        {
            RaribleTextureSearcher = GetComponent<RaribleTextureSearcher>();
        }

        public void GetTextures (ISearchRequest searchRequest, System.Action<SearchSample> callback)
        {
            if (searchRequest is RaribleSearchRequest)
                RaribleTextureSearcher.Request(searchRequest as RaribleSearchRequest, callback);
        }
    }
}
