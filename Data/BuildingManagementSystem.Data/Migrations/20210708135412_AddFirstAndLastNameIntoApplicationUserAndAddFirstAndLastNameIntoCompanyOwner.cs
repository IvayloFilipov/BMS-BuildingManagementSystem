namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddFirstAndLastNameIntoApplicationUserAndAddFirstAndLastNameIntoCompanyOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyOwnerFullName",
                table: "CompanyOwners");

            migrationBuilder.AddColumn<string>(
                name: "CompanyOwnerFirstName",
                table: "CompanyOwners",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "CompanyOwnerLastName",
                table: "CompanyOwners",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyOwnerFirstName",
                table: "CompanyOwners");

            migrationBuilder.DropColumn(
                name: "CompanyOwnerLastName",
                table: "CompanyOwners");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CompanyOwnerFullName",
                table: "CompanyOwners",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: string.Empty);
        }
    }
}
