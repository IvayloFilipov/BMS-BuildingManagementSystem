using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class ChangeContactFormEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Readed",
                table: "ContactForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ContactForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ContactForms",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ContactForms");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ContactForms");

            migrationBuilder.AddColumn<bool>(
                name: "Readed",
                table: "ContactForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
