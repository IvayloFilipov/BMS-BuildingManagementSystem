namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SetAddressIdInOwnerAndCompanyOwnerToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_AddressId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_CompanyOwners_AddressId",
                table: "CompanyOwners");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Owners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "CompanyOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_AddressId",
                table: "CompanyOwners",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_AddressId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_CompanyOwners_AddressId",
                table: "CompanyOwners");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "CompanyOwners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_AddressId",
                table: "CompanyOwners",
                column: "AddressId",
                unique: true);
        }
    }
}
