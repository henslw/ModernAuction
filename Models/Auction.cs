namespace ModernAuction.Models
{
    public class Auction
    {
        public string AuctionID { get; set; }  = string.Empty;
        public DateTime AuctionStartTime { get; set; }
        public DateTime AuctionEndTime { get; set;}
        public decimal FinalPrice { get; set; }
        public decimal Currentprice { get; set; }
        public int Bids { get; set; }
        public bool AuctionActive { get; set; }

        public Bidder Bidder { get; set; }
        public Item Item { get; set; }
    }
}