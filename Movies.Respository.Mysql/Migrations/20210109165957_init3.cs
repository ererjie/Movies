using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Respository.Mysql.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_related_movies_group_Id",
                table: "movies_related");

            migrationBuilder.AlterColumn<string>(
                name: "MoviesGroupId",
                table: "movies_related",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_related_movies_group_MoviesGroupId",
                table: "movies_related");

            migrationBuilder.DropIndex(
                name: "IX_movies_related_MoviesGroupId",
                table: "movies_related");

            migrationBuilder.AlterColumn<string>(
                name: "MoviesGroupId",
                table: "movies_related",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_related_movies_group_Id",
                table: "movies_related",
                column: "Id",
                principalTable: "movies_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
