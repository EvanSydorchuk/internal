using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ConfiguredContactsAndCandidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Contact");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Candidates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Candidates");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Contact",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Contact",
                nullable: false,
                defaultValue: 0);
        }
    }
}
