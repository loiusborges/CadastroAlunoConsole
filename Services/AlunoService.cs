using CadastroAlunoConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroAlunoConsole.Services
{
    public class AlunoService
    {
        private List<Aluno> alunos = new();
        private int proximoId = 1;

        public void CadastrarAluno(string nome, int idade, string curso)
        {
            alunos.Add(new Aluno
            {
                Id = proximoId++,
                Nome = nome,
                Idade = idade,
                Curso = curso
            });
        }

        public List<Aluno> ListarAlunos() => alunos;

        public Aluno BuscarPorId(int id) => alunos.FirstOrDefault(a => a.Id == id);

        public bool EditarAluno(int id, string nome, int idade, string curso)
        {
            var aluno = BuscarPorId(id);
            if (aluno == null) return false;

            aluno.Nome = nome;
            aluno.Idade = idade;
            aluno.Curso = curso;
            return true;
        }

        public bool RemoverAluno(int id)
        {
            var aluno = BuscarPorId(id);
            if (aluno == null) return false;

            alunos.Remove(aluno);
            return true;
        }
    }
}
