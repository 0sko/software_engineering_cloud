﻿// <auto-generated />
using System;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarRentalSystem.Migrations
{
    [DbContext(typeof(PgsqlContext))]
    partial class PgsqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarRentalSystem.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CustomerUserID")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerUserID1")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCarAvailable")
                        .HasColumnType("boolean");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("RentalId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarID");

                    b.HasIndex("CustomerUserID");

                    b.HasIndex("CustomerUserID1");

                    b.HasIndex("RentalId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("RentEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RentStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("RentalTotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRentalSystem.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CarRentalSystem.Agent", b =>
                {
                    b.HasBaseType("CarRentalSystem.User");

                    b.Property<int>("AgentCode")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Agent");
                });

            modelBuilder.Entity("CarRentalSystem.Customer", b =>
                {
                    b.HasBaseType("CarRentalSystem.User");

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("numeric");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("CarRentalSystem.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Customer", null)
                        .WithMany("Cart")
                        .HasForeignKey("CustomerUserID");

                    b.HasOne("CarRentalSystem.Customer", null)
                        .WithMany("RentedCars")
                        .HasForeignKey("CustomerUserID1");

                    b.HasOne("CarRentalSystem.Models.Rental", null)
                        .WithMany("Cars")
                        .HasForeignKey("RentalId");
                });

            modelBuilder.Entity("CarRentalSystem.Models.Rental", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Customer", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("RentedCars");
                });
#pragma warning restore 612, 618
        }
    }
}
