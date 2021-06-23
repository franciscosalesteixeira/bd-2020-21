using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	
	[Serializable()]
	class Aula_Instancia
	{
		private string fk_aula;
		private string fk_professor;
		private string codigo;

		public Aula_Instancia(string fk_aula, string fk_professor, string codigo)
		{
			this.fk_aula = fk_aula;
			this.fk_professor = fk_professor;
			this.codigo = codigo;
		}

		public Aula_Instancia()
		{

		}

		public String Fk_Aula
		{
			get { return fk_aula; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Course field can't be empty");
				}
				fk_aula = value;
			}
		}

		public String Fk_Professor
		{
			get { return fk_professor; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Teacher ID field can't be empty");
				}
				fk_professor = value;
			}
		}

		public String Codigo
		{
			get { return codigo; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Code field can't be empty");
				}
				codigo = value;
			}
		}
	}
}