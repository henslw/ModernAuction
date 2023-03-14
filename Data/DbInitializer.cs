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

                new Item{ Userid= "245324535",ItemDescription ="Lamp" ,StartingPrice = 89.99m,
                     IsSold = false },
                new Item{ Userid= "07684567564",ItemDescription ="Sneakers" ,StartingPrice = 10.99m,
                     IsSold = false },
                new Item{ Userid= "23467965767",ItemDescription ="TV" ,StartingPrice = 1000m,
                     IsSold = false },
                new Item{ Userid= "763734574",ItemDescription ="Watch" ,StartingPrice = 2.50m,
                     IsSold = false },
                new Item{ Userid= "7896796796",ItemDescription ="Golf Clubs" ,StartingPrice = 35m,
                     IsSold = false },
                new Item{ Userid= "56536373",ItemDescription ="Comic book" ,StartingPrice = 17.99m,
                     IsSold = false }


            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();


            var auctions = new Auction[]
            {
                new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(14), Currentprice = 5.99m, AuctionStartTime =DateTime.Now.Date , ItemID = 1     },
                new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(5), Currentprice = 89.99m, AuctionStartTime =DateTime.Now.Date, ItemID = 2  },
                 new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(3), Currentprice = 10.99m, AuctionStartTime =DateTime.Now.Date, ItemID = 3  },
                  new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(7), Currentprice = 1000m, AuctionStartTime =DateTime.Now.Date, ItemID = 4  },
                   new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(7), Currentprice = 2.50m, AuctionStartTime =DateTime.Now.Date, ItemID = 5  },
                    new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(24), Currentprice = 35m, AuctionStartTime =DateTime.Now.Date, ItemID = 6  },
                     new Auction{ AuctionActive = true, AuctionEndTime = DateTime.Now.AddDays(9), Currentprice = 17.99m, AuctionStartTime =DateTime.Now.Date, ItemID = 7  },

            };

            foreach (Auction a in auctions)
            {
                context.Auctions.Add(a);
            }
            context.SaveChanges();


            var bidders = new Bidder[]
            {
                new Bidder{ BidAmount = 20.99m,BidderAuctionID= 1, BidderUserID="7b81623d-55f0-4b0e-9362-0c0bf3cd0f96"},
                new Bidder{ BidAmount = 100.99m, BidderAuctionID= 2,BidderUserID="245324535" },
                new Bidder{ BidAmount = 12m,BidderAuctionID= 3, BidderUserID="07684567564"},
                new Bidder{ BidAmount = 1149.99m, BidderAuctionID= 4, BidderUserID="23467965767"},
                new Bidder{ BidAmount = 9.99m,BidderAuctionID= 5 ,BidderUserID="763734574"},
                new Bidder{ BidAmount = 49.99m, BidderAuctionID= 6,BidderUserID="7896796796" },
                new Bidder{ BidAmount = 60m, BidderAuctionID= 7,BidderUserID="56536373" },
            };

            foreach (Bidder b in bidders)
            {
                context.Bidders.Add(b);
            }
            context.SaveChanges();
        }
    }
}
