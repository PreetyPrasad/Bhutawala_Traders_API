﻿// <auto-generated />
using System;
using Bhutawala_Traders_API.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250308091340_RamzanMubarak")]
    partial class RamzanMubarak
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bhutawala_Traders_API.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.ApplyCredit", b =>
                {
                    b.Property<int>("ApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplyId"));

                    b.Property<int?>("CreditNoteId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("ApplyId");

                    b.HasIndex("CreditNoteId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("ApplyCredits");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.CreditNote", b =>
                {
                    b.Property<int>("CreditNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditNoteId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoteNo")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("CreditNoteId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("CreditNotes");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.CustomerInstallment", b =>
                {
                    b.Property<int>("InstallmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstallmentId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Paymentmode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RefNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("InstallmentId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("CustomerInstallments");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.DebitNote", b =>
                {
                    b.Property<int>("NoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteID"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("NoteID");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("StaffId");

                    b.ToTable("DebitNotes");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceDetailId"));

                    b.Property<double>("GSTAmount")
                        .HasColumnType("float");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InvoiceDetailId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("MaterialId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InvoiceMaster", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("GST")
                        .HasColumnType("float");

                    b.Property<string>("GSTIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GST_TYPE")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("NoticePeriod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalGross")
                        .HasColumnType("float");

                    b.Property<int?>("TransactionYearId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TransactionYearId");

                    b.ToTable("InvoiceMasters");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InwordStock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<DateTime>("RecivedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StockId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("StaffId");

                    b.ToTable("Inwordstocks");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("GST")
                        .HasColumnType("float");

                    b.Property<string>("GST_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Net_Qty")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaterialId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchaseMaster", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<string>("BillNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("GST")
                        .HasColumnType("float");

                    b.Property<string>("GST_Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("GrossTotal")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("NoticePeriod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int?>("TransactionYearId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TransactionYearId");

                    b.ToTable("PurchaseMasters");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchasePayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<string>("RefNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PaymentId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchasePayments");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchaseReturn", b =>
                {
                    b.Property<int>("PurchaseReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseReturnId"));

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PurchaseReturnId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseReturns");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.SalesReturn", b =>
                {
                    b.Property<int>("SalesReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesReturnId"));

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Paymentmode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RefNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("SalesReturnId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("SalesReturns");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.SalesReturnDetails", b =>
                {
                    b.Property<int>("ReturnDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnDetailId"));

                    b.Property<int?>("InvoiceDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.Property<int?>("SalesReturnId")
                        .HasColumnType("int");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReturnDetailId");

                    b.HasIndex("InvoiceDetailId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("SalesReturnId");

                    b.HasIndex("StockId");

                    b.ToTable("SellsReturnDetails");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.StaffMaster", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AdharNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StaffId");

                    b.ToTable("StaffMasters");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("AccountNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BanckBranch")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GSTIN")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("IFSC")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PAN")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.TransactionYearMaster", b =>
                {
                    b.Property<int>("TransactionYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionYearId"));

                    b.Property<string>("CurrentYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TransactionYearId");

                    b.ToTable("TransactionYearMasters");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.ApplyCredit", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.CreditNote", "CreditNote")
                        .WithMany()
                        .HasForeignKey("CreditNoteId");

                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("CreditNote");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.CreditNote", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.CustomerInstallment", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany("installments")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.DebitNote", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.PurchaseMaster", "PurchaseMaster")
                        .WithMany()
                        .HasForeignKey("PurchaseId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("PurchaseMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InvoiceDetail", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InvoiceMaster", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.HasOne("Bhutawala_Traders_API.Models.TransactionYearMaster", "TransactionYearMaster")
                        .WithMany()
                        .HasForeignKey("TransactionYearId");

                    b.Navigation("StaffMaster");

                    b.Navigation("TransactionYearMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InwordStock", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("Bhutawala_Traders_API.Models.PurchaseMaster", "PurchaseMaster")
                        .WithMany()
                        .HasForeignKey("PurchaseId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("PurchaseMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.Material", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchaseMaster", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.HasOne("Bhutawala_Traders_API.Models.TransactionYearMaster", "TransactionYearMaster")
                        .WithMany()
                        .HasForeignKey("TransactionYearId");

                    b.Navigation("Supplier");

                    b.Navigation("TransactionYearMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchasePayment", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.PurchaseMaster", "PurchaseMaster")
                        .WithMany()
                        .HasForeignKey("PurchaseId");

                    b.Navigation("PurchaseMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.PurchaseReturn", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.PurchaseMaster", "PurchaseMaster")
                        .WithMany()
                        .HasForeignKey("PurchaseId");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("PurchaseMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.SalesReturn", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.StaffMaster", "StaffMaster")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("StaffMaster");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.SalesReturnDetails", b =>
                {
                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceDetail", "InvoiceDetail")
                        .WithMany()
                        .HasForeignKey("InvoiceDetailId");

                    b.HasOne("Bhutawala_Traders_API.Models.InvoiceMaster", "InvoiceMaster")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Bhutawala_Traders_API.Models.SalesReturn", "SalesReturn")
                        .WithMany("SellsReturnDetail")
                        .HasForeignKey("SalesReturnId");

                    b.HasOne("Bhutawala_Traders_API.Models.InwordStock", "InwordStock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("InvoiceDetail");

                    b.Navigation("InvoiceMaster");

                    b.Navigation("InwordStock");

                    b.Navigation("SalesReturn");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.InvoiceMaster", b =>
                {
                    b.Navigation("InvoiceDetails");

                    b.Navigation("installments");
                });

            modelBuilder.Entity("Bhutawala_Traders_API.Models.SalesReturn", b =>
                {
                    b.Navigation("SellsReturnDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
