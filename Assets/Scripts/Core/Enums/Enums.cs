namespace NFTViewer
{
    public enum ApplicationState
    {
        Search,
        Browse,
        Menu,
        Loading,
    }

    public enum ViewMode
    {
        View2D,
        View3D
    }

    public enum AddressType
    {
        Creator = 0,
        Owner = 1,
        Collection = 2,
    }

    public enum NotificationType
    {
        EmptySearch,
        EmptySearchResult,
        EmptySearchSample
    }
}
