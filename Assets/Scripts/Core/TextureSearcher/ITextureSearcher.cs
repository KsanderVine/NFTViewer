using System;

namespace NFTViewer
{
    public interface ITextureSearcher<T> where T : ISearchRequest
    {
        void Request(T searchRequest, Action<SearchSample> callback);
    }
}
