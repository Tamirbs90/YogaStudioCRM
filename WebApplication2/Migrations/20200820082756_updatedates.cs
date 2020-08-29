using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class updatedates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
