using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class updatepaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPaid",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Paid",
                table: "Classes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPaid",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Classes");
        }
    }
}
