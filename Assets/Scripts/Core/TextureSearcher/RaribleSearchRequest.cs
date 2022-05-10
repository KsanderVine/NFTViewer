namespace NFTViewer
{
    public class RaribleSearchRequest : ISearchRequest
    {
        public string Address { get; private set; }
        public AddressType AddressType { get; private set; }
        public int Size { get; private set; }

        public RaribleSearchRequest (AddressType addressType, string address, int size)
        {
            AddressType = addressType;
            Address = address;
            Size = size;
        }

        public bool IsAnyEmpty()
        {
            if (string.IsNullOrEmpty(Address))
                return true;
            return false;
        }
    }
}
