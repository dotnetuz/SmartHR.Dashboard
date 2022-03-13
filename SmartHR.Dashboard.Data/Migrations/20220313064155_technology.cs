using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmartHR.Dashboard.Data.Migrations
{
    public partial class technology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TechnologyId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TechnologyId",
                table: "Users",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Technology_TechnologyId",
                table: "Users",
                column: "TechnologyId",
                principalTable: "Technology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Technology_TechnologyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Technology");

            migrationBuilder.DropIndex(
                name: "IX_Users_TechnologyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Users");
        }
    }
}
