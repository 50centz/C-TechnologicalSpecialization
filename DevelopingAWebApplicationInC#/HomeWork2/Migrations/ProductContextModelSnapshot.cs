﻿// <auto-generated />
using System;
using HomeWork1.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomeWork1.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HomeWork1.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("CategoryName");

                    b.HasKey("Id")
                        .HasName("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("HomeWork1.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("integer")
                        .HasColumnName("Cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ProductName");

                    b.HasKey("Id")
                        .HasName("ProductId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("HomeWork1.Models.ProductStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ProductStorageName");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<int?>("StorageId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("ProductStorageId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.HasIndex("StorageId");

                    b.ToTable("ProductStorages", (string)null);
                });

            modelBuilder.Entity("HomeWork1.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("StorageName");

                    b.HasKey("Id")
                        .HasName("StorageId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Storages", (string)null);
                });

            modelBuilder.Entity("HomeWork1.Models.ProductStorage", b =>
                {
                    b.HasOne("HomeWork1.Models.Product", "Product")
                        .WithMany("ProductStorage")
                        .HasForeignKey("ProductId");

                    b.HasOne("HomeWork1.Models.Storage", "Storage")
                        .WithMany("ProductStorage")
                        .HasForeignKey("StorageId");

                    b.Navigation("Product");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("HomeWork1.Models.Product", b =>
                {
                    b.Navigation("ProductStorage");
                });

            modelBuilder.Entity("HomeWork1.Models.Storage", b =>
                {
                    b.Navigation("ProductStorage");
                });
#pragma warning restore 612, 618
        }
    }
}
