using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class renametablesellsReturnTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "SalesReturns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "SalesReturns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturns_StaffMasters_StaffId",
                table: "SalesReturns",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
