using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciamento_biblioteca.Models.Enums;

namespace gerenciamento_biblioteca.Models.DTOs
{
    public class EmprestimoDto
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public TipoUsuario TipoUsuario { get; set; } 
    }
}