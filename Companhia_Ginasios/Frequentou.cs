using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Frequentou
	{
		private string numero_aluno;
		private string codigo_aula;

		public Frequentou(string numero_aluno, string codigo_aula)
		{
			this.numero_aluno = numero_aluno;
			this.codigo_aula = codigo_aula;
		}

		public Frequentou()
		{

		}

		public String Numero_Aluno
		{
			get { return numero_aluno; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Student ID field can't be empty");
				}
				numero_aluno = value;
			}
		}

		public String Codigo_Aula
		{
			get { return codigo_aula; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Class Code field can't be empty");
				}
				codigo_aula = value;
			}
		}
	}
}