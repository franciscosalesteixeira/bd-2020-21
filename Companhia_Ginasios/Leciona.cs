using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Leciona
	{
		private string numero_professor;
		private string designacao_aula;

		public Leciona(string numero_professor, string designacao_aula)
		{
			this.numero_professor = numero_professor;
			this.designacao_aula = designacao_aula;
		}

		public Leciona()
		{

		}

		public String Numero_Professor
		{
			get { return numero_professor; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Teacher ID field can't be empty");
				}
				numero_professor = value;
			}
		}

		public String Designacao_Aula
		{
			get { return designacao_aula; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Class Designation field can't be empty");
				}
				designacao_aula = value;
			}
		}
	}
}