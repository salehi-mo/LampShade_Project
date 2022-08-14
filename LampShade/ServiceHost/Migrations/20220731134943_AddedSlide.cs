﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceHost.Migrations
{
    public partial class AddedSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}
