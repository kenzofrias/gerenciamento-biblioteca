using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Livros");
        }
    }
}
