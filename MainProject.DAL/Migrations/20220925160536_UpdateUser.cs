using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainProject.DAL.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "UserCourses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "UserCourses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Course_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
