﻿// <auto-generated />
using System;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryManagement.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("InventoryManagement.Core.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("InventoryManagement.Core.ItemAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("InventoryManagement.Core.ManufacturerAggregate.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers", (string)null);
                });

            modelBuilder.Entity("InventoryManagement.Core.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Manufacturer_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Manufacturer_id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("InventoryManagement.Core.StaffAggregate.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("InventoryManagement.Core.CategoryAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryManagement.Core.ProductAggregate.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Core.CategoryAggregate.Category", b =>
                {
                    b.OwnsOne("InventoryManagement.Core.CategoryAggregate.ValueObjects.CategoryName", "CategoryName", b1 =>
                        {
                            b1.Property<int>("CategoryId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("CategoryId");

                            b1.HasIndex("Name")
                                .IsUnique();

                            b1.ToTable("Categories");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("CategoryName")
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Core.ItemAggregate.Item", b =>
                {
                    b.HasOne("InventoryManagement.Core.ProductAggregate.Product", null)
                        .WithMany("Items")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("InventoryManagement.Core.ItemAggregate.ValueObjects.DateCode", "DateCode", b1 =>
                        {
                            b1.Property<Guid>("ItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DateCode");

                            b1.HasKey("ItemId");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });

                    b.OwnsOne("InventoryManagement.Core.ItemAggregate.ValueObjects.SerialNumber", "SerialNumber", b1 =>
                        {
                            b1.Property<Guid>("ItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Serial Number");

                            b1.HasKey("ItemId");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });

                    b.Navigation("DateCode")
                        .IsRequired();

                    b.Navigation("SerialNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Core.ProductAggregate.Product", b =>
                {
                    b.HasOne("InventoryManagement.Core.ManufacturerAggregate.Manufacturer", null)
                        .WithMany("Products")
                        .HasForeignKey("Manufacturer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("InventoryManagement.Core.ProductAggregate.Enums.Frequency", "Frequency", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Frequency");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("InventoryManagement.Core.ProductAggregate.ValueObjects.ProductCode", "ProductCode", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("ProductCode");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Frequency")
                        .IsRequired();

                    b.Navigation("ProductCode")
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Core.StaffAggregate.Staff", b =>
                {
                    b.OwnsOne("InventoryManagement.Core.StaffAggregate.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("StaffId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("StaffId");

                            b1.ToTable("Staff");

                            b1.WithOwner()
                                .HasForeignKey("StaffId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Core.ManufacturerAggregate.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("InventoryManagement.Core.ProductAggregate.Product", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
