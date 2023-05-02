using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeCorpAB.Data.Migrations
{
    /// <inheritdoc />
    public partial class vacationtalble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                });

            migrationBuilder.CreateTable(
                name: "VacationLists",
                columns: table => new
                {
                    VacationListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FK_VacationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationLists", x => x.VacationListId);
                    table.ForeignKey(
                        name: "FK_VacationLists_Employees_FK_EmployeeId",
                        column: x => x.FK_EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationLists_Vacations_FK_VacationId",
                        column: x => x.FK_VacationId,
                        principalTable: "Vacations",
                        principalColumn: "VacationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationLists_FK_EmployeeId",
                table: "VacationLists",
                column: "FK_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationLists_FK_VacationId",
                table: "VacationLists",
                column: "FK_VacationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vacations");
        }
    }
}
