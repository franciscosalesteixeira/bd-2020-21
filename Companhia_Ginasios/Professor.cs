using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Professor
	{
		private string numero_funcionario;

		public Professor(string numero_funcionario)
		{
			this.numero_funcionario = numero_funcionario;
		}

		public Professor()
		{

		}

		public String Numero_Funcionario
		{
			get { return numero_funcionario; }
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