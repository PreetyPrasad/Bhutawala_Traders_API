using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class outwordStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutwordMaster",
                columns: table => new
                {
                    OutwordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Givento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutwordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwordMaster", x => x.OutwordId);
                    table.ForeignKey(
                        name: "FK_OutwordMaster_StaffMasters_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMasters",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutwordItems",
                columns: table => new
                {
                    OutwordStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    OutwordId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutwordItems", x => x.OutwordStockId);
                    table.ForeignKey(
                        name: "FK_OutwordItems_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutwordItems_OutwordMaster_OutwordId",
                        column: x => x.OutwordId,
                        principalTable: "OutwordMaster",
                        principalColumn: "OutwordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutwordItems_MaterialId",
                table: "OutwordItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwordItems_OutwordId",
                table: "OutwordItems",
                column: "OutwordId");

            migrationBuilder.CreateIndex(
                name: "IX_OutwordMaster_StaffId",
                table: "OutwordMaster",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutwordItems");

            migrationBuilder.DropTable(
                name: "OutwordMaster");
        }
    }
}
