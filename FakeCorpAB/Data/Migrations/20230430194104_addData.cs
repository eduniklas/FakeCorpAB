using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FakeCorpAB.Data.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "City", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, "Road 2", "Pawne", "Tom", "Havafort" },
                    { 3, "Corner 1", "Pawne", "Ann", "Perkins" },
                    { 4, "The Pit 1", "Pawne", "Andy", "Dvier" },
                    { 5, "Mansion road", "Pawne", "Leslie", "Knope" }
                });

            migrationBuilder.InsertData(
                table: "VacationLists",
                columns: new[] { "VacationListId", "ApplicationTime", "End", "FK_EmployeeId", "FK_VacationId", "Start", "Status" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), "Done" });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "VacationId", "Description", "VacationType" },
                values: new object[,]
                {
                    { 2, "Taking care of sick child", "VAB" },
                    { 3, "Time off using saved overtime hours", "COMP" }
                });

            migrationBuilder.InsertData(
                table: "VacationLists",
                columns: new[] { "VacationListId", "ApplicationTime", "End", "FK_EmployeeId", "FK_VacationId", "Start", "Status" },
                values: new object[,]
                {
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004), "Done" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2001), 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2001), "Done" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1996), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994), 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1995), "Done" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1991), "Done" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2005), 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006), "Done" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VacationLists",
                keyColumn: "VacationListId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "VacationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "VacationId",
                keyValue: 2);
        }
    }
}
