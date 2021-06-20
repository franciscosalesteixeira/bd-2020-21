using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Produto
	{
		private string codigo;
		private string nome;
		private string preco;
		private string stock;

		public Produto(string codigo, string nome, string preco, string stock)
		{
			this.codigo = codigo;
			this.nome = nome;
			this.preco = preco;
			this.stock = stock;
		}

		public Produto(string codigo, string nome, string preco)
		{
			this.codigo = codigo;
			this.nome = nome;
			this.preco = preco;
		}

		public Produto()
		{

		}

		public String Codigo
		{
			get { return codigo; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Code field can't be empty");
				}
				codigo = value;
			}
		}

		public String Nome
		{
			get { return nome; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Name field can't be empty");
				}
				nome = value;
			}
		}

		public String Preco
		{
			get { return preco; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Price field can't be empty");
				}
				preco = value;
			}
		}
		public String Stock
		{
			get { return stock; }
			set { stock = value; }
		}
	}
}