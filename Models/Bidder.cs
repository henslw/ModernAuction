using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernAuction.Models
{
    public class Bidder
    {
        
        public string BidderID { get; set; } = string.Empty;
        public string BidderUserID { get; set; } = string.Empty;
        public int BidderAuctionID { get; set; }
        public decimal BidAmount { get; set; }

        public ICollection<Auction> Auctions { get; set; }


    }
}