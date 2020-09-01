﻿// <auto-generated />
using Lecture.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lecture.Migrations
{
    [DbContext(typeof(ApartmentDbContext))]
    partial class ApartmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Lecture.Models.ResidentModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("apartmentNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("hasPets")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("residents");
                });
#pragma warning restore 612, 618
        }
    }
}
