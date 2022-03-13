using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHR.Dashboard.Data.Migrations
{
    public partial class mixedChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Technologies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicantId",
                table: "Interviews",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_ApplicantId",
                table: "Interviews",
                column: "ApplicantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_ApplicantId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_ApplicantId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technologies");
        }
    }
}
