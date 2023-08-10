using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Block",
                schema: "dbo",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.BlockId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceType",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                schema: "dbo",
                columns: table => new
                {
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TCNo = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePlate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.ResidentId);
                });

            migrationBuilder.CreateTable(
                name: "CardInformation",
                schema: "dbo",
                columns: table => new
                {
                    CardInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CVV = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInformation", x => x.CardInformationId);
                    table.ForeignKey(
                        name: "FK_CardInformation_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                schema: "dbo",
                columns: table => new
                {
                    FlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TypeOfFlat = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerorTenant = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.FlatId);
                    table.ForeignKey(
                        name: "FK_Flat_Block_BlockId",
                        column: x => x.BlockId,
                        principalSchema: "dbo",
                        principalTable: "Block",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flat_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    Month = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceType_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalSchema: "dbo",
                        principalTable: "InvoiceType",
                        principalColumn: "InvoiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "dbo",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SendingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "dbo",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    VehicleBrand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehiclePlate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "dbo",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_BlockId",
                schema: "dbo",
                table: "Block",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CardInformation_CVV",
                schema: "dbo",
                table: "CardInformation",
                column: "CVV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardInformation_ReferenceNumber",
                schema: "dbo",
                table: "CardInformation",
                column: "ReferenceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardInformation_ResidentId",
                schema: "dbo",
                table: "CardInformation",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flat_BlockId",
                schema: "dbo",
                table: "Flat",
                column: "BlockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flat_ResidentId",
                schema: "dbo",
                table: "Flat",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceTypeId",
                schema: "dbo",
                table: "Invoice",
                column: "InvoiceTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ResidentId",
                schema: "dbo",
                table: "Invoice",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_ResidentId",
                schema: "dbo",
                table: "Message",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceId",
                schema: "dbo",
                table: "Payment",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ResidentId",
                schema: "dbo",
                table: "Payment",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resident_TCNo",
                schema: "dbo",
                table: "Resident",
                column: "TCNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resident_VehiclePlate",
                schema: "dbo",
                table: "Resident",
                column: "VehiclePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ResidentId",
                schema: "dbo",
                table: "Vehicle",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehiclePlate",
                schema: "dbo",
                table: "Vehicle",
                column: "VehiclePlate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardInformation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Flat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Block",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InvoiceType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Resident",
                schema: "dbo");
        }
    }
}
