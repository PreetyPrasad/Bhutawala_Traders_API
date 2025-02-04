using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class updation_Done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceMasterInvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceMasterInvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceMasterInvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_SellsReturnDetails_SalesReturnId",
                table: "SellsReturnDetails",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_MaterialId",
                table: "InvoiceDetails",
                column: "MaterialId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_SellsReturnDetails_SalesReturnId",
                table: "SellsReturnDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_MaterialId",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceMasterInvoiceId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceMasterInvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceMasterInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceMasters_InvoiceMasterInvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceMasterInvoiceId",
                principalTable: "InvoiceMasters",
                principalColumn: "InvoiceId");
        }
    }
}
