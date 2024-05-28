using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biuro_podrozy_praca_inzynierska.Migrations
{
    public partial class PoprawaBazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "tripPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "tripPurchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id");
        }
    }
}
