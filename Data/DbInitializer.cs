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
                new Item{ ItemID= 122343, Userid= "4655758",ItemDescription ="Samsung Headphones" ,StartingPrice = 5.99m,
                     IsSold = false }
            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();

            if (context.Items.Any())
            {
                return; // DB has been seeded
            }

            var auctions = new Auction[]
            {
                new Auction{ AuctionId = 352353, AuctionActive = true, AuctionEndTime = DateTime.MaxValue, Currentprice = 5.99m, AuctionStartTime =DateTime.Now     }
            };

            foreach (Auction i in auctions)
            {
                context.Auctions.Add(i);
            }
            context.SaveChanges();

            if (context.Items.Any())
            {
                return; // DB has been seeded
            }

            var bidders = new Bidder[]
            {
                new Bidder{ BidAmount = 9.99m, BidderId = 898797  }
            };

            foreach (Bidder i in bidders)
            {
                context.Bidders.Add(i);
            }
            context.SaveChanges();
        }
    }
}
