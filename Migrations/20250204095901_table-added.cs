using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class tableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "SellsReturnDetails",
                newName: "SalesReturnId");

            migrationBuilder.RenameColumn(
                name: "SellsID",
                table: "SellsReturnDetails",
                newName: "ReturnDetailId");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceMasterInvoiceId",
                table: "CustomerInstallments",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInstallments_InvoiceMasters_InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInstallments_InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.DropColumn(
                name: "InvoiceMasterInvoiceId",
                table: "CustomerInstallments");

            migrationBuilder.RenameColumn(
                name: "SalesReturnId",
                table: "SellsReturnDetails",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "ReturnDetailId",
                table: "SellsReturnDetails",
                newName: "SellsID");
        }
    }
}
