using ModernAuction.Models;
using Microsoft.EntityFrameworkCore;
namespace ModernAuction.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
        {
        }

        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bidder>().ToTable("Bidder");
            modelBuilder.Entity<Auction>().ToTable("Auction");
            modelBuilder.Entity<Item>().ToTable("Item");
        }

    }
}
