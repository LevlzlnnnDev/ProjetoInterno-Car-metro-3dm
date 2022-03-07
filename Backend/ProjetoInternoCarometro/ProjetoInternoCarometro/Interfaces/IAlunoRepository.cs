﻿using Microsoft.AspNetCore.Http;
using ProjetoInternoCarometro.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoInternoCarometro.Interfaces
{
    /// <summary>
    /// Interface resonsável pela AlunoRepository
    /// </summary>
    
        interface IAlunoRepository
        {
            /// <summary>
            /// Lista todos os alunos
            /// </summary>
            /// <returns>uma lista com todos os alunos</returns>
            List<Aluno> ListarTodos();


            /// <summary>
            /// Cadastra um novo aluno
            /// </summary>
            /// <param name="novoAluno">objeto com as informações cadastradas</param>
            void Cadastrar(Aluno novoAluno);


        /// <summary>
        /// Deleta um aluno existente
        /// </summary>
        /// <param name="aluno">aluno que será deletado</param>
        void Deletar(Aluno aluno);



            /// <summary>
            /// Atualiza um aluno pelo seu id
            /// </summary>
            /// <param name="idAluno">id da clinica que será atualizada</param>
            /// <param name="alunoAtualizado">objeto Clinica com as novas informações</param>
            void Atualizar(int idAluno, Aluno alunoAtualizado);


        /// <summary>
        /// Busca um aluno pelo seu id
        /// </summary>
        /// <param name="idAluno">id do aluno que será buscado</param>
        /// <returns></returns>
        Aluno BuscarId(int idAluno);


        }
    }