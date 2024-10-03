using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inz.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DepartureDate",
                table: "trips",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ArrivalDate",
                table: "trips",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "trips",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "trips",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "tripPurchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "tripPurchases",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tripPurchases_UserId",
                table: "tripPurchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_AspNetUsers_UserId",
                table: "tripPurchases",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_AspNetUsers_UserId",
                table: "tripPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases");

            migrationBuilder.DropIndex(
                name: "IX_tripPurchases_UserId",
                table: "tripPurchases");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tripPurchases");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "trips",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDate",
                table: "trips",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "tripPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
