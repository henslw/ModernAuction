using Microsoft.AspNetCore.Mvc;
using ModernAuction.Models;
using System;
using System.Linq;
namespace ModernAuction.Data
{
    public class DbInitializer
    {
        public static void Initialize(AuctionDbContext context)
        {
            context.Database.EnsureCreated();

            //look for items
            if (context.Items.Any())
            {
                return; // DB has been seeded
            }

            var items = new Item[]
            {
                new Item{ ItemID= "122343", Userid= "7b81623d-55f0-4b0e-9362-0c0bf3cd0f96",ItemDescription ="Samsung Headphones" ,StartingPrice = 5.99m,
                     IsSold = false },

                new Item{ ItemID= "909009", Userid= "343533234",ItemDescription ="TV" ,StartingPrice = 599.99m,
                     IsSold = false }
            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();


            var auctions = new Auction[]
            {
                new Auction{ AuctionID = "352353", AuctionActive = true, AuctionEndTime = DateTime.MaxValue, Currentprice = 5.99m, AuctionStartTime =DateTime.Now , ItemID = "122343"     },
                new Auction{ AuctionID = "667866", AuctionActive = true, AuctionEndTime = DateTime.MaxValue, Currentprice = 599.99m, AuctionStartTime =DateTime.Now, ItemID = "909009"   }
            };

            foreach (Auction a in auctions)
            {
                context.Auctions.Add(a);
            }
            context.SaveChanges();


            var bidders = new Bidder[]
            {
                new Bidder{ BidAmount = 9.99m, BidderID = "898797"  },
                new Bidder{ BidAmount = 49.99m, BidderID = "58764"  }
            };

            foreach (Bidder b in bidders)
            {
                context.Bidders.Add(b);
            }
            context.SaveChanges();
        }
    }
}
