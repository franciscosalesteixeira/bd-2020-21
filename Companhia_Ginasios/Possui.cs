using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{
	[Serializable()]
	class Possui
	{
		private string nif;
		private string designacao;

		public Possui(string nif, string designacao)
		{
			this.nif = nif;
			this.designacao = designacao;
		}

		public Possui()
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
	}
}