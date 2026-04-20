using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoEmprestimos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivroTitulo",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "UsuarioSobrenome",
                table: "Emprestimos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivroTitulo",
                table: "Emprestimos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Emprestimos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSobrenome",
                table: "Emprestimos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
