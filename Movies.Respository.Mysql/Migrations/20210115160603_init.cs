using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Respository.Mysql.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_account");

            migrationBuilder.DropTable(
                name: "movies_group_and_related");

            migrationBuilder.DropTable(
                name: "movies_related");

            migrationBuilder.RenameColumn(
                name: "MoviesGroupName",
                table: "movies_group",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "admin_account",
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
                    table.PrimaryKey("PK_admin_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Douban = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseYear = table.Column<string>(nullable: true),
                    ReleaseMonth = table.Column<string>(nullable: true),
                    ReleaseDay = table.Column<string>(nullable: true),
                    ReleaseTime = table.Column<DateTime>(nullable: false),
                    AreaName = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    IsRecommend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_area",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AreaName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_banner",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Banner = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    MoviesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_release_time",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReleaseYear = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_release_time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_tag",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MoviesGroupId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_tag_movies_group_MoviesGroupId",
                        column: x => x.MoviesGroupId,
                        principalTable: "movies_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_and_group",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MoviesGroupId = table.Column<string>(nullable: true),
                    MoviesId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_and_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_and_group_movies_Id",
                        column: x => x.Id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_and_line",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MoviesId = table.Column<string>(nullable: true),
                    MoviesLineId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_and_line", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_and_line_movies_Id",
                        column: x => x.Id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_drama_series",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DramaSeriesNum = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    MoviesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_drama_series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_drama_series_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_introduction",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DirectorName = table.Column<string>(nullable: true),
                    ActorName = table.Column<string>(nullable: true),
                    IntroductionContent = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_introduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_introduction_movies_Id",
                        column: x => x.Id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_line",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    MoviesRelatedId = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    MoviesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_line", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_line_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_drama_series_MoviesId",
                table: "movies_drama_series",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_line_MoviesId",
                table: "movies_line",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_tag_MoviesGroupId",
                table: "movies_tag",
                column: "MoviesGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_account");

            migrationBuilder.DropTable(
                name: "movies_and_group");

            migrationBuilder.DropTable(
                name: "movies_and_line");

            migrationBuilder.DropTable(
                name: "movies_area");

            migrationBuilder.DropTable(
                name: "movies_banner");

            migrationBuilder.DropTable(
                name: "movies_drama_series");

            migrationBuilder.DropTable(
                name: "movies_introduction");

            migrationBuilder.DropTable(
                name: "movies_line");

            migrationBuilder.DropTable(
                name: "movies_release_time");

            migrationBuilder.DropTable(
                name: "movies_tag");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "movies_group",
                newName: "MoviesGroupName");

            migrationBuilder.CreateTable(
                name: "movies_account",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_related",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsDel = table.Column<bool>(nullable: false),
                    MoviesName = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_related", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies_group_and_related",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    MoviesGroupId = table.Column<string>(nullable: true),
                    MoviesRelatedId = table.Column<string>(nullable: true)
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
    }
}
