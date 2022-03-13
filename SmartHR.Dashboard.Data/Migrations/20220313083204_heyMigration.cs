using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHR.Dashboard.Data.Migrations
{
    public partial class heyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TechnologyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technology",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Technology",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "TechnologyId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TechnologyId",
                table: "Users",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Technologies_TechnologyId",
                table: "Users",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
