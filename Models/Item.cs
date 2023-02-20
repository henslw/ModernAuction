namespace ModernAuction.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Userid { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public Decimal StartingPrice { get; set; }
        public bool IsSold { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
