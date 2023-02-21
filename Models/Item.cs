using System;
using System.Collections.Generic;
namespace ModernAuction.Models
{
    public class Item
    {
        public string ItemID { get; set; } = string.Empty;
        public string Userid { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public Decimal StartingPrice { get; set; }
        public bool IsSold { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
