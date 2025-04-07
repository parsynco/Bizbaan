using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parsyn.Apps.Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addcat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaCatModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCatModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_CatId",
                table: "Media",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCatModel_CatId",
                table: "Media",
                column: "CatId",
                principalTable: "MediaCatModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCatModel_CatId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "MediaCatModel");

            migrationBuilder.DropIndex(
                name: "IX_Media_CatId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Media");
        }
    }
}
