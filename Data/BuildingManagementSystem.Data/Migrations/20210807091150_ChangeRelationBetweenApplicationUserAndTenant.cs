namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeRelationBetweenApplicationUserAndTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_UserId",
                table: "Tenants");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_UserId",
                table: "Tenants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_UserId",
                table: "Tenants");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_UserId",
                table: "Tenants",
                column: "UserId",
                unique: true);
        }
    }
}
