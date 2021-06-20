using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Aluno
	{
		private string numero_cliente;

		public Aluno(string numero_cliente)
		{
			this.numero_cliente = numero_cliente;
		}

		public Aluno()
		{

		}

		public String Numero_Cliente
		{
			get { return numero_cliente; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Client Number field can't be empty");
				}
				numero_cliente = value;
			}
		}
	}
}