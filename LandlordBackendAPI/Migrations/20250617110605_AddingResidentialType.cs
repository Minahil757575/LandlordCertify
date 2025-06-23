using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandlordBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingResidentialType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "PATs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireSafetyCertificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "PATs");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireSafetyCertificates");
        }
    }
}
