using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Crud
{
	class Produto
	{
		public int Id { get; set; }
		public string Nome { get; set; } = "";
		public double Preco { get; set; }
	}
	class ProdutoRepositorio
	{
		private readonly string _arquivo = "produto.json";

		private List<Produto> Ler()
		{
			if (!File.Exists(_arquivo)) return new List<Produto>();
			var json = File.ReadAllText(_arquivo);
			return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
		}

		private void Salvar(List<Produto> produtos)
		{
			var json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(_arquivo, json);
		}
		public void Adicionar(string nome, double preco)
		{
			var lista = Ler();
			var novoId = lista.Count > 0 ? lista[^1].Id + 1 : 1;

			lista.Add(new Produto { Id = novoId, Nome = nome, Preco = preco });
			Salvar(lista);

			Console.WriteLine($"Produto '{nome}' Adicionado com sucesso!");
		}

		public void ListarTodos()
		{
			var lista = Ler();
			if (lista.Count == 0) { Console.WriteLine("Nenhum produto cadastrado"); return; }
			Console.WriteLine("\n Produtos Cadastrados:");
			Console.WriteLine($"{"ID",-5} {"Nome",-20} {"Preco",10}");
			foreach (var p in lista)
			{
				Console.WriteLine($"{p.Id,-5} {p.Nome,-20} {p.Preco,10:C}");
			}
		}
		public Produto? BuscarPorId(int id)
		{
			var produto = Ler().Find(p => p.Id == id);
			if (produto == null)
			{
				Console.WriteLine($"Produto com ID {id} não encontrado.");
				return null;
			}
			return produto;
		}
		public void Atualizar(int id, string novoNome, double novoPreco)
		{
			var lista = Ler();
			var produto = lista.Find(p => p.Id == id);
			if (produto == null)
			{
				Console.WriteLine($"Produto com ID {id} não encontrado.");
				return;
			}

			produto.Nome = novoNome;
			produto.Preco = novoPreco;
			Salvar(lista);

			Console.WriteLine($"Produto com ID {id} atualizado com sucesso!");
		}
		public void Remover(int id)
		{
			var lista = Ler();
			var produto = lista.Find(p => p.Id == id);
			if (produto == null)
			{
				Console.WriteLine($"Produto com ID {id} não encontrado.");
				return;
			}
			lista.Remove(produto);
			Salvar(lista);

			Console.WriteLine($"Produto com ID {id} removido com sucesso!");
		}
	}

	class Program
	{
		public static void Main()
		{
			var repo = new ProdutoRepositorio();
			while (true)
			{
				Console.WriteLine("\n=== CRUD de Produtos ===");
				Console.WriteLine("1 - Adicionar produto");
				Console.WriteLine("2 - Listar todos");
				Console.WriteLine("3 - Buscar por ID");
				Console.WriteLine("4 - Atualizar produto");
				Console.WriteLine("5 - Remover produto");
				Console.WriteLine("0 - Sair");
				Console.Write("\nEscolha: ");

				var opcao = Console.ReadLine();

				switch (opcao)
				{
					case "1":
						Console.Write("Nome: ");
						var nome = Console.ReadLine() ?? "";
						Console.Write("Preço: ");
						double.TryParse(Console.ReadLine(), out double preco);
						repo.Adicionar(nome,preco);
						break;

					case "2":
						repo.ListarTodos();
						break;

					case "3":
						Console.Write("ID: ");
						int.TryParse(Console.ReadLine(), out int idBusca);
						var produto = repo.BuscarPorId(idBusca);
						if (produto != null)
						{
							Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
						}
						break;

					case "4":
						Console.Write("ID do produto a atualizar: ");
						int.TryParse(Console.ReadLine(), out int idAtualizar);
						Console.Write("Novo nome: ");
						var novoNome = Console.ReadLine() ?? "";
						Console.Write("Novo preço: ");
						double.TryParse(Console.ReadLine(), out double novoPreco);
						repo.Atualizar(idAtualizar, novoNome, novoPreco);
						break;

					case "5":
						Console.Write("ID do produto a remover: ");
						int.TryParse(Console.ReadLine(), out int idRemover);
						repo.Remover(idRemover);
						break;

						case "0":
						Console.WriteLine("Saindo...");
						return;

						default:
						Console.WriteLine("Opção inválida. Tente novamente.");
						break;
				}
			}
		}
	}
}