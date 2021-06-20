using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Tem_Clientes
	{
		private string nif;
		private string numero_cliente;

		public Tem_Clientes(string nif, string numero_cliente)
		{
			this.nif = nif;
			this.numero_cliente = numero_cliente;
		}

		public Tem_Clientes()
		{

		}

		public String NIF
		{
			get { return nif; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("NIF field can't be empty");
				}
				nif = value;
			}
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