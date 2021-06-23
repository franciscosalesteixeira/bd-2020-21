using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Inscrito
	{
		private string numero_aluno;
		private string designacao_aula;

		public Inscrito(string numero_aluno, string designacao_aula)
		{
			this.numero_aluno = numero_aluno;
			this.designacao_aula = designacao_aula;
		}

		public Inscrito()
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

		public String Designacao_Aula
		{
			get { return designacao_aula; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Course Designation field can't be empty");
				}
				designacao_aula = value;
			}
		}
	}
}