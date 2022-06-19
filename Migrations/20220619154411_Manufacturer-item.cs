using Microsoft.EntityFrameworkCore.Migrations;

namespace storeapp.Migrations
{
    public partial class Manufactureritem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Item");
        }
    }
}
