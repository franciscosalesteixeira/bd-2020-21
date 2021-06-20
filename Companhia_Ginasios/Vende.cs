using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Vende
	{
		private string nif;
		private string codigo;

		public Vende(string nif, string codigo)
		{
			this.nif = nif;
			this.codigo = codigo;
		}

		public Vende()
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