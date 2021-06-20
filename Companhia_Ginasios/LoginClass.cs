using System;
using System.Collections.Generic;
using System.Text;

namespace Companhia_Ginasios
{

	[Serializable()]
	class LoginClass
	{
		private string username;
		private string pass;

		public LoginClass(string username, string pass)
		{
			this.username = username;
			this.pass = pass;
		}

		public LoginClass()
		{

		}

		public String Username
		{
			get { return username; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Username field can't be empty");
				}
				username = value;
			}
		}

		public String Pass
		{
			get { return pass; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("Password field can't be empty");
				}
				pass = value;
			}
		}
	}
}