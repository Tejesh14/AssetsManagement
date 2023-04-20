﻿// <auto-generated />
using System;
using AssetManagementWebAPI.Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetManagementWebAPI.Data_Access_Layer.Migrations
{
    [DbContext(typeof(AssetDBContext))]
    [Migration("20220403180023_inti")]
    partial class inti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetManagementWebAPI.Data_Access_Layer.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPublish")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("AssetManagementWebAPI.Data_Access_Layer.Models.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfManufacture")
                        .HasColumnType("datetime2");

                    b.Property<string>("HardwareCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HardwareName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hardwares");
                });

            modelBuilder.Entity("AssetManagementWebAPI.Data_Access_Layer.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftwareCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftwareName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Softwares");
                });
#pragma warning restore 612, 618
        }
    }
}
