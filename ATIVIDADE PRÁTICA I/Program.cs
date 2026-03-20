using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static List<string> nomes = new List<string>();
    static List<string> grupos = new List<string>();
    static List<double> cargas = new List<double>();
    static List<int> repeticoes = new List<int>();
    static void Main(string[] args)
    {
        int opcao;
        do
        {
            ExibirMenu();
            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1: AdicionarExercicio(); break;
                case 2: ListarExercicios(); break;
                case 3: BuscarPorNome(); break;
                case 4: FiltrarPorGrupo(); break;
                case 5: CalcularCargaTotal(); break;
                case 6: ExibirMaisPesado(); break;
                case 7: RemoverExercicio(); break;
                case 0: Console.WriteLine("Saindo..."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("=== SISTEMA DE TREINO - POO II ===");
        Console.WriteLine("1 - Adicionar exercício");
        Console.WriteLine("2 - Listar exercícios");
        Console.WriteLine("3 - Buscar exercício por nome");
        Console.WriteLine("4 - Filtrar por grupo muscular");
        Console.WriteLine("5 - Calcular carga total do treino");
        Console.WriteLine("6 - Exibir exercício mais pesado");
        Console.WriteLine("7 - Remover exercício");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void AdicionarExercicio()
    {
        string nome, grupo;
        double carga;
        int reps;

        do
        {
            Console.Write("Nome do exercício: ");
            nome = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(nome));

        Console.Write("Grupo muscular: ");
        grupo = Console.ReadLine();

        do
        {
            Console.Write("Carga (kg): ");
        } while (!double.TryParse(Console.ReadLine(), out carga) || carga < 0);

        do
        {
            Console.Write("Repetições: ");
        } while (!int.TryParse(Console.ReadLine(), out reps) || reps < 1);

        nomes.Add(nome);
        grupos.Add(grupo);
        cargas.Add(carga);
        repeticoes.Add(reps);
        Console.WriteLine("Exercício adicionado com sucesso!");
    }

    static void ListarExercicios()
    {
        if (!VerificarListaVazia()) return;

        for (int i = 0; i < nomes.Count; i++)
        {
            Console.WriteLine($"{nomes[i]} - {grupos[i]} - {cargas[i]}kg - {repeticoes[i]} reps");
        }
    }

    static void BuscarPorNome()
    {
        if (!VerificarListaVazia()) return;

        Console.Write("Digite o nome para busca: ");
        string busca = Console.ReadLine();

        
        var index = nomes.FindIndex(n => n.Equals(busca, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
            Console.WriteLine($"Encontrado: {nomes[index]} | Grupo: {grupos[index]} | Carga: {cargas[index]}kg");
        else
            Console.WriteLine("Exercício não encontrado.");
    }

    static void FiltrarPorGrupo()
    {
        if (!VerificarListaVazia()) return;

        Console.Write("Grupo muscular: ");
        string grupoBusca = Console.ReadLine();

        var filtrados = nomes.Where((t, i) => grupos[i].Equals(grupoBusca, StringComparison.OrdinalIgnoreCase));

        if (filtrados.Any())
            foreach (var item in filtrados) Console.WriteLine($"- {item}");
        else
            Console.WriteLine("Nenhum exercício para este grupo.");
    }

    static void CalcularCargaTotal()
    {
        double total = cargas.Sum();
        Console.WriteLine($"Carga total do treino: {total} kg");
    }

    static void ExibirMaisPesado()
    {
        if (!VerificarListaVazia()) return;

        double maiorCarga = cargas.Max();
        int index = cargas.IndexOf(maiorCarga);

        Console.WriteLine($"Mais pesado: {nomes[index]} com {cargas[index]}kg");
    }

    static void RemoverExercicio()
    {
        if (!VerificarListaVazia()) return;

        Console.Write("Nome do exercício a remover: ");
        string nomeRemover = Console.ReadLine();
        int index = nomes.FindIndex(n => n.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
        {
            nomes.RemoveAt(index);
            grupos.RemoveAt(index);
            cargas.RemoveAt(index);
            repeticoes.RemoveAt(index);
            Console.WriteLine("Exercício removido de todas as listas.");
        }
        else Console.WriteLine("Exercício não encontrado.");
    }

    static bool VerificarListaVazia()
    {
        if (nomes.Count == 0)
        {
            Console.WriteLine("A lista está vazia!");
            return false;
        }
        return true;
    }
}
