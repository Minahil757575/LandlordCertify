using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandlordBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingAsbestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "AsbestosBookings",
                newName: "PreferredSlot");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AsbestosBookings",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "AsbestosBookings",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "AsbestosBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AsbestosBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredDate",
                table: "AsbestosBookings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "AsbestosBookings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AsbestosBookings");

            migrationBuilder.DropColumn(
                name: "PreferredDate",
                table: "AsbestosBookings");

            migrationBuilder.RenameColumn(
                name: "PreferredSlot",
                table: "AsbestosBookings",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AsbestosBookings",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AsbestosBookings",
                newName: "BookingDate");
        }
    }
}
