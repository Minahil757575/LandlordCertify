using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandlordBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddResidentialUnitTypeToEICR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "GasSafeties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FuseBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireRiskAssessments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireExtinguishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireDoors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "FireAlarms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "EmergencyLightsTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "EicrBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "CommercialGasCertificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "CommercialEICRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidentialUnitType",
                table: "AsbestosBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "GasSafeties");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FuseBoxes");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireRiskAssessments");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireExtinguishers");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireDoors");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "FireAlarms");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "EmergencyLightsTests");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "EicrBookings");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "CommercialGasCertificates");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "ResidentialUnitType",
                table: "AsbestosBookings");
        }
    }
}
