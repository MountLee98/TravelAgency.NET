﻿// <auto-generated />
using System;
using Biuro_podrozy_praca_inzynierska.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biuro_podrozy_praca_inzynierska.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221130192532_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("airports");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("continents");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FromAirportId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFirstMinute")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsLastMinute")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumberOfBooking")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceForAdult")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PriceForChild")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ToAirportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromAirportId");

                    b.HasIndex("HotelId");

                    b.HasIndex("ToAirportId");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.TripPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdultNumber")
                        .HasColumnType("int");

                    b.Property<int>("ChildNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("tripPurchases");
                });

            modelBuilder.Entity("Biuro_podrozy_praca_inzynierska.Model.Trip", b =>
                {
                    b.HasOne("Biuro_podrozy_praca_inzynierska.Model.Airport", "FromAirport")
                        .WithMany()
                        .HasForeignKey("FromAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biuro_podrozy_praca_inzynierska.Model.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biuro_podrozy_praca_inzynierska.Model.Airport", "ToAirport")
                        .WithMany()
                        .HasForeignKey("ToAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAirport");

                    b.Navigation("Hotel");

                    b.Navigation("ToAirport");
                });
#pragma warning restore 612, 618
        }
    }
}
