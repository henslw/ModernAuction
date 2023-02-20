using ModernAuction.Models;
using Microsoft.EntityFrameworkCore;
namespace ModernAuction.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bidder> Bidders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Item>().ToTable("Auction");
            modelBuilder.Entity<Item>().ToTable("Bidder");
        }

    }
}
