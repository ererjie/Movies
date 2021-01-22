using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Respository.Mysql.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoviesGroupId",
                table: "movies_related",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoviesGroupId",
                table: "movies_related");
        }
    }
}
