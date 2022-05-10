namespace NFTViewer.UI
{
    public interface IView
    {
        bool IsVisible();
        void Show();
        void Hide();
    }
}
