using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhutawala_Traders_API.Migrations
{
    /// <inheritdoc />
    public partial class outwordStock_iii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutwordItems_OutwordMaster_OutwordId",
                table: "OutwordItems");

            migrationBuilder.DropTable(
                name: "OutwordMaster");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "OutwardMasters");

            migrationBuilder.RenameColumn(
                name: "OutwardId",
                table: "OutwardMasters",
                newName: "OutwordId");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "OutwardMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Givento",
                table: "OutwardMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OutwordDate",
                table: "OutwardMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "OutwardMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OutwordItems_OutwardMasters_OutwordId",
                table: "OutwordItems",
                column: "OutwordId",
                principalTable: "OutwardMasters",
                principalColumn: "OutwordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutwordItems_OutwardMasters_OutwordId",
                table: "OutwordItems");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "OutwardMasters");

            migrationBuilder.DropColumn(
                name: "Givento",
                table: "OutwardMasters");

            migrationBuilder.DropColumn(
                name: "OutwordDate",
                table: "OutwardMasters");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "OutwardMasters");

            migrationBuilder.RenameColumn(
                name: "OutwordId",
                table: "OutwardMasters",
                newName: "OutwardId");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "OutwardMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OutwordMaster",
                columns: table => new
                {
                    OutwordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Givento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutwordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_OutwordMaster_StaffId",
                table: "OutwordMaster",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutwordItems_OutwordMaster_OutwordId",
                table: "OutwordItems",
                column: "OutwordId",
                principalTable: "OutwordMaster",
                principalColumn: "OutwordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
