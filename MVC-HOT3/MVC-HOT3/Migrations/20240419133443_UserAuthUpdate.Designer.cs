﻿// <auto-generated />
using System;
using MVC_HOT3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_HOT3.Migrations
{
    [DbContext(typeof(TechStoreContext))]
    [Migration("20240419133443_UserAuthUpdate")]
    partial class UserAuthUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_HOT3.Models.Phone", b =>
                {
                    b.Property<int>("PhoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneID"));

                    b.Property<string>("PhoneBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneOsID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("PhonePrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("PhoneID");

                    b.HasIndex("PhoneOsID");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            PhoneID = 1,
                            PhoneBrand = "Apple",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "A2403",
                            PhoneName = "iPhone 12",
                            PhoneOsID = 1,
                            PhonePrice = 100.0
                        },
                        new
                        {
                            PhoneID = 6,
                            PhoneBrand = "Apple",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "A2403",
                            PhoneName = "iPhone 15",
                            PhoneOsID = 1,
                            PhonePrice = 100.0
                        },
                        new
                        {
                            PhoneID = 2,
                            PhoneBrand = "Samsung",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "SM-G991U",
                            PhoneName = "Galaxy S21",
                            PhoneOsID = 2,
                            PhonePrice = 100.0
                        },
                        new
                        {
                            PhoneID = 3,
                            PhoneBrand = "Google",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "GD1YQ",
                            PhoneName = "Pixel 5",
                            PhoneOsID = 2,
                            PhonePrice = 100.0
                        },
                        new
                        {
                            PhoneID = 4,
                            PhoneBrand = "Samsung",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "SM-G991U",
                            PhoneName = "Galaxy S22 Ulta",
                            PhoneOsID = 2,
                            PhonePrice = 100.0
                        },
                        new
                        {
                            PhoneID = 5,
                            PhoneBrand = "Samsung",
                            PhoneImageName = "Phone.png",
                            PhoneModel = "SM-Z999A",
                            PhoneName = "Galaxy S35 Ulta Super",
                            PhoneOsID = 2,
                            PhonePrice = 100.0
                        });
                });

            modelBuilder.Entity("MVC_HOT3.Models.PhoneOs", b =>
                {
                    b.Property<int>("PhoneOsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneOsID"));

                    b.Property<string>("PhoneOsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneOsID");

                    b.ToTable("PhoneOs");

                    b.HasData(
                        new
                        {
                            PhoneOsID = 1,
                            PhoneOsName = "iOS"
                        },
                        new
                        {
                            PhoneOsID = 2,
                            PhoneOsName = "Android"
                        });
                });

            modelBuilder.Entity("MVC_HOT3.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseID"));

                    b.Property<int>("PhoneID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PurchaseID");

                    b.HasIndex("PhoneID");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("MVC_HOT3.Models.Phone", b =>
                {
                    b.HasOne("MVC_HOT3.Models.PhoneOs", "PhoneOs")
                        .WithMany()
                        .HasForeignKey("PhoneOsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhoneOs");
                });

            modelBuilder.Entity("MVC_HOT3.Models.Purchase", b =>
                {
                    b.HasOne("MVC_HOT3.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phone");
                });
#pragma warning restore 612, 618
        }
    }
}
