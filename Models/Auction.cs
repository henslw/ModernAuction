namespace ModernAuction.Models
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public DateTime AuctionStartTime { get; set; }
        public DateTime AuctionEndTime { get; set;
        }
        public decimal FinalPrice { get; set; }
        public decimal Currentprice { get; set; }
        public int Bids { get; set; }
        public bool AuctionActive { get; set; }

        public Bidder Bidder { get; set; }
        public Item Item { get; set; }
    }
}