using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeVault.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageToSnippets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lenguage",
                table: "Snippets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lenguage",
                table: "Snippets");
        }
    }
}
