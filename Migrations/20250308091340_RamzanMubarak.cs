using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class RamzanMubarak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "CurrentYear",
                table: "TransactionYearMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Materials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Admins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inwordstocks_StaffId",
                table: "Inwordstocks",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inwordstocks_StaffMasters_StaffId",
                table: "Inwordstocks",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inwordstocks_StaffMasters_StaffId",
                table: "Inwordstocks");

            migrationBuilder.DropIndex(
                name: "IX_Inwordstocks_StaffId",
                table: "Inwordstocks");

            migrationBuilder.DropColumn(
                name: "CurrentYear",
                table: "TransactionYearMasters");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Materials");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
