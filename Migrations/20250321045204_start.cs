using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "StaffMasters",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdharNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMasters", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BanckBranch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionYearMasters",
                columns: table => new
                {
                    TransactionYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CurrentYear = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionYearMasters", x => x.TransactionYearId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Net_Qty = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GST = table.Column<double>(type: "float", nullable: false),
                    GST_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "OutwardMasters",
                columns: table => new
                {
                    OutwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwardMasters", x => x.OutwardId);
                    table.ForeignKey(
                        name: "FK_OutwardMasters_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceMasters",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    TransactionYearId = table.Column<int>(type: "int", nullable: true),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalGross = table.Column<double>(type: "float", nullable: false),
                    GST = table.Column<double>(type: "float", nullable: false),
                    GST_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoticePeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GSTIN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceMasters", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceMasters_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                    table.ForeignKey(
                        name: "FK_InvoiceMasters_TransactionYearMasters_TransactionYearId",
                        column: x => x.TransactionYearId,
                        principalTable: "TransactionYearMasters",
                        principalColumn: "TransactionYearId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseMasters",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    TransactionYearId = table.Column<int>(type: "int", nullable: true),
                    GrossTotal = table.Column<double>(type: "float", nullable: false),
                    GST = table.Column<double>(type: "float", nullable: false),
                    GST_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoticePeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseMasters", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "FK_PurchaseMasters_TransactionYearMasters_TransactionYearId",
                        column: x => x.TransactionYearId,
                        principalTable: "TransactionYearMasters",
                        principalColumn: "TransactionYearId");
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    CreditNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    NoteNo = table.Column<int>(type: "int", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.CreditNoteId);
                    table.ForeignKey(
                        name: "FK_CreditNotes_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_CreditNotes_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerInstallments",
                columns: table => new
                {
                    InstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Paymentmode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInstallments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_CustomerInstallments_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_CustomerInstallments_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GSTAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId");
                });

            migrationBuilder.CreateTable(
                name: "SalesReturns",
                columns: table => new
                {
                    SalesReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Paymentmode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturns", x => x.SalesReturnId);
                    table.ForeignKey(
                        name: "FK_SalesReturns_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_SalesReturns_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "DebitNotes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitNotes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_DebitNotes_PurchaseMasters_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMasters",
                        principalColumn: "PurchaseId");
                    table.ForeignKey(
                        name: "FK_DebitNotes_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "Inwordstocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    RecivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inwordstocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Inwordstocks_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId");
                    table.ForeignKey(
                        name: "FK_Inwordstocks_PurchaseMasters_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMasters",
                        principalColumn: "PurchaseId");
                    table.ForeignKey(
                        name: "FK_Inwordstocks_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PurchasePayments_PurchaseMasters_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMasters",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturns",
                columns: table => new
                {
                    PurchaseReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturns", x => x.PurchaseReturnId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_PurchaseMasters_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMasters",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateTable(
                name: "ApplyCredits",
                columns: table => new
                {
                    ApplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    CreditNoteId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyCredits", x => x.ApplyId);
                    table.ForeignKey(
                        name: "FK_ApplyCredits_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "CreditNoteId");
                    table.ForeignKey(
                        name: "FK_ApplyCredits_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_ApplyCredits_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "SellsReturnDetails",
                columns: table => new
                {
                    ReturnDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: true),
                    SalesReturnId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellsReturnDetails", x => x.ReturnDetailId);
                    table.ForeignKey(
                        name: "FK_SellsReturnDetails_InvoiceDetails_InvoiceDetailId",
                        column: x => x.InvoiceDetailId,
                        principalTable: "InvoiceDetails",
                        principalColumn: "InvoiceDetailId");
                    table.ForeignKey(
                        name: "FK_SellsReturnDetails_InvoiceMasters_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceMasters",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_SellsReturnDetails_Inwordstocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Inwordstocks",
                        principalColumn: "StockId");
                    table.ForeignKey(
                        name: "FK_SellsReturnDetails_SalesReturns_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalTable: "SalesReturns",
                        principalColumn: "SalesReturnId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyCredits_CreditNoteId",
                table: "ApplyCredits",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyCredits_InvoiceId",
                table: "ApplyCredits",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyCredits_StaffId",
                table: "ApplyCredits",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_InvoiceId",
                table: "CreditNotes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_StaffId",
                table: "CreditNotes",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInstallments_InvoiceId",
                table: "CustomerInstallments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInstallments_StaffId",
                table: "CustomerInstallments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_PurchaseId",
                table: "DebitNotes",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_StaffId",
                table: "DebitNotes",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_MaterialId",
                table: "InvoiceDetails",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMasters_StaffId",
                table: "InvoiceMasters",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMasters_TransactionYearId",
                table: "InvoiceMasters",
                column: "TransactionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_MaterialId",
                table: "Inwordstocks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_PurchaseId",
                table: "Inwordstocks",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_StaffId",
                table: "Inwordstocks",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwardMasters_StaffId",
                table: "OutwardMasters",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_TransactionYearId",
                table: "PurchaseMasters",
                column: "TransactionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_InvoiceId",
                table: "PurchaseReturns",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_PurchaseId",
                table: "PurchaseReturns",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_InvoiceId",
                table: "SalesReturns",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_StaffId",
                table: "SalesReturns",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_InvoiceDetailId",
                table: "SellsReturnDetails",
                column: "InvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_InvoiceId",
                table: "SellsReturnDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_SalesReturnId",
                table: "SellsReturnDetails",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_StockId",
                table: "SellsReturnDetails",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ApplyCredits");

            migrationBuilder.DropTable(
                name: "CustomerInstallments");

            migrationBuilder.DropTable(
                name: "DebitNotes");

            migrationBuilder.DropTable(
                name: "OutwardMasters");

            migrationBuilder.DropTable(
                name: "PurchasePayments");

            migrationBuilder.DropTable(
                name: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "SellsReturnDetails");

            migrationBuilder.DropTable(
                name: "CreditNotes");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Inwordstocks");

            migrationBuilder.DropTable(
                name: "SalesReturns");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "PurchaseMasters");

            migrationBuilder.DropTable(
                name: "InvoiceMasters");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "StaffMasters");

            migrationBuilder.DropTable(
                name: "TransactionYearMasters");
        }
    }
}
