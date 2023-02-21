using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernAuction.Models
{
    public class Bidder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidderId { get; set; }
        public int Userid { get; set; }
        public int AuctionId { get; set; }
        public decimal BidAmount { get; set; }

        public ICollection<Auction> Auctions { get; set; }


    }
}