using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernAuction.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string Userid { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string ItemDescription { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Currency)]
        public decimal StartingPrice { get; set; }
        public bool IsSold { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
