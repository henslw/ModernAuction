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
                new Item{ Userid= "7b81623d-55f0-4b0e-9362-0c0bf3cd0f96",ItemDescription ="Samsung Headphones" ,StartingPrice = 5.99m,
                     IsSold = false },

                new Item{ Userid= "343533234",ItemDescription ="TV" ,StartingPrice = 599.99m,
                     IsSold = false }
            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();


            var auctions = new Auction[]
            {
                new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(7), Currentprice = 5.99m, AuctionStartTime =DateTime.Now.Date , ItemID = 1     },
                new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(7), Currentprice = 599.99m, AuctionStartTime =DateTime.Now.Date, ItemID = 2  }
            };

            foreach (Auction a in auctions)
            {
                context.Auctions.Add(a);
            }
            context.SaveChanges();


            var bidders = new Bidder[]
            {
                new Bidder{ BidAmount = 9.99m },
                new Bidder{ BidAmount = 49.99m  }
            };

            foreach (Bidder b in bidders)
            {
                context.Bidders.Add(b);
            }
            context.SaveChanges();
        }
    }
}
