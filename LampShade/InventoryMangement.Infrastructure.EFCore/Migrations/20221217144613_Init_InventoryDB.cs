using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EFCore.Migrations
{
    public partial class Init_InventoryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    InStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOperations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation = table.Column<bool>(nullable: false),
                    Count = table.Column<long>(nullable: false),
                    OperatorId = table.Column<long>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    CurrentCount = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    InventoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOperations_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperations_InventoryId",
                table: "InventoryOperations",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOperations");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
