using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6910), new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6926), new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6927), new DateTime(2023, 2, 19, 19, 32, 19, 792, DateTimeKind.Local).AddTicks(6927) });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTable_Status",
                table: "ToDoTable",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTable_Statuses_Status",
                table: "ToDoTable",
                column: "Status",
                principalTable: "Statuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTable_Statuses_Status",
                table: "ToDoTable");

            migrationBuilder.DropIndex(
                name: "IX_ToDoTable_Status",
                table: "ToDoTable");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2896), new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2909), new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2911), new DateTime(2023, 2, 19, 19, 6, 42, 553, DateTimeKind.Local).AddTicks(2912) });
        }
    }
}
