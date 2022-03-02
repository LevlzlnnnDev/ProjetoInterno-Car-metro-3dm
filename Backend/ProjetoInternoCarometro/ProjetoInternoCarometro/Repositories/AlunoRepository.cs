﻿using Microsoft.AspNetCore.Http;
using ProjetoInternoCarometro.Contexts;
using ProjetoInternoCarometro.Domains;
using ProjetoInternoCarometro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoInternoCarometro.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        CarometroContext ctx = new CarometroContext();

        public void Atualizar(int idAluno, Aluno alunoAtualizado)
        {
            Aluno AlunoBuscado = ctx.Alunos.Find(idAluno);

            if (alunoAtualizado.IdEscola != null)
            {
                AlunoBuscado.IdEscola = alunoAtualizado.IdEscola;
            }

            if (alunoAtualizado.IdSerie != null)
            {
                AlunoBuscado.IdSerie = alunoAtualizado.IdSerie;
            }

            if (alunoAtualizado.IdTurma != null)
            {
                AlunoBuscado.IdTurma = alunoAtualizado.IdTurma;
            }

            if (alunoAtualizado.IdFace != null)
            {
                AlunoBuscado.IdFace = alunoAtualizado.IdFace;
            }

            if (alunoAtualizado.NomeAluno != null)
            {
                AlunoBuscado.NomeAluno = alunoAtualizado.NomeAluno;
            }

            if (alunoAtualizado.Cpf != null)
            {
                AlunoBuscado.Cpf = alunoAtualizado.Cpf;
            }

            if (alunoAtualizado.Rm != null)
            {
                AlunoBuscado.Rm = alunoAtualizado.Rm;
            }

            if (alunoAtualizado.Foto != null)
            {
                AlunoBuscado.Foto = alunoAtualizado.Foto;
            }

            ctx.Alunos.Update(AlunoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(Aluno novoAluno)
        {
            ctx.Alunos.Add(novoAluno);
            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int idAluno)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idAluno)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public string SalvarPerfilDir(IFormFile foto, int idAluno)
        {
            throw new NotImplementedException();
        }
    }
}