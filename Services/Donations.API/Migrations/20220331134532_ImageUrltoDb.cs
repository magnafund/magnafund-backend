using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donations.API.Migrations
{
    public partial class ImageUrltoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Donations");
        }
    }
}
