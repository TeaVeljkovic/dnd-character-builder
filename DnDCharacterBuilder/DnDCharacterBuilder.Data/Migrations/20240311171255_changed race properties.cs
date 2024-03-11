using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedraceproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ClassSavingThrows");

            migrationBuilder.AddColumn<string>(
                name: "AlignmentInfo",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlignmentInfo",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "ClassSavingThrows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
