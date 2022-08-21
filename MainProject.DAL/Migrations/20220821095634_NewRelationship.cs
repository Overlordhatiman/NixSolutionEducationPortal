using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainProject.DAL.Migrations
{
    public partial class NewRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Course_CourseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Course_CourseId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CourseId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CourseId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "CourseMaterials",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterials", x => new { x.CoursesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_CourseMaterials_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMaterials_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSkill",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSkill", x => new { x.CoursesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CourseSkill_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSkill_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterials_MaterialsId",
                table: "CourseMaterials",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSkill_SkillsId",
                table: "CourseSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropTable(
                name: "CourseMaterials");

            migrationBuilder.DropTable(
                name: "CourseSkill");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CourseId",
                table: "Skill",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Course_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Course_CourseId",
                table: "Skill",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
