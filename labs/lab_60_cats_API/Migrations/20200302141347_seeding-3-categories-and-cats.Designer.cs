﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_60_cats_API.Models;

namespace lab_60_cats_API.Migrations
{
    [DbContext(typeof(CatDbContext))]
    [Migration("20200302141347_seeding-3-categories-and-cats")]
    partial class seeding3categoriesandcats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_60_cats_API.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("CatId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            CatName = "Sanjana",
                            CategoryId = 1
                        },
                        new
                        {
                            CatId = 2,
                            CatName = "Petrova",
                            CategoryId = 3
                        },
                        new
                        {
                            CatId = 3,
                            CatName = "George",
                            CategoryId = 2
                        });
                });

            modelBuilder.Entity("lab_60_cats_API.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Bengal"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Tabby"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Siamese"
                        });
                });

            modelBuilder.Entity("lab_60_cats_API.Models.Cat", b =>
                {
                    b.HasOne("lab_60_cats_API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
