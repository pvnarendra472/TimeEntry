using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeEntry.Migrations
{
    public partial class Added_Employee_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "TimeSheetEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "TimeSheetEntries");
        }
    }
}
