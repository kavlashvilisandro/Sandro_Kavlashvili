using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsItAcademyGe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminID", "AdminName", "AdminPassword" },
                values: new object[] { 1, "MainAdmin", "fdb203aa7d6e599674fed8d2a2bfa1024bb37907db5314e8adaa1b33bdaa521c67c3476af46856243ef1dea5326bf78818a98086261ddfc0c5c2c5541f166c55" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
