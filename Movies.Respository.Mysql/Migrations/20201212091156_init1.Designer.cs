﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Respository.Mysql;

namespace Movies.Respository.Mysql.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20201212091156_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Movies.Domin.MoviesAccount", b =>
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

                    b.ToTable("movies_account");
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

                    b.Property<string>("MoviesGroupName");

                    b.HasKey("Id");

                    b.ToTable("movies_group");
                });

            modelBuilder.Entity("Movies.Domin.MoviesRelated", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("DelTime");

                    b.Property<string>("Image");

                    b.Property<bool>("IsDel");

                    b.Property<string>("MoviesName");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("movies_related");
                });

            modelBuilder.Entity("Movies.Domin.MoviesRelated", b =>
                {
                    b.HasOne("Movies.Domin.MoviesGroup", "MoviesGroup")
                        .WithMany("MoviesRelated")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
