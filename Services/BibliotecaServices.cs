using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerenciamento_biblioteca.Context;
using gerenciamento_biblioteca.Models.DTOs;
using gerenciamento_biblioteca.Models.Entities;
using gerenciamento_biblioteca.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace gerenciamento_biblioteca.Services
{

    public class BibliotecaServices
    {
        private readonly BibliotecaContext _context;
        public BibliotecaServices(BibliotecaContext context)
        {
            _context = context;
        }

        public ResultadoDto RealizarEmprestimo(EmprestimoDto dto)
        {
            bool usuarioExiste = false;
            int limite = 0;

            if (dto.TipoUsuario == TipoUsuario.Aluno)
            {
                usuarioExiste = _context.Alunos.Any(a => a.Id == dto.UsuarioId);
                limite = 3;
            }
            else if (dto.TipoUsuario == TipoUsuario.Professor)
            {
                usuarioExiste = _context.Professores.Any(a => a.Id == dto.UsuarioId);
                limite = 6;
            }

            if (!usuarioExiste) return ResultadoDto.Erro("Usuário não encontrado.");

            var livro = _context.Livros.Find(dto.LivroId);
            if (livro == null) return ResultadoDto.Erro("Livro não encontrado.");

            if (livro.Estoque <= 0) return ResultadoDto.Erro("Livro sem estoque.");

            var quantidade = _context.Emprestimos.Count(e => e.UsuarioId == dto.UsuarioId && e.TipoUsuario == dto.TipoUsuario);

            if (quantidade >= limite) return ResultadoDto.Erro("Limite de empréstimos alcançado.");

            var realizado = _context.Emprestimos.Any(e => e.UsuarioId == dto.UsuarioId && e.TipoUsuario == dto.TipoUsuario && e.LivroId == dto.LivroId);

            if (realizado) return ResultadoDto.Erro("Usuário já possui esse livro.");

            var emprestimo = new Emprestimo(dto.UsuarioId, dto.LivroId, dto.TipoUsuario);
            _context.Emprestimos.Add(emprestimo);
            livro.Emprestar();
            _context.SaveChanges();

            return ResultadoDto.Ok(emprestimo);
        }

        public ResultadoDto RealizarDevolucao(int usuarioId, int livroId, TipoUsuario tipoUsuario)
        {
            var livro = _context.Livros.Find(livroId);
            if (livro == null) return ResultadoDto.Erro("Livro não cadastrado no sistema.");

            var emprestimo = _context.Emprestimos.FirstOrDefault(e => e.UsuarioId == usuarioId && e.LivroId == livroId && e.TipoUsuario == tipoUsuario);
            if (emprestimo == null) return ResultadoDto.Erro("Empréstimo não efetuado ou devolução já realizada.");

            _context.Remove(emprestimo);
            livro.Devolver();
            _context.SaveChanges();

            return ResultadoDto.Ok(livro);
        }
    }
}