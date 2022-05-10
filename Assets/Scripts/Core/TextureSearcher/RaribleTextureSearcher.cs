using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;
using SimpleJSON;

namespace NFTViewer
{
    public class RaribleTextureSearcher : MonoBehaviour, ITextureSearcher<RaribleSearchRequest>
    {
        protected const string _raribleRequestUrl = "https://ethereum-api.rarible.org/v0.1/nft/items/{0}?{1}={2}&size={3}";

        public void Request(RaribleSearchRequest searchRequest, Action<SearchSample> callback)
        {
            StartCoroutine(RequestForItemsAndCallback(searchRequest, callback));
        }

        private IEnumerator RequestForItemsAndCallback(RaribleSearchRequest searchRequest, Action<SearchSample> callback)
        {
            AddressType requestAddressType = searchRequest.AddressType;
            string address = searchRequest.Address;
            int size = searchRequest.Size;

            string requestType = $"by{requestAddressType.ToString()}";
            string parameterType = requestAddressType.ToString().ToLower();

            string url = string.Format(_raribleRequestUrl, requestType, parameterType, address, size);
            
            var www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();

            if (string.IsNullOrEmpty(www.error) == false || www.responseCode != 200)
            {
                callback(null);
                yield break;
            }

            string requestContent = www.downloadHandler.text;
            JSONNode jSONNode = JSON.Parse(requestContent);
            int avaliableCount = jSONNode["total"];

            SearchSample searchSample = new SearchSample();

            for (int i = 0; i < avaliableCount; i++)
            {
                string parsedUrl = jSONNode["items"][i]["meta"]["image"]["url"][0].Value.ToString();
                // todo: converter from svg?
                searchSample.AddReferenceUrl(parsedUrl);
            }

            if (searchSample.IsSampleEmpty())
            {
                callback(null);
                yield break;
            }

            yield return StartCoroutine(DownloadTextures(searchSample));

            callback(searchSample);
            yield break;
        }

        private IEnumerator DownloadTextures(SearchSample searchSample)
        {
            for (int i = 0; i < searchSample.References.Count; i++)
            {
                string url = searchSample.References[i].Url;
                var www = UnityWebRequestTexture.GetTexture(url);

                Debug.Log("Target URL: " + url);
                yield return www.SendWebRequest();

                if (string.IsNullOrEmpty(www.error) || www.responseCode != 200)
                {
                    Texture texture = DownloadHandlerTexture.GetContent(www);
                    searchSample.SetReferenceTexturebyIndex(i, texture);
                }
            }
        }
    }
}
