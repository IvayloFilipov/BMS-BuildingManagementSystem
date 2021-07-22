using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class AddedCoOwnerPropertyIntoPropertyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoOwner",
                table: "Properties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoOwner",
                table: "Properties");
        }
    }
}
