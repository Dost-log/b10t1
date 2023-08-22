﻿// <auto-generated />
using System;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(LoanDBContext))]
    partial class LoanDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Entities.AdminMasters", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DOJ")
                        .HasColumnType("DateTime");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("char");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("EmployeeId");

                    b.ToTable("AdminMasters");
                });

            modelBuilder.Entity("Backend.Entities.EmployeeCards", b =>
                {
                    b.Property<int>("emp_card_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emp_card_id"));

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("LoanId")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("issue_date")
                        .HasColumnType("DateTime");

                    b.HasKey("emp_card_id");

                    b.ToTable("EmployeeCards");
                });

            modelBuilder.Entity("Backend.Entities.EmployeeIssues", b =>
                {
                    b.Property<int>("issueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("issueId"));

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("issue_date")
                        .HasColumnType("DateTime");

                    b.Property<string>("itemId")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("return_date")
                        .HasColumnType("DateTime");

                    b.HasKey("issueId");

                    b.ToTable("EmployeeIssues");
                });

            modelBuilder.Entity("Backend.Entities.EmployeeMasters", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DOJ")
                        .HasColumnType("DateTime");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("char");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("EmployeeId");

                    b.ToTable("EmployeeMasters");
                });

            modelBuilder.Entity("Backend.Entities.ItemMasters", b =>
                {
                    b.Property<string>("itemId")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("descprition")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("make")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("char");

                    b.Property<int>("valuation")
                        .HasColumnType("int");

                    b.HasKey("itemId");

                    b.ToTable("ItemMasters");
                });

            modelBuilder.Entity("Backend.Entities.LoanCardMasters", b =>
                {
                    b.Property<string>("LoanId")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("loan_type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("char");

                    b.HasKey("LoanId");

                    b.ToTable("LoanCardMasters");
                });
#pragma warning restore 612, 618
        }
    }
}
