using Microsoft.EntityFrameworkCore.Migrations;

namespace DeleaSarca_Georgiana_proiect.Migrations
{
    public partial class LeadSinger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortHistory",
                table: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "LeadSinger",
                table: "Artist",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadSinger",
                table: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "ShortHistory",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
