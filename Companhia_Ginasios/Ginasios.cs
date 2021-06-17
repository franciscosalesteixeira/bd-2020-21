using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Ginasios
    {
        private string nif;
        private string morada;
        private string telefone;
        private string gestor;

		public Ginasios(string nif, string morada, string telefone, string gestor)
		{
			this.nif = nif;
			this.morada = morada;
			this.telefone = telefone;
			this.gestor = gestor;
		}

		public Ginasios()
		{
			
		}

		public String NIF
		{
			get { return nif; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("NIF field can’t be empty");
				}
				nif = value;
			}
		}

		public String Morada
		{
			get { return morada; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Address field can’t be empty");
				}
				morada = value;
			}
		}

		public String Gestor
		{
			get { return gestor; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Manager field can’t be empty");
				}
				gestor = value;
			}
		}

		public String Telefone
		{
			get { return telefone; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Phone Number field can’t be empty");
				}
				telefone = value;
			}
		}
	}
}
