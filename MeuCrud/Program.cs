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
		}
	}
	}