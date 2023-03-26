using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsItAcademyGe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statusses_Status",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "EventStatusses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventStatusCode = table.Column<int>(type: "int", nullable: false),
                    EventStatusDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatusses", x => x.ID);
                    table.UniqueConstraint("AK_EventStatusses_EventStatusCode", x => x.EventStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    EventDescription = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    TicketAmount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndData = table.Column<DateTime>(type: "date", nullable: false),
                    EventStatus = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_EventStatusses_EventStatus",
                        column: x => x.EventStatus,
                        principalTable: "EventStatusses",
                        principalColumn: "EventStatusCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Statusses_Status",
                        column: x => x.Status,
                        principalTable: "Statusses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EventStatusses",
                columns: new[] { "ID", "EventStatusCode", "EventStatusDescription" },
                values: new object[,]
                {
                    { 1, 1, "Pending" },
                    { 2, 2, "Active" },
                    { 3, 3, "Finished" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStatus",
                table: "Events",
                column: "EventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerID",
                table: "Events",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Status",
                table: "Events",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statusses_Status",
                table: "Users",
                column: "Status",
                principalTable: "Statusses",
                principalColumn: "StatusCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statusses_Status",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventStatusses");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statusses_Status",
                table: "Users",
                column: "Status",
                principalTable: "Statusses",
                principalColumn: "StatusCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
