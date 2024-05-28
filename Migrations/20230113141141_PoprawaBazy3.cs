using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biuro_podrozy_praca_inzynierska.Migrations
{
    public partial class PoprawaBazy3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "trips",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "trips");
        }
    }
}
