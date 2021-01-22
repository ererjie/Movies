using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Respository.Mysql.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies_account",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_group",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    MoviesGroupName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_related",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MoviesName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_related", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_related_movies_group_Id",
                        column: x => x.Id,
                        principalTable: "movies_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_account");

            migrationBuilder.DropTable(
                name: "movies_related");

            migrationBuilder.DropTable(
                name: "movies_group");
        }
    }
}
