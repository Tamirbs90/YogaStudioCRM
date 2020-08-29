using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class addMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Debt",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_MonthId",
                table: "Classes",
                column: "MonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropIndex(
                name: "IX_Classes_MonthId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Debt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MonthId",
                table: "Classes");
        }
    }
}
