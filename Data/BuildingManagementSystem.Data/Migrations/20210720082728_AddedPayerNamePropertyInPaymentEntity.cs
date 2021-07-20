using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class AddedPayerNamePropertyInPaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppartNumber",
                table: "Properties",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "PayerName",
                table: "IncomingPayments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppartNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayerName",
                table: "IncomingPayments");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Properties",
                newName: "AppartNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppartNumber",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
