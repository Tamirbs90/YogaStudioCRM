using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class adddatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Persons_PersonId",
                table: "Classes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthId",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Persons_PersonId",
                table: "Classes",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Persons_PersonId",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MonthId",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Months_MonthId",
                table: "Classes",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Persons_PersonId",
                table: "Classes",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
