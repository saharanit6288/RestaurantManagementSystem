using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManagementSystem.Migrations
{
    public partial class ReservationTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableId = table.Column<int>(nullable: false),
                    ReserveDate = table.Column<DateTime>(nullable: false),
                    RestaurantTableTableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_RestaurantTables_RestaurantTableTableId",
                        column: x => x.RestaurantTableTableId,
                        principalTable: "RestaurantTables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantTableTableId",
                table: "Reservations",
                column: "RestaurantTableTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
