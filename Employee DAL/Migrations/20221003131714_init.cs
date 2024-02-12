using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    PhoneNo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roles = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    RoleMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_RoleMembers_RoleMemberId",
                        column: x => x.RoleMemberId,
                        principalTable: "RoleMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_RoleMembers_RoleMemberId",
                        column: x => x.RoleMemberId,
                        principalTable: "RoleMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectsEmployeeMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsEmployeeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsEmployeeMappings_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsEmployeeMappings_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEmployeeMappings_EmployeeId",
                table: "ProjectsEmployeeMappings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEmployeeMappings_ProjectId",
                table: "ProjectsEmployeeMappings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleMemberId",
                table: "Roles",
                column: "RoleMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleMemberId",
                table: "Users",
                column: "RoleMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsEmployeeMappings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "RoleMembers");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
