using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parsyn.Apps.Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionEnToAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Ads");
        }
    }
}
