namespace ModernAuction.Models
{
    public class Bidder
    {
        public int BidderId { get; set; }
        public int Userid { get; set; }
        public int AuctionId { get; set; }
        public decimal BidAmount { get; set; }

        public ICollection<Auction> Auctions { get; set; }


    }
}