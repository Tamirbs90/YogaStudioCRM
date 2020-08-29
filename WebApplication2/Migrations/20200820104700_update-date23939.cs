using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class updatedate23939 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Classes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
