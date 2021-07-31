namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewRealationsBetweenTenantAndOwnerAndCompanyOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyOwnerId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CompanyOwnerId",
                table: "Tenants",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_OwnerId",
                table: "Tenants",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_CompanyOwners_CompanyOwnerId",
                table: "Tenants",
                column: "CompanyOwnerId",
                principalTable: "CompanyOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Owners_OwnerId",
                table: "Tenants",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_CompanyOwners_CompanyOwnerId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Owners_OwnerId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_CompanyOwnerId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_OwnerId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CompanyOwnerId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tenants");
        }
    }
}
