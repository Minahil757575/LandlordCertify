using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandlordBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class REMOVINGFROMTHEFIREEXTINGUISHERS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireExtinguishers");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireAlarms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireExtinguishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireAlarms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
