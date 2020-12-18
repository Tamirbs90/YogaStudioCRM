using Microsoft.EntityFrameworkCore.Migrations;

namespace YogaStudio.Migrations
{
    public partial class updateyogalesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesPartipciations_YogaLessons_YogaLessonId",
                table: "ClassesPartipciations");

            migrationBuilder.AlterColumn<int>(
                name: "YogaLessonId",
                table: "ClassesPartipciations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesPartipciations_YogaLessons_YogaLessonId",
                table: "ClassesPartipciations",
                column: "YogaLessonId",
                principalTable: "YogaLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesPartipciations_YogaLessons_YogaLessonId",
                table: "ClassesPartipciations");

            migrationBuilder.AlterColumn<int>(
                name: "YogaLessonId",
                table: "ClassesPartipciations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesPartipciations_YogaLessons_YogaLessonId",
                table: "ClassesPartipciations",
                column: "YogaLessonId",
                principalTable: "YogaLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
