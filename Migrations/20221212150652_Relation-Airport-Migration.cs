using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biuro_podrozy_praca_inzynierska.Migrations
{
    public partial class RelationAirportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "tripPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "tripPurchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContinentId",
                table: "country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "airports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tripPurchases_ClientId",
                table: "tripPurchases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tripPurchases_TripId",
                table: "tripPurchases",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_CityId",
                table: "hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_country_ContinentId",
                table: "country",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryId",
                table: "cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_airports_CityId",
                table: "airports",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_airports_cities_CityId",
                table: "airports",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_country_CountryId",
                table: "cities",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_country_continents_ContinentId",
                table: "country",
                column: "ContinentId",
                principalTable: "continents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_cities_CityId",
                table: "hotels",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airports_cities_CityId",
                table: "airports");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_country_CountryId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_country_continents_ContinentId",
                table: "country");

            migrationBuilder.DropForeignKey(
                name: "FK_hotels_cities_CityId",
                table: "hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_trips_TripId",
                table: "tripPurchases");

            migrationBuilder.DropIndex(
                name: "IX_tripPurchases_ClientId",
                table: "tripPurchases");

            migrationBuilder.DropIndex(
                name: "IX_tripPurchases_TripId",
                table: "tripPurchases");

            migrationBuilder.DropIndex(
                name: "IX_hotels_CityId",
                table: "hotels");

            migrationBuilder.DropIndex(
                name: "IX_country_ContinentId",
                table: "country");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryId",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_airports_CityId",
                table: "airports");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "tripPurchases");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "tripPurchases");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "country");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "airports");
        }
    }
}
