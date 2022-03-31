using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Donations.API.Migrations
{
    public partial class DonationCategoryToDbII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Donations");
        }
    }
}
