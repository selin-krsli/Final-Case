using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Resident]\r\n        ([FirstName]\r\n           ,[LastName]\r\n           ,[TCNo]\r\n           ,[Email]\r\n           ,[Phone]\r\n           ,[Password]\r\n           ,[VehiclePlate])\r\n     VALUES\r\n           ('Selin'\r\n           ,'Karslı'\r\n           ,'14020563987'\r\n           ,'selin01@hotmail.com'\r\n           ,'05694123665'\r\n           ,'selin01'\r\n           ,'SWX14')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Resident]\r\n        ([FirstName]\r\n           ,[LastName]\r\n           ,[TCNo]\r\n           ,[Email]\r\n           ,[Phone]\r\n           ,[Password]\r\n           ,[VehiclePlate])\r\n     VALUES\r\n           ('Ali'\r\n           ,'Karslı'\r\n           ,'15020963987'\r\n           ,'ali01@hotmail.com'\r\n           ,'05694000665'\r\n           ,'ali01'\r\n           ,'AQX14')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Resident]\r\n        ([FirstName]\r\n           ,[LastName]\r\n           ,[TCNo]\r\n           ,[Email]\r\n           ,[Phone]\r\n           ,[Password]\r\n           ,[VehiclePlate])\r\n     VALUES\r\n           ('Tunc'\r\n           ,'Karslı'\r\n           ,'69232120144'\r\n           ,'tunckrsli@hotmail.com'\r\n           ,'03219651414'\r\n           ,'tunc00'\r\n           ,'AXW0104')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Block]\r\n           ([BlockName])\r\n     VALUES\r\n           ('Block A')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Block]\r\n           ([BlockName])\r\n     VALUES\r\n           ('Block B')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Block]\r\n           ([BlockName])\r\n     VALUES\r\n           ('Block C')");

            migrationBuilder.Sql("INSERT INTO [dbo].[Flat]\r\n           ([BlockId]\r\n           ,[Status]\r\n           ,[TypeOfFlat]\r\n           ,[FloorNumber]\r\n           ,[FlatNumber]\r\n           ,[OwnerorTenant]\r\n           ,[ResidentId])\r\n     VALUES\r\n           (1\r\n           ,1\r\n           ,'2+1'\r\n           ,4\r\n           ,102\r\n           ,1\r\n           ,1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Flat]\r\n           ([BlockId]\r\n           ,[Status]\r\n           ,[TypeOfFlat]\r\n           ,[FloorNumber]\r\n           ,[FlatNumber]\r\n           ,[OwnerorTenant]\r\n           ,[ResidentId])\r\n     VALUES\r\n           (2\r\n           ,1\r\n           ,'3+1'\r\n           ,13\r\n           ,720\r\n           ,0\r\n           ,2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Flat]\r\n           ([BlockId]\r\n           ,[Status]\r\n           ,[TypeOfFlat]\r\n           ,[FloorNumber]\r\n           ,[FlatNumber]\r\n           ,[OwnerorTenant]\r\n           ,[ResidentId])\r\n     VALUES\r\n           (3\r\n           ,0\r\n           ,'2+1'\r\n           ,8\r\n           ,129\r\n           ,1\r\n           ,3)");

            migrationBuilder.Sql("INSERT INTO [dbo].[InvoiceType]\r\n           ([InvoiceTypeName])\r\n     VALUES\r\n           ('Water Invoice')");
            migrationBuilder.Sql("INSERT INTO [dbo].[InvoiceType]\r\n           ([InvoiceTypeName])\r\n     VALUES\r\n           ('Electric Invoice')");
            migrationBuilder.Sql("INSERT INTO [dbo].[InvoiceType]\r\n           ([InvoiceTypeName])\r\n     VALUES\r\n           ('Natural Gas Invoive')");
            migrationBuilder.Sql("INSERT INTO [dbo].[InvoiceType]\r\n           ([InvoiceTypeName])\r\n     VALUES\r\n           ('Other')");

            migrationBuilder.Sql("INSERT INTO [dbo].[Invoice]\r\n           ([InvoiceTypeId]\r\n           ,[ResidentId]\r\n           ,[Amount]\r\n           ,[Month]\r\n           ,[IsPaid])\r\n     VALUES\r\n           (1\r\n           ,1\r\n           ,550\r\n           ,1\r\n           ,1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Invoice]\r\n           ([InvoiceTypeId]\r\n           ,[ResidentId]\r\n           ,[Amount]\r\n           ,[Month]\r\n           ,[IsPaid])\r\n     VALUES\r\n           (2\r\n           ,2\r\n           ,250\r\n           ,1\r\n           ,1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Invoice]\r\n           ([InvoiceTypeId]\r\n           ,[ResidentId]\r\n           ,[Amount]\r\n           ,[Month]\r\n           ,[IsPaid])\r\n     VALUES\r\n           (3\r\n           ,3\r\n           ,150\r\n           ,1\r\n           ,0)");

            migrationBuilder.Sql("INSERT INTO [dbo].[Payment]\r\n           ([ResidentId]\r\n           ,[InvoiceId]\r\n           ,[PaymentAmount]\r\n           ,[DueDate])\r\n     VALUES\r\n           (1\r\n           ,1\r\n           ,326\r\n           ,'2023-08-06')");
            migrationBuilder.Sql("\r\nINSERT INTO [dbo].[Payment]\r\n       ([ResidentId]\r\n           ,[InvoiceId]\r\n           ,[PaymentAmount]\r\n           ,[DueDate])\r\n     VALUES\r\n           (2\r\n           ,2\r\n           ,450\r\n           ,'2023-08-15')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Payment]\r\n           ([ResidentId]\r\n           ,[InvoiceId]\r\n           ,[PaymentAmount]\r\n           ,[DueDate])\r\n     VALUES\r\n           (3\r\n           ,3\r\n           ,270\r\n           ,'2023-08-10')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
