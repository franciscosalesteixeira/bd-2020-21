using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Aula
	{
		private string designacao;
		private string tipo_aula;
		private string hora;
		private string dias_semana;
		private string nr_max_alunos;

		public Aula(string designacao, string tipo_aula, string hora, string dias_semana, string nr_max_alunos)
		{
			this.designacao = designacao;
			this.tipo_aula = tipo_aula;
			this.hora = hora;
			this.dias_semana = dias_semana;
			this.nr_max_alunos = nr_max_alunos;
		}

		public Aula(string designacao, string hora, string dias_semana, string nr_max_alunos)
		{
			this.designacao = designacao;
			this.hora = hora;
			this.dias_semana = dias_semana;
			this.nr_max_alunos = nr_max_alunos;
		}

		public Aula()
		{

		}

		public String Designacao
		{
			get { return designacao; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Designation field can't be empty");
				}
				designacao = value;
			}
		}

		public String Tipo_Aula
		{
			get { return tipo_aula; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Class Type field can't be empty");
				}
				tipo_aula = value;
			}
		}

		public String Hora
		{
			get { return hora; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Time field can't be empty");
				}
				hora = value;

			}
		}

		public String Dias_Semana
		{
			get { return dias_semana; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Days field can't be empty");
				}
				dias_semana = value;
			}
		}

		public String Nr_Max_Alunos
		{
			get { return nr_max_alunos; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Maximum Attendance field can't be empty");
				}
				nr_max_alunos = value;
			}
		}
	}
}