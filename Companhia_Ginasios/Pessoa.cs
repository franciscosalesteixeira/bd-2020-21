using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Pessoa
	{
		private string numero_CC;
		private string nome;
		private string telefone;
		private string morada;
		private string email;

		public Pessoa(string numero_CC, string nome, string telefone, string morada, string email)
		{
			this.numero_CC = numero_CC;
			this.nome = nome;
			this.morada = morada;
			this.telefone = telefone;
			this.email = email;
		}

		public Pessoa(string numero_CC, string nome)
		{
			this.numero_CC = numero_CC;
			this.nome = nome;
		}

		public Pessoa()
		{

		}

		public String Numero_CC
		{
			get { return numero_CC; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("ID Number field can't be empty");
				}
				numero_CC = value;
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

		public String Telefone
		{
			get { return telefone; }
			set { telefone = value; }
		}

		public String Morada
		{
			get { return morada; }
			set { morada = value; }
		}

		public String Email
		{
			get { return email; }
			set { email = value; }
		}
	}
}