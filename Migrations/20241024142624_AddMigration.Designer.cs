﻿// <auto-generated />
using System;
using Developer_Task.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Developer_Task.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241024142624_AddMigration")]
    partial class AddMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Developer_Task.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "English"
                        },
                        new
                        {
                            Id = 2,
                            Name = "French"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Spanish"
                        });
                });

            modelBuilder.Entity("Developer_Task.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Developer_Task.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudentClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Third"
                        });
                });

            modelBuilder.Entity("Developer_Task.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("StudentClassId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            Name = "Mathematics",
                            StudentClassId = 1
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 2,
                            Name = "Physics",
                            StudentClassId = 2
                        },
                        new
                        {
                            Id = 3,
                            LanguageId = 3,
                            Name = "Chemistry",
                            StudentClassId = 3
                        });
                });

            modelBuilder.Entity("Developer_Task.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Developer_Task.Models.Student", b =>
                {
                    b.HasOne("Developer_Task.Models.StudentClass", "StudentClass")
                        .WithMany("Students")
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentClass");
                });

            modelBuilder.Entity("Developer_Task.Models.Subject", b =>
                {
                    b.HasOne("Developer_Task.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Developer_Task.Models.StudentClass", "StudentClass")
                        .WithMany()
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("StudentClass");
                });

            modelBuilder.Entity("Developer_Task.Models.StudentClass", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
