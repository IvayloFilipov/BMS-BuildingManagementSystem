﻿namespace BuildingManagementSystem.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreateDataBaseEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 15000, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Readed = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Descrtiption = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFloors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<byte>(type: "tinyint", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFloors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStatusMonthly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStatusMonthly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingAccounts_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BlockNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    EntranceNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    AppartNumber = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingPayments_BuildingAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "BuildingAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingPayments_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingPayments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UIC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyOwnerFullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOwners_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyFloorId = table.Column<int>(type: "int", nullable: false),
                    AppartNumber = table.Column<int>(type: "int", nullable: false),
                    PropertyPart = table.Column<double>(type: "float", nullable: false),
                    DogCount = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CompanyOwnerId = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_CompanyOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyFloors_PropertyFloorId",
                        column: x => x.PropertyFloorId,
                        principalTable: "PropertyFloors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomingPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentPeriod = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingPayments_BuildingAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "BuildingAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomingPayments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomingPayments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertiesOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertiesOwners_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDebtsMonthly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    PropertyStatusId = table.Column<int>(type: "int", nullable: true),
                    FeeId = table.Column<int>(type: "int", nullable: false),
                    Descrtiption = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDebtsMonthly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyDebtsMonthly_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyDebtsMonthly_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyDebtsMonthly_PropertyStatusMonthly_PropertyStatusId",
                        column: x => x.PropertyStatusId,
                        principalTable: "PropertyStatusMonthly",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BuildingId",
                table: "Addresses",
                column: "BuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Addresses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAccounts_BuildingId",
                table: "BuildingAccounts",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAccounts_IsDeleted",
                table: "BuildingAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_AddressId",
                table: "CompanyOwners",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_IsDeleted",
                table: "CompanyOwners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_IsDeleted",
                table: "Fees",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Files_IsDeleted",
                table: "Files",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingPayments_AccountId",
                table: "IncomingPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingPayments_PaymentTypeId",
                table: "IncomingPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingPayments_PropertyId",
                table: "IncomingPayments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPayments_AccountId",
                table: "OutgoingPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPayments_ExpenseTypeId",
                table: "OutgoingPayments",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingPayments_PaymentTypeId",
                table: "OutgoingPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_IsDeleted",
                table: "Owners",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BuildingId",
                table: "Properties",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CompanyOwnerId",
                table: "Properties",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyFloorId",
                table: "Properties",
                column: "PropertyFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TenantId",
                table: "Properties",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesOwners_OwnerId",
                table: "PropertiesOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesOwners_PropertyId",
                table: "PropertiesOwners",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDebtsMonthly_FeeId",
                table: "PropertyDebtsMonthly",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDebtsMonthly_IsDeleted",
                table: "PropertyDebtsMonthly",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDebtsMonthly_PropertyId",
                table: "PropertyDebtsMonthly",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDebtsMonthly_PropertyStatusId",
                table: "PropertyDebtsMonthly",
                column: "PropertyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatusMonthly_IsDeleted",
                table: "PropertyStatusMonthly",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_IsDeleted",
                table: "Tenants",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "IncomingPayments");

            migrationBuilder.DropTable(
                name: "OutgoingPayments");

            migrationBuilder.DropTable(
                name: "PropertiesOwners");

            migrationBuilder.DropTable(
                name: "PropertyDebtsMonthly");

            migrationBuilder.DropTable(
                name: "BuildingAccounts");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyStatusMonthly");

            migrationBuilder.DropTable(
                name: "CompanyOwners");

            migrationBuilder.DropTable(
                name: "PropertyFloors");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
