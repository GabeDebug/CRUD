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
			if(!File.Exists(_arquivo)) return new List<Produto>();
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
			if(lista.Count == 0) {Console.WriteLine("Nenhum produto cadastrado"); return;}
			Console.WriteLine("\n Produtos Cadastrados:");
			Console.WriteLine($"{"ID", -5} {"Nome", -20} {"Preco", 10}");
		  foreach(var p in lista)
			{
				Console.WriteLine($"{p.Id, -5} {p.Nome, -20} {p.Preco, 10:C}");
			}
		}
		public Produto? BuscarPorId(int id)
		{
			var produto = Ler().Find(p => p.Id == id);
			if(produto == null)
			{
				Console.WriteLine($"Produto com ID {id} não encontrado.");
				return null;
			}
		}
	}
	}