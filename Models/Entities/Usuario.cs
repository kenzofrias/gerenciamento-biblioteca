using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciamento_biblioteca.Models.Enums;

namespace gerenciamento_biblioteca.Models.Entities
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public abstract TipoUsuario TipoUsuario { get; set; }

        public abstract int LimiteEmprestimos();

        public Usuario(){}
        public Usuario(string nome, string sobrenome, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }
    }
}