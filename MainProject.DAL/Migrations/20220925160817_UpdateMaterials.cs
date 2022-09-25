using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainProject.DAL.Migrations
{
    public partial class UpdateMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_User_UserId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_UserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "MaterialsUser",
                columns: table => new
                {
                    MaterialsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsUser", x => new { x.MaterialsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MaterialsUser_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialsUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsUser_UsersId",
                table: "MaterialsUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                return;
            }

            migrationBuilder.DropTable(
                name: "MaterialsUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UserId",
                table: "Materials",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_User_UserId",
                table: "Materials",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
