namespace BuildingManagementSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedNewRealtionBetweenPropertyAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [PropertyStatusMonthly] ([Status], [CreatedOn], [IsDeleted], ) VALUES (N'Обитаем', '2021-08-10', 0) WHERE NOT EXISTS (SELECT * FROM PropertyStatusMonthly
              WHERE id = 1)");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDebtsMonthly_PropertyStatusMonthly_PropertyStatusId",
                table: "PropertyDebtsMonthly");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDebtsMonthly_PropertyStatusId",
                table: "PropertyDebtsMonthly");

            migrationBuilder.DropColumn(
                name: "PropertyStatusId",
                table: "PropertyDebtsMonthly");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StatusId",
                table: "Properties",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyStatusMonthly_StatusId",
                table: "Properties",
                column: "StatusId",
                principalTable: "PropertyStatusMonthly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyStatusMonthly_StatusId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_StatusId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyStatusId",
                table: "PropertyDebtsMonthly",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDebtsMonthly_PropertyStatusId",
                table: "PropertyDebtsMonthly",
                column: "PropertyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDebtsMonthly_PropertyStatusMonthly_PropertyStatusId",
                table: "PropertyDebtsMonthly",
                column: "PropertyStatusId",
                principalTable: "PropertyStatusMonthly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
