﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetCreativity.Core.Context;

#nullable disable

namespace SweetCreativity.Core.Migrations
{
    [DbContext(typeof(SweetCreativityContext))]
    partial class SweetCreativityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SweetCreativity.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NameCategory")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameCategory = "Торти"
                        },
                        new
                        {
                            Id = 2,
                            NameCategory = "Тістечка"
                        },
                        new
                        {
                            Id = 3,
                            NameCategory = "Цукерки"
                        },
                        new
                        {
                            Id = 4,
                            NameCategory = "Печиво"
                        },
                        new
                        {
                            Id = 5,
                            NameCategory = "Вафлі"
                        });
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtListing")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Listings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CoverPath = "\\img\\listing\\no_cover.jpg",
                            CreatedAtListing = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = " Це відомий і популярний торт, який складається з тонких шарів бісквіту і вершкового крему.",
                            Location = "Lviv",
                            Price = 165,
                            Product = "Борошно, вершкове масло, яйця, оцет, цукор, ванільний цукор або ванільний екстракт, кукурудзяний крохмаль, вершки, сіль, прикраси (за бажанням).",
                            Title = "Торт Наполеон",
                            UserId = 1,
                            Weight = 1000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CoverPath = "\\img\\listing\\no_cover.jpg",
                            CreatedAtListing = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Гармонійне поєднання повітряного шоколадного тіста мафіну з ніжно-солодкою вершковою начинкою.",
                            Location = "Rivne",
                            Price = 180,
                            Product = "Борошно пшеничне, цукор-пісок, суміш “Мафін шоколадний”, олія рослинна, меланж, вода. Начинка: згущене молоко “Іриска”з вершками.",
                            Title = "Мафіни",
                            UserId = 2,
                            Weight = 80
                        });
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtOrder")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("NameOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            CreatedAtOrder = new DateTime(2023, 10, 31, 16, 17, 46, 853, DateTimeKind.Local).AddTicks(1376),
                            CustomerNumber = 985684335,
                            ListingId = 1,
                            NameOrder = "Торт Наполеон",
                            Quantity = 1,
                            TotalPrice = 250m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            CreatedAtOrder = new DateTime(2023, 10, 31, 16, 17, 46, 853, DateTimeKind.Local).AddTicks(1433),
                            CustomerNumber = 985688735,
                            ListingId = 2,
                            NameOrder = "Торт Спартак",
                            Quantity = 1,
                            TotalPrice = 400m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("RatingPoint")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtResponse")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("TextResponse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsComplicted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("UrlSocialnetwork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            Email = "taniabondar@gmail.com",
                            FullName = "Тетяна Бондар",
                            Password = "2.0taniab",
                            PhoneNumber = 985674335,
                            UrlSocialnetwork = "@taniabondar23",
                            UserName = "Тетяна2.0"
                        },
                        new
                        {
                            Id = 2,
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            Email = "olenatkachuk@gmail.com",
                            FullName = "Олена Ткачук",
                            Password = "123olenatt",
                            PhoneNumber = 986390482,
                            UrlSocialnetwork = "@olena_tkachuk",
                            UserName = "ОленаT"
                        });
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Listing", b =>
                {
                    b.HasOne("SweetCreativity.Core.Entities.Category", "Category")
                        .WithMany("Listings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SweetCreativity.Core.Entities.User", "User")
                        .WithMany("Listings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Order", b =>
                {
                    b.HasOne("SweetCreativity.Core.Entities.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId");

                    b.HasOne("SweetCreativity.Core.Entities.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SweetCreativity.Core.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Listing");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Rating", b =>
                {
                    b.HasOne("SweetCreativity.Core.Entities.Listing", "Listing")
                        .WithMany("Ratings")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetCreativity.Core.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Response", b =>
                {
                    b.HasOne("SweetCreativity.Core.Entities.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId");

                    b.HasOne("SweetCreativity.Core.Entities.User", "User")
                        .WithMany("Responses")
                        .HasForeignKey("UserId");

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Category", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Listing", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SweetCreativity.Core.Entities.User", b =>
                {
                    b.Navigation("Listings");

                    b.Navigation("Orders");

                    b.Navigation("Ratings");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
