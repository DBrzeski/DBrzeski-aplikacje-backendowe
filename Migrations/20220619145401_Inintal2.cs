using Microsoft.EntityFrameworkCore.Migrations;

namespace storeapp.Migrations
{
    public partial class Inintal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ManufacturerId",
                table: "Item",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Manufacturer_ManufacturerId",
                table: "Item",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Manufacturer_ManufacturerId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Item_ManufacturerId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Item");
        }
    }
}
