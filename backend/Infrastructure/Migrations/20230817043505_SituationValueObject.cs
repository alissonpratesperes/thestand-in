using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SituationValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Prospects",
                newName: "Status_Available");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Prospects",
                newName: "Status_Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Available",
                table: "Prospects",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "Status_Active",
                table: "Prospects",
                newName: "Active");
        }
    }
}
