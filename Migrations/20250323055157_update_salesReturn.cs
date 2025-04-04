using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class update_salesReturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_Inwordstocks_StockId",
                table: "SellsReturnDetails");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "SellsReturnDetails",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_SellsReturnDetails_StockId",
                table: "SellsReturnDetails",
                newName: "IX_SellsReturnDetails_MaterialId");

            migrationBuilder.AddColumn<double>(
                name: "BillReturnAmount",
                table: "SalesReturns",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReturnAmount",
                table: "SalesReturns",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_Materials_MaterialId",
                table: "SellsReturnDetails",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellsReturnDetails_Materials_MaterialId",
                table: "SellsReturnDetails");

            migrationBuilder.DropColumn(
                name: "BillReturnAmount",
                table: "SalesReturns");

            migrationBuilder.DropColumn(
                name: "ReturnAmount",
                table: "SalesReturns");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "SellsReturnDetails",
                newName: "StockId");

            migrationBuilder.RenameIndex(
                name: "IX_SellsReturnDetails_MaterialId",
                table: "SellsReturnDetails",
                newName: "IX_SellsReturnDetails_StockId");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_SellsReturnDetails_Inwordstocks_StockId",
                table: "SellsReturnDetails",
                column: "StockId",
                principalTable: "Inwordstocks",
                principalColumn: "StockId");
        }
    }
}
