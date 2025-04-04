using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class staffid_material : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StaffId",
                table: "Materials",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_StaffMasters_StaffId",
                table: "Materials",
                column: "StaffId",
                principalTable: "StaffMasters",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_StaffMasters_StaffId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_StaffId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Materials");
        }
    }
}
