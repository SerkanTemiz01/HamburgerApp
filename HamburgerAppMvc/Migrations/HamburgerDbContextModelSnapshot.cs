﻿// <auto-generated />
using System;
using HamburgerAppMvc.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HamburgerAppMvc.Migrations
{
    [DbContext(typeof(HamburgerDbContext))]
    partial class HamburgerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExtraOrder", b =>
                {
                    b.Property<int>("ExtrasExtraID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.HasKey("ExtrasExtraID", "OrdersID");

                    b.HasIndex("OrdersID");

                    b.ToTable("ExtraOrder");
                });

            modelBuilder.Entity("HamburgerAppMvc.Models.Extra", b =>
                {
                    b.Property<int>("ExtraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtraID"));

                    b.Property<string>("ExtraName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ExtraID");

                    b.ToTable("Extras");

                    b.HasData(
                        new
                        {
                            ExtraID = 1,
                            ExtraName = "Barbeque",
                            Price = 10m,
                            Status = 1
                        },
                        new
                        {
                            ExtraID = 2,
                            ExtraName = "Ketchup",
                            Price = 9m,
                            Status = 1
                        },
                        new
                        {
                            ExtraID = 3,
                            ExtraName = "Ranch",
                            Price = 12m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("HamburgerAppMvc.Models.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuID"));

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("MenuID");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuID = 1,
                            MenuName = "Mass SteakHouse",
                            Price = 150m,
                            Status = 1
                        },
                        new
                        {
                            MenuID = 2,
                            MenuName = "Double MassBurger",
                            Price = 140m,
                            Status = 1
                        },
                        new
                        {
                            MenuID = 3,
                            MenuName = "Cheese & MassBurger",
                            Price = 130m,
                            Status = 1
                        },
                        new
                        {
                            MenuID = 4,
                            MenuName = "MassBurger",
                            Price = 120m,
                            Status = 1
                        });
                });

            modelBuilder.Entity("HamburgerAppMvc.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ExtraOrder", b =>
                {
                    b.HasOne("HamburgerAppMvc.Models.Extra", null)
                        .WithMany()
                        .HasForeignKey("ExtrasExtraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HamburgerAppMvc.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HamburgerAppMvc.Models.Order", b =>
                {
                    b.HasOne("HamburgerAppMvc.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID");

                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}