using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatesProspectsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProspectId",
                table: "Dates",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dates_ProspectId",
                table: "Dates",
                column: "ProspectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dates_Prospects_ProspectId",
                table: "Dates",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dates_Prospects_ProspectId",
                table: "Dates");

            migrationBuilder.DropIndex(
                name: "IX_Dates_ProspectId",
                table: "Dates");

            migrationBuilder.DropColumn(
                name: "ProspectId",
                table: "Dates");
        }
    }
}
