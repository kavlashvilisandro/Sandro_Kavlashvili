﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsItAcademyGe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SettingModerators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsModerator",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsModerator",
                table: "Users");
        }
    }
}
