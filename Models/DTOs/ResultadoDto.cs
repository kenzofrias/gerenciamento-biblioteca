using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerenciamento_biblioteca.Models.DTOs
{
    public class ResultadoDto
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public object Dados { get; set; } = new { };

        public static ResultadoDto Ok(object dados) => new ResultadoDto { Sucesso = true, Dados = dados };
        public static ResultadoDto Erro(string mensagem) => new ResultadoDto { Sucesso = false, Mensagem = mensagem };

        //Feito com auxílio da IA
    }
}