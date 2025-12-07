using System;
using System.Collections.Generic;
using System.Linq;

class Aluno
{
    public string Nome { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }

    public double Media => Math.Round((Nota1 + Nota2) / 2, 2);

    public string Situacao
    {
        get
        {
            if (Media >= 7) return "Aprovado";
            if (Media >= 5) return "Recuperação";
            return "Reprovado";
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Nota 1: {Nota1} | Nota 2: {Nota2} | Média: {Media} | Situação: {Situacao}";
    }
}

class Program
{
    static List<Aluno> alunos = new List<Aluno>();

    static void Main(string[] args)
    {
        int opcao = 0;

        while (opcao != 4)
        {
            Console.Clear();
            Console.WriteLine("_-_-_ SISTEMA DE NOTAS _-_-_");
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Buscar Aluno por Nome");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida! Pressione ENTER...");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    ListarAlunos();
                    break;
                case 3:
                    BuscarAluno();
                    break;
                case 4:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CadastrarAluno()
    {
        Console.Clear();
        Console.Write("Nome do aluno: ");
        string nome = Console.ReadLine();

        Console.Write("Nota 1: ");
        double nota1 = LerNota();

        Console.Write("Nota 2: ");
        double nota2 = LerNota();

        alunos.Add(new Aluno
        {
            Nome = nome,
            Nota1 = nota1,
            Nota2 = nota2
        });

        Console.WriteLine("\nAluno cadastrado com sucesso!");
        Console.ReadLine();
    }

    static double LerNota()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 10)
            {
                return nota;
            }
            Console.Write("Nota inválida! Digite um valor entre 0 e 10: ");
        }
    }

    static void ListarAlunos()
    {
        Console.Clear();
        Console.WriteLine("_-_-_ LISTA DE ALUNOS _-_-_");

        if (!alunos.Any())
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            foreach (var a in alunos)
            {
                Console.WriteLine(a);
            }
        }

        Console.ReadLine();
    }

    static void BuscarAluno()
    {
        Console.Clear();
        Console.Write("Digite o nome para busca: ");
        string busca = Console.ReadLine().ToLower();

        var resultados = alunos
            .Where(a => a.Nome.ToLower().Contains(busca))
            .ToList();

        Console.WriteLine("==== RESULTADOS ====");

        if (resultados.Any())
        {
            foreach (var a in resultados)
            {
                Console.WriteLine(a);
            }
        }
        else
        {
            Console.WriteLine("Nenhum aluno encontrado.");
        }

        Console.ReadLine();
    }
}