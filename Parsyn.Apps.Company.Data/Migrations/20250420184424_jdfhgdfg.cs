using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parsyn.Apps.Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class jdfhgdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Ads");
        }
    }
}
