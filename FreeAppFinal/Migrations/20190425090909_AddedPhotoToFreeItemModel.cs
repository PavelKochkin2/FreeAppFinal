using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeAppFinal.Migrations
{
    public partial class AddedPhotoToFreeItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "FreeItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "FreeItems");
        }
    }
}
