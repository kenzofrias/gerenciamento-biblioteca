using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gerenciamento_biblioteca.Context;
using gerenciamento_biblioteca.Models.Entities;
using gerenciamento_biblioteca.Models.DTOs;
using gerenciamento_biblioteca.Services;
using gerenciamento_biblioteca.Models.Enums;

namespace gerenciamento_biblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestarController : ControllerBase
    {
        private readonly BibliotecaServices _bibliotecaServices; // O seu Service aqui
        public EmprestarController(BibliotecaServices bibliotecaServices)
        {
            _bibliotecaServices = bibliotecaServices;
        }


        [HttpPost("RealizarEmprestimo")]
        public IActionResult RealizarEmprestimo(EmprestimoDto dto)
        {
            var resultado = _bibliotecaServices.RealizarEmprestimo(dto);
            if (!resultado.Sucesso) return BadRequest(resultado.Mensagem);

            return Ok(resultado.Dados);
        }

        [HttpPost("RealizarDevolucao")]
        public IActionResult RealizarDevolucao(int usuarioId, int livroId, TipoUsuario tipoUsuario)
        {
            var resultado = _bibliotecaServices.RealizarDevolucao(usuarioId, livroId, tipoUsuario);
            if (!resultado.Sucesso) return BadRequest(resultado.Mensagem);

            return Ok("Devolução realizada com sucesso.");
        }
    }
}