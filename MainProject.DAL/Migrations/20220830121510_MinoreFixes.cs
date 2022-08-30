using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainProject.DAL.Migrations
{
    public partial class MinoreFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skill_SkillId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_User_UserId",
                table: "UserSkills");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserSkills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "UserSkills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skill_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_User_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skill_SkillId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_User_UserId",
                table: "UserSkills");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserSkills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "UserSkills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skill_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_User_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
