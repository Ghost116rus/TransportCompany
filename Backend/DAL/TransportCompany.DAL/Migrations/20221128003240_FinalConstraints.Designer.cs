﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportCompany.DAL;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    [DbContext(typeof(TransportCompanyContext))]
    [Migration("20221128003240_FinalConstraints")]
    partial class FinalConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TransportCompany.Domain.Entities.Driver", b =>
                {
                    b.Property<string>("Driver_license_number")
                        .HasColumnType("char(10)");

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("Driver_license_category")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Year_of_start_work")
                        .IsRequired()
                        .HasColumnType("char(4)");

                    b.HasKey("Driver_license_number");

                    b.HasIndex("Phone_number")
                        .IsUnique();

                    b.ToTable("Driver");

                    b.HasCheckConstraint("Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'На больничном'");

                    b.HasCheckConstraint("Year_of_start_work", "Year_of_start_work LIKE '[1-2][0,9][0-9][0-9]'");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Product", b =>
                {
                    b.Property<string>("Сatalogue_number")
                        .HasColumnType("char(35)");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("RequestNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Сatalogue_number");

                    b.HasIndex("RequestNumber");

                    b.ToTable("Product");

                    b.HasCheckConstraint("Cost", "Cost > 0");

                    b.HasCheckConstraint("Height", "Height > 0");

                    b.HasCheckConstraint("Length", "Length > 0");

                    b.HasCheckConstraint("Type", "Type LIKE 'крупногабаритный' OR Type LIKE 'малогабаритный'");

                    b.HasCheckConstraint("Weight", "Weight > 0");

                    b.HasCheckConstraint("Width", "Width > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Product_exmp", b =>
                {
                    b.Property<int>("Storage_number")
                        .HasColumnType("int");

                    b.Property<string>("Сatalogue_number")
                        .HasColumnType("char(35)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Storage_number", "Сatalogue_number");

                    b.HasIndex("Сatalogue_number");

                    b.ToTable("Product_exmp");

                    b.HasCheckConstraint("Storage_number", "Storage_number > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Requare_product", b =>
                {
                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<string>("Сatalogue_number")
                        .HasColumnType("char(35)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Сatalogue_number");

                    b.HasIndex("Сatalogue_number");

                    b.ToTable("Requare_product");

                    b.HasCheckConstraint("RequestID", "RequestID > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Request", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"), 1L, 1);

                    b.Property<int?>("Car_load")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_dispatch")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Delivery_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverID")
                        .HasColumnType("char(10)");

                    b.Property<int>("Num_Receiving_storage")
                        .HasColumnType("int");

                    b.Property<int?>("Num_Sending_storage")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("Total_cost")
                        .HasColumnType("int");

                    b.Property<int?>("Total_length")
                        .HasColumnType("int");

                    b.Property<int>("Total_mass")
                        .HasColumnType("int");

                    b.Property<int?>("Total_shipping_cost")
                        .HasColumnType("int");

                    b.Property<int?>("Total_time")
                        .HasColumnType("int");

                    b.Property<string>("VehicleID")
                        .HasColumnType("char(17)");

                    b.HasKey("Number");

                    b.HasIndex("DriverID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Request");

                    b.HasCheckConstraint("Car_load", "Car_load > 0");

                    b.HasCheckConstraint("Num_Receiving_storage", "Num_Receiving_storage > 0");

                    b.HasCheckConstraint("Num_Sending_storage", "Num_Sending_storage > 0");

                    b.HasCheckConstraint("Number", "Number > 0");

                    b.HasCheckConstraint("Status", "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена'");

                    b.HasCheckConstraint("Total_cost", "Total_cost > 0");

                    b.HasCheckConstraint("Total_length", "Total_length > 0");

                    b.HasCheckConstraint("Total_mass", "Total_mass > 0");

                    b.HasCheckConstraint("Total_shipping_cost", "Total_shipping_cost > 0");

                    b.HasCheckConstraint("Total_time", "Total_time > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Storage", b =>
                {
                    b.Property<int>("Storage_number")
                        .HasColumnType("int");

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("FIO_manager")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("Requests")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Storage_number");

                    b.HasIndex("Phone_number")
                        .IsUnique();

                    b.ToTable("Storage");

                    b.HasCheckConstraint("Requests", "Requests LIKE 'Отсутствуют' OR Requests LIKE 'Есть'");

                    b.HasCheckConstraint("Storage_number", "Storage_number > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Transport_vehicle", b =>
                {
                    b.Property<string>("Vehicle_identification_number")
                        .HasColumnType("char(17)");

                    b.Property<float>("Fuel_consumption")
                        .HasColumnType("real");

                    b.Property<int>("Load_capacity")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Required_category")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("Transported_volume")
                        .HasColumnType("int");

                    b.HasKey("Vehicle_identification_number");

                    b.ToTable("Transport_vehicle");

                    b.HasCheckConstraint("Fuel_consumption", "Fuel_consumption > 0");

                    b.HasCheckConstraint("Load_capacity", "Load_capacity > 0");

                    b.HasCheckConstraint("Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'В ремонте'");

                    b.HasCheckConstraint("Transported_volume", "Transported_volume > 0");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Product", b =>
                {
                    b.HasOne("TransportCompany.Domain.Entities.Request", null)
                        .WithMany("Products")
                        .HasForeignKey("RequestNumber");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Product_exmp", b =>
                {
                    b.HasOne("TransportCompany.Domain.Entities.Storage", "Storage")
                        .WithMany("Product_Exmps")
                        .HasForeignKey("Storage_number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportCompany.Domain.Entities.Product", "Product")
                        .WithMany("Product_Exmps")
                        .HasForeignKey("Сatalogue_number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Requare_product", b =>
                {
                    b.HasOne("TransportCompany.Domain.Entities.Request", "Request")
                        .WithMany("Requare_Products")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportCompany.Domain.Entities.Product", "Product")
                        .WithMany("Requare_Products")
                        .HasForeignKey("Сatalogue_number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Request", b =>
                {
                    b.HasOne("TransportCompany.Domain.Entities.Driver", "Driver")
                        .WithMany("Requests")
                        .HasForeignKey("DriverID");

                    b.HasOne("TransportCompany.Domain.Entities.Transport_vehicle", "vehicle")
                        .WithMany("Requests")
                        .HasForeignKey("VehicleID");

                    b.Navigation("Driver");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Product", b =>
                {
                    b.Navigation("Product_Exmps");

                    b.Navigation("Requare_Products");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Request", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Requare_Products");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Storage", b =>
                {
                    b.Navigation("Product_Exmps");
                });

            modelBuilder.Entity("TransportCompany.Domain.Entities.Transport_vehicle", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
