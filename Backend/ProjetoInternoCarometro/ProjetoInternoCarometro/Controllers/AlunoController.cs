﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInternoCarometro.Domains;
using ProjetoInternoCarometro.Interfaces;
using ProjetoInternoCarometro.Repositories;
using ProjetoInternoCarometro.Utils;
using System;

namespace ProjetoInternoCarometro.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository;

        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] Aluno novoAluno, IFormFile arquivo)
        {
            try
            {
                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado!");
                }

                if (uploadResultado == "Extensão não permitida!")
                {
                    return BadRequest("Extensão de arquivo não permitida!");
                }

                novoAluno.Foto = uploadResultado;
                _alunoRepository.Cadastrar(novoAluno);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Aluno alunoAtualizado)
        {
            try
            {
                _alunoRepository.Atualizar(id, alunoAtualizado);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_alunoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{idAluno}")]
        public IActionResult Deletar(int idAluno)
        {
            try
            {

                var alunoBuscado = _alunoRepository.BuscarId(idAluno);
                if (alunoBuscado == null)
                {
                    return NotFound();
                }

                _alunoRepository.Deletar(alunoBuscado);


                //Removendo Arquivo do servidor
               Upload.RemoverArquivo(alunoBuscado.Foto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}