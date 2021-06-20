using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Cliente
	{
		private string numero_CC;
		private string numero_cliente;
		private string tipo_subscricao;

		public Cliente(string numero_CC, string numero_cliente, string tipo_subscricao, string salario)
		{
			this.numero_CC = numero_CC;
			this.numero_cliente = numero_cliente;
			this.tipo_subscricao = tipo_subscricao;
		}

		public Cliente()
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

		public String Tipo_Subscricao
		{
			get { return tipo_subscricao; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Subscription Type field can't be empty");
				}
				tipo_subscricao = value;
			}
		}
	}
}

