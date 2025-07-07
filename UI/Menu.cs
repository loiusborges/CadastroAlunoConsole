using CadastroAlunoConsole.Services;
using System;

namespace CadastroAlunoConsole.UI
{
    public class Menu
    {
        private readonly AlunoService alunoService = new();

        public void Exibir()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Cadastro de Alunos ===");
                Console.WriteLine("1. Cadastrar aluno");
                Console.WriteLine("2. Listar alunos");
                Console.WriteLine("3. Editar aluno");
                Console.WriteLine("4. Remover aluno");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Cadastrar(); break;
                    case "2": Listar(); break;
                    case "3": Editar(); break;
                    case "4": Remover(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Cadastrar()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Curso: ");
            string curso = Console.ReadLine();

            alunoService.CadastrarAluno(nome, idade, curso);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        private void Listar()
        {
            var alunos = alunoService.ListarAlunos();
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }

            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Id} | Nome: {aluno.Nome} | Idade: {aluno.Idade} | Curso: {aluno.Curso}");
            }
        }

        private void Editar()
        {
            Console.Write("ID do aluno: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();
            Console.Write("Nova idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Novo curso: ");
            string curso = Console.ReadLine();

            if (alunoService.EditarAluno(id, nome, idade, curso))
                Console.WriteLine("Aluno atualizado com sucesso!");
            else
                Console.WriteLine("Aluno não encontrado.");
        }

        private void Remover()
        {
            Console.Write("ID do aluno: ");
            int id = int.Parse(Console.ReadLine());

            if (alunoService.RemoverAluno(id))
                Console.WriteLine("Aluno removido com sucesso!");
            else
                Console.WriteLine("Aluno não encontrado.");
        }
    }
}