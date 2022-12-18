using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class Init_ShopDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    PayAmount = table.Column<double>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false),
                    IssueTrackingNo = table.Column<string>(maxLength: 8, nullable: true),
                    RefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Picture = table.Column<string>(maxLength: 1000, nullable: true),
                    PictureAlt = table.Column<string>(maxLength: 255, nullable: true),
                    PictureTitle = table.Column<string>(maxLength: 500, nullable: true),
                    Keywords = table.Column<string>(maxLength: 80, nullable: false),
                    MetaDescription = table.Column<string>(maxLength: 150, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<string>(maxLength: 1000, nullable: false),
                    PictureAlt = table.Column<string>(maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(maxLength: 500, nullable: false),
                    Heading = table.Column<string>(maxLength: 255, nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Text = table.Column<string>(maxLength: 255, nullable: true),
                    BtnText = table.Column<string>(maxLength: 50, nullable: false),
                    Link = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    DiscountRate = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Code = table.Column<string>(maxLength: 15, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(maxLength: 1000, nullable: true),
                    PictureAlt = table.Column<string>(maxLength: 255, nullable: true),
                    PictureTitle = table.Column<string>(maxLength: 500, nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    Slug = table.Column<string>(maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Picture = table.Column<string>(maxLength: 1000, nullable: false),
                    PictureAlt = table.Column<string>(maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(maxLength: 500, nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
