﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Respository.Mysql;

namespace Movies.Respository.Mysql.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Movies.Domin.AdminAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("DelTime");

                    b.Property<DateTime?>("EditTime");

                    b.Property<bool>("IsDel");

                    b.Property<DateTime?>("LastLoginTime");

                    b.Property<string>("NickName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("admin_account");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesAndGroup", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("MoviesGroupId");

                    b.Property<string>("MoviesId");

                    b.HasKey("Id");

                    b.ToTable("movies_and_group");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesAndLine", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("MoviesId");

                    b.Property<string>("MoviesLineId");

                    b.HasKey("Id");

                    b.ToTable("movies_and_line");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesArea", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaName");

                    b.Property<DateTime>("CreateTime");

                    b.HasKey("Id");

                    b.ToTable("movies_area");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesBanner", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Banner");

                    b.Property<string>("Introduction");

                    b.Property<string>("MoviesId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("movies_banner");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesDramaSeries", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DramaSeriesNum");

                    b.Property<string>("MoviesId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("movies_drama_series");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesIntroduction", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ActorName");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DirectorName");

                    b.Property<string>("IntroductionContent");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("movies_introduction");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesLine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("MoviesId");

                    b.Property<string>("MoviesRelatedId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("movies_line");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesReleaseTime", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ReleaseYear");

                    b.HasKey("Id");

                    b.ToTable("movies_release_time");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesTag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("MoviesGroupId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MoviesGroupId");

                    b.ToTable("movies_tag");
                });

            modelBuilder.Entity("Movies.Domin.Movies", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaName");

                    b.Property<string>("Cover");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("DelTime");

                    b.Property<decimal>("Douban")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDel");

                    b.Property<bool>("IsRecommend");

                    b.Property<string>("Name");

                    b.Property<string>("ReleaseDay");

                    b.Property<string>("ReleaseMonth");

                    b.Property<DateTime>("ReleaseTime");

                    b.Property<string>("ReleaseYear");

                    b.Property<int>("Sort");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Movies.Domin.MoviesGroup", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("DelTime");

                    b.Property<DateTime?>("EditTime");

                    b.Property<bool>("IsDel");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("movies_group");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesAndGroup", b =>
                {
                    b.HasOne("Movies.Domin.Movies", "Movies")
                        .WithOne("MoviesAndGroup")
                        .HasForeignKey("Movies.Domin.Model.MoviesAndGroup", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesAndLine", b =>
                {
                    b.HasOne("Movies.Domin.Movies", "Movies")
                        .WithOne("MoviesAndLine")
                        .HasForeignKey("Movies.Domin.Model.MoviesAndLine", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesDramaSeries", b =>
                {
                    b.HasOne("Movies.Domin.Movies", "Movies")
                        .WithMany("MoviesDramaSeries")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesIntroduction", b =>
                {
                    b.HasOne("Movies.Domin.Movies", "Movies")
                        .WithOne("MoviesIntroduction")
                        .HasForeignKey("Movies.Domin.Model.MoviesIntroduction", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesLine", b =>
                {
                    b.HasOne("Movies.Domin.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId");
                });

            modelBuilder.Entity("Movies.Domin.Model.MoviesTag", b =>
                {
                    b.HasOne("Movies.Domin.MoviesGroup", "MoviesGroup")
                        .WithMany("MoviesTag")
                        .HasForeignKey("MoviesGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
