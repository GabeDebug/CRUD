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
	}
	}