﻿// <auto-generated />
using ASPDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPDatabase.Migrations
{
    [DbContext(typeof(WorkerContext))]
    [Migration("20201115143022_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ASPDatabase.Models.Car", b =>
                {
                    b.Property<int>("carID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("kilometers")
                        .HasColumnType("int");

                    b.Property<string>("make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("carID");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
