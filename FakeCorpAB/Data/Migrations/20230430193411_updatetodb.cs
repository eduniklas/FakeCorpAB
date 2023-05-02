using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeCorpAB.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vacations");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "VacationLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "VacationLists");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Vacations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
