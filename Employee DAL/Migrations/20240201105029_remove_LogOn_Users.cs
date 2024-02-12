using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_DAL.Migrations
{
    public partial class remove_LogOn_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogOn",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LogOn",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }
    }
}
