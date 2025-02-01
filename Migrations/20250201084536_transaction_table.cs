using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class transaction_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionYearId",
                table: "PurchaseMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionYearId",
                table: "InvoiceMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionYearId",
                table: "PurchaseMasters");

            migrationBuilder.DropColumn(
                name: "TransactionYearId",
                table: "InvoiceMasters");
        }
    }
}
