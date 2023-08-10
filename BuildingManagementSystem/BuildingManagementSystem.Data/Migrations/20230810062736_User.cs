using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User",
                column: "Id");
        }
    }
}
