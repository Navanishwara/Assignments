using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCodeFirstLib.Migrations
{
    /// <inheritdoc />
    public partial class countycolumnaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customer");
        }
    }
}
