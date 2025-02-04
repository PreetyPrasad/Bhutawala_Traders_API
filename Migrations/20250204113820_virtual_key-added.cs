using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class virtual_keyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInstallments_InvoiceMasters_InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Materials_MaterialId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_SalesReturns_SalesReturnId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInstallments_InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropColumn(
                name: "InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalesReturnId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceDetailId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "SalesReturns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "PurchaseReturns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "PurchaseReturns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "PurchasePayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionYearId",
                table: "PurchaseMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "PurchaseMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "Inwordstocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Inwordstocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionYearId",
                table: "InvoiceMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "InvoiceMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "DebitNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "DebitNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "CustomerInstallments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "CustomerInstallments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "CreditNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "CreditNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "ApplyCredits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "ApplyCredits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditNoteId",
                table: "ApplyCredits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_InvoiceDetailId",
                table: "SellsReturnDetails",
                column: "InvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_InvoiceId",
                table: "SellsReturnDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_StockId",
                table: "SellsReturnDetails",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_InvoiceId",
                table: "SalesReturns",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturns_StaffId",
                table: "SalesReturns",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_InvoiceId",
                table: "PurchaseReturns",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_PurchaseId",
                table: "PurchaseReturns",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseMasters_TransactionYearId",
                table: "PurchaseMasters",
                column: "TransactionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_MaterialId",
                table: "Inwordstocks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_PurchaseId",
                table: "Inwordstocks",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMasters_StaffId",
                table: "InvoiceMasters",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMasters_TransactionYearId",
                table: "InvoiceMasters",
                column: "TransactionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_PurchaseId",
                table: "DebitNotes",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_StaffId",
                table: "DebitNotes",
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
                name: "IX_CreditNotes_InvoiceId",
                table: "CreditNotes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_StaffId",
                table: "CreditNotes",
                column: "StaffId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyCredits_CreditNotes_CreditNoteId",
                table: "ApplyCredits",
                column: "CreditNoteId",
                principalTable: "CreditNotes",
                principalColumn: "CreditNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyCredits_InvoiceMasters_InvoiceId",
                table: "ApplyCredits",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyCredits_StaffMasters_StaffId",
                table: "ApplyCredits",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNotes_InvoiceMasters_InvoiceId",
                table: "CreditNotes",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNotes_StaffMasters_StaffId",
                table: "CreditNotes",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInstallments_InvoiceMasters_InvoiceId",
                table: "CustomerInstallments",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInstallments_StaffMasters_StaffId",
                table: "CustomerInstallments",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_PurchaseMasters_PurchaseId",
                table: "DebitNotes",
                column: "PurchaseId",
                principalTable: "PurchaseMasters",
                principalColumn: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_StaffMasters_StaffId",
                table: "DebitNotes",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Materials_MaterialId",
                table: "InvoiceDetails",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceMasters_StaffMasters_StaffId",
                table: "InvoiceMasters",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceMasters_TransactionYearMasters_TransactionYearId",
                table: "InvoiceMasters",
                column: "TransactionYearId",
                principalTable: "TransactionYearMasters",
                principalColumn: "TransactionYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inwordstocks_Materials_MaterialId",
                table: "Inwordstocks",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inwordstocks_PurchaseMasters_PurchaseId",
                table: "Inwordstocks",
                column: "PurchaseId",
                principalTable: "PurchaseMasters",
                principalColumn: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Categories_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseMasters_Suppliers_SupplierId",
                table: "PurchaseMasters",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseMasters_TransactionYearMasters_TransactionYearId",
                table: "PurchaseMasters",
                column: "TransactionYearId",
                principalTable: "TransactionYearMasters",
                principalColumn: "TransactionYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_PurchaseMasters_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId",
                principalTable: "PurchaseMasters",
                principalColumn: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_InvoiceMasters_InvoiceId",
                table: "PurchaseReturns",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_PurchaseMasters_PurchaseId",
                table: "PurchaseReturns",
                column: "PurchaseId",
                principalTable: "PurchaseMasters",
                principalColumn: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturns_InvoiceMasters_InvoiceId",
                table: "SalesReturns",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_InvoiceDetails_InvoiceDetailId",
                table: "SellsReturnDetails",
                column: "InvoiceDetailId",
                principalTable: "InvoiceDetails",
                principalColumn: "InvoiceDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_InvoiceMasters_InvoiceId",
                table: "SellsReturnDetails",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_Inwordstocks_StockId",
                table: "SellsReturnDetails",
                column: "StockId",
                principalTable: "Inwordstocks",
                principalColumn: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_SalesReturns_SalesReturnId",
                table: "SellsReturnDetails",
                column: "SalesReturnId",
                principalTable: "SalesReturns",
                principalColumn: "SalesReturnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyCredits_CreditNotes_CreditNoteId",
                table: "ApplyCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyCredits_InvoiceMasters_InvoiceId",
                table: "ApplyCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyCredits_StaffMasters_StaffId",
                table: "ApplyCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNotes_InvoiceMasters_InvoiceId",
                table: "CreditNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNotes_StaffMasters_StaffId",
                table: "CreditNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInstallments_InvoiceMasters_InvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInstallments_StaffMasters_StaffId",
                table: "CustomerInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_PurchaseMasters_PurchaseId",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_StaffMasters_StaffId",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Materials_MaterialId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceMasters_StaffMasters_StaffId",
                table: "InvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceMasters_TransactionYearMasters_TransactionYearId",
                table: "InvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Inwordstocks_Materials_MaterialId",
                table: "Inwordstocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Inwordstocks_PurchaseMasters_PurchaseId",
                table: "Inwordstocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Categories_CategoryId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseMasters_Suppliers_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseMasters_TransactionYearMasters_TransactionYearId",
                table: "PurchaseMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_PurchaseMasters_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_InvoiceMasters_InvoiceId",
                table: "PurchaseReturns");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_PurchaseMasters_PurchaseId",
                table: "PurchaseReturns");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturns_InvoiceMasters_InvoiceId",
                table: "SalesReturns");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_InvoiceDetails_InvoiceDetailId",
                table: "SellsReturnDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_InvoiceMasters_InvoiceId",
                table: "SellsReturnDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_Inwordstocks_StockId",
                table: "SellsReturnDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_SalesReturns_SalesReturnId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellsReturnDetails_InvoiceDetailId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellsReturnDetails_InvoiceId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellsReturnDetails_StockId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturns_InvoiceId",
                table: "SalesReturns");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturns_StaffId",
                table: "SalesReturns");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturns_InvoiceId",
                table: "PurchaseReturns");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturns_PurchaseId",
                table: "PurchaseReturns");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseMasters_SupplierId",
                table: "PurchaseMasters");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseMasters_TransactionYearId",
                table: "PurchaseMasters");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Inwordstocks_MaterialId",
                table: "Inwordstocks");

            migrationBuilder.DropIndex(
                name: "IX_Inwordstocks_PurchaseId",
                table: "Inwordstocks");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceMasters_StaffId",
                table: "InvoiceMasters");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceMasters_TransactionYearId",
                table: "InvoiceMasters");

            migrationBuilder.DropIndex(
                name: "IX_DebitNotes_PurchaseId",
                table: "DebitNotes");

            migrationBuilder.DropIndex(
                name: "IX_DebitNotes_StaffId",
                table: "DebitNotes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInstallments_InvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInstallments_StaffId",
                table: "CustomerInstallments");

            migrationBuilder.DropIndex(
                name: "IX_CreditNotes_InvoiceId",
                table: "CreditNotes");

            migrationBuilder.DropIndex(
                name: "IX_CreditNotes_StaffId",
                table: "CreditNotes");

            migrationBuilder.DropIndex(
                name: "IX_ApplyCredits_CreditNoteId",
                table: "ApplyCredits");

            migrationBuilder.DropIndex(
                name: "IX_ApplyCredits_InvoiceId",
                table: "ApplyCredits");

            migrationBuilder.DropIndex(
                name: "IX_ApplyCredits_StaffId",
                table: "ApplyCredits");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesReturnId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceDetailId",
                table: "SellsReturnDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "SalesReturns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "PurchaseReturns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "PurchaseReturns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "PurchasePayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionYearId",
                table: "PurchaseMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "PurchaseMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "Inwordstocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Inwordstocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionYearId",
                table: "InvoiceMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "InvoiceMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "DebitNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "DebitNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "CustomerInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "CustomerInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceMasterInvoiceId",
                table: "CustomerInstallments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "CreditNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "CreditNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "ApplyCredits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "ApplyCredits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreditNoteId",
                table: "ApplyCredits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInstallments_InvoiceMasterInvoiceId",
                table: "CustomerInstallments",
                column: "InvoiceMasterInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInstallments_InvoiceMasters_InvoiceMasterInvoiceId",
                table: "CustomerInstallments",
                column: "InvoiceMasterInvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Materials_MaterialId",
                table: "InvoiceDetails",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_SalesReturns_SalesReturnId",
                table: "SellsReturnDetails",
                column: "SalesReturnId",
                principalTable: "SalesReturns",
                principalColumn: "SalesReturnId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
