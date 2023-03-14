using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModernAuction.Models
{
    public class Auction
    {
        [Key]
        public int AuctionID { get; set; }
        public DateTime AuctionStartTime { get; set; }
        public DateTime AuctionEndTime { get; set;}
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "Auction on going")]
        public decimal FinalPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal Currentprice { get; set; }
        [DisplayFormat(NullDisplayText = "No Bids")]
        public int Bids { get; set; }
        public bool AuctionActive { get; set; }
        public int ItemID { get; set; }


        public Bidder Bidder { get; set; }
        public Item Item { get; set; }
    }
}