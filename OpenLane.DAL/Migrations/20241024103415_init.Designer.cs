﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Openlane.DAL;

#nullable disable

namespace OpenLane.DAL.Migrations
{
    [DbContext(typeof(Openlanecontext))]
    [Migration("20241024103415_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Domain.Bike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("TEXT");

                    b.Property<string>("BikeContainerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Equipments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstRegistrationDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IncludesAllTaxes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BikeContainerId");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("Domain.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BikeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Domain.Taxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BikeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("Openlane.Domain.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BikeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Openlane.Domain.BikeContainer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BikeContainers");
                });

            modelBuilder.Entity("Domain.Bike", b =>
                {
                    b.HasOne("Openlane.Domain.BikeContainer", "BikeContainer")
                        .WithMany("Bikes")
                        .HasForeignKey("BikeContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BikeContainer");
                });

            modelBuilder.Entity("Domain.Document", b =>
                {
                    b.HasOne("Domain.Bike", "Bike")
                        .WithMany("Documents")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");
                });

            modelBuilder.Entity("Domain.Taxes", b =>
                {
                    b.HasOne("Domain.Bike", "Bike")
                        .WithMany("Taxes")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");
                });

            modelBuilder.Entity("Openlane.Domain.Bid", b =>
                {
                    b.HasOne("Domain.Bike", "Bike")
                        .WithMany("Bids")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");
                });

            modelBuilder.Entity("Domain.Bike", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Documents");

                    b.Navigation("Taxes");
                });

            modelBuilder.Entity("Openlane.Domain.BikeContainer", b =>
                {
                    b.Navigation("Bikes");
                });
#pragma warning restore 612, 618
        }
    }
}
