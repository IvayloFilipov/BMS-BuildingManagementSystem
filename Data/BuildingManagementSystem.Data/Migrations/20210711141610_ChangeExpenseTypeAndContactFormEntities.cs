namespace BuildingManagementSystem.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeExpenseTypeAndContactFormEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip",
                table: "ContactForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ExpenseTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ExpenseTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExpenseTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ExpenseTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_IsDeleted",
                table: "ExpenseTypes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_IsDeleted",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ExpenseTypes");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "ContactForms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
