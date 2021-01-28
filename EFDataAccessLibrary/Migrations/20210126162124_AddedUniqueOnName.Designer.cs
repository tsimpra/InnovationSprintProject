﻿// <auto-generated />
using System;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDataAccessLibrary.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20210126162124_AddedUniqueOnName")]
    partial class AddedUniqueOnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataAccessLibrary.Models.MorbidityGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MorbidityGroups");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dob")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.PatientMorbidityGroup", b =>
                {
                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long>("MorbidityGroupId")
                        .HasColumnType("bigint");

                    b.HasKey("PatientId", "MorbidityGroupId");

                    b.HasIndex("MorbidityGroupId");

                    b.ToTable("PatientMorbidityGroup");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.SymptomInstance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PatientId");

                    b.ToTable("SymptomInstances");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.PatientMorbidityGroup", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.MorbidityGroup", "MorbidityGroup")
                        .WithMany("Patients")
                        .HasForeignKey("MorbidityGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.Patient", "Patient")
                        .WithMany("MorbidityGroups")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.SymptomInstance", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Patient", "Patient")
                        .WithMany("SymptomInstances")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}