using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Respository.Mysql.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_related_movies_group_MoviesGroupId",
                table: "movies_related");

            migrationBuilder.DropIndex(
                name: "IX_movies_related_MoviesGroupId",
                table: "movies_related");

            migrationBuilder.DropColumn(
                name: "MoviesGroupId",
                table: "movies_related");

            migrationBuilder.CreateTable(
                name: "movies_group_and_related",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MoviesGroupId = table.Column<string>(nullable: true),
                    MoviesRelatedId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_group_and_related", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_group_and_related_movies_related_Id",
                        column: x => x.Id,
                        principalTable: "movies_related",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_group_and_related");

            migrationBuilder.AddColumn<string>(
                name: "MoviesGroupId",
                table: "movies_related",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movies_related_MoviesGroupId",
                table: "movies_related",
                column: "MoviesGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_related_movies_group_MoviesGroupId",
                table: "movies_related",
                column: "MoviesGroupId",
                principalTable: "movies_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
