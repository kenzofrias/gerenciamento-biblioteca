using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciamento_biblioteca.Models.Enums;

namespace gerenciamento_biblioteca.Models.Entities
{
    public class Aluno : Usuario
    {
        public override TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Aluno;
        public override int LimiteEmprestimos() => 3;
    }
}