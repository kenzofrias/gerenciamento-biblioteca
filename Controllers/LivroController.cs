using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gerenciamento_biblioteca.Context;
using gerenciamento_biblioteca.Models;
using gerenciamento_biblioteca.Models.Entities;

namespace gerenciamento_biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpPost("CadastrarLivro")]
        public IActionResult CadastrarLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return Ok("Livro cadastrado com sucesso!");
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterLivros()
        {
            var livros = _context.Livros.ToList();
            return Ok(livros);
        }

        [HttpGet("ObterLivroPorId/{id}")]
        public IActionResult ObterLivroPorId(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound("Livro não cadastrado.");
            }
            return Ok(livro);
        }

        [HttpPatch("AtualizarLivro/{id}")]
        public IActionResult AtualizarLivro(int id, Livro livroAtualizado)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null) return NotFound("Livro não cadastrado.");

            livro.Titulo = livroAtualizado.Titulo;
            livro.Autor = livroAtualizado.Autor;
            livro.Estoque = livroAtualizado.Estoque;

            _context.SaveChanges();
            return Ok("Informações do livro atualizadas com sucesso.");
        }

        [HttpDelete("DeletarLivro/{id}")]
        public IActionResult DeletarLivro(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null) return NotFound("Livro não cadastrado.");

            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return Ok("Livro deletado com sucesso.");
        }
    }
}