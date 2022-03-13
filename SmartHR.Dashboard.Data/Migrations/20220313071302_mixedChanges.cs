using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHR.Dashboard.Data.Migrations
{
    public partial class mixedChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Technology_TechnologyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technology",
                table: "Technology");

            migrationBuilder.RenameTable(
                name: "Technology",
                newName: "Technologies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technology");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technology",
                table: "Technology",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Technology_TechnologyId",
                table: "Users",
                column: "TechnologyId",
                principalTable: "Technology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
