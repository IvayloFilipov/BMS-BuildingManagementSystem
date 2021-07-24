namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedNewPropertyInCompanyOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesOwners_AspNetUsers_UserId",
                table: "PropertiesOwners");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesOwners_UserId",
                table: "PropertiesOwners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PropertiesOwners");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CompanyOwners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_UserId",
                table: "CompanyOwners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwners_AspNetUsers_UserId",
                table: "CompanyOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwners_AspNetUsers_UserId",
                table: "CompanyOwners");

            migrationBuilder.DropIndex(
                name: "IX_CompanyOwners_UserId",
                table: "CompanyOwners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompanyOwners");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PropertiesOwners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesOwners_UserId",
                table: "PropertiesOwners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesOwners_AspNetUsers_UserId",
                table: "PropertiesOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
