﻿// <auto-generated />
using Manufacture_ASP.NET_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manufacture_ASP.NET_MVC.Migrations
{
    [DbContext(typeof(ManufactureContext))]
    [Migration("20210917051505_complited_status_table")]
    partial class complited_status_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Export", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComplitedStatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ImporterId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComplitedStatusId");

                    b.HasIndex("ImporterId");

                    b.HasIndex("ProductId");

                    b.ToTable("Export");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Importer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Importer");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Complited")
                        .HasColumnType("bigint");

                    b.Property<long>("Defect")
                        .HasColumnType("bigint");

                    b.Property<long>("Plan")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Manufacture");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WholesalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Product_Raw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CostRate")
                        .HasColumnType("int");

                    b.Property<int>("Lost")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RawId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RawId");

                    b.ToTable("Product_Raw");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Raw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Raw");
                });

            modelBuilder.Entity("Manufacture_ASP.NET_MVC.Models.ComplitedStatus", b =>
                {
                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Status");

                    b.ToTable("ComplitedStatus");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Export", b =>
                {
                    b.HasOne("Manufacture_ASP.NET_MVC.Models.ComplitedStatus", "ComplitedStatus")
                        .WithMany()
                        .HasForeignKey("ComplitedStatusId");

                    b.HasOne("KP_MANUFACTURE_MVC.Models.Importer", "Importer")
                        .WithMany("Exports")
                        .HasForeignKey("ImporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KP_MANUFACTURE_MVC.Models.Product", "Product")
                        .WithMany("Exports")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComplitedStatus");

                    b.Navigation("Importer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Manufacture", b =>
                {
                    b.HasOne("KP_MANUFACTURE_MVC.Models.Product", "Product")
                        .WithMany("Manufactures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Product_Raw", b =>
                {
                    b.HasOne("KP_MANUFACTURE_MVC.Models.Product", "Product")
                        .WithMany("Product_Raws")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KP_MANUFACTURE_MVC.Models.Raw", "Raw")
                        .WithMany("Product_Raws")
                        .HasForeignKey("RawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Raw");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Importer", b =>
                {
                    b.Navigation("Exports");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Product", b =>
                {
                    b.Navigation("Exports");

                    b.Navigation("Manufactures");

                    b.Navigation("Product_Raws");
                });

            modelBuilder.Entity("KP_MANUFACTURE_MVC.Models.Raw", b =>
                {
                    b.Navigation("Product_Raws");
                });
#pragma warning restore 612, 618
        }
    }
}
