using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciamento_biblioteca.Models.Enums;

namespace gerenciamento_biblioteca.Models.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public Emprestimo(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
        public Emprestimo(int usuarioId, int livroId, TipoUsuario tipoUsuario)
        {
            UsuarioId = usuarioId;
            LivroId = livroId;
            TipoUsuario = tipoUsuario;
            DataEmprestimo = DateTime.Now;
        }
    }
}