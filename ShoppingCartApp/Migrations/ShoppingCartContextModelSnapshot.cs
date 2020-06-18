﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    partial class ShoppingCartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCartApp.Domain.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Martin WickrmaSinghe",
                            Image = "MadolDoova.jpg",
                            Name = "Madol Doova",
                            Price = 300f,
                            Stock = 100,
                            Type = "Sinhala Novel"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jagath Samarajeewa",
                            Image = "Hapana.jpg",
                            Name = "Hapana",
                            Price = 150f,
                            Stock = 200,
                            Type = "Kids"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Charles Dickens",
                            Image = "olivertwist.jpg",
                            Name = "Oliver Twist",
                            Price = 550f,
                            Stock = 50,
                            Type = "English Novel"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Arthur Conan Doyle",
                            Image = "Sherlock Homes.jpg",
                            Name = "Sherlock Holmes",
                            Price = 600f,
                            Stock = 300,
                            Type = "English Novel"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Arthur Conan Doyle",
                            Image = "The Lost World.jpg",
                            Name = "The Lost World",
                            Price = 400f,
                            Stock = 180,
                            Type = "English Novel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
