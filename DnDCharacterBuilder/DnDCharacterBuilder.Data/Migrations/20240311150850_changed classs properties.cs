using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedclasssproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Classes",
                newName: "ProficiencyDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProficiencyDescription",
                table: "Classes",
                newName: "Description");
        }
    }
}
