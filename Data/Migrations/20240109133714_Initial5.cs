using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inz.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases");

            migrationBuilder.DropIndex(
                name: "IX_tripPurchases_ClientId",
                table: "tripPurchases");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "tripPurchases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "tripPurchases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tripPurchases_ClientId",
                table: "tripPurchases",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_tripPurchases_clients_ClientId",
                table: "tripPurchases",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");
        }
    }
}
