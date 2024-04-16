﻿// <auto-generated />
using System;
using APIControleDeProcessos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIControleDeProcessos.Migrations
{
    [DbContext(typeof(APIControleDeProcessosDBContext))]
    partial class APIControleDeProcessosDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIControleDeProcessos.Models.OrderModel", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Process")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Number");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderModels");
                });

            modelBuilder.Entity("APIControleDeProcessos.Models.ProductModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductModels");
                });

            modelBuilder.Entity("APIControleDeProcessos.Models.OrderModel", b =>
                {
                    b.HasOne("APIControleDeProcessos.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}