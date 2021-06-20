using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Funcionario
	{
		private string numero_CC;
		private string numero_funcionario;
		private string funcao;
		private string salario;

		public Funcionario(string numero_CC, string numero_funcionario, string funcao, string salario)
		{
			this.numero_CC = numero_CC;
			this.numero_funcionario = numero_funcionario;
			this.funcao = funcao;
            this.salario = salario;
		}

		public Funcionario()
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

		public String Funcao
		{
			get { return funcao; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Job field can't be empty");
				}
				funcao = value;
			}
		}

		public String Salario
		{
			get { return salario; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Salary can't be empty");
				}
				salario = value;
			}
		}
	}
}
