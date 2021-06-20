using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class Equipamento
	{
		private string designacao;
		private string tipo_equipamento;
		private string quantidade;

		public Equipamento(string designacao, string tipo_equipamento, string quantidade)
		{
			this.designacao = designacao;
			this.tipo_equipamento = tipo_equipamento;
			this.quantidade = quantidade;
		}

		public Equipamento(string designacao, string tipo_equipamento)
		{
			this.designacao = designacao;
			this.tipo_equipamento = tipo_equipamento;
		}

		public Equipamento()
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

		public String Tipo_Equipamento
		{
			get { return tipo_equipamento; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Equipment Type field can't be empty");
				}
				tipo_equipamento = value;
			}
		}

		public String Quantidade
		{
			get { return quantidade; }
			set { quantidade = value; }
		}
	}
}