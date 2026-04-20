using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Alunos");
        }
    }
}
