﻿// <auto-generated />
using System;
using AnimeList.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeList.Data.Access.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("57119219-2f62-44f8-a2af-0970ea0195cf"),
                            AccessFailCount = 0,
                            Email = "admin@gmail.com",
                            EmailConfirmed = "admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            PasswordHash = "A3984180E6FAF1739A2449B603522B197943F5761FE021BAEC9AEC8A706264048B1EE81C896815BBCF61881B45B3EEBF4B67790819934440FAA1751191D53EDE",
                            Role = 0,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c35bdf6d-869e-4825-b7cd-957fda7e3879"),
                            AccessFailCount = 0,
                            Email = "user@gmail.com",
                            EmailConfirmed = "user@gmail.com",
                            FirstName = "User",
                            LastName = "User",
                            LockoutEnabled = false,
                            PasswordHash = "F4A38A1998C23F150102A58098694D4C03A94A6C66EC35088249D55CBE42F752DA3D0F8C31634211473D769126011F4F2C06A67310C6FEB2F700152C327FBBA2",
                            Role = 1,
                            UserName = "User"
                        },
                        new
                        {
                            Id = new Guid("4b04ceb9-15af-42e3-b5cc-f585d3403746"),
                            AccessFailCount = 0,
                            Email = "guest@gmail.com",
                            EmailConfirmed = "guest@gmail.com",
                            FirstName = "Guest",
                            LastName = "Guest",
                            LockoutEnabled = false,
                            PasswordHash = "3964A9166A9955FE50CB4BB781671C35DFACC84DCCCA0532B0ADEFB7C1B7ED149E7F6740552591C9C0B7A4975482D52829C14A873124E397BE0B4E330C09AE9A",
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
