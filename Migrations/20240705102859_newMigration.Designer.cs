﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart_Credit.Data;

#nullable disable

namespace Smart_Credit.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240705102859_newMigration")]
    partial class newMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Smart_Credit.Entities.Addressee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addressees");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddresseeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddresseeId")
                        .IsUnique();

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Deadline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AgreedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DeadlineDates");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Intermediary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddresseeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("LoanDate")
                        .HasColumnType("int");

                    b.Property<int?>("LoanId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddresseeId")
                        .IsUnique();

                    b.HasIndex("LoanId")
                        .IsUnique();

                    b.ToTable("Intermediaries");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Lender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddresseeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("LenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddresseeId")
                        .IsUnique();

                    b.ToTable("Lenders");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LenderBorrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BorrowerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("LenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LoanId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("LenderId");

                    b.HasIndex("LoanId");

                    b.ToTable("LenderBorrowers");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeadLineId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RepaymentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeadLineId");

                    b.HasIndex("RepaymentId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LoanRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("BorowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanRequests");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LoanRequestLender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("LenderId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LoanRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LenderId");

                    b.HasIndex("LoanRequestId");

                    b.ToTable("LoanRequestLenders");
                });

            modelBuilder.Entity("smart_credit.Entities.Repayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Repayments");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Borrower", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Addressee", "Addressee")
                        .WithOne("Borrower")
                        .HasForeignKey("Smart_Credit.Entities.Borrower", "AddresseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addressee");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Intermediary", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Addressee", "Addressee")
                        .WithOne("Intermediary")
                        .HasForeignKey("Smart_Credit.Entities.Intermediary", "AddresseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Credit.Entities.Loan", "Loan")
                        .WithOne("Intermediary")
                        .HasForeignKey("Smart_Credit.Entities.Intermediary", "LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addressee");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Lender", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Addressee", "Addressee")
                        .WithOne("Lender")
                        .HasForeignKey("Smart_Credit.Entities.Lender", "AddresseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addressee");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LenderBorrower", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Borrower", "Borrower")
                        .WithMany("LenderBorrower")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Credit.Entities.Lender", "Lender")
                        .WithMany()
                        .HasForeignKey("LenderId");

                    b.HasOne("Smart_Credit.Entities.Loan", "Loan")
                        .WithMany("LenderBorrower")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Borrower");

                    b.Navigation("Lender");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Loan", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Deadline", "DeadLine")
                        .WithMany("Loan")
                        .HasForeignKey("DeadLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smart_credit.Entities.Repayment", "Repayment")
                        .WithMany("Loan")
                        .HasForeignKey("RepaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeadLine");

                    b.Navigation("Repayment");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LoanRequestLender", b =>
                {
                    b.HasOne("Smart_Credit.Entities.Lender", "Lender")
                        .WithMany("LoanRequestLender")
                        .HasForeignKey("LenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Credit.Entities.LoanRequest", "LoanRequest")
                        .WithMany("LoanRequestLender")
                        .HasForeignKey("LoanRequestId");

                    b.Navigation("Lender");

                    b.Navigation("LoanRequest");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Addressee", b =>
                {
                    b.Navigation("Borrower")
                        .IsRequired();

                    b.Navigation("Intermediary")
                        .IsRequired();

                    b.Navigation("Lender")
                        .IsRequired();
                });

            modelBuilder.Entity("Smart_Credit.Entities.Borrower", b =>
                {
                    b.Navigation("LenderBorrower");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Deadline", b =>
                {
                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Lender", b =>
                {
                    b.Navigation("LoanRequestLender");
                });

            modelBuilder.Entity("Smart_Credit.Entities.Loan", b =>
                {
                    b.Navigation("Intermediary")
                        .IsRequired();

                    b.Navigation("LenderBorrower");
                });

            modelBuilder.Entity("Smart_Credit.Entities.LoanRequest", b =>
                {
                    b.Navigation("LoanRequestLender");
                });

            modelBuilder.Entity("smart_credit.Entities.Repayment", b =>
                {
                    b.Navigation("Loan");
                });
#pragma warning restore 612, 618
        }
    }
}
