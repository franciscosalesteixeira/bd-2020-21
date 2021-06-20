using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Tem_Funcionarios
	{
		private string nif;
		private string numero_funcionario;

		public Tem_Funcionarios(string nif, string numero_funcionario)
		{
			this.nif = nif;
			this.numero_funcionario = numero_funcionario;
		}

		public Tem_Funcionarios()
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

		public String Numero_Funcionario
		{
			get { return numero_funcionario	; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Employee Number field can't be empty");
				}
				numero_funcionario = value;
			}
		}
	}
}