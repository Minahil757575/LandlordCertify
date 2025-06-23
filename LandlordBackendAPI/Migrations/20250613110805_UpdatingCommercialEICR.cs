using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandlordBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCommercialEICR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotEndTime",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "SlotStartTime",
                table: "CommercialEICRs");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "CommercialEICRs",
                newName: "PreferredSlot");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CommercialEICRs",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "CommercialEICRs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "AccessLevel",
                table: "CommercialEICRs",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "CommercialEICRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CommercialEICRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "CommercialEICRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CommercialEICRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredDate",
                table: "CommercialEICRs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CommercialEICRs");

            migrationBuilder.DropColumn(
                name: "PreferredDate",
                table: "CommercialEICRs");

            migrationBuilder.RenameColumn(
                name: "PreferredSlot",
                table: "CommercialEICRs",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "CommercialEICRs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "CommercialEICRs",
                newName: "AccessLevel");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "CommercialEICRs",
                newName: "BookingDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SlotEndTime",
                table: "CommercialEICRs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SlotStartTime",
                table: "CommercialEICRs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
