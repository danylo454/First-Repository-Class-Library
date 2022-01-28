using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyID", "Name", "Position", "Salary", "Surname" },
                values: new object[] { 1, 1, "Bill", "CEO", 300000, "Gates" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyID", "Name", "Position", "Salary", "Surname" },
                values: new object[] { 2, 1, "Tim", "Developer", 8000, "Ridgers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
