using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gerenciamento_biblioteca.Context;
using gerenciamento_biblioteca.Models.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace gerenciamento_biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        public UsuarioController(BibliotecaContext context)
        {
            _context = context;
        }

        //Usuarios
        [HttpGet("Usuarios/ObterTodos")]
        public IActionResult ObterUsuarios()
        {
            var usuariosProfessor = _context.Professores.ToList();
            var usuariosAluno = _context.Alunos.ToList();
            var usuarios = new List<object>();
            usuarios.AddRange(usuariosAluno);
            usuarios.AddRange(usuariosProfessor);
            return Ok(usuarios);
        }

        //Alunos
        [HttpPost("Aluno/CadastrarAluno")]
        public IActionResult CadastrarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Ok("Cadastro de aluno realizado com sucesso.");
        }

        [HttpGet("Aluno/ObterAluno/Todos")]
        public IActionResult ObterTodosAlunos()
        {
            var alunos = _context.Alunos.ToList();
            return Ok(alunos);
        }

        [HttpGet("Aluno/ObterAluno/Id/{id}")]
        public IActionResult ObterAlunoPorId(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound("Aluno não cadastrado.");
            }
            return Ok(aluno);
        }

        [HttpPatch("Aluno/AtualizarAluno/Id/{id}")]
        public IActionResult AtualizarAluno(int id, Aluno alunoAtualizado)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound("Aluno não cadastrado.");
            }

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Sobrenome = alunoAtualizado.Sobrenome;
            aluno.Email = alunoAtualizado.Email;
            aluno.TipoUsuario = alunoAtualizado.TipoUsuario;
            _context.SaveChanges();
            return Ok("Informações do aluno atualizadas com sucesso.");
        }

        [HttpDelete("Aluno/DeletarAluno/Id/{id}")]
        public IActionResult DeletarAluno(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound("Aluno não cadastrado.");
            }

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Ok("Aluno deletado com sucesso.");
        }

        //Professores
        [HttpPost("Professor/CadastrarProfessor")]
        public IActionResult CadastrarProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return Ok("Cadastro de professor realizado com sucesso.");
        }

        [HttpGet("Professor/ObterProfessor/Todos")]
        public IActionResult ObterTodosProfessores()
        {
            var professores = _context.Professores.ToList();
            return Ok(professores);
        }

        [HttpGet("Professor/ObterProfessor/Id/{id}")]
        public IActionResult ObterProfessorPorId(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound("Professor não cadastrado.");
            }
            return Ok(professor);
        }

        [HttpPatch("Professor/AtualizarProfessor/Id/{id}")]
        public IActionResult AtualizarProfessor(int id, Professor professorAtualizado)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound("Professor não cadastrado.");
            }

            professor.Nome = professorAtualizado.Nome;
            professor.Sobrenome = professorAtualizado.Sobrenome;
            professor.Email = professorAtualizado.Email;
            _context.SaveChanges();
            return Ok("Informações do professor atualizadas com sucesso.");
        }

        [HttpDelete("Professor/DeletarProfessor/Id/{id}")]
        public IActionResult DeletarProfessor(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound("Professor não cadastrado.");
            }

            _context.Professores.Remove(professor);
            _context.SaveChanges();
            return Ok("Professor deletado com sucesso.");
        }

    }
}