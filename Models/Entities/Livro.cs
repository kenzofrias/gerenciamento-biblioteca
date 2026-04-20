using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerenciamento_biblioteca.Models.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Estoque { get; set; }

        public Livro()
        {
            
        }
        public Livro(string titulo, string autor, int estoque)
        {
            Titulo = titulo;
            Autor = autor;
            Estoque = estoque;
        }

        public void Devolver()
        {
            Estoque++;
        }

        public void Emprestar()
        {
            if (Estoque <= 0)
            {
                throw new InvalidOperationException("Livro indisponível para empréstimo.");
            }
            
            Estoque--;
        } 
    }
}