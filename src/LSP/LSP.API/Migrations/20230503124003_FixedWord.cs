using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSP.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufracturer",
                table: "Products",
                newName: "Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Products",
                newName: "Manufracturer");
        }
    }
}
