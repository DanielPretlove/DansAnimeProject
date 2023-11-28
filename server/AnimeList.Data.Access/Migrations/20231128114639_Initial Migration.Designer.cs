﻿// <auto-generated />
using System;
using AnimeList.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeList.Data.Access.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20231128114639_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Anime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.AnimeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimeType");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SeasonsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeasonsId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Premired", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("SeasonalTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Premired");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Seasons", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<Guid>("PremiredId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ranked")
                        .HasColumnType("int");

                    b.Property<int>("RelatedAnime")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<Guid>("SeriesTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("PremiredId");

                    b.HasIndex("SeriesTypeId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailConfirmed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc496db5-892a-472b-8beb-20f148b645de"),
                            AccessFailCount = 0,
                            Email = "admin@gmail.com",
                            EmailConfirmed = "admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$11$vTS4yjab0QycFaLvcm4bIOCHuJ2Y8WLySw0W4jAaGia2whPLnC4dO",
                            Role = 0,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("66cc1ab7-ae23-491e-a511-5e0c23e9653d"),
                            AccessFailCount = 0,
                            Email = "user@gmail.com",
                            EmailConfirmed = "user@gmail.com",
                            FirstName = "User",
                            LastName = "User",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$11$EK61Lc9etXC/PKFtO/fXkeRuMfoyWx9bdicl2pUfhzKNMAOZYJfeC",
                            Role = 1,
                            UserName = "User"
                        },
                        new
                        {
                            Id = new Guid("f99dff03-33f5-4930-9c59-3f8b98e15ce7"),
                            AccessFailCount = 0,
                            Email = "guest@gmail.com",
                            EmailConfirmed = "guest@gmail.com",
                            FirstName = "Guest",
                            LastName = "Guest",
                            LockoutEnabled = false,
                            PasswordHash = "$2a$11$0NYFht5ypfyuG8vRBw4.XOvQlcokeQBCrZAQp6E5tS3r2xiaf.Tk2",
                            Role = 2,
                            UserName = "Guest"
                        });
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Genre", b =>
                {
                    b.HasOne("AnimeList.Data.Entities.AnimeSeries.Seasons", null)
                        .WithMany("Genre")
                        .HasForeignKey("SeasonsId");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Seasons", b =>
                {
                    b.HasOne("AnimeList.Data.Entities.AnimeSeries.Anime", null)
                        .WithMany("AnimeTitles")
                        .HasForeignKey("AnimeId");

                    b.HasOne("AnimeList.Data.Entities.AnimeSeries.Premired", "Premired")
                        .WithMany()
                        .HasForeignKey("PremiredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Data.Entities.AnimeSeries.AnimeType", "SeriesType")
                        .WithMany()
                        .HasForeignKey("SeriesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Premired");

                    b.Navigation("SeriesType");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Anime", b =>
                {
                    b.Navigation("AnimeTitles");
                });

            modelBuilder.Entity("AnimeList.Data.Entities.AnimeSeries.Seasons", b =>
                {
                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
