using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_DAL.Migrations
{
    public partial class jith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_RoleMembers_RoleMemberId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleMembers_RoleMemberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleMemberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleMemberId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleMemberId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleMemberId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "RoleMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RoleMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_RoleId",
                table: "RoleMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_UserId",
                table: "RoleMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMembers_Roles_RoleId",
                table: "RoleMembers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMembers_Users_UserId",
                table: "RoleMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMembers_Roles_RoleId",
                table: "RoleMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMembers_Users_UserId",
                table: "RoleMembers");

            migrationBuilder.DropIndex(
                name: "IX_RoleMembers_RoleId",
                table: "RoleMembers");

            migrationBuilder.DropIndex(
                name: "IX_RoleMembers_UserId",
                table: "RoleMembers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleMembers");

            migrationBuilder.AddColumn<int>(
                name: "RoleMemberId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleMemberId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleMemberId",
                table: "Users",
                column: "RoleMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleMemberId",
                table: "Roles",
                column: "RoleMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_RoleMembers_RoleMemberId",
                table: "Roles",
                column: "RoleMemberId",
                principalTable: "RoleMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleMembers_RoleMemberId",
                table: "Users",
                column: "RoleMemberId",
                principalTable: "RoleMembers",
                principalColumn: "Id");
        }
    }
}
