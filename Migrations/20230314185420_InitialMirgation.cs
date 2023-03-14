using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModernAuction.Migrations
{
    /// <inheritdoc />
    public partial class InitialMirgation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidder",
                columns: table => new
                {
                    BidderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BidderAuctionID = table.Column<int>(type: "int", nullable: false),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidder", x => x.BidderID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    AuctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currentprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bids = table.Column<int>(type: "int", nullable: false),
                    AuctionActive = table.Column<bool>(type: "bit", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    BidderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auction_Bidder_BidderID",
                        column: x => x.BidderID,
                        principalTable: "Bidder",
                        principalColumn: "BidderID");
                    table.ForeignKey(
                        name: "FK_Auction_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_BidderID",
                table: "Auction",
                column: "BidderID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ItemID",
                table: "Auction",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Bidder");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
