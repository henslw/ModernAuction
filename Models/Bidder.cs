using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernAuction.Models
{
    public class Bidder
    {
        [Key]
        public int BidderID { get; set; }
        public string BidderUserID { get; set; } = string.Empty;
        public int BidderAuctionID { get; set; }
        public decimal BidAmount { get; set; }

        public ICollection<Auction> Auctions { get; set; }


    }
}