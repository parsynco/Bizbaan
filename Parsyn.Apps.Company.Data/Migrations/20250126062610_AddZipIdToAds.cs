using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parsyn.Apps.Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddZipIdToAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Longitude",
            //    table: "Zipcodes",
            //    type: "decimal(18,2)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(15,5)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Latitude",
            //    table: "Zipcodes",
            //    type: "decimal(18,2)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(15,5)",
            //    oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ZipId",
                table: "Ads",
                column: "ZipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Zipcodes_ZipId",
                table: "Ads",
                column: "ZipId",
                principalTable: "Zipcodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Zipcodes_ZipId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_ZipId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ZipId",
                table: "Ads");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Longitude",
            //    table: "Zipcodes",
            //    type: "decimal(15,5)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Latitude",
            //    table: "Zipcodes",
            //    type: "decimal(15,5)",
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)",
            //    oldNullable: true);
        }
    }
}
