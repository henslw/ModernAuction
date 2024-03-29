﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModernAuction.Data;

#nullable disable

namespace ModernAuction.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20230314185420_InitialMirgation")]
    partial class InitialMirgation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModernAuction.Models.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"));

                    b.Property<bool>("AuctionActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AuctionEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AuctionStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BidderID")
                        .HasColumnType("int");

                    b.Property<int>("Bids")
                        .HasColumnType("int");

                    b.Property<decimal>("Currentprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.HasKey("AuctionID");

                    b.HasIndex("BidderID");

                    b.HasIndex("ItemID");

                    b.ToTable("Auction", (string)null);
                });

            modelBuilder.Entity("ModernAuction.Models.Bidder", b =>
                {
                    b.Property<int>("BidderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidderID"));

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BidderAuctionID")
                        .HasColumnType("int");

                    b.Property<string>("BidderUserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BidderID");

                    b.ToTable("Bidder", (string)null);
                });

            modelBuilder.Entity("ModernAuction.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("ModernAuction.Models.Auction", b =>
                {
                    b.HasOne("ModernAuction.Models.Bidder", "Bidder")
                        .WithMany("Auctions")
                        .HasForeignKey("BidderID");

                    b.HasOne("ModernAuction.Models.Item", "Item")
                        .WithMany("Auctions")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bidder");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ModernAuction.Models.Bidder", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("ModernAuction.Models.Item", b =>
                {
                    b.Navigation("Auctions");
                });
#pragma warning restore 612, 618
        }
    }
}
